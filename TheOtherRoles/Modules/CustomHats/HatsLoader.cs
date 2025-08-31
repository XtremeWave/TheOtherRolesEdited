using System.Collections;
using System.IO;
using System.Text.Json;
using BepInEx.Unity.IL2CPP.Utils;
using TheOtherRolesEdited;
using TheOtherRolesEdited.Modules.CustomHats;
using TheOtherRolesEdited.Utilities;
using UnityEngine;
using UnityEngine.Networking;
using static TheOtherRolesEdited.Modules.CustomHats.CustomHatManager;

namespace TheOtherRolesEdited;

public class HatsLoader : MonoBehaviour
{
    internal bool isRunning;
    public int totalFilesToDownload;
    public int downloadedFiles;

    public void FetchHats()
    {
        if (isRunning) return;
        this.StartCoroutine(CoFetchHats());
    }

    [HideFromIl2Cpp]
    private IEnumerator CoFetchHats()
    {
        isRunning = true;
        var www = new UnityWebRequest();
        www.SetMethod(UnityWebRequest.UnityWebRequestMethod.Get);
        TheOtherRolesEditedPlugin.Logger.LogMessage($"Download manifest at: {RepositoryUrl}/{ManifestFileName}");
        www.SetUrl($"{RepositoryUrl}/{ManifestFileName}");
        www.downloadHandler = new DownloadHandlerBuffer();
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        if (www.isNetworkError || www.isHttpError)
        {
            TheOtherRolesEditedPlugin.Logger.LogError(www.error);
            yield break;
        }

        var response = JsonSerializer.Deserialize<SkinsConfigFile>(www.downloadHandler.text, new JsonSerializerOptions
        {
            AllowTrailingCommas = true
        });
        www.downloadHandler.Dispose();
        www.Dispose();

        if (!Directory.Exists(HatsDirectory)) Directory.CreateDirectory(HatsDirectory);

        UnregisteredHats.AddRange(SanitizeHats(response));
        var toDownload = GenerateDownloadList(UnregisteredHats);
        if (EventUtility.isEnabled) UnregisteredHats.AddRange(CustomHatManager.loadHorseHats());

        TheOtherRolesEditedPlugin.Logger.LogMessage($"I'll download {toDownload.Count} hat files");
        totalFilesToDownload = toDownload.Count;
        downloadedFiles = 0;

        foreach (var fileName in toDownload)
        {
            yield return CoDownloadHatAsset(fileName);
            downloadedFiles++;
        }

        isRunning = false;
    }

    private static IEnumerator CoDownloadHatAsset(string fileName)
    {
        var www = new UnityWebRequest();
        www.SetMethod(UnityWebRequest.UnityWebRequestMethod.Get);
        fileName = fileName.Replace(" ", "%20");
        TheOtherRolesEditedPlugin.Logger.LogMessage($"downloading hat: {fileName}");
        www.SetUrl($"{RepositoryUrl}/hats/{fileName}");
        www.downloadHandler = new DownloadHandlerBuffer();
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        if (www.isNetworkError || www.isHttpError)
        {
            TheOtherRolesEditedPlugin.Logger.LogError(www.error);
            yield break;
        }

        var filePath = Path.Combine(HatsDirectory, fileName);
        filePath = filePath.Replace("%20", " ");
        var persistTask = File.WriteAllBytesAsync(filePath, www.downloadHandler.GetUnstrippedData());
        while (!persistTask.IsCompleted)
        {
            if (persistTask.Exception != null)
            {
                TheOtherRolesEditedPlugin.Logger.LogError(persistTask.Exception.Message);
                break;
            }

            yield return new WaitForEndOfFrame();
        }

        www.downloadHandler.Dispose();
        www.Dispose();
    }
}
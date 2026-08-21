using System.Collections;
using System.IO;
using System.Text.Json;
using BepInEx.Unity.IL2CPP.Utils;
using TheOtherRolesEdited.Utilities;
using UnityEngine;
using UnityEngine.Networking;
using static TheOtherRolesEdited.Modules.CustomHats.CustomHatManager;

namespace TheOtherRolesEdited.Modules.CustomHats
{
    public class HatsLoader : MonoBehaviour
    {
        public bool isRunning;
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

            yield return CoRegisterHatsWhenReady();

            isRunning = false;
        }

        private static IEnumerator CoDownloadHatAsset(string fileName)
        {
            var www = new UnityWebRequest();
            www.SetMethod(UnityWebRequest.UnityWebRequestMethod.Get);
            fileName = fileName.Replace(" ", "%20");
            TheOtherRolesEditedPlugin.Logger.LogMessage($"Downloading {fileName} hat");
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

        private IEnumerator CoRegisterHatsWhenReady()
        {
            while (DestroyableSingleton<HatManager>.Instance == null || DestroyableSingleton<HatManager>.Instance.allHats == null)
            {
                TheOtherRolesEditedPlugin.Logger.LogMessage("Waiting for HatManager to be ready...");
                yield return new WaitForEndOfFrame();
            }

            TheOtherRolesEditedPlugin.Logger.LogMessage("HatManager ready, registering hats...");
            RegisterAllHats();
        }
    }
}
using HarmonyLib;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace TheOtherRolesEdited.Modules;

[HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
public static class GameStartManagePatch
{
    private static bool isAspectSizeVisible = true;
    private static GameObject aspectSizeCache;
    private static GameObject closeAspectButton;
    private static float animationProgress = 1f; // 动画进度(0-1)
    private static bool isAnimating = false; // 是否正在动画中
    private static Vector3 startPosition = Vector3.zero; // 起始位置(0,0,0)
    private static Vector3 targetPosition = new Vector3(4.4f, 0f, 0f); // 目标位置

    public static void Postfix(GameStartManager __instance)
    {
        if (aspectSizeCache == null)
        {
            aspectSizeCache = GameObject.Find("AspectSize");
            if (aspectSizeCache != null)
            {
                var background = aspectSizeCache.transform.Find("Background")?.GetComponent<SpriteRenderer>();
                if (background != null)
                {
                    background.color = new Color(0f, 0.6f, 255f);
                }
                aspectSizeCache.transform.localPosition = targetPosition;
                InitializeCloseAspectButton();
            }
            return;
        }

        if (isAnimating)
        {
            UpdateAnimation();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleAspectVisibility();
        }
    }

    private static void InitializeCloseAspectButton()
    {
        if (aspectSizeCache == null || closeAspectButton != null) return;
        closeAspectButton = new GameObject("CloseAspectButton");
        closeAspectButton.transform.SetParent(aspectSizeCache.transform);
        closeAspectButton.transform.localPosition = new Vector3(-4.2773f * GetResolutionOffset(), -1.7491f, 1f);
        closeAspectButton.transform.localScale = new Vector3(1f, 1f, 1f);
        var collider = closeAspectButton.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(0.6f, 1.5f);
        var spriteRenderer = closeAspectButton.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Helpers.loadSpriteFromResources("TheOtherRolesEdited.Resources.MainPhoto.RightPanelCloseButton.png", 100f);
        spriteRenderer.color = new Color(0f, 0.6f, 255f); 
        var passiveButton = closeAspectButton.AddComponent<PassiveButton>();
        passiveButton.OnClick = new Button.ButtonClickedEvent();
        passiveButton.OnClick.AddListener((Action)ToggleAspectVisibility);
        passiveButton.OnMouseOver = new Button.ButtonClickedEvent();
        passiveButton.OnMouseOver.AddListener((System.Action)(() => spriteRenderer.color = new Color(0f, 0f, 255f)));
        passiveButton.OnMouseOut = new Button.ButtonClickedEvent();
        passiveButton.OnMouseOut.AddListener((System.Action)(() => spriteRenderer.color = new Color(0f, 0.6f, 255f)));
    }

    private static void ToggleAspectVisibility()
    {
        if (aspectSizeCache == null || isAnimating) return;

        isAspectSizeVisible = !isAspectSizeVisible;
        isAnimating = true;
        animationProgress = isAspectSizeVisible ? 0f : 1f;
    }

    private static void UpdateAnimation()
    {
        float animationSpeed = 2.4f;
        animationProgress += (isAspectSizeVisible ? 1f : -1f) * Time.deltaTime * animationSpeed;
        animationProgress = Mathf.Clamp01(animationProgress);

        Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, animationProgress);
        aspectSizeCache.transform.localPosition = currentPosition;

        if ((isAspectSizeVisible && animationProgress >= 1f) ||
            (!isAspectSizeVisible && animationProgress <= 0f))
        {
            isAnimating = false;
            aspectSizeCache.transform.localPosition = isAspectSizeVisible ? targetPosition : startPosition;
        }
    }

    private static float GetResolutionOffset()
    {
        return (float)Screen.width / Screen.height / (16f / 9f);
    }
}
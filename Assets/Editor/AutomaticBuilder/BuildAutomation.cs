using UnityEditor;
using UnityEngine;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;

public class BuildAutomation
{
    public static bool BuildAddressables(BuildTarget target)
    {
        // Set the active build target
        if (EditorUserBuildSettings.activeBuildTarget != target)
        {
            Debug.LogWarning($"Switching build target to {target}. This may take a moment...");
            if (EditorUserBuildSettings.SwitchActiveBuildTarget(BuildPipeline.GetBuildTargetGroup(target), target))
            {
                Debug.Log($"Build target switched to {target}.");
            }
            else
            {
                Debug.LogError($"Failed to switch build target to {target}.");
                return false;
            }
        }

        // Clean Addressables build
        try
        {
            Debug.Log($"Cleaning Addressables for {target}...");
            AddressableAssetSettings.CleanPlayerContent(AddressableAssetSettingsDefaultObject.Settings.ActivePlayerDataBuilder);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error cleaning Addressables for {target}: {e.Message}");
            return false;
        }

        // Build Addressables
        try
        {
            Debug.Log($"Building Addressables for {target}...");
            AddressableAssetSettings.BuildPlayerContent();
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error building Addressables for {target}: {e.Message}");
            return false;
        }

    }
}
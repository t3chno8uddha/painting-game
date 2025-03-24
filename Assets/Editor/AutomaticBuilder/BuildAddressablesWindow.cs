using System;
using UnityEditor;
using UnityEngine;

public class BuildAddressablesWindow : EditorWindow
{
    private bool buildAndroid = false;
    private bool buildMacOS = false;
    private bool buildIOS = false;
    private bool buildWindows = false;
    private string bucketName;
    private string gameName;

    [MenuItem("Build/Build Addressables with Options")]
    public static void ShowWindow()
    {
        GetWindow<BuildAddressablesWindow>("Build Addressables");
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Platforms to Build", EditorStyles.boldLabel);

        // Platform selection checkboxes
        buildAndroid = EditorGUILayout.Toggle("Build Android", buildAndroid);
        buildMacOS = EditorGUILayout.Toggle("Build macOS", buildMacOS);
        buildIOS = EditorGUILayout.Toggle("Build iOS", buildIOS);
        buildWindows = EditorGUILayout.Toggle("Build Windows", buildWindows);

        //bucketName = EditorGUILayout.TextField("Bucket Name",bucketName); 


        if (GUILayout.Button("Build Selected Platforms"))
        {
            BuildSelectedPlatforms();
        }

        // gameName = EditorGUILayout.TextField("Game Repository Name",gameName);

        // if (GUILayout.Button("Upload On GitHub"))
        // {
        //     UploadOnGitHub();
        // }

    }

    // private void UploadOnGitHub()
    // {
    //     GitHUbUploader.UploadOnGitHub(gameName);
    // }

    private void BuildSelectedPlatforms()
    {
        if (buildAndroid)
        {
            BuildAutomation.BuildAddressables(BuildTarget.Android);
        }

        if (buildMacOS)
        {
            BuildAutomation.BuildAddressables(BuildTarget.StandaloneOSX);
        }

        if (buildIOS)
        {
            BuildAutomation.BuildAddressables(BuildTarget.iOS);
        }

        if(buildWindows)
        {
            BuildAutomation.BuildAddressables(BuildTarget.StandaloneWindows64);
        }

        //R2Uploader.UploadFile(bucketName);
        //Debug.Log("Addressables build process finished for selected platforms.");

    }
}
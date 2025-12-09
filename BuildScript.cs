// Assets/Editor/BuildScript.cs
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.IO;
using System.Linq;

public static class BuildScript
{
    public static void BuildAndroidAAB()
    {
        string outputFolder = "Builds/Android";
        string outputAAB = Path.Combine(outputFolder, "UnoPlus.aab");

        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);

        // ensure Android is active
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);

        // build as Android App Bundle
        EditorUserBuildSettings.buildAppBundle = true;

        // basic versioning (update as needed)
        PlayerSettings.bundleVersion = "0.1.0";
        PlayerSettings.Android.bundleVersionCode = 1;

        // auto-detect enabled scenes
        var scenes = EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
        if (scenes.Length == 0)
        {
            Debug.LogError("No scenes found in Build Settings. Add at least one scene and enable it.");
            EditorApplication.Exit(1);
            return;
        }

        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputAAB,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        BuildReport report = BuildPipeline.BuildPlayer(options);

        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("AAB built: " + outputAAB);
            EditorApplication.Exit(0);
        }
        else
        {
            Debug.LogError("Build failed: " + report.summary.result);
            EditorApplication.Exit(1);
        }
    }
}

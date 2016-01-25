using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;


public class BuildLevel
{

    [MenuItem("Tools/Build")]
    private static void build()
    {
        Debug.Log("oi");

        string[] levels = new string[] { "Assets/Scenes/Marble Course.unity" };

        BuildPipeline.BuildPlayer(levels, "D:/BuiltGames/Test.exe", BuildTarget.StandaloneWindows, BuildOptions.None);

    }
}

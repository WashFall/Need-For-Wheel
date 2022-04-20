using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SwitchObstacleComponent))]
public class SwitchObstacleEditor : Editor
{
    MeshFilter meshfilter;
    GameObject obstacle;

    string searchPath = "Assets/Prefabs/Obstacles";
    GameObject[] obstaclePrefabs;
    List<string> obstacleNames = new List<string>();

    int selected = 0;

    private void LoadAssets()
    {
        var filePaths = GetAllFilePathsAtFolder($"t:Prefab", searchPath);
        List<GameObject> files = new List<GameObject>();
        foreach (var path in filePaths)
        {
            GameObject temporary = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            files.Add(temporary);
        }
        obstaclePrefabs = files.ToArray();

        foreach(var obstaclePrefab in obstaclePrefabs)
        {
            obstacleNames.Add(obstaclePrefab.name);
        }
    }

    private void OnEnable()
    {
        //Debug.Log("hej");
        LoadAssets();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SwitchObstacleComponent script = (SwitchObstacleComponent)target;
        meshfilter = script.GetComponent<MeshFilter>();

        selected = EditorGUILayout.Popup("Obstacle", selected, obstacleNames.ToArray());



        //if (GUILayout.Button("'Box'"))
        //{
        //    SetMesh("Cube.fbx");
        //}

        //if (GUILayout.Button("'Tree'"))
        //{
        //    SetMesh("Cylinder.fbx");
        //}

        //if (GUILayout.Button("'Person'"))
        //{
        //    SetMesh("Capsule.fbx");
        //}
    }

    private void SetMesh(string name)
    {
        Undo.RecordObject(meshfilter, "Name of my operation after this Undo-block");
        meshfilter.mesh = Resources.GetBuiltinResource<Mesh>(name);
    }

    private static string[] GetAllFilePathsAtFolder(string filter, string folderPath)
    {
        List<string> filePaths = new List<string>();

        // search for a ScriptObject called CatchphraseCategoryData inside the PhraseDataFolder
        var guids = AssetDatabase.FindAssets($"{filter}", new string[] { folderPath });
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            filePaths.Add(path);
        }
        return filePaths.ToArray();
    }
}

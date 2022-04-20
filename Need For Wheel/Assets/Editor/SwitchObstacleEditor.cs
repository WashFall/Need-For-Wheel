using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SwitchObstacleComponent))]
public class SwitchObstacleEditor : Editor
{
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
        LoadAssets();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUI.BeginChangeCheck();
        selected = EditorGUILayout.Popup("Obstacle", selected, obstacleNames.ToArray());
        if (EditorGUI.EndChangeCheck())
        {
            SetPrefab(selected);
        }
    }

    private void SetPrefab(int prefabIndex)
    {
        var script = (SwitchObstacleComponent)target;
        foreach(Transform trans in script.transform)
        {
            Undo.DestroyObjectImmediate(trans.gameObject);
        }
        var temporary = PrefabUtility.InstantiatePrefab(obstaclePrefabs[prefabIndex], script.transform);
        Undo.RecordObject(temporary, "Added object");
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

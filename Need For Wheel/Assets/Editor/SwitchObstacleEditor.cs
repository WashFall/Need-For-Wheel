using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SwitchObstacleComponent))]
public class SwitchObstacleEditor : Editor
{
	MeshFilter meshfilter;
	GameObject obstacle;

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		SwitchObstacleComponent script = (SwitchObstacleComponent)target;
		meshfilter = script.GetComponent<MeshFilter>();

		if (GUILayout.Button("'Box'"))
		{
			SetMesh("Cube.fbx");
		}

		if (GUILayout.Button("'Tree'"))
		{
			SetMesh("Cylinder.fbx");
		}

		if (GUILayout.Button("'Person'"))
		{
			SetMesh("Capsule.fbx");
		}
	}

	private void SetMesh(string name)
    {
		Undo.RecordObject(meshfilter, "Name of my operation after this Undo-block");
		meshfilter.mesh = Resources.GetBuiltinResource<Mesh>(name);
	}
}

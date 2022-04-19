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

		if (GUILayout.Button("'Box'"))
		{
			meshfilter = script.GetComponent<MeshFilter>();
			meshfilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
		}

		if (GUILayout.Button("'Tree'"))
		{
			meshfilter = script.GetComponent<MeshFilter>();
			meshfilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("Cylinder.fbx");
		}

		if (GUILayout.Button("'Person'"))
		{
			meshfilter = script.GetComponent<MeshFilter>();
			meshfilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("Capsule.fbx");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class PiyoWindow : EditorWindow
{
	void OnGUI()
	{
		GUILayout.Label("Hoge");
		if (GUILayout.Button("FugaA"))
		{
			Debug.Log("A!!!");
		}
		if (GUILayout.Button("FugaB"))
		{
			Debug.Log("B!!!");
		}
		
		GUILayout.BeginHorizontal();
		GUILayout.Button("1");
		GUILayout.Button("2");
		GUILayout.Button("3");
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button("4");
		GUILayout.Button("5");
		GUILayout.Button("6");
		GUILayout.EndHorizontal();
	}
}

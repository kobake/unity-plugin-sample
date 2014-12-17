using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class PiyoWindow : EditorWindow
{
	bool m_dame = true;
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

		H(delegate()
		{
			H(delegate()
			{
				H(delegate()
				{
					H(delegate()
					{
						V(delegate()
						{
							GUILayout.Button("a");
							GUILayout.Button("b");
						});
						V(delegate()
						{
							GUILayout.Button("c");
							GUILayout.Button("d");
						});
					});
					V(delegate()
					{
						GUILayout.Button("x");
						GUILayout.Button("y");
					});
					GUILayout.Button("z");
				});
			});
		});
	}
	public void H(Action action)
	{
		GUILayout.BeginHorizontal("box");
		try
		{
			action();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
		GUILayout.EndHorizontal();
	}
	public void V(Action action)
	{
		GUILayout.BeginVertical("box");
		try
		{
			action();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
		GUILayout.EndVertical();
	}
}

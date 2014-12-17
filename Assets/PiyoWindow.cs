using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class PiyoWindow : EditorWindow
{
	string lastState = "";
	string currentState = "";
	int guiCount = 0;
	string GetState()
	{
		string state = "";
		GameObject ball = GameObject.Find("MyBall");
		if (ball != null)
		{
			state = "Y = " + ball.transform.position.y;
		}
		else
		{
			state = "no ball";
		}
		return state;
	}
	void Update()
	{
		currentState = GetState();
		if (currentState != lastState)
		{
			Repaint();
			lastState = currentState;
		}
	}
	void OnGUI()
	{
		// ボールの座標が変化している間だけ呼ばれまくる。
		// ボールが止まると静かになる。（PiyoWindowの再描画されまくりも止まるので負荷も収まる）
		// ※そもそもOnGUIはGUI操作中にも呼ばれまくられるので、
		// 　ゲーム監視有無に関係なく「呼ばれまくられることはよくある」想定で作るのが良い。
		Debug.Log("OnGUI:" + guiCount++);

		// 状態の監視
		GUILayout.Label(currentState);

		// ボタン
		if (GUILayout.Button("FugaA"))
		{
			Debug.Log("A!!!");
		}
		if (GUILayout.Button("FugaB"))
		{
			Debug.Log("B!!!");
		}

		// 横並び
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

		// 入れ子
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

using UnityEngine;
using UnityEditor;

public class TestDesu {
	[MenuItem("Hoge/Fuga")]
	public static void Fugafuga()
	{
		Debug.Log("Hello");
		PiyoWindow.GetWindow(typeof(PiyoWindow));
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class PluginManager : MonoBehaviour
{
	[DllImport("__Internal")]
	private static extern void _openShare(string text , string url , string imgname);

	public static void OpenShare(string text , string url , string imgname)
	{
		Debug.Log ("PluginManager : openShare");
		if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			Debug.Log ("PluginManager : platform : iOS");
			_openShare(text,url,imgname);

		}
			
	}

	IEnumerator sample()
	{
		// ログ出力  
		Debug.Log ("1");  

		// 1秒待つ  
		yield return new WaitForSeconds (1.0f);  

		// ログ出力  
		Debug.Log ("2");  

		// 2秒待つ  
		yield return new WaitForSeconds (2.0f);  

		// ログ出力  
		Debug.Log ("3"); 
	}
	/*
	IEnumerator CaptureScreenshot(string fileName)
	{
		Application.CaptureScreenshot(fileName);

		var filePath = Path.Combine(Application.persistentDataPath, fileName);
		while (!File.Exists(fullPath))
		{
			yield return null;
		}

		// 保存できている
	}
	//*/
}
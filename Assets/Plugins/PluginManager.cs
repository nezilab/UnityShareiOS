using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class PluginManager : MonoBehaviour
{
	[DllImport("__Internal")]
	private static extern void _openShare(string text , string url , string imgname , string gameobjname = "" , string callbackname = "");

	public static void OpenShare(string text , string url , string imgname , string gameobjname = "" , string callbackname = "")
	{
		Debug.Log ("[ PluginManager ] : openShare");
		if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			Debug.Log ("[ PluginManager ] : platform : iOS");
			_openShare(text,url,imgname,gameobjname,callbackname);
		}
	}
}
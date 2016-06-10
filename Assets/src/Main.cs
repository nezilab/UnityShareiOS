/*
using UnityEngine;
using System.Collections;
*/

using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Nezilab.Log;

public class Main : MonoBehaviour 
{
	private const string traceClassName = "[ Main ]";
	public Button btnShare;

	void Start () 
	{
		NeziLog.debug (traceClassName, "Start : " + gameObject.name);
		btnShare.onClick.AddListener (shareHandler);
	}

	void Update () 
	{
		
	}

	private string GetScreenShotPath(string name)
	{
		string path = "";
		switch (Application.platform) {
		case RuntimePlatform.IPhonePlayer:
			path = Application.persistentDataPath + "/" + name;
			break;
		case RuntimePlatform.Android:
			path = Application.persistentDataPath + "/" + name;
			break;
		default:
			path = name;
			break;
		}
		return path;
	}

	void shareHandler()
	{
		NeziLog.debug (traceClassName, "shareHandler");
		btnShare.enabled = false;
		StartCoroutine (startCap("moge","hoge.png")); 
	}

	void shareCallback()
	{
		NeziLog.debug (traceClassName, "shareCallback");
		btnShare.enabled = true;
	}

	public IEnumerator startCap(string text , string filename) 
	{
		NeziLog.debug (traceClassName, "startCap");

		var filePath = GetScreenShotPath(filename);
		NeziLog.debug (traceClassName, "startCap : filePath : "+filePath);
		if (File.Exists (filePath)) 
		{
			NeziLog.debug (traceClassName, "img ");
			File.Delete (filePath);
			yield return StartCoroutine (imgDeleteWait(filePath));
		}

		Application.CaptureScreenshot (filename);
		while(!File.Exists(filePath))
		{
			NeziLog.debug (traceClassName, "save");
			yield return null;    
		}
		NeziLog.debug (traceClassName, "save_end");
		PluginManager.OpenShare (text, "http://nezilab.com", filePath,gameObject.name,"shareCallback");
		yield break;
	}

	IEnumerator imgDeleteWait(string filename) 
	{  
		while(System.IO.File.Exists(filename))
		{
			NeziLog.debug (traceClassName, "yes_img");
			yield return null;    
		}
		NeziLog.debug (traceClassName, "no_img");
		//print ("-----no_img");
		yield break;
	}
}

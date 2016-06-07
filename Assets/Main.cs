/*
using UnityEngine;
using System.Collections;
*/

using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {

	//private PluginManager pluginmanager;
	public Button btnShare;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");

		//pluginmanager = new PluginManager ();

		btnShare.onClick.AddListener (shareHandler);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void shareHandler()
	{
		Debug.Log ("shareHandler_start");
		//PluginManager.OpenShare ("hoge", "http://nezilab.com", "homu");
		StartCoroutine (WaitAndCap("hoge.png")); 
		Debug.Log ("shareHandler_end");
	}

	IEnumerator WaitAndCap(string filename) 
	{
		var filePath = Path.Combine(Application.persistentDataPath, filename);
		Debug.Log (filePath);
		if (File.Exists (filePath)) 
		{
			print ("img_true");
			File.Delete (filePath);
			yield return StartCoroutine (imgDeleteWait(filePath));
		}

		Application.CaptureScreenshot (filename);
		while(!File.Exists(filePath))
		{
			print ("Saving");
			yield return null;    
		}
		print ("save_end");
		PluginManager.OpenShare ("hoge", "http://nezilab.com", filePath);
		yield break;
	}

	IEnumerator imgDeleteWait(string filename) 
	{  
		while(System.IO.File.Exists(filename))
		{
			print ("-----img_true");
			yield return null;    
		}
		print ("-----no_img");
		yield break;
	} 
}

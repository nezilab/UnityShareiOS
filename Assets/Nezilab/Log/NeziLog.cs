using UnityEngine;
using System.Collections;

namespace Nezilab.Log
{
	public class NeziLog
	{
		public static bool isDebug = true;
		public NeziLog ()
		{
		}

		//public static void debug(params object[] args)
		public static void debug(string classname , string text)
		{
			if (isDebug == true) 
			{
				Debug.Log (classname + " : " + text);
			}
		}
	}
}


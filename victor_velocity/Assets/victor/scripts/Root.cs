using UnityEngine;
using System.Collections;
using victor.Road;

namespace victor
{
	public class Root : MonoBehaviour 
	{
		void Update ()
		{
			if (Input.GetButtonDown("Quit"))
			{
				Application.Quit();
			}
		}
	}
}
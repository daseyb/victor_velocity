using UnityEngine;
using System.Collections;

public class CarKey : MonoBehaviour 
{
	public bool engineRunning = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("ToggleEngine")) {
			engineRunning = !engineRunning;
			transform.Rotate (0f, 0f, 90f);
		}
	}
}

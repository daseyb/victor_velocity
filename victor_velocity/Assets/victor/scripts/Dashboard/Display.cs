using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour {
	GearStick stick;
	public Texture2D[] gearTextures;
	// Use this for initialization
	void Start () {
		stick = GameObject.Find("GearStick").GetComponent<GearStick>();
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTexture = gearTextures[stick.Gear];
	}
}

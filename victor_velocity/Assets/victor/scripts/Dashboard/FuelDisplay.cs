using UnityEngine;
using System.Collections;

public class FuelDisplay : MonoBehaviour {
	public GearStick stick;
	public Vector3 PosFull;
	public Vector3 PosEmpty;
	public float FuelCost;
	
	float fuel = 1;
	// Use this for initialization
	void Start () {
		stick = GameObject.Find("GearStick").GetComponent<GearStick>();
		transform.localPosition = PosFull;
	}
	
	void FixedUpdate()
	{
		fuel -= stick.Gear * FuelCost;
		fuel = Mathf.Clamp(fuel, 0, 1);
	}
	// Update is called once per frame
	void Update () {
		transform.localPosition = Vector3.Lerp(PosEmpty, PosFull, fuel);
	}
}

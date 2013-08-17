using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GearStick : MonoBehaviour 
{
	public int Gear = 0;
	
	public float Gear1Speed = 0.0007f;
	public float Gear2Speed = 0.0005f;
	public float Gear3Speed = 0.0002f;
	public float Gear4Speed = 0.0001f;
	
	public float Gear1Angle = 0f;
	public float Gear2Angle = 15f;
	public float Gear3Angle = 30f;
	public float Gear4Angle = 45f;
	
	private Quaternion initialRotation;
	private List<float> angles;
	private List<float> speeds;
	
	void Start () 
	{
		initialRotation = transform.rotation;
		angles = new List<float> { Gear1Angle, Gear2Angle, Gear3Angle, Gear4Angle };
		speeds = new List<float> { Gear1Speed, Gear2Speed, Gear3Speed, Gear4Speed };
	}
	
	void Update () 
	{
		var angle = angles[Gear];
		
		transform.rotation = initialRotation;
		transform.Rotate (transform.right, angle);
		
		if (Input.GetButtonDown ("GearUp")) {
			Gear++;
		}
		if (Input.GetButtonDown ("GearDown")) {
			Gear--;
		}
		
		Gear = (Gear < 0 ? 0 : (Gear > 3 ? 3 : Gear));
		
		var speed = speeds[Gear];
		Time.fixedDeltaTime = speed;
	}
}

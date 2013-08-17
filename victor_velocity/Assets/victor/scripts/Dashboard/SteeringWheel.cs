using UnityEngine;
using System.Collections;

public class SteeringWheel : MonoBehaviour {
	
	private Quaternion baseRotation;
	
	public float MaxAngle = 0.001f;
	
	// Use this for initialization
	void Start () {
		baseRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		var rel = Input.GetAxis ("Horizontal");
		var angle = Mathf.Lerp (0, MaxAngle, Mathf.Abs(rel));
		
		if (rel < 0) {
			angle = -angle;
		}
		
		transform.rotation = baseRotation;
		transform.RotateAround (transform.forward, angle);
	}
}

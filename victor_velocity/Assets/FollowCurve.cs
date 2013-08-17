using UnityEngine;
using System.Collections;

public class FollowCurve : MonoBehaviour {
	
	const float START_Z = 4;
	const float SCALE = 10;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, NumericCurve.Func(START_Z), START_Z) * SCALE;
	}
	
	// Update is called once per frame
	void FixedUpdate() 
	{
		Vector3 pos = transform.position/SCALE;
		NumericCurve.IntegrateStep(ref pos);
		transform.position = pos * SCALE;
		if(transform.position.z < 0.01f)
			transform.position = new Vector3(0, NumericCurve.Func(START_Z), START_Z) * SCALE;
	}
}

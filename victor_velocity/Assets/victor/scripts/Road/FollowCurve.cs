using UnityEngine;
using System.Collections;

namespace victor.Road
{
	/// <summary>
	/// Sample MonoBehaviour.
	/// </summary>
	public class FollowCurve : MonoBehaviour {
		
		const float START_X = 0;
		const float START_Z = 4;
		const float SCALE = 10;
		
		// Use this for initialization
		void Start () {
			transform.position = NumericalCurve.SnapYToCurve(new Vector3(0, 0, START_Z));
		}
		
		// Update is called once per frame
		void FixedUpdate() 
		{
			Vector3 pos = transform.position/SCALE;
			NumericalCurve.IntegrateStep(ref pos);
			transform.position = pos * SCALE;
			if(transform.position.z < 0.01f)
				transform.position = NumericalCurve.SnapYToCurve(new Vector3(0, 0, START_Z));
		}
	}
}

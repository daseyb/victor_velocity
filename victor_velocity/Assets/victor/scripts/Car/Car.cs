using UnityEngine;
using System.Collections;

namespace victor.car
{	
	public class Car : MonoBehaviour 
	{
		public float MaxSteering = 1f;
	
		void Update () 
		{
			var pos = transform.position;
			var rel = Input.GetAxis("Horizontal");
			
			pos.x = Mathf.Lerp (0, MaxSteering, Mathf.Abs(rel));
			if (rel < 0) {
				pos.x = -pos.x;
			}
			
			transform.position = pos;
		}
	}
}
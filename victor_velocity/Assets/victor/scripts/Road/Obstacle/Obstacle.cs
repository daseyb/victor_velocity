using UnityEngine;
using System.Collections;

namespace victor.Road
{
	public class Obstacle : MonoBehaviour {
		
		public int lane = 2;
		public int step = 0;
		
		void Start () 
		{
			var pos = transform.position;
			pos.x = ((float)(lane) - 1.5f) * 0.5f; 
			pos.z = RoadConstants.MaxRoadZ;
			transform.position = NumericalCurve.SnapYToCurve (pos);
		}
		
		void FixedUpdate () 
		{
			NumericalCurve.IntegrateStep (gameObject);
			
			step++;
			
			if (step > RoadConstants.NumIntegrationSteps) {
				GameObject.Destroy (gameObject);
			}
		}
	}
}
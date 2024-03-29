﻿using UnityEngine;
using System.Collections;

namespace victor.Road
{
	public class Obstacle : MonoBehaviour {
		
		public int lane = 2;
		public int step = 0;
		
		private CarKey key;
		
		void Awake ()
		{
			key = GameObject.Find("CarKey").GetComponent<CarKey>();
		}
		
		void Start () 
		{
			var pos = transform.position;
			pos.x = ((float)(lane) - 1.5f) * 1.0f; 
			pos.z = RoadConstants.MaxRoadZ;
			transform.position = NumericalCurve.SnapYToCurve (pos);
		}
		
		void FixedUpdate () 
		{
			if (GameObject.Find("CarKey").GetComponent<CarKey>().engineRunning) 
			{
				NumericalCurve.IntegrateStep (gameObject);
			
				step++;
				
				if (step > RoadConstants.NumIntegrationSteps) {
					GameObject.Destroy (gameObject);
				}
			}
		}
	}
}
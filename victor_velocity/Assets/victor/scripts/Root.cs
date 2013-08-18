using UnityEngine;
using System.Collections;
using victor.Road;

namespace victor
{
	public class Root : MonoBehaviour 
	{
		private GameObject road;
		private CarKey key;
		private int step;
		
		void Awake () 
		{
			road = GameObject.Find ("RoadLines");
			key = GameObject.Find("CarKey").GetComponent<CarKey>();
		}
	
		void Start () 
		{			
			var roadMesh = road.GetComponent<MeshFilter>().mesh;
			RoadMesh.BuildMesh (roadMesh, RoadConstants.NumRoadSegments);
			
			step = 0;
		}
		
		void Update () 
		{
			
		}
		
		void FixedUpdate ()
		{
			if (key.engineRunning) 
			{
				RoadMesh.Update (step, road, RoadConstants.NumRoadSegments);
				step += 1;
				
				if (step > RoadConstants.NumIntegrationSteps) {
					step -= RoadConstants.NumIntegrationSteps;
				}
			}
		}
	}
}
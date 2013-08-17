using UnityEngine;
using System.Collections;
using victor.Road;

namespace victor
{
	public class Root : MonoBehaviour 
	{
		private Mesh roadMesh;
		private CarKey key;
		
		void Awake () 
		{
			var road = GameObject.Find ("RoadLines");
			roadMesh = road.GetComponent<MeshFilter>().mesh;
			
			key = GameObject.Find("CarKey").GetComponent<CarKey>();
		}
	
		void Start () 
		{
			RoadMesh.BuildMesh (roadMesh, RoadConstants.NumRoadSegments);
		}
		
		void Update () 
		{
			
		}
		
		void FixedUpdate ()
		{
			if (key.engineRunning) 
			{
				RoadMesh.UpdateMesh (roadMesh);
			}
		}
	}
}
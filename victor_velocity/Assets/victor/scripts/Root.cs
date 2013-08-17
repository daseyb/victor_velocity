using UnityEngine;
using System.Collections;
using victor.Road;

namespace victor
{
	public class Root : MonoBehaviour 
	{
		private Mesh mesh;
		private CarKey key;
		
		void Awake () 
		{
			var road = GameObject.Find ("Road");
			mesh = road.GetComponent<MeshFilter>().mesh;
			
			key = GameObject.Find("CarKey").GetComponent<CarKey>();
		}
	
		void Start () 
		{
			RoadMesh.BuildMesh (mesh);		
		}
		
		void Update () 
		{
			
		}
		
		void FixedUpdate ()
		{
			if (key.engineRunning) 
			{
				RoadMesh.UpdateMesh (mesh);
			}
		}
	}
}
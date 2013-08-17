using UnityEngine;
using System.Collections;
using victor.Road;

namespace victor
{
	public class Root : MonoBehaviour 
	{
		private Mesh mesh;
		
		void Awake () 
		{
		}
	
		void Start () 
		{
			var road = GameObject.Find ("Road");
			
			mesh = road.GetComponent<MeshFilter>().mesh;
			RoadMesh.BuildMesh (mesh);		
		}
		
		void Update () 
		{
			
		}
		
		void FixedUpdate ()
		{
			RoadMesh.UpdateMesh (mesh);
		}
	}
}
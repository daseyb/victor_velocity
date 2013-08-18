using System;
using UnityEngine;
using System.Collections.Generic;

namespace victor.Road.mesh
{
	public class RoadMesh : MonoBehaviour
	{
		public int numSegments = 6;
		
		private Mesh mesh;
		private CarKey key;
		private int step;
		
		void Awake () 
		{
			mesh = GetComponent<MeshFilter>().mesh;
			key = GameObject.Find("CarKey").GetComponent<CarKey>();
			step = 0;
		}
	
		void Start () 
		{			
			BuildMesh();
		}
		
		void FixedUpdate ()
		{
			if (key.engineRunning) 
			{
				var ofs = (float)numSegments / (float)RoadConstants.NumIntegrationSteps;
				ofs *= step;
				//ofs -= Mathf.Floor(ofs);
				
				renderer.material.SetFloat ("_Offset", -ofs);
				
				step += 1;
				
				if (step > RoadConstants.NumIntegrationSteps) {
					step -= RoadConstants.NumIntegrationSteps;
				}
			}
		}		
		
		private void BuildMesh ()
		{
			mesh.vertices = buildVertices();
			mesh.triangles = buildTriangles();
			mesh.uv = buildUVs();
		}
		
		private Vector3[] buildVertices ()
		{
			var numVertices = (numSegments+1) * 2;
			
			Vector3 left = NumericalCurve.SnapYToCurve (new Vector3(-1, 0, RoadConstants.MaxRoadZ));
			Vector3 right = NumericalCurve.SnapYToCurve (new Vector3(1, 0, RoadConstants.MaxRoadZ));
			
			Vector3[] vertices = new Vector3[numVertices];
			vertices[0] = left;
			vertices[1] = right;
			
			var stepsPerSegment = RoadConstants.NumIntegrationSteps / numSegments;
			
			for (var i = 2; i < numVertices; i += 2)
			{
				for (var j = 0; j < stepsPerSegment; ++j)
				{
					NumericalCurve.IntegrateStep (ref left);
					NumericalCurve.IntegrateStep (ref right);
				}
				
				vertices[i] = left;
				vertices[i+1] = right;
			}
			
			return vertices;
		}
		
		private int[] buildTriangles ()
		{
			// two triangles per segment
			int[] indices = new int[numSegments * 2 * 3];
			
			for (var seg = 0; seg < numSegments; ++seg)
			{
				var i = seg*6; // index buffer position
				var v = seg*2; // vertex index
				
				indices[i+0] = v+0;
				indices[i+1] = v+1;
				indices[i+2] = v+2;
				
				indices[i+3] = v+1;
				indices[i+4] = v+3;
				indices[i+5] = v+2;
			}
			
			return indices;
		}
		
		private Vector2[] buildUVs ()
		{
			int numVertices = (numSegments + 1) * 2; 
			
			Vector2[] uvs = new Vector2 [numVertices];
			
			for (var i = 0; i < numSegments + 1; ++i) 
			{
				uvs[2*i] = new Vector2(0, (float)i);
				uvs[2*i+1] = new Vector2(1, (float)i);
			}
			
			return uvs;
		}		
	}
}


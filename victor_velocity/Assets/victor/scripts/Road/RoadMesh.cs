using System;
using UnityEngine;
using System.Collections.Generic;

namespace victor.Road
{
	public class RoadMesh
	{
		public static void BuildMesh (Mesh mesh, int numSegments)
		{
			mesh.vertices = buildVertices (numSegments);
			mesh.triangles = buildTriangles (numSegments);
			mesh.uv = buildUVs (numSegments);
		}
		
		private static Vector3[] buildVertices (int numSegments)
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
		
		private static int[] buildTriangles (int numSegments)
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
		
		private static Vector2[] buildUVs (int numSegments)
		{
			int numVertices = (numSegments + 1) * 2; 
			
			Vector2[] uvs = new Vector2 [numVertices];
			
			for (var i = 0; i < numSegments; ++i) 
			{
				uvs[2*i] = new Vector2(0, (float)i);
				uvs[2*i+1] = new Vector2(1, (float)i);
			}
			
			return uvs;
		}
		
		public static void UpdateMesh (Mesh mesh)
		{
			// step every vertex
			
			// if vertex leaves valid area, remove it and add a new one at the top
		}
	}
}


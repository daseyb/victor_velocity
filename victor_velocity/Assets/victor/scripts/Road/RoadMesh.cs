using System;
using UnityEngine;
using System.Collections.Generic;

namespace victor.Road
{
	public class RoadMesh
	{
		public static void BuildMesh (Mesh mesh)
		{
			Vector3 left = NumericalCurve.SnapYToCurve (new Vector3(-1, 0, RoadConstants.MaxRoadZ));
			Vector3 right = NumericalCurve.SnapYToCurve (new Vector3(1, 0, RoadConstants.MaxRoadZ));
			
			List<Vector3> vertices = new List<Vector3>();
			vertices.Add (left);
			vertices.Add (right);
						
			for (var i=0; i < RoadConstants.NumIntegrationSteps; ++i)
			{
				if (i % RoadConstants.NumStepsPerMeshGrid == 0) 
				{
					NumericalCurve.IntegrateStep (ref left);
					NumericalCurve.IntegrateStep (ref right);
					
					// build mesh
				}
			}
		}
		
		public static void UpdateMesh (Mesh mesh)
		{
			// step every vertex
			
			// if vertex leaves valid area, remove it and add a new one at the top
		}
	}
}


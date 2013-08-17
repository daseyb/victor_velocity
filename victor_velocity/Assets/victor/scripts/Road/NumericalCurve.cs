using System;
using UnityEngine;

namespace victor.Road
{
	public class NumericalCurve
	{
		public static void IntegrateStep (ref Vector3 point)
		{
		}
		
		public static Vector3 SnapYToCurve (Vector3 point)
		{
			var z = point.z;
			point.y = (z*z*z*z) / 100;
			return point;
		}
		
		
	}
}


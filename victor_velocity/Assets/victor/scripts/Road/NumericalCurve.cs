using System;
using UnityEngine;

namespace victor.Road
{
	public class NumericalCurve
	{
		public const float STEP_SIZE = 0.01f;
		public static void IntegrateStep(ref Vector3 _position)
		{
			float x = _position.z;
			float y = _position.y;
			
			float dy = m(x);
			
			float dx = 1;
			
			_position -= new Vector3(0, dy, dx).normalized * STEP_SIZE;		
		}
		
		private static float m(float _x)
		{
			return (_x * _x * _x)/25;	
		}
		
		private static float func(float _x)
		{
			return Mathf.Pow(_x, 4)/100;	
		}
		
		public static Vector3 SnapYToCurve(Vector3 _pos)
		{
			return new Vector3(_pos.x, func(_pos.z), _pos.z);	
		}
	}
}


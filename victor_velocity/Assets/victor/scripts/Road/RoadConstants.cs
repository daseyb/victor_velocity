using System;

namespace victor.Road
{
	public class RoadConstants
	{
		public const int NumIntegrationSteps = 10000;
		
		public const float MinRoadZ = 0f;
		public const float MaxRoadZ = 4f;
		
		public const int NumRoadSegments = 10;
		public const int NumStepsPerMeshGrid = NumIntegrationSteps / NumRoadSegments;
	}
}


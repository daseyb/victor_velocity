using UnityEngine;

namespace victor.Road
{
	public class ObstacleSpawner : MonoBehaviour
	{
		public GameObject prefab;
		public int lane;
		
		public int minStepsBetweenSpawns = 1000;
		public int maxStepsBetweenSpawns = 10000;
		
		private int stepsToNextSpawn;
		
		private GameObject road;
		private CarKey key;
		
		void Awake ()
		{
			key = GameObject.Find("CarKey").GetComponent<CarKey>();
		}
		
		void Start ()
		{
			pickNextSpawnStep();
			road = GameObject.Find("Road");
		}
		
		void FixedUpdate ()
		{
			if (key.engineRunning)
			{
				stepsToNextSpawn--;
			
				if (stepsToNextSpawn <= 0) {
					spawn();
					pickNextSpawnStep();
				}
			}
		}
		
		private void pickNextSpawnStep()
		{
			stepsToNextSpawn = Random.Range (minStepsBetweenSpawns, maxStepsBetweenSpawns);
		}
		
		private void spawn()
		{
			var obj = (GameObject) GameObject.Instantiate (prefab);
			obj.GetComponent<Obstacle>().lane = lane;
			
			obj.transform.parent = road.transform;
		}
	}
}


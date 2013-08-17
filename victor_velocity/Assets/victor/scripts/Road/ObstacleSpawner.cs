using UnityEngine;

namespace victor.Road
{
	public class ObstacleSpawner : MonoBehaviour
	{
		public GameObject prefab;
		public int lane;
		
		public float minSecBetweenSpawns = 0.5f;
		public float maxSecBetweenSpawns = 5.0f;
		
		private float nextSpawnTime;
		
		private GameObject road;
		
		void Start ()
		{
			pickNextSpawnTime();
			road = GameObject.Find("Road");
		}
		
		void Update ()
		{
			if (Time.time > nextSpawnTime) {
				spawn();
				pickNextSpawnTime();
			}
		}
		
		private void pickNextSpawnTime()
		{
			nextSpawnTime = Time.time + Random.Range (minSecBetweenSpawns, maxSecBetweenSpawns);
		}
		
		private void spawn()
		{
			var obj = (GameObject) GameObject.Instantiate (prefab);
			obj.GetComponent<Obstacle>().lane = lane;
			
			obj.transform.parent = road.transform;
		}
	}
}


using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {
	ScreenOverlay overlay;
	
	float flickerTimer = 0;
	const float FLICKER_TIME = 0.05f;
	public Texture2D Tex;
	
	int flickerCount = 3;
	
	float intervalTimer = 0;
	const float INTERVAL_TIME = 0.1f;
	
	float waitTimer = 0; 
	float WAIT_TIME = 5;
	
	// Use this for initialization
	void Start () {
		waitTimer = WAIT_TIME;
		overlay = GetComponent<ScreenOverlay>();
	}
	
	// Update is called once per frame
	void Update () {
		overlay.intensity = flickerTimer > 0 ?  1 : 0;
		
		if(flickerTimer > 0)
			flickerTimer -= FLICKER_TIME;
		else
		{
			flickerTimer = 0;
			intervalTimer = INTERVAL_TIME;
		}
		
		if(intervalTimer > 0)
		{
			intervalTimer -= Time.deltaTime;	
		}
		else
		{
			if(flickerCount > 0)
			{
				intervalTimer = INTERVAL_TIME;
				DoFlicker();
			}
			else
			{
				waitTimer = Random.value * 5 + 5;
				flickerCount = (int)(Random.value * 4);
			}
		}
		
		if(waitTimer > 0)
		{
			waitTimer -= Time.deltaTime;	
		}
		else
		{
			waitTimer = 0;
			DoFlicker();
		}
	}
	
	
	void DoFlicker()
	{
		//Debug.Log("FLicker");
		flickerCount--;
		flickerTimer = FLICKER_TIME;	
	}
}

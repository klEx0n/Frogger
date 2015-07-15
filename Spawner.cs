using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject[] spawnObject;
	public float startTime = 0;
	public float interval;
	public int carInterval = 1;
	public int freePlaces = 2;
	private int count = 0;
	private GameObject car;
	private bool makeJam = false;
	private float oldInterval;

	public enum CarDrive {
		NoJam,
		Jam
	}
	public CarDrive direction;
	// Use this for initialization
	void Start () {
		if(direction == CarDrive.NoJam)
			InvokeRepeating("SpawnObject", startTime, interval);
		else
			InvokeRepeating("MakeJam", startTime, interval);

		oldInterval = interval;
	}

	public void SpawnObject()
	{
		int random = Random.Range(0, spawnObject.Length);
		GameObject.Instantiate(spawnObject[random], transform.position, Quaternion.identity);
	}

	public void MakeJam()
	{
		if(makeJam == false)
		{
			++count;		
			int random = Random.Range(0, spawnObject.Length);
			GameObject.Instantiate(spawnObject[random], transform.position, Quaternion.identity);
			if(count == carInterval)
			{
				makeJam = true;
				count = freePlaces;
			}
		} else
		{
			--count;
			if(count == 0)
				makeJam = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if(interval != oldInterval && direction == CarDrive.NoJam)
		{
			CancelInvoke("SpawnObject");
			InvokeRepeating("SpawnObject", startTime, interval);
			oldInterval = interval;
		} else if(interval != oldInterval && direction == CarDrive.Jam)
		{
			CancelInvoke("MakeJam");
			InvokeRepeating("MakeJam", startTime, interval);
			oldInterval = interval;
		}
	}
}

using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {


	private Vector3 carScale;
	private Vector3 levelBorder;

//	public float speed = 5;

	// Use this for initialization
	void Start () {
		carScale = transform.localScale;
		levelBorder = GameObject.FindGameObjectWithTag("Border").transform.localScale;
	}

	public void MoveCar()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow))
			if(transform.position.x - carScale.x > -levelBorder.x / 2f)
				transform.Translate(new Vector3(-carScale.x, 0, 0));

		if(Input.GetKeyDown(KeyCode.RightArrow))
			if(transform.position.x + carScale.x < levelBorder.x / 2f)
				transform.Translate(new Vector3(carScale.x, 0, 0));

		if(Input.GetKeyDown(KeyCode.UpArrow))
			if(transform.position.y + carScale.y < levelBorder.y)
				transform.Translate(new Vector3(0, carScale.y, 0));

		if(Input.GetKeyDown(KeyCode.DownArrow))
			if(transform.position.y - carScale.y > 0)
				transform.Translate(new Vector3(0, -carScale.y, 0));
	}


	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale > 0)
			MoveCar();
	}
}

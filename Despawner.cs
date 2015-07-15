using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Cars")
			GameObject.Destroy (other.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

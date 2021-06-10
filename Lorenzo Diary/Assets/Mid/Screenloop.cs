using UnityEngine;
using System.Collections;

public class Screenloop : MonoBehaviour {
	public float speed = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time * speed);
	}
}

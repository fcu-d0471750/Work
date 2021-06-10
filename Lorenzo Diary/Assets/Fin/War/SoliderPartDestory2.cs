using UnityEngine;
using System.Collections;

public class SoliderPartDestory2 : MonoBehaviour {

	private float PartTime = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		PartTime = PartTime + Time.deltaTime;
		if (PartTime >= 3.0f) Destroy(gameObject);//消滅物件本身
	}
}

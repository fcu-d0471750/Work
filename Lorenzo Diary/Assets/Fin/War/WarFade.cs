﻿using UnityEngine;
using System.Collections;

public class WarFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Back(){
		Application.LoadLevelAsync ("WarSelect");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadScene",2.0f);
    }

    void LoadScene() {
        Application.LoadLevel("MainScene");
    }
    
}

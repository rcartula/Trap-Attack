using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Quit"))
        {
            Application.Quit();
        }
        if (Input.GetButton("Restart"))
        {
            SceneManager.LoadScene(0);
        }
    }
}

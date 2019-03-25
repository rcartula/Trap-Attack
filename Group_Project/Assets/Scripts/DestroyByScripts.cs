using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "boundary")
        {
            Destroy(gameObject);
        }
        return;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shield")
        {
            Destroy(gameObject);
        }
        if (other.tag == "BasicBolt")
        {
            Destroy(other.gameObject);
        }

    }
    // Update is called once per frame
    void Update () {

	}
}

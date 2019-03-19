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
        if (other.tag == "shield")
        {
            Destroy(gameObject);
        }
        return;
    }
    // Update is called once per frame
    void Update () {

	}
}

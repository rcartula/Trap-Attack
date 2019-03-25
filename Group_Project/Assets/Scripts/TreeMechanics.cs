using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMechanics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TreeBreak")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            return;
        }
        if (other.tag == "STrap")
        {
            return;
        }
        if (other.tag == "BeeTrap")
        {
            return;
        }
        if (other.tag == "Trap")
        {
            return;
        }
        Destroy(other.gameObject);
    }
}

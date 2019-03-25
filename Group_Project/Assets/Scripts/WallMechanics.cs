using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMechanics : MonoBehaviour {
    public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0)
        {
            Destroy(gameObject);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BasicBolt")
        {
            Destroy(other.gameObject);
            health -= 1;
        }
        if (other.tag == "Slow")
        {
            Destroy(other.gameObject);
            health -= 2;
        }
        if (other.tag == "missle")
        {
            Destroy(other.gameObject);
            health -= 4;
        }
        if (other.tag == "TreeBreak")
        {
            Destroy(other.gameObject);
            health -= 3;
        }
        if (other.tag == "Disable")
        {
            Destroy(other.gameObject);
            health -= 2;
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

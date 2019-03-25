using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMover : MonoBehaviour {
    private float speed;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        StartCoroutine(TrapMove());
        rb = GetComponent<Rigidbody>();
        
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward * speed;
    }
    public IEnumerator TrapMove()
    {
        speed = 20;
        yield return new WaitForSeconds(.2f);
        speed = 0;
    }
}

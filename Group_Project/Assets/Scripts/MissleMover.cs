using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleMover : MonoBehaviour {
    public float speed;
    public float speedBoost;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        speed =speed + Time.deltaTime * speedBoost;
    }
}
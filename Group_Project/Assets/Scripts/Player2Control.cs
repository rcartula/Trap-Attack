using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour {
    public float speed;
    public int health;

    public GameObject basicshot;
    public Transform basicshotSpawn;
    public float basicfireRate;
    private float basicnextFire;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("HorizontalP2");
        float movevertical = Input.GetAxis("VerticalP2");

        Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);
        rb.velocity = (movement * speed);

        if (Input.GetButton("Fire1P2") && Time.time > basicnextFire)
        {
            basicnextFire = Time.time + basicfireRate;
            Instantiate(basicshot, basicshotSpawn.position, basicshotSpawn.rotation);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BasicBolt")
        {
            Destroy(other.gameObject);
            health -= 1;
            if (health <= 0)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
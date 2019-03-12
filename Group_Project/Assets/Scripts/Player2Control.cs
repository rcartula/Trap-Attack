using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour
{
    public float speed;
    public int health;

    public GameObject basicshot;
    public GameObject fastshot;
    public GameObject machineshot;
    public Transform basicshotSpawn;
    public Transform spreadshotSpawn2;
    public Transform spreadshotSpawn3;
    public float basicfireRate;
    public float spreadFireRate;
    public float fastFireRate;
    public float machineFireRate;

    private float basicnextFire;

    public GameObject slowBolt;
    public float slowFireRate;
    private float strongnextFire;

    private int range;
    private int range2;
    private Rigidbody rb;
    private float counter = 0;

    private bool basicshotactive;
    private bool spreadshotactive;
    private bool fastshotactive;
    private bool machineshotactive;
    private bool slowactive;
    private bool slowammoactive;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        basicshotactive = true;
        spreadshotactive = false;
        fastshotactive = false;
        machineshotactive = false;
        slowactive = false;
        slowammoactive = true;
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

        if (basicshotactive)
        {
            if (Input.GetButton("Fire1P2") && Time.time > basicnextFire)
            {
                basicnextFire = Time.time + basicfireRate;
                Instantiate(basicshot, basicshotSpawn.position, basicshotSpawn.rotation);
            }
        }
        if (fastshotactive)
        {
            if (Input.GetButton("Fire1P2") && Time.time > basicnextFire)
            {
                basicnextFire = Time.time + fastFireRate;
                Instantiate(fastshot, basicshotSpawn.position, basicshotSpawn.rotation);
            }
        }
        if (machineshotactive)
        {
            if (Input.GetButton("Fire1P2") && Time.time > basicnextFire)
            {
                basicnextFire = Time.time + machineFireRate;
                Instantiate(machineshot, basicshotSpawn.position, basicshotSpawn.rotation);
            }
        }
        if (spreadshotactive)
        {
            if (Input.GetButton("Fire1P2") && Time.time > basicnextFire)
            {
                basicnextFire = Time.time + spreadFireRate;
                Instantiate(basicshot, basicshotSpawn.position, basicshotSpawn.rotation);
                Instantiate(basicshot, spreadshotSpawn2.position, spreadshotSpawn2.rotation);
                Instantiate(basicshot, spreadshotSpawn3.position, spreadshotSpawn3.rotation);
            }
        }
        if (slowactive)
        {
            counter += Time.deltaTime;
            if (counter >= 5)
            {
                speed += 10;
                slowactive = false;
                counter = 0;
            }
        }
        if (slowammoactive)
        {
            {
                if (Input.GetButton("Fire2P2") && Time.time > strongnextFire)
                {
                    strongnextFire = Time.time + slowFireRate;
                    Instantiate(slowBolt, basicshotSpawn.position, basicshotSpawn.rotation);
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (health <= 0)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.tag == "BasicBolt")
        {
            Destroy(other.gameObject);
            health -= 1;
        }
        if (other.tag == "Slow")
        {
            Destroy(other.gameObject);
            health -= 1;
            speed -= 10;
            slowactive = true;
        }
        if (other.tag == "PowerUp")
        {
            range = Random.Range(0, 4);
            Destroy(other.gameObject);
            if (range == 0)
            {
                basicshotactive = true;
                spreadshotactive = false;
                fastshotactive = false;
                machineshotactive = false;
            }
            if (range == 1)
            {
                basicshotactive = false;
                spreadshotactive = true;
                fastshotactive = false;
                machineshotactive = false;
            }
            if (range == 2)
            {
                basicshotactive = false;
                spreadshotactive = false;
                fastshotactive = true;
                machineshotactive = false;
            }
            if (range == 3)
            {
                basicshotactive = false;
                spreadshotactive = false;
                fastshotactive = false;
                machineshotactive = true;
                if (machineshotactive == true)
                {
                    Debug.Log("It's true!");
                }
            }
        }
        if (other.tag == "SPowerUp")
        {
            range2 = Random.Range(0, 4);
            Destroy(other.gameObject);
            if (range == 0)
            {

            }
        }
    }
}
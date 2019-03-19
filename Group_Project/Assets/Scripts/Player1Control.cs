﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Player1Control : MonoBehaviour
{
    private float speed = 15;
    public int health;
    public Boundary boundary;
    public int dodgeCooldown;
    public int shieldCooldown;
    public GameObject shield;

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
    private float nextShield;
    private float nextdodge;

    public GameObject slowBolt;
    public GameObject missle;
    public GameObject treebreak;
    public GameObject disable;
    public float slowFireRate;
    public float missleFireRate;
    private float strongnextFire;

    private int range;
    private int range2;
    private int SAmmo;
    private Rigidbody rb;

    private bool basicshotactive;
    private bool spreadshotactive;
    private bool fastshotactive;
    private bool machineshotactive;
    private bool slowammoactive;
    private bool missleammoactive;
    private bool treeBreakammoactive;
    private bool disableammoactive;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        basicshotactive = true;
        spreadshotactive = false;
        fastshotactive = false;
        machineshotactive = false;
        slowammoactive = false;
        missleammoactive = false;
        disableammoactive = false;
        treeBreakammoactive = false;
}

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("HorizontalP1");
        float movevertical = Input.GetAxis("VerticalP1");

        Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);
        rb.velocity = (movement * speed);

        rb.position = new Vector3
    (
     Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
    0.0f,
     Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
     );

        if (Input.GetButton("Fire4P1")&& Time.time > nextdodge)
        {
            nextdodge = Time.time + dodgeCooldown;
            StartCoroutine(Dodgeactive());
        }
        if (Input.GetButton("Fire3P1")&& Time.time > nextShield)
        {
            nextShield = Time.time + shieldCooldown;
            StartCoroutine(Shieldactive());
        }
        if (basicshotactive)
        {
            if (Input.GetButton("Fire1P1") && Time.time > basicnextFire)
            {
                basicnextFire = Time.time + basicfireRate;
                Instantiate(basicshot, basicshotSpawn.position, basicshotSpawn.rotation);
            }
        }
        if (fastshotactive)
        {
            if (Input.GetButton("Fire1P1") && Time.time > basicnextFire)
            {
                basicnextFire = Time.time + fastFireRate;
                Instantiate(fastshot, basicshotSpawn.position, basicshotSpawn.rotation);
            }
        }
        if (machineshotactive)
        {
            if (Input.GetButton("Fire1P1") && Time.time > basicnextFire)
            {
                basicnextFire = Time.time + machineFireRate;
                Instantiate(machineshot, basicshotSpawn.position, basicshotSpawn.rotation);
            }
        }
        if (spreadshotactive)
        {
            if (Input.GetButton("Fire1P1") && Time.time > basicnextFire)
            {
                basicnextFire = Time.time + spreadFireRate;
                Instantiate(basicshot, basicshotSpawn.position, basicshotSpawn.rotation);
                Instantiate(basicshot, spreadshotSpawn2.position, spreadshotSpawn2.rotation);
                Instantiate(basicshot, spreadshotSpawn3.position, spreadshotSpawn3.rotation);
            }
        }
        if (slowammoactive)
        {
            {
                if (Input.GetButton("Fire2P1") && Time.time > strongnextFire)
                {
                    SAmmo -= 1;
                    strongnextFire = Time.time + slowFireRate;
                    Instantiate(slowBolt, basicshotSpawn.position, basicshotSpawn.rotation);
                    if (SAmmo == 0)
                    {
                        slowammoactive = false;
                    }
                }
            }
        }
        if (missleammoactive)
        {
            {
                if (Input.GetButton("Fire2P1") && Time.time > strongnextFire)
                {
                    SAmmo -= 1;
                    strongnextFire = Time.time + missleFireRate;
                    Instantiate(missle, basicshotSpawn.position, basicshotSpawn.rotation);
                    if (SAmmo == 0)
                    {
                        missleammoactive = false;
                    }
                }
            }
        }
        if (treeBreakammoactive)
        {
            {
                if (Input.GetButton("Fire2P1") && Time.time > strongnextFire)
                {
                    SAmmo -= 1;
                    strongnextFire = Time.time + slowFireRate;
                    Instantiate(treebreak, basicshotSpawn.position, basicshotSpawn.rotation);
                    if (SAmmo == 0)
                    {
                        treeBreakammoactive = false;
                    }
                }
            }
        }
        if (disableammoactive)
        {
            {
                if (Input.GetButton("Fire2P1") && Time.time > strongnextFire)
                {
                    SAmmo -= 1;
                    strongnextFire = Time.time + slowFireRate;
                    Instantiate(disable, basicshotSpawn.position, basicshotSpawn.rotation);
                    if (SAmmo == 0)
                    {
                        disableammoactive = false;
                    }
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (health == 0)
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
            StartCoroutine(Slowed());
        }
        if (other.tag == "missle")
        {
            Destroy(other.gameObject);
            health -= 5;
        }
        if (other.tag == "TreeBreak")
        {
            Destroy(other.gameObject);
            health -= 2;
        }
        if (other.tag == "Disable")
        {
            Destroy(other.gameObject);
            health -= 2;
            StartCoroutine(Disablegun());
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
            }
        }
        if (other.tag == "SPowerUp")
        {
            range2 = Random.Range(0, 4);
            Destroy(other.gameObject);
            if (range2 == 0)
            {
                SAmmo = 2;
                slowammoactive = true;
                missleammoactive = false;
                disableammoactive = false;
                treeBreakammoactive = false;
            }
            if (range2 == 1)
            {
                SAmmo = 3;
                slowammoactive = false;
                missleammoactive = true;
                disableammoactive = false;
                treeBreakammoactive = false;
            }
            if (range2 == 2)
            {
                SAmmo = 2;
                slowammoactive = false;
                missleammoactive = false;
                disableammoactive = false;
                treeBreakammoactive = true;
            }
            if (range2 == 3)
            {
                SAmmo = 2;
                slowammoactive = false;
                missleammoactive = false;
                disableammoactive = true;
                treeBreakammoactive = false;
            }
        }
    }
    public IEnumerator Dodgeactive()
    {
        speed = 65;
        yield return new WaitForSeconds(.1f);
        speed = 15;
    }
    public IEnumerator Shieldactive()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(4f);
        shield.SetActive(false);
    }
    public IEnumerator Slowed()
    {
        basicnextFire = 2;
        speed = 7;
        yield return new WaitForSeconds(5f);
        speed = 15;
    }
    public IEnumerator Disablegun()
    {
        basicshotactive = false;
        missleammoactive = false;
        spreadshotactive = false;
        fastshotactive = false;
        machineshotactive = false;
        slowammoactive = false;
        disableammoactive = false;
        treeBreakammoactive = false;
        yield return new WaitForSeconds(2f);
        basicshotactive = true;
        missleammoactive = true;
        spreadshotactive = false;
        fastshotactive = false;
        machineshotactive = false;
        slowammoactive = false;
        disableammoactive = false;
        treeBreakammoactive = false;
        SAmmo = 1;
    }
}

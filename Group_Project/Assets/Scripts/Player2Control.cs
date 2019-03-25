using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary2
{
    public float xMin, xMax, zMin, zMax;
}

public class Player2Control : MonoBehaviour
{
    //general values in gameplay
    private float speed = 10;
    public int health;
    public Boundary boundary;
    public int dodgeCooldown;
    public int shieldCooldown;
    public GameObject shield;
    private Rigidbody rb;
    private float counter = 0;

    //any text value used in game
    public Text Health;
    public Text HeavyFire;
    public Text TrapFire;

    //any image files for weapons
    public GameObject FishShow;
    public GameObject CheatShow;
    public GameObject DogShow;
    public GameObject CrowShow;
    public GameObject PandaShow;
    public GameObject SlothShow;
    public GameObject BeaverShow;
    public GameObject SnakeShow;
    public GameObject BearTShow;
    public GameObject BeeTShow;
    public GameObject PooTShow;

    //objects that effect the basic fire button
    public GameObject basicshot;
    public GameObject fastshot;
    public GameObject machineshot;
    public GameObject spreadshot;
    public Transform basicshotSpawn;
    public Transform spreadshotSpawn2;
    public Transform spreadshotSpawn3;
    public float basicfireRate;
    public float spreadFireRate;
    public float fastFireRate;
    public float machineFireRate;

    //floats that modify firerates by a base value
    private float basicnextFire;
    private float nextShield;
    private float nextdodge;
    private float nextTrap;
    private float nextWall;

    //objects that effect the strong fire button
    public GameObject slowBolt;
    public GameObject missle;
    public GameObject treebreak;
    public GameObject disable;
    public Transform strongShotSpawn;
    public float slowFireRate;
    public float missleFireRate;
    private float strongnextFire;

    //objects that effect the trap fire button
    public GameObject trap;
    public GameObject STrap;
    public GameObject BTrap;
    public float trapFireRate;
    public Transform TrapSpawn;

    //values that effect weapon rolls and ammo values
    private int range;
    private int SAmmo;
    private int TAmmo = 1;

    //values that effect the placeable walls
    public GameObject Wall;
    public float wallRate;

    //bools that activate fire modes
    private bool basicshotactive;
    private bool spreadshotactive;
    private bool fastshotactive;
    private bool machineshotactive;
    private bool slowammoactive;
    private bool missleammoactive;
    private bool treeBreakammoactive;
    private bool disableammoactive;
    private bool BTrapAmmoActive;
    private bool STrapAmmoActive;
    private bool BeeTrapAmmoActive;
    private GameController gameController;

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
        BTrapAmmoActive = true;
        STrapAmmoActive = false;
        BeeTrapAmmoActive = false;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "Health: " + health;
        if (health == 0)
        {
            Destroy(gameObject);
            Destroy(shield);
            gameController.GameOver2();
        }
    }
    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("HorizontalP2");
        float movevertical = Input.GetAxis("VerticalP2");

        Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);
        rb.velocity = (movement * speed);
        rb.position = new Vector3
(
Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
0.0f,
Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
);
        if (Input.GetButton("Fire4P2") && Time.time > nextdodge)
        {
            nextdodge = Time.time + dodgeCooldown;
            StartCoroutine(Dodgeactive());
        }
        if (Input.GetButton("Fire3P2") && Time.time > nextShield)
        {
            nextShield = Time.time + shieldCooldown;
            StartCoroutine(Shieldactive());
        }
        if (Input.GetButton("Fire6P2") && Time.time > nextWall)
        {
            nextWall = Time.time + wallRate;
            Instantiate(Wall, strongShotSpawn.position, strongShotSpawn.rotation);
        }
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
        if (slowammoactive)
        {
            {
                if (Input.GetButton("Fire2P2") && Time.time > strongnextFire)
                {
                    SAmmo -= 1;
                    strongnextFire = Time.time + slowFireRate;
                    Instantiate(slowBolt, strongShotSpawn.position, strongShotSpawn.rotation);
                    HeavyFire.text = ": " + SAmmo;
                    if (SAmmo == 0)
                    {
                        slowammoactive = false;
                        SlothShow.SetActive(false);
                    }
                }
            }
        }
        if (missleammoactive)
        {
            {
                if (Input.GetButton("Fire2P2") && Time.time > strongnextFire)
                {
                    SAmmo -= 1;
                    strongnextFire = Time.time + missleFireRate;
                    Instantiate(missle, basicshotSpawn.position, basicshotSpawn.rotation);
                    HeavyFire.text = ": " + SAmmo;
                    if (SAmmo == 0)
                    {
                        missleammoactive = false;
                        PandaShow.SetActive(false);
                    }
                }
            }
        }
        if (treeBreakammoactive)
        {
            {
                if (Input.GetButton("Fire2P2") && Time.time > strongnextFire)
                {
                    SAmmo -= 1;
                    strongnextFire = Time.time + slowFireRate;
                    Instantiate(treebreak, basicshotSpawn.position, basicshotSpawn.rotation);
                    HeavyFire.text = ": " + SAmmo;
                    if (SAmmo == 0)
                    {
                        treeBreakammoactive = false;
                        BeaverShow.SetActive(true);
                    }
                }
            }
        }
        if (disableammoactive)
        {
            {
                if (Input.GetButton("Fire2P2") && Time.time > strongnextFire)
                {
                    SAmmo -= 1;
                    strongnextFire = Time.time + slowFireRate;
                    Instantiate(disable, basicshotSpawn.position, basicshotSpawn.rotation);
                    HeavyFire.text = ": " + SAmmo;
                    if (SAmmo == 0)
                    {
                        disableammoactive = false;
                        SnakeShow.SetActive(false);
                    }
                }
            }
        }
        if (BTrapAmmoActive)
        {
            if (Input.GetButton("Fire5P2") && Time.time > nextTrap)
            {
                {
                    TAmmo -= 1;
                    nextTrap = Time.time + trapFireRate;
                    Instantiate(trap, basicshotSpawn.position, basicshotSpawn.rotation);
                    TrapFire.text = ": " + TAmmo;
                    if (TAmmo == 0)
                    {
                        BTrapAmmoActive = false;
                        BearTShow.SetActive(false);
                    }
                }
            }
        }
        if (STrapAmmoActive)
        {
            if (Input.GetButton("Fire5P2") && Time.time > nextTrap)
            {
                {
                    TAmmo -= 1;
                    nextTrap = Time.time + trapFireRate;
                    Instantiate(STrap, TrapSpawn.position, TrapSpawn.rotation);
                    TrapFire.text = ": " + TAmmo;
                    if (TAmmo == 0)
                    {
                        STrapAmmoActive = false;
                        PooTShow.SetActive(false);
                    }
                }
            }
        }
        if (BeeTrapAmmoActive)
        {
            if (Input.GetButton("Fire5P2") && Time.time > nextTrap)
            {
                {
                    TAmmo -= 1;
                    nextTrap = Time.time + trapFireRate;
                    Instantiate(BTrap, TrapSpawn.position, TrapSpawn.rotation);
                    TrapFire.text = ": " + TAmmo;
                    if (TAmmo == 0)
                    {
                        BeeTrapAmmoActive = false;
                        BeeTShow.SetActive(false);
                    }
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
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
            health -= 4;
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
            basicshotactive = false;
            spreadshotactive = false;
            fastshotactive = false;
            machineshotactive = false;
            CrowShow.SetActive(false);
            FishShow.SetActive(false);
            CheatShow.SetActive(false);
            DogShow.SetActive(false);
            if (range == 0)
            {
                basicshotactive = true;
                FishShow.SetActive(true);
            }
            if (range == 1)
            {
                spreadshotactive = true;
                DogShow.SetActive(true);
            }
            if (range == 2)
            {
                fastshotactive = true;
                CheatShow.SetActive(true);
            }
            if (range == 3)
            {
                machineshotactive = true;
                CrowShow.SetActive(true);
            }
        }
        if (other.tag == "SPowerUp")
        {
            range = Random.Range(0, 4);
            Destroy(other.gameObject);
            slowammoactive = false;
            missleammoactive = false;
            disableammoactive = false;
            treeBreakammoactive = false;
            PandaShow.SetActive(false);
            SnakeShow.SetActive(false);
            BeaverShow.SetActive(false);
            SlothShow.SetActive(false);
            if (range == 0)
            {
                SAmmo = 2;
                slowammoactive = true;
                HeavyFire.text = ": " + SAmmo;
                SlothShow.SetActive(true);
            }
            if (range == 1)
            {
                SAmmo = 3;
                missleammoactive = true;
                HeavyFire.text = ": " + SAmmo;
                PandaShow.SetActive(true);
            }
            if (range == 2)
            {
                SAmmo = 2;
                treeBreakammoactive = true;
                HeavyFire.text = ": " + SAmmo;
                BeaverShow.SetActive(true);
            }
            if (range == 3)
            {
                SAmmo = 2;
                disableammoactive = true;
                HeavyFire.text = ": " + SAmmo;
                SnakeShow.SetActive(true);
            }
        }
        if (other.tag == "TPowerUp")
        {
            range = Random.Range(0, 3);
            Destroy(other.gameObject);
            BTrapAmmoActive = false;
            STrapAmmoActive = false;
            BeeTrapAmmoActive = false;
            BearTShow.SetActive(false);
            BeeTShow.SetActive(false);
            PooTShow.SetActive(false);
            if (range == 0)
            {
                TAmmo = 3;
                BTrapAmmoActive = true;
                TrapFire.text = ": " + TAmmo;
                BearTShow.SetActive(true);
            }
            if (range == 1)
            {
                TAmmo = 2;
                STrapAmmoActive = true;
                TrapFire.text = ": " + TAmmo;
                PooTShow.SetActive(true);
            }
            if (range == 2)
            {
                TAmmo = 2;
                BeeTrapAmmoActive = true;
                TrapFire.text = ": " + TAmmo;
                BeeTShow.SetActive(true);
            }
        }
        if (other.tag == "Trap")
        {
            Destroy(other.gameObject);
            health -= 1;
            StartCoroutine(BearTrap());
        }
        if (other.tag == "STrap")
        {
            Destroy(other.gameObject);
            health -= 1;
            StartCoroutine(Slowed());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "BeeTrap")
        {
            counter += Time.deltaTime;
            if (counter >= 1)
            {
                health -= 1;
                counter = 0;
            }
        }
    }
    public IEnumerator Dodgeactive()
    {
        speed = 65;
        yield return new WaitForSeconds(.1f);
        speed = 10;
    }
    public IEnumerator Shieldactive()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(4f);
        shield.SetActive(false);
    }
    public IEnumerator Slowed()
    {
        speed = 4;
        yield return new WaitForSeconds(5f);
        speed = 10;
    }
    public IEnumerator Disablegun()
    {
        FishShow.SetActive(true);
        CrowShow.SetActive(false);
        CheatShow.SetActive(false);
        DogShow.SetActive(false);
        PandaShow.SetActive(true);
        SnakeShow.SetActive(false);
        BeaverShow.SetActive(false);
        SlothShow.SetActive(false);
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
    public IEnumerator BearTrap()
    {
        speed = 0;
        yield return new WaitForSeconds(1f);
        speed = 10;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {
    public Vector3 spawnValues;

    //classes for basic powerUps
    public GameObject Bpowerups;
    public int BpowerCount;
    public float BspawnWait;
    public float BstartWait;
    public float BwaveWait;

    //classes for heavy powerUps
    public GameObject Hpowerups;
    public int HpowerCount;
    public float HspawnWait;
    public float HstartWait;
    public float HwaveWait;
    public Transform PowerUpRotate;

    //classes for trap powerUps
    public GameObject Tpowerups;
    public int TpowerCount;
    public float TspawnWait;
    public float TstartWait;
    public float TwaveWait;

    //classes for tree spawning
    public GameObject Trees;
    public Vector3 spawnValuesT;
    private int treeCount;
    private int treeCount2;
    public Transform TreeRotate;

    //classes for rock spawning
    public GameObject Rocks;
    private int rockCount;
    public Transform RockRotate;
    public float RspawnWait;
    public float RstartWait;
    public float RwaveWait;

    public Text gameOverText;
    public Text winnerText;

    private bool gameOver;
    // Use this for initialization
    void Start () {
        gameOverText.text = "";
        winnerText.text = "";
        gameOver = false;
        StartCoroutine(SpawnWeakPowers());
        StartCoroutine(SpawnStrongPowers());
        StartCoroutine(SpawnTrapPowers());
        StartCoroutine(SpawnTreesTop());
        StartCoroutine(SpawnTreesBottom());
        StartCoroutine(SpawnRocks());
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Quit"))
        {
            Application.Quit();
        }
        if (gameOver)
        {
            gameOverText.text = "Game Over!";
            if (Input.GetButton("Restart"))
            {
            SceneManager.LoadScene(0);
            }
        }
    }
    IEnumerator SpawnTreesTop()
    {
        treeCount = Random.Range(8, 13);
        for (int i = 0; i < treeCount; i++)
        {
            GameObject Tree = Trees;
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesT.x, spawnValuesT.x), spawnValuesT.y, Random.Range(5,14));
            Instantiate(Tree, spawnPosition, TreeRotate.rotation);
            yield return new WaitForSeconds(0);
        }
    }
    IEnumerator SpawnRocks()
    {
        yield return new WaitForSeconds(RstartWait);
        rockCount = Random.Range(3, 6);
        while (true)
        {
            for (int i = 0; i < rockCount; i++)
            {
                GameObject Rock = Rocks;
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesT.x, spawnValuesT.x), spawnValuesT.y, Random.Range(-2, 3));
                Instantiate(Rock, spawnPosition, RockRotate.rotation);
                yield return new WaitForSeconds(RspawnWait);
            }
            yield return new WaitForSeconds(RwaveWait);
        }
    }
    IEnumerator SpawnTreesBottom()
    {
        treeCount2 = Random.Range(8, 13);
        for (int i = 0; i < treeCount2; i++)
        {
            GameObject Tree = Trees;
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesT.x, spawnValuesT.x), spawnValuesT.y, Random.Range(-5, -14));
            Instantiate(Tree, spawnPosition, TreeRotate.rotation);
            yield return new WaitForSeconds(0);
        }
    }
    IEnumerator SpawnWeakPowers()
    {
        yield return new WaitForSeconds(BstartWait);
        while (true)
        {
            for (int i = 0; i < BpowerCount; i++)
            {
                GameObject BpowerUp = Bpowerups;
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-14,14));
                Instantiate(BpowerUp, spawnPosition, PowerUpRotate.rotation);
                yield return new WaitForSeconds(BspawnWait);
            }
            yield return new WaitForSeconds(BwaveWait);
        }
    }
    IEnumerator SpawnStrongPowers()
    {
        yield return new WaitForSeconds(HstartWait);
        while (true)
        {
            for (int i = 0; i < HpowerCount; i++)
            {
                GameObject HpowerUp = Hpowerups;
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-8,8));
                Instantiate(HpowerUp, spawnPosition, PowerUpRotate.rotation);
                yield return new WaitForSeconds(HspawnWait);
            }
            yield return new WaitForSeconds(HwaveWait);
        }
    }
    IEnumerator SpawnTrapPowers()
    {
        yield return new WaitForSeconds(TstartWait);
        while (true)
        {
            for (int i = 0; i < TpowerCount; i++)
            {
                GameObject TpowerUp = Tpowerups;
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-11, 11));
                Instantiate(TpowerUp, spawnPosition, PowerUpRotate.rotation);
                yield return new WaitForSeconds(TspawnWait);
            }
            yield return new WaitForSeconds(TwaveWait);
        }
    }
    public void GameOver1()
    {
        winnerText.text = "Player 2 wins!";
        gameOver = true;
    }
    public void GameOver2()
    {
        winnerText.text = "Player 1 wins!";
        gameOver = true;
    }
}

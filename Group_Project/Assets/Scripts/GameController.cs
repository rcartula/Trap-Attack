using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
    public GameObject[] powerups;
    public Vector3 spawnValues;
    public int powerCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnPowers());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator SpawnPowers()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < powerCount; i++)
            {
                GameObject powerUp = powerups[Random.Range(0, powerups.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(powerUp, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}

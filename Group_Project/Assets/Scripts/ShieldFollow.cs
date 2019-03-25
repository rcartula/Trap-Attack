using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFollow : MonoBehaviour {
    public GameObject player;
    public GameObject Shield;

    private Vector3 offset;
    // Use this for initialization
    void Start () {
        StartCoroutine(Shieldactive());
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
    }
    public IEnumerator Shieldactive()
    {
        Shield.SetActive(true);
        yield return new WaitForSeconds(.1f);
        Shield.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMover : MonoBehaviour {
    public float speed;

    public float startWait;
    public float nextWait;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(SnakeMove());
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward * speed;
    }
    public IEnumerator SnakeMove()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                transform.Rotate(new Vector3(0, 25, 0));
                yield return new WaitForSeconds(.3f);
                transform.Rotate(new Vector3(0, -25, 0));
                yield return new WaitForSeconds(.1f);
                transform.Rotate(new Vector3(0, -25, 0));
                yield return new WaitForSeconds(.3f);
                transform.Rotate(new Vector3(0, 25, 0));
                yield return new WaitForSeconds(nextWait);
            }
            yield return new WaitForSeconds(nextWait);
        }
    }
}

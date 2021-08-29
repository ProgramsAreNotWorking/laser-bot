using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : Robots
{
    GameManager gm;

    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        moveTo = transform.position;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Bullet"))
        {
            gm.StartGame();
            Destroy(gameObject);
        }
    }
}

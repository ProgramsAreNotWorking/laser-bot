using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Robots
{
    int waitForFrame;
    [SerializeField] GameObject dead;

    [SerializeField] GameObject player;

    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        gm.AddEnemy(this);
        moveTo = transform.position;

    }

    private void Update()
    {
        
        Direction();
        Atack();
    }

    public override void Direction()
    {
        if (player != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) CanMove(new Vector3(0, 0, 1));
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) CanMove(new Vector3(-1, 0, 0));
            else if (Input.GetKeyDown(KeyCode.DownArrow)) CanMove(new Vector3(0, 0, -1));
            else if (Input.GetKeyDown(KeyCode.RightArrow)) CanMove(new Vector3(1, 0, 0));
        }
    }

    public override void CanMove(Vector3 direction)
    {
        dir = direction;
        transform.forward = dir;

        StartCoroutine(Esperar(direction));
    }

    IEnumerator Esperar(Vector3 direction)
    {
        yield return new WaitForSeconds(waitForFrame);

        if (Physics.Raycast((transform.position - rayPos) + direction * multiply, Vector3.down, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Walk"))
            {
                if (currentTile != null) currentTile.tag = "Walk";
                currentTile = hit.transform.gameObject;
                currentTile.tag = "Untagged";
                moveTo = hit.transform.position + new Vector3(0, transform.position.y, 0);

                transform.position = moveTo;
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Bullet"))
        {
            GameObject efecto = Instantiate(deathEfect, bulletSpawner.position, transform.rotation);
            Destroy(efecto, 1);
            if (currentTile != null) currentTile.tag = "Walk";
            Destroy(gameObject);
            Destroy(Instantiate(dead), 3);
        }
    }

    private void OnDestroy()
    {
        gm.RemoveEnemy(this);
    }

}

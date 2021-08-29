using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robots : MonoBehaviour , IRobots
{
    public Vector3 rayPos = new Vector3(0,-7,0);

    public Transform bulletSpawner;
    public GameObject bullet;

    //move
    public int multiply = 4;
    public GameObject currentTile;
    public Vector3 moveTo;
    public Vector3 dir;

    //morir
    public GameObject deathEfect;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        moveTo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Direction()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) CanMove(new Vector3(0, 0, 1));
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) CanMove(new Vector3(-1, 0, 0));
        else if (Input.GetKeyDown(KeyCode.DownArrow)) CanMove(new Vector3(0, 0, -1));
        else if (Input.GetKeyDown(KeyCode.RightArrow)) CanMove(new Vector3(1, 0, 0));
    }

    public virtual void CanMove(Vector3 direction)
    {
        dir = direction;
        transform.forward = dir;
        if (Physics.Raycast((transform.position - rayPos) + direction * multiply, Vector3.down, out RaycastHit hit))
        {
            if(hit.transform.CompareTag("Walk"))
            {
                if(currentTile != null) currentTile.tag = "Walk";
                currentTile = hit.transform.gameObject;
                currentTile.tag = "Untagged";
                moveTo = hit.transform.position + new Vector3(0, transform.position.y, 0);

                transform.position = moveTo;
            }
        }

    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = moveTo;
            transform.forward = dir;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = moveTo;
            transform.forward = dir;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = moveTo;
            transform.forward = dir;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = moveTo;
            transform.forward = dir;
        }
    }

    public virtual void Atack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject laser = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            laser.GetComponent<Laser>().EnemyBullet = true;

        }

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Robots , IRobots
{
    public Vector3 inicialPos;

    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioSource motor;

    private void Start()
    {
        inicialPos = transform.position;
        moveTo = transform.position;
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void Update()
    {
        Direction();
        Atack();
    }

    public virtual void Direction()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CanMove(new Vector3(0, 0, 1));
            motor.clip = jump;
            motor.Play();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            motor.clip = jump;
            motor.Play();
            CanMove(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) 
        { 
            motor.clip = jump;
            motor.Play();
            CanMove(new Vector3(0, 0, -1));
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            motor.clip = jump;
            motor.Play();
            CanMove(new Vector3(1, 0, 0));
        }
    }

    public override void Atack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            motor.clip = shoot;
            motor.Play();
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.CompareTag("Bullet"))
        {
            if(coll.gameObject.GetComponent<Laser>().EnemyBullet)
            {
                gm.Restart();
            }
        }
    }

    private void OnDestroy()
    {
        
    }


}

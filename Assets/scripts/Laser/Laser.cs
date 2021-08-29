using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float lifeTime;
    bool enemyBullet;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        GetComponent<Rigidbody>().AddForce(transform.forward * (speed * speed));
    }
    public  bool EnemyBullet { get { return enemyBullet; } set { enemyBullet = value; } }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player") && enemyBullet == true) Destroy(gameObject);

        if(coll.CompareTag("Enemy") && enemyBullet == false) Destroy(gameObject);
    }
}

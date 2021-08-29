using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int maxRange;
    [SerializeField] GameObject[] enemys;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range( 0, maxRange++);

        Instantiate(enemys[random], transform.position + new Vector3(0, 4 - transform.position.y, 0), transform.rotation);
    }
}

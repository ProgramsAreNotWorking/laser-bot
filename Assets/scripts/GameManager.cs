using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    LinkedList<Robots> enemy = new LinkedList<Robots>();

    int state;
    [SerializeField] string[] states;

    bool first;

    [SerializeField] float wait;

    [SerializeField] AudioSource win;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        GameObject otro = GameObject.FindGameObjectWithTag("GameController");
        if (otro != null && otro != gameObject) Destroy(gameObject);
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // Spawn();
    }

    IEnumerator PassLevel(float wait)
    {
        yield return new WaitForSeconds(wait);
        win.Play();
        if (enemy.Count == 0 && state < states.Length)
        {
            state++;
            //if (first == true && state == 1) state++;
            if (state >= states.Length) state = 0;
            //if (state == 1) first = true;
            SceneManager.LoadScene(states[state]);
        }

    }

    public void StartGame()
    {
        state++;
        if (first == true && state == 1) state++;
        if (state == 1) first = true;
        SceneManager.LoadScene(states[state]);
    }

    public void Restart()
    {
        state = 0;
        SceneManager.LoadScene(states[state]);
    }

    public void RemoveEnemy(Robots index)
    {
        enemy.Remove(index);
        if (enemy.Count <= 0) StartCoroutine(PassLevel(wait));
    }
    public void AddEnemy(Robots index) => enemy.AddLast(index);
}

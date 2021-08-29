using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlue : Enemy
{
    public virtual void Direction()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) CanMove(new Vector3(0, 0, -1));
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) CanMove(new Vector3(1, 0, 0));
        else if (Input.GetKeyDown(KeyCode.DownArrow)) CanMove(new Vector3(0, 0, 1));
        else if (Input.GetKeyDown(KeyCode.RightArrow)) CanMove(new Vector3(-1, 0, 0));
    }
}

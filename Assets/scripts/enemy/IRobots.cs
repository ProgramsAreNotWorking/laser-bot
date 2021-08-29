using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IRobots
{
    void Direction();
    void CanMove(Vector3 direction);

    void Move();

    void Atack();
}
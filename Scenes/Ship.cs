using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public abstract class Ship : MonoBehaviour
{
    [SerializeField] protected Vector2 _directionOfMovement;

    abstract protected void Movement();

    abstract protected void Spawn();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PowerUpType
{
    None,
    Pushback,
    Rockets,
    Smash
}
public class PowerUp : MonoBehaviour
{

    public PowerUpType powerUpType;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime*30);
    }
}

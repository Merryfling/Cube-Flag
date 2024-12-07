using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]private GameObject deathVFX;

    public void DestroyGameObject()
    {
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
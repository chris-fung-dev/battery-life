using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryAdd : MonoBehaviour
{
    public ControllingLight Light;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           Light.AddTime();
           Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryAdd : MonoBehaviour
{
        public ControllingLight Light;
        public AudioSource pickup;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                pickup.Play();
                Light.AddTime();
                Invoke("Disappear", 0.2f); // Invoke the method name as a string with the delay
            }
        }

        private void Disappear() // Renamed the method to follow naming conventions
        {
            Destroy(gameObject);
        }
    }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ControllingLight : MonoBehaviour
{
    // Public variable to change the outer radius in the Inspector
    private Light2D myLight; // Reference to the 2D Light component
    public float currentTime = 0f;
    private float startingTime = 5f;
    private float BatteryTimeAdd = 5f;

    void Start()
    {
        // Get the Light2D component attached to this GameObject
        myLight = GetComponent<Light2D>();
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 0.3f * Time.deltaTime; // Subtract deltaTime directly

        if (currentTime <= 0)
        {
            currentTime = 0;
            // You might want to add logic here for what happens when the countdown reaches zero
            // For example, stopping the countdown or triggering another action.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        myLight.pointLightOuterRadius = currentTime; // Update the light's outer radius directly
    }

    public void AddTime()
    {
        currentTime = BatteryTimeAdd;
    }
}


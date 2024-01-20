using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashFX;
    public GameObject mainCam;

    void OnTriggerEnter(Collider other)
    {
        // Turn off the collider to avoid retriggering
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // Disable player move
        thePlayer.GetComponent<PlayerMove>().enabled = false;

        // Play animation
        charModel.GetComponent<Animator>().Play("Stumble Backwards");

        // Play crash sound effect
        crashFX.Play();

        // Enable camera's animation (crash shake)
        mainCam.GetComponent<Animator>().enabled = true;
    }
}

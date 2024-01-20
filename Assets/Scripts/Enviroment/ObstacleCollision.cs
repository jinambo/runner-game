using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashFX;
    public GameObject mainCam;
    public GameObject levelControl;

    public static bool hasStumbled = false;

    void OnTriggerEnter(Collider other)
    {
        // Turn off the collider to avoid retriggering
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // Disable player move
        thePlayer.GetComponent<PlayerMove>().enabled = false;

        // Play animation
        charModel.GetComponent<Animator>().Play("Stumble Backwards");

        // set true so the another aniamtion isn ot triggered
        hasStumbled = true;

        // Stop counting distance
        levelControl.GetComponent<LevelDistance>().enabled = false;

        // Play crash sound effect
        crashFX.Play();

        // Enable camera's animation (crash shake)
        mainCam.GetComponent<Animator>().enabled = true;

        //Starts end of run sequence
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}

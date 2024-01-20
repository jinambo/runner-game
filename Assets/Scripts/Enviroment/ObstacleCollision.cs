using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    void OnTriggerEnter(Collider other)
    {
        // Turn off the collider to avoid retriggering
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        // Disable player move
        thePlayer.GetComponent<PlayerMove>().enabled = false;

        charModel.GetComponent<Animator>().Play("Stumble Backwards");
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject distanceDisplay;
    public GameObject distanceEndDisplay;
    public static int distanceRun;
    public bool addingDistance = false;

    //TODO: Preparing for future, when the player will run faster
    public static float distanceDelay = 0.35f;
    // public static float originalDistanceDelay;

    void Update()
    {
        if (addingDistance == false) {
            addingDistance = true;
            StartCoroutine(AddingDis());

        }
    }

    IEnumerator AddingDis() {
        distanceRun += 1;
        distanceDisplay.GetComponent<Text>().text = "" + distanceRun;
        distanceEndDisplay.GetComponent<Text>().text = "" + distanceRun;

        yield return new WaitForSeconds(distanceDelay);
        addingDistance = false;
    }
}

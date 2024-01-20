using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject kunaiPrefab;
    public GameObject playerPrefab; 
    public Transform kunaiSpawnPoint;
    public GameObject charModel;
    public float activationDistance = 50.0f;

    private float throwInterval = 2.0f;
    private float timer;

    void Start()
    {
        timer = throwInterval;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(playerPrefab.transform.position, transform.position);
        if (distanceToPlayer > activationDistance) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            kunaiPrefab.SetActive(true);
            ThrowKunai();
            timer = throwInterval;
            // Play animation
            charModel.GetComponent<Animator>().Play("Frisbee Throw");
        }
    }

    void ThrowKunai()
    {
        Instantiate(kunaiPrefab, kunaiSpawnPoint.position, kunaiSpawnPoint.rotation);
    }
}

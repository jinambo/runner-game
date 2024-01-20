using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject kunaiPrefab; 
    public Transform kunaiSpawnPoint;
    public GameObject charModel;

    private float throwInterval = 2.0f;
    private float timer;

    void Start()
    {
        timer = throwInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ThrowKunai();
            // Play animation
            charModel.GetComponent<Animator>().Play("Frisbee Throw");
            timer = throwInterval;
        }
    }

    void ThrowKunai()
    {
        Instantiate(kunaiPrefab, kunaiSpawnPoint.position, kunaiSpawnPoint.rotation);
    }
}

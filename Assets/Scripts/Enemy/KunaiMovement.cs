using UnityEngine;

public class KunaiMovement : MonoBehaviour
{
    public GameObject playerPrefab; 
    public float speed = 20.0f;

    void Update()
    {
      transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);

      // if (playerPrefab != null && transform.position.z < playerPrefab.transform.position.z)
      // {
      //   Destroy(gameObject); 
      // }
    }
}
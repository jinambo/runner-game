using UnityEngine;

public class KunaiMovement : MonoBehaviour
{
    public float speed = 20.0f;

    void Update()
    {
      transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);
    }
}
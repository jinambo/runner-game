using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVerticalObject : MonoBehaviour
{
  public float moveSpeed = 1.0f;
  public float maxHeight = 2.5f;
  public float minHeight = 1f;
  private float direction = 1.0f;

    void Update()
    {
      // Move the object up and down
      transform.Translate(Vector3.up * moveSpeed * direction * Time.deltaTime, Space.World);

      // Check if the object has reached the maximum or minimum height
      if (transform.position.y >= maxHeight || transform.position.y <= minHeight)
      {
          // Reverse the direction
          direction *= -1;
      }
    }
}
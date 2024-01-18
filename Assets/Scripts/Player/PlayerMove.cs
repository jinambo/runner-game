using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float moveSpeed = 3;
  public float leftRightSpeed = 4;

  // Update is called once per frame
  void Update()
  {
    // Move the GameObject forward at a constant speed. The movement is relative to the world space.
    transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

    // Move the GameObject to the left, if the key is pressed
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
      // Check if the GameObject is within boundaries
      if (this.gameObject.transform.position.x > LevelBoundary.leftSide) {
        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
      }
    }
    // Move the GameObject to the right, if the key is pressed
    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
      // Check if the GameObject is within boundaries
      if (this.gameObject.transform.position.x < LevelBoundary.rightSide) {
        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
      }
    }
  }
}

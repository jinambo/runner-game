using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float moveSpeed = 5;
  public float leftRightSpeed = 4;
  static public bool canMove = false;

  public bool isJumping = false;

  public bool comingDown = false;
  public GameObject playerObject;

  // Update is called once per frame
  void Update()
  {
    // Move the GameObject forward at a constant speed. The movement is relative to the world space.
    transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

    if (canMove) {
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
      if (Input.GetKey(KeyCode.Space)) {
        if (isJumping == false){
          isJumping = true;
          playerObject.GetComponent<Animator>().Play("Jump");
          StartCoroutine(JumpSequence());
        }
      }
    }

    if (isJumping == true){
      if (comingDown == false) {
        transform.Translate(Vector3.up * Time.deltaTime * 5, Space.World);
      } else {
        transform.Translate(Vector3.up * Time.deltaTime * -5, Space.World);
      }
    }
  }
  IEnumerator JumpSequence() {
    yield return new WaitForSeconds(0.45f);
    comingDown = true;
    yield return new WaitForSeconds(0.45f);
    isJumping = false;
    comingDown = false;
    if (!ObstacleCollision.hasStumbled) {
      playerObject.GetComponent<Animator>().Play("Run");
    }
  }
}

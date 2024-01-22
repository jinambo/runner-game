using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  //TODO: Make this dynamicaly changed
  public float accelerationFactor = 0.1f;
  public float maxSpeed = 10f;
  public float moveSpeed = 5f;
  private float originalSpeed;
  private float originalDistanceDelay;
  public float leftRightSpeed = 4;
  static public bool canMove = false;

  public bool isJumping = false;

  public bool comingDown = false;
  public bool isTempSpeed = false;
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
          playerObject.GetComponent<Animator>().Play("Ninja Jump");
          StartCoroutine(JumpSequence());
        }
      }
    }

    if (isJumping == true){
      if (comingDown == false) {
        // TODO, idk if the jump height should be changed (mby for some bonus jump), just change the 5
        transform.Translate(Vector3.up * Time.deltaTime * 5, Space.World);
      } else {
        // TODO: here is also needed cahnge the value
        transform.Translate(Vector3.up * Time.deltaTime * -5, Space.World);
      }
    }

    // Increase speed by distance
    if (!isTempSpeed) {
      float distanceFactor = LevelDistance.distanceRun / 20; 
      float newSpeed = originalSpeed + (distanceFactor * accelerationFactor);
      IncreaseSpeed(newSpeed, 0, true);
      Debug.Log("Original Speed: " + newSpeed);
      Debug.Log("New Speed: " + newSpeed);
    }
  }

  void Start()
  {
    originalSpeed = moveSpeed; // Uložení původní rychlosti
    originalDistanceDelay = LevelDistance.distanceDelay;
  }

  public void IncreaseSpeed(float newSpeed, float duration, bool isInfinite)
  {
    // Calc new and original speed difference
    float speedDiff = originalSpeed / newSpeed; // example: 5 / 10 = 0.5

    // Set movespeed to the new speed from the params
    moveSpeed = newSpeed; 

    // Set new distance delay according to speed diff
    LevelDistance.distanceDelay = originalDistanceDelay * speedDiff; // 0.35 * 0.5 = 0.175

    // If it's not infinite reset speed to original
    if (!isInfinite) {
      isTempSpeed = true;
      StartCoroutine(ResetSpeed(duration)); // Reset speed after time
    }
  }

  IEnumerator ResetSpeed(float duration)
  {
    yield return new WaitForSeconds(duration);

    // Reset speed back to original
    moveSpeed = originalSpeed; 

    // Reset distance delay back to original
    LevelDistance.distanceDelay = originalDistanceDelay;

    isTempSpeed = false;
  }

  IEnumerator JumpSequence() {
    yield return new WaitForSeconds(0.45f);
    comingDown = true;
    yield return new WaitForSeconds(0.45f);
    isJumping = false;
    comingDown = false;
    transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
    if (!ObstacleCollision.hasStumbled) {
      playerObject.GetComponent<Animator>().Play("Run");
    }
  }
}
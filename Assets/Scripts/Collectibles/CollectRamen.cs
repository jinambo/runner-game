using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectRamen : MonoBehaviour
{
  public AudioSource ramenFX;
  public PlayerMove playerMoveScript;
  public RamenTimer ramenTimer;

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      ramenFX.Play();

      // Increase player's speed and change distance delay
      playerMoveScript.IncreaseSpeed(PlayerMove.moveSpeed * 2, 5f, false);

      ramenTimer.StartTimer();
      this.gameObject.SetActive(false);
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
  public void StartGame(){
    ObstacleCollision.hasStumbled = false;
    PlayerMove.canMove = false;
    SceneManager.LoadScene(1);

    // Re-set coins and distance
    CollectableControl.coinCount = 0;
    LevelDistance.distanceRun = 0;
    LevelDistance.distanceDelay = 0.35f;
  }

  public void QuitGame(){
    #if UNITY_EDITOR
    // Application.Quit() does not work in the editor so
    // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
    UnityEditor.EditorApplication.isPlaying = false;
    #else
    // Quit the application
    Application.Quit();
    #endif
  }
}

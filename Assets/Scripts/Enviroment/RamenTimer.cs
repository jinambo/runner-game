using UnityEngine;
using UnityEngine.UI;

public class RamenTimer : MonoBehaviour
{
  public Slider timerSlider;
  private float maxTime = 5f;
  private float timeRemaining;
  private bool isTimerRunning = false;

  void Update()
  {
    if (isTimerRunning) {
      if (timeRemaining > 0) {
        timeRemaining -= Time.deltaTime;
        timerSlider.value = timeRemaining / maxTime;
      } else {
        isTimerRunning = false;
        gameObject.SetActive(false);
      }
    }
  }

  public void StartTimer()
  {
    timeRemaining = maxTime;
    timerSlider.value = 1;
    isTimerRunning = true;
    gameObject.SetActive(true);
  }
}

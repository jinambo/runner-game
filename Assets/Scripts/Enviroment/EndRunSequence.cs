using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveDistance;
    public GameObject endScreen;
    public GameObject fadeOut;
    public AudioSource gameMusic;
    public AudioSource overMusic;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence(){
        yield return new WaitForSeconds(3);

        gameMusic.Stop();
        overMusic.Play();

        liveCoins.SetActive(false);
        liveDistance.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}

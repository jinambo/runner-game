using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
  public GameObject[] section;
  // first position where we will generate section, each section is 50 units long
  public int zPos = 50;
  public bool creatingSection = false;
  public int secNum;

  // Update is called once per frame
  void Update()
  {
    if (creatingSection == false) {
        creatingSection = true;
        StartCoroutine(GenerateSection());
    }
  }

  IEnumerator GenerateSection() {
    secNum = Random.Range(0,3);
    Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
    zPos += 50;
    // how long the function will wait for generating new section
    // TODO: If the player's speed will incrementing, this value must be dynamicly changed
    yield return new WaitForSeconds(2);
    creatingSection = false;
  }
}

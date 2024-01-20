using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySection : MonoBehaviour
{
  public string parentName;
  void Start()
  {
    parentName = transform.name;
    StartCoroutine(DestroyClone());
  }

  IEnumerator DestroyClone() {
    // TODO: Optimaze this time when adding increasing speed, now if the player RUNS too long, map starting dissapear
    yield return new WaitForSeconds(120);
    if (parentName == "Section(Clone)"){
      Destroy(gameObject);
    }
  }
}

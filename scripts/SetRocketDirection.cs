using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRocketDirection : MonoBehaviour {
  void Start() {
    GameManager.gameManager.changeCompass += SetRocketDir;
  }

  void SetRocketDir(float compass) {
    transform.localRotation = Quaternion.Euler(- compass - 90, 90, 0);
  }
}

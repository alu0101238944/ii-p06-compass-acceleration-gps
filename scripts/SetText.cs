using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {
  public Text text;
  private string compassText;
  private string accelerationText;
  private string gpsText;

  void Start() {
    GameManager.gameManager.changeCompass += SetCompassText;
    GameManager.gameManager.changeAcceleration += SetAccelerationText;
    GameManager.gameManager.setGps += SetGpsText;
  }

  void Update() {
    if (text != null) {
      text.text = "Use horizontal axis to move the camera\n" + 
                  "Use vertical axis to move the sun\n" +
                  "Compass: " + compassText + "\n" +
                  "Acceleration: " + accelerationText + "\n" +
                  "Gps: " + gpsText; 
    }
  }

  void SetCompassText(float compass) {
    compassText = compass.ToString();
  }

  void SetAccelerationText(Vector3 acceleration) {
    accelerationText = acceleration.ToString();
  }

  void SetGpsText(Vector3 gps) {
    gpsText = gps.ToString();
  }
}

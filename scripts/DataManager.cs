using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour {
  private float compass;
  private Vector3 acceleration;
  private Vector3 gps;

IEnumerator Start() {
  // Check if the user has location service enabled.
  if (!Input.location.isEnabledByUser) {
    yield break;
  }
  // Starts the location service.
  Input.location.Start();

  // Waits until the location service initializes
  int maxWait = 20;
  while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
    yield return new WaitForSeconds(1);
    maxWait--;
  }
  // If the service didn't initialize in 20 seconds this cancels location service use.
  if (maxWait < 1) {
    print("Timed out");
    yield break;
  }
  // If the connection failed this cancels location service use.
  if (Input.location.status == LocationServiceStatus.Failed) {
    print("Unable to determine device location");
    yield break;
  } else {
    LocationService location = Input.location;
    // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
    LocationInfo locationData = location.lastData;
    acceleration = Input.acceleration;

    Input.compass.enabled = true;
    compass = Input.compass.trueHeading;

    gps = new Vector3(locationData.latitude,
                      locationData.longitude, locationData.altitude);
    Debug.Log("Input.location funciona correctamente");
    
    GameManager.gameManager.ThrowSetGps(gps);
    GameManager.gameManager.ThrowChangeAcceleration(acceleration);
    GameManager.gameManager.ThrowChangeCompass(compass);
  }

  // Stops the location service if there is no need to query location updates continuously.
  // Input.location.Stop(); TODO ???
}

  void Update() {
    float newCompass = Input.compass.trueHeading;
    if (Input.location.status == LocationServiceStatus.Running && newCompass != compass) {
      compass = newCompass;
      GameManager.gameManager.ThrowChangeCompass(compass);
    }
    Vector3 newAcceleration = Input.acceleration;
    if (newAcceleration != null && newAcceleration != acceleration) {
      acceleration = newAcceleration;
      GameManager.gameManager.ThrowChangeAcceleration(acceleration);
    }
  }
}

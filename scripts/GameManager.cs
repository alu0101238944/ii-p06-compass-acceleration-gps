using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangeCompass(float compass);
public delegate void ChangeAcceleration(Vector3 acceleration);
public delegate void SetGps(Vector3 gps);

public class GameManager : MonoBehaviour {
  public static GameManager gameManager;

  public event ChangeCompass changeCompass;
  public event ChangeAcceleration changeAcceleration;
  public event SetGps setGps;

  void Awake() {
    if (!gameManager) {
      gameManager = this;
      DontDestroyOnLoad(this);
    } else if (gameManager != this) {
      Destroy(gameObject);
    }
  }

  public void ThrowChangeCompass(float compass) {
    changeCompass(compass);
  }

  public void ThrowChangeAcceleration(Vector3 acceleration) {
    changeAcceleration(acceleration);
  }

  public void ThrowSetGps(Vector3 gps) {
    setGps(gps);
  }
}

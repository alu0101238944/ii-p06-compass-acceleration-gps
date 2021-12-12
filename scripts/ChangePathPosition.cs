using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePathPosition : MonoBehaviour {
  public float power = 0.0025f;
  public Joystick joystick;
  private CinemachineTrackedDolly trackDolly;

  void Start() {
    trackDolly = gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>();
  }

  void Update() {
    trackDolly.m_PathPosition -= power * (Input.GetAxis("Horizontal") + 5 * joystick.Horizontal);
  }
}

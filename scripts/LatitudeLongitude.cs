using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatitudeLongitude : MonoBehaviour {
  public GameObject point;
  void Start() {
    GameManager.gameManager.setGps += SetPosition;
  }

  void SetPosition(Vector3 gps) {
    Vector3 ecef = LLHtoECEF(new Vector3(gps[0], - gps[1], 0));
    point.GetComponent<Transform>().position += new Vector3(ecef[0], ecef[1], 0);
  }

  // https://stackoverflow.com/questions/10473852/convert-latitude-and-longitude-to-point-in-3d-space
  Vector3 LLHtoECEF(Vector3 gps) {
    float lat = gps[0];
    float lon = gps[1];
    float alt = gps[2];

    float rad = gameObject.transform.GetComponent<SphereCollider>().radius;
    float cosLat = Mathf.Cos(lat);
    float sinLat = Mathf.Sin(lat);
    float C = 1 / Mathf.Sqrt(Mathf.Pow(cosLat, 2) + Mathf.Pow(sinLat, 2));

    float x = cosLat * Mathf.Cos(lon);
    float y = cosLat * Mathf.Sin(lon);
    float z = sinLat;

    return (rad * C + alt) * new Vector3(x, y, z);
  }
}

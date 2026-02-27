using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class LookAt : MonoBehaviour
{
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    [SerializeField] private GameObject crosshair;

    void FixedUpdate()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = 3f;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;
        crosshair.transform.position = Input.mousePosition;
    }
}

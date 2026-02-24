using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}

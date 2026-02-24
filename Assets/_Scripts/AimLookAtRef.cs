using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AimLookAtRef : MonoBehaviour
{
    private Transform lookAtObject;
    void Start()
    {
        GameObject obj = GameObject.Find("AimRef");

        if (obj != null)
        {
            lookAtObject = obj.transform;
        }
    }

    void Update()
    {
        if (this.gameObject.GetComponentInParent<PhotonView>().IsMine == true)
        {
            if (lookAtObject != null)
            {
                transform.position = lookAtObject.transform.position;
                transform.rotation = lookAtObject.transform.rotation;
            }
        }
    }
}

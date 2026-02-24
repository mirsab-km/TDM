using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;
using Photon.Pun;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] private TwoBoneIKConstraint leftHand;
    [SerializeField] private TwoBoneIKConstraint rightHand;

    [SerializeField] private RigBuilder rig;

    [SerializeField] private Transform[] leftTargets;
    [SerializeField] private Transform[] rightTargets;
    [SerializeField] private GameObject[] weapons;

    private CinemachineVirtualCamera cam;
    private GameObject camObject;

    public MultiAimConstraint[] aimObjects;
    private Transform aimTarget;

    private int weaponCount;
    void Start()
    {
        camObject = GameObject.Find("PlayerCamera");
        aimTarget = GameObject.Find("AimRef").transform;
        if (this.gameObject.GetComponent<PhotonView>().IsMine)
        {
            cam = camObject.GetComponent<CinemachineVirtualCamera>();
            cam.Follow = this.gameObject.transform;
            cam.LookAt = this.gameObject.transform;
            Invoke("LookAt", 0.1f);
        }
        else
        {
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void LookAt()
    {
        if (aimTarget != null)
        {
            for (int i = 0; i < aimObjects.Length; i++)
            {
                var target = aimObjects[i].data.sourceObjects;
                target.SetTransform(0, aimTarget.transform);
                aimObjects[i].data.sourceObjects = target;
            }
            rig.Build();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            weaponCount++;
            //count reset
            if (weaponCount > weapons.Length - 1)
            {
                weaponCount = 0;
            }

            //Resets all weapons
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }

            //Turn on corresponding weapon and its rig values
            weapons[weaponCount].SetActive(true);
            leftHand.data.target = leftTargets[weaponCount];
            rightHand.data.target = rightTargets[weaponCount];
            rig.Build();
        }
    }
}

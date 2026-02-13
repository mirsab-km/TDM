using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] private TwoBoneIKConstraint leftHand;
    [SerializeField] private TwoBoneIKConstraint rightHand;

    [SerializeField] private RigBuilder rig;

    [SerializeField] private Transform[] leftTargets;
    [SerializeField] private Transform[] rightTargets;
    [SerializeField] private GameObject[] weapons;

    private int weaponCount;
    void Start()
    {
        
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

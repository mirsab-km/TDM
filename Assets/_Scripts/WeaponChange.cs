using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations.Rigging;
using Cinemachine;
using Photon.Pun;
using TMPro;

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

    private int weaponCount;
    private GameObject testForWeapons;
    private Image weaponIcon;
    private TextMeshProUGUI ammoAmtText;
    public Sprite[] weaponIcons;
    public int[] ammoAmts;
    void Start()
    {
        camObject = GameObject.Find("PlayerCamera");
        weaponIcon = GameObject.Find("WeaponUI").GetComponent<Image>();
        ammoAmtText = GameObject.Find("AmmoAmt").GetComponent<TextMeshProUGUI>();
        if (this.gameObject.GetComponent<PhotonView>().IsMine)
        {
            cam = camObject.GetComponent<CinemachineVirtualCamera>();
            cam.Follow = this.gameObject.transform;
            cam.LookAt = this.gameObject.transform;
        }
        else
        {
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;
        }

        testForWeapons = GameObject.Find("Weapon1Pickup(Clone)");
        if (testForWeapons == null)
        {
            var spawner = GameObject.Find("Spawner");
            spawner.GetComponent<SpawnPlayers>().WeaponSpawnStart();
        }
    }

    void Update()
    {
        if (!GetComponent<PhotonView>().IsMine) return;

        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<PhotonView>().RPC("Change", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void Change()
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

        weaponIcon.GetComponent<Image>().sprite = weaponIcons[weaponCount];
        ammoAmtText.text = ammoAmts[weaponCount].ToString();

        leftHand.data.target = leftTargets[weaponCount];
        rightHand.data.target = rightTargets[weaponCount];
        rig.Build();
    }
}

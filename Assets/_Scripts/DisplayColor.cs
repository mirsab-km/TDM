using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class DisplayColor : MonoBehaviour
{
    public int[] buttonNumbers;
    public int[] viewID;
    public Color32[] colors;
    private GameObject nameObject;

    private void Start()
    {
        if (nameObject == null)
        {
            nameObject = GameObject.Find("NameBG");
        }

    }
    public void ChooseColor()
    {
        GetComponent<PhotonView>().RPC("AssignColor",
        RpcTarget.AllBuffered);
    }
    [PunRPC]

    private void AssignColor()
    {
        for (int i = 0; i < viewID.Length; i++)
        {
            if (this.GetComponent<PhotonView>().ViewID == viewID[i])
            {
                this.transform.GetChild(2).GetComponent<Renderer>
                ().material.color = colors[i];
                nameObject.GetComponent<NickNames>().names[i].gameObject.SetActive(true);
                nameObject.GetComponent<NickNames>().healthBars[i].gameObject.SetActive(true);
                nameObject.GetComponent<NickNames>().names[i].text = GetComponent<PhotonView>().Owner.NickName;
            }
        }
    }
}
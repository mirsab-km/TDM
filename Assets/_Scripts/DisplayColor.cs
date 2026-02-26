using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class DisplayColor : MonoBehaviour
{
    public int[] buttonNumbers;
    public int[] viewID;
    public Color32[] colors;
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
            }
        }
    }
}
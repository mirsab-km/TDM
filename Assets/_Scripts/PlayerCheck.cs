using UnityEngine;
using Photon.Pun;
using TMPro;
public class PlayerCheck : MonoBehaviour
{
    [SerializeField] private int maxPlayersInRoom = 2;
    [SerializeField] private TextMeshProUGUI currentPlayers;
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayersInRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            gameObject.SetActive(false);
        }
        currentPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / " + maxPlayersInRoom + " Joined";
    }
}

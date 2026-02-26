using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;
public class LobbyScript : MonoBehaviourPunCallbacks
{
    private TypedLobby killCount = new TypedLobby("killCount", LobbyType.Default);
    private TypedLobby teamBattle = new TypedLobby("teamBattle", LobbyType.Default);
    private TypedLobby noRespawn = new TypedLobby("noRespawn", LobbyType.Default);

    [SerializeField] private TextMeshProUGUI roomName;
    private string levelName;
    public void ReturnButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void JoinKillCount()
    {
        levelName = "GamePlay";
        PhotonNetwork.JoinLobby(killCount);
    }

    public void JoinTeamBattle()
    {
        levelName = "GamePlay";
        PhotonNetwork.JoinLobby(teamBattle);
    }

    public void JoinNoRespawn()
    {
        levelName = "GamePlay";
        PhotonNetwork.JoinLobby(noRespawn);
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Joined random room failed. Creating a new room");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom("Arena" + Random.Range(1, 1000), roomOptions);
    }

    public override void OnJoinedRoom()
    {
        roomName.text = PhotonNetwork.CurrentRoom.Name;

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(levelName);
        }
    }
}

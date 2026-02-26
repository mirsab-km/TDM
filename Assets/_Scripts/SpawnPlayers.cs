

using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public Transform[] spawnPoints;

    public GameObject[] weapons;
    public Transform[] weaponSpawnPoints;

    private void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            SpawnLocalPlayer();
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom called from SpawnPlayers script");
        SpawnLocalPlayer();
    }

    private void SpawnLocalPlayer()
    {
        Transform spawn = spawnPoints[PhotonNetwork.CurrentRoom.PlayerCount - 1];
        PhotonNetwork.Instantiate(player.name, spawn.position, spawn.rotation);
    }


    public void WeaponSpawnStart()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            PhotonNetwork.Instantiate(weapons[i].name, weaponSpawnPoints[i].position, Quaternion.Euler(0, 90, 0));
        }
    }
}

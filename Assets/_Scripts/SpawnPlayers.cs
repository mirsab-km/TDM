using UnityEngine;
using Photon.Pun;

// Use MonoBehaviourPunCallbacks so we can listen for the Join event
public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public Transform[] spawnPoints;

    public GameObject[] weapons;
    public Transform[] weaponSpawnPoints;
    private float weaponRespawnTime = 10f;

    void Start()
    {
        // If we are already fully in the room, spawn immediately
        if (PhotonNetwork.InRoom)
        {
            SpawnPlayer();
        }
        // If the scene loaded but we aren't "InRoom" yet, 
        // the OnJoinedRoom() override below will catch it.
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom called from SpawnPlayers script");
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        // Safety check: Don't spawn twice
        if (PhotonView.Get(this) != null)
        {
            // Check if I already have a player object in the scene to prevent duplicates
        }

        int index = (PhotonNetwork.LocalPlayer.ActorNumber - 1) % spawnPoints.Length;
        Transform spawn = spawnPoints[index];

        PhotonNetwork.Instantiate(player.name, spawn.position, spawn.rotation);
    }

    public void WeaponSpawnStart()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            PhotonNetwork.Instantiate(weapons[i].name, weaponSpawnPoints[i].position, Quaternion.Euler(0, 90,0));
        }
    }
}

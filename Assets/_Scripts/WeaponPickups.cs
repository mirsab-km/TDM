using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class WeaponPickups : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private float respawnTime = 5f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           GetComponent<PhotonView>().RPC("PickUpSound", RpcTarget.All);
           GetComponent<PhotonView>().RPC("TurnOff", RpcTarget.All);
        }
    }

    [PunRPC]
    private void PickUpSound()
    {
        audioSource.Play();
    }

    [PunRPC]
    private void TurnOff()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(WaitToRespawn());
    }

    [PunRPC]
    private void TurnOn()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private IEnumerator WaitToRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        GetComponent<PhotonView>().RPC("TurnOn", RpcTarget.All);
    }
}

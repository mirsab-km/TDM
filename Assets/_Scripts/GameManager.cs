using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField playerInput;
    [SerializeField] private TextMeshProUGUI ConnectingText;
    private string playerName = "";
    void Start()
    {
        ConnectingText.gameObject.SetActive(false);
    }

    public void SetName()
    {
        playerName = playerInput.text;
        PhotonNetwork.LocalPlayer.NickName = playerName;
    }

    public void EnterButton()
    {
        if (playerName != "")
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
            ConnectingText.gameObject.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Debug.Log("Exited the game");
        Application.Quit();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Succesfully Connected to the server");
        SceneManager.LoadScene("Lobby");
    }
}

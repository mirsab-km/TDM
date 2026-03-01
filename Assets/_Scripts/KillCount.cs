using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public List<Kills> highestKills = new List<Kills>();
    public TextMeshProUGUI[] names;
    public TextMeshProUGUI[] killAmts;
    private GameObject killCountPanel;
    private GameObject namesObject;
    private bool killCountOn;
    void Start()
    {
        killCountPanel = GameObject.Find("KillCountPanel");
        namesObject = GameObject.Find("NameBG");
        killCountPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            killCountOn = !killCountOn; //Toggle
            killCountPanel.SetActive(killCountOn);

            if (killCountOn)
            {
                UpdateLeaderboard();
            }
        }
    }

    private void UpdateLeaderboard()
    {
        highestKills.Clear();

        for (int i = 0; i < names.Length; i++)
        {
            highestKills.Add(new Kills(
                namesObject.GetComponent<NickNames>().names[i].text,
                Random.Range(1, 40)
            ));
        }

        highestKills.Sort();

        for (int i = 0; i < names.Length; i++)
        {
            names[i].text = highestKills[i].playerName;
            killAmts[i].text = highestKills[i].playerKills.ToString();

            if (names[i].text == "Name")
            {
                names[i].text = string.Empty;
                killAmts[i].text = string.Empty;
            }
        }
    }
}

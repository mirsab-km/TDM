using Photon.Pun;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviourPun
{
    [SerializeField] private int startingTime = 30;
    private float timer;
    private bool timeStarted;

    public TextMeshProUGUI timerText;

    void Start()
    {
        timer = startingTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timeStarted && timer > 0f)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay();

            if (timer <= 0f)
            {
                timer = 0f;
                timeStarted = false;
                TimerEnded();
            }
        }
    }

    public void BeginTimer()
    {
        // Call RPC so all clients start their local countdown
        photonView.RPC("StartCountdown", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void StartCountdown()
    {
        timer = startingTime; // reset timer for everyone
        timeStarted = true;
    }

    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            // Clamp to zero so it never goes negative
            float displayTime = Mathf.Max(timer, 0f);

            int minutes = Mathf.FloorToInt(displayTime / 60);
            int seconds = Mathf.FloorToInt(displayTime % 60);

            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    private void TimerEnded()
    {
        Debug.Log("Timer finished!");
    }
}
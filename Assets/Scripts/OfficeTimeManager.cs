using TMPro;
using UnityEngine;

public class OfficeTimeManager : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    [Header("Work Day")]
    public int startHour = 9;
    public int endHour = 17;

    [Header("Clock Speed")]
    public float secondsPerGameMinute = 1f;

    private int currentHour;
    private int currentMinute;

    private float timer;

    private void Start()
    {
        currentHour = startHour;
        currentMinute = 0;

        UpdateClock();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= secondsPerGameMinute)
        {
            timer = 0f;

            currentMinute++;

            if (currentMinute >= 60)
            {
                currentMinute = 0;
                currentHour++;
            }

            UpdateClock();

            if (currentHour >= endHour)
            {
                EndWorkDay();
            }
        }
    }

    private void UpdateClock()
    {
        string amPm = currentHour >= 12 ? "PM" : "AM";

        int displayHour = currentHour;

        if (displayHour > 12)
            displayHour -= 12;

        clockText.text =
            displayHour.ToString("00") + ":" +
            currentMinute.ToString("00") +
            " " + amPm;
    }

    private void EndWorkDay()
    {
        Debug.Log("Work Day Complete!");

        Time.timeScale = 0f;

        // Open Victory Screen here
    }
}
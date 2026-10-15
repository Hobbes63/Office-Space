using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    public string requiredText = "hello world";
    public int rewardMoney = 50;

    private bool taskActive = false;
    public int playerMoney = 0;

    public GameObject taskPanel;

    public PlayerController playerController;

    public TextMeshProUGUI moneyText;

   public TextMeshProUGUI feedbackText;

private void Start()
{
    if (taskPanel != null)
    {
        taskPanel.SetActive(false);
    }

    UpdateMoneyUI();
}


    private void Awake()
    {
        Instance = this;
    }

public void StartTask()
{
    taskActive = true;

    if (feedbackText != null)
    {
        feedbackText.text = "";
    }

    if (taskPanel != null)
    {
        taskPanel.SetActive(true);
    }

    Time.timeScale = 0f;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    Debug.Log("TASK STARTED");
}


public void SubmitTask(string playerInput)
{
    if (!taskActive)
        return;

    if (playerInput.ToLower() == requiredText.ToLower())
    {
        taskActive = false;

        playerMoney += rewardMoney;

        UpdateMoneyUI();

        taskPanel.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("TASK COMPLETED!");
    }
    else
    {
        feedbackText.text = "Incorrect! Try again.";
        Debug.Log("Incorrect answer submitted.");
    }

}

private void UpdateMoneyUI()
{
    if (moneyText != null)
    {
        moneyText.text = "Money: $" + playerMoney;
    }
}
}
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

    if (playerController != null)
    {
        playerController.canMove = false;
    }

    if (taskPanel != null)
    {
        taskPanel.SetActive(true);
    }

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

        if (taskPanel != null)
        {
            taskPanel.SetActive(false);
        }

        if (playerController != null)
        {
            playerController.canMove = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("TASK COMPLETED!");
        Debug.Log("Money: $" + playerMoney);
    }
    else
    {
        Debug.Log("Incorrect text!");
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
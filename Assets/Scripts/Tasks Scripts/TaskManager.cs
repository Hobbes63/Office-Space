
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    [Header("Task Settings")]
    public string requiredText = "hello world";
    public int rewardMoney = 50;

    private bool taskActive = false;
    private int lastCompletedHour = -1;

    [Header("Player Money")]
    public int playerMoney = 0;
    public TextMeshProUGUI moneyText;

    [Header("Task UI")]
    public GameObject taskPanel;
    public TMP_InputField taskInputField;
    public TextMeshProUGUI feedbackText;

    [Header("References")]
    public PlayerController playerController;
    public OfficeTimeManager officeTimeManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if (taskPanel != null)
            taskPanel.SetActive(false);

        UpdateMoneyUI();
    }

    public bool IsTaskActive()
    {
        return taskActive;
    }

    public void StartTask()
    {
        if (taskActive)
            return;

        if (officeTimeManager == null)
        {
            Debug.LogError("OfficeTimeManager reference missing!");
            return;
        }

        int currentHour = officeTimeManager.GetCurrentHour();

        if (lastCompletedHour == currentHour)
        {
            if (feedbackText != null)
                feedbackText.text = "Come back next hour for more work!";

            return;
        }

        taskActive = true;

        if (feedbackText != null)
            feedbackText.text = "";

        if (taskInputField != null)
            taskInputField.text = "";

        if (taskPanel != null)
            taskPanel.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("TASK STARTED");
    }

    public void SubmitTask(string playerInput)
    {
        if (!taskActive)
            return;

        if (playerInput.Trim().ToLower() ==
            requiredText.Trim().ToLower())
        {
            CompleteTask();
        }
        else
        {
            if (feedbackText != null)
                feedbackText.text = "Incorrect! Try again.";

            Debug.Log("Incorrect answer submitted.");
        }
    }

    private void CompleteTask()
    {
        taskActive = false;

        playerMoney += rewardMoney;

        lastCompletedHour =
            officeTimeManager.GetCurrentHour();

        UpdateMoneyUI();

        if (taskInputField != null)
            taskInputField.text = "";

        if (taskPanel != null)
            taskPanel.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("TASK COMPLETED! Money earned: $" + rewardMoney);
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "Money: $" + playerMoney;
        }
    }
}

using TMPro;
using UnityEngine;

public class TaskInputUI : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject taskPanel;

    public void SubmitAnswer()
    {
        TaskManager.Instance.SubmitTask(inputField.text);

        inputField.text = "";

        taskPanel.SetActive(false);
    }
}
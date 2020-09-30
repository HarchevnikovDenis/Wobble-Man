using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStateController : MonoBehaviour
{
    [SerializeField] private GameObject completePanel;
    [SerializeField] private GameObject lostPanel;
    [SerializeField] private bool isLastFloor;

    private bool isLevelCompleted;
    public static bool isTheGameLost{ get; set;}

    public void ShowCompletePanel()
    {
        isLevelCompleted = true;
        completePanel.SetActive(true);
    }

    public void ShowLostPanel()
    {
        if(!isLevelCompleted)
        {
            lostPanel.SetActive(true);
        }
    }

    public void RestartFloor()
    {
        LevelStateController.isTheGameLost = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextFloor()
    {
        if(!isLastFloor)
        {
            PlayerPrefs.SetInt("Floor", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
             PlayerPrefs.SetInt("Floor", 1);
             SceneManager.LoadScene(1);
        }
    }
}

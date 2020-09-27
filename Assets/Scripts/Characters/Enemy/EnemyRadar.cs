using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRadar : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Transform warningLogo;
    [SerializeField] private LevelStateController stateController;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerLost();
        }
    }

    private void PlayerLost()
    {
        stateController.isTheGameLost = true;
        warningLogo.LookAt(Camera.main.transform);
        enemyAnimator.SetTrigger("Gotcha");

        Invoke("RestartFloor", 2.0f);
    }

    private void RestartFloor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

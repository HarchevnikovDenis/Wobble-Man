using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    [SerializeField] private LevelStateController stateController;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Transform warningLogo;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerLost();
        }
    }

    private void PlayerLost()
    {
        LevelStateController.isTheGameLost = true;
        warningLogo.LookAt(Camera.main.transform);
        enemyAnimator.SetTrigger("Gotcha");

        Invoke("ShowGameOverPanel", 2.0f);
    }

    private void ShowGameOverPanel()
    {
        stateController.ShowLostPanel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    [SerializeField] private Transform enemyBase;
    [SerializeField] private LevelStateController stateController;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Transform warningLogo;

    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag(playerTag))
        {
            if(IsThePlayerSeen(other.gameObject.transform))
            {
                PlayerLost();
            }
        }
    }

    private bool IsThePlayerSeen(Transform player)
    {
        RaycastHit hit;
        Vector3 direction = player.position - enemyBase.position;

        if(Physics.Raycast(enemyBase.position, direction, out hit))
        {
            if(hit.collider.gameObject.CompareTag(playerTag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
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

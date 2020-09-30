using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : GeneralMovement
{
    [SerializeField] private List<Transform> sequencePoints;
    [SerializeField] private bool isStatic;
    private int currentPointIndex;
    private Transform currentPoint
    {
        get
        {
            return sequencePoints[currentPointIndex];
        }
    }

    private void Start()
    {
        if(!isStatic)
            SetNewDirectionVector(true);
    }

    private void Update()
    {
        if(LevelStateController.isTheGameLost || isStatic) return;

        if(Vector3.Distance(transform.position, currentPoint.position) > 0.2f)
        {
            Move();
        }
        else
        {
            SetNewDirectionVector();
        }
    }

    public override void Move()
    {
         transform.position += movementDirection * movementSpeed * Time.deltaTime;

         LookToMovementDirection(transform);
    }

    private void SetNewDirectionVector(bool isFirstInit = false)
    {
        if(!isFirstInit)
        {
            currentPointIndex++;
            if(currentPointIndex >= sequencePoints.Count) currentPointIndex = 0;
        }

        movementDirection = currentPoint.position - transform.position;
        movementDirection = Vector3.ClampMagnitude(movementDirection, 1.0f);
    }
}

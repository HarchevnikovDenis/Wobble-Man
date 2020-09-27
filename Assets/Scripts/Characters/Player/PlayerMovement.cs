using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : GeneralMovement, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform playerTransform;
    private bool isMoving;

    private void Update()
    {
        if(isMoving)
        {
            Move();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        isMoving = true;
        if(eventData.delta.magnitude <= 10.0f && isMoving) return;

        movementDirection = new Vector3(eventData.delta.x, 0.0f, eventData.delta.y);
        movementDirection = Vector3.ClampMagnitude(movementDirection, 1.0f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isMoving = false;
    }

    public override void Move()
    {
        playerTransform.position += movementDirection * movementSpeed * Time.deltaTime;
        
        if(movementDirection != Vector3.zero)
        {
            LookToMovementDirection(playerTransform);
        }
    }
}
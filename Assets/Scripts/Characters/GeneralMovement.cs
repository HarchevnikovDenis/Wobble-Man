using UnityEngine;

public abstract class GeneralMovement : MonoBehaviour
{
    [SerializeField] protected LevelStateController stateController;
    [SerializeField] protected float movementSpeed;
    protected Vector3 movementDirection;

    public abstract void Move();

    protected void LookToMovementDirection(Transform objectTransform)
    {
        Quaternion LookRotation = Quaternion.LookRotation(movementDirection);
        objectTransform.rotation = Quaternion.Lerp(objectTransform.rotation, LookRotation, movementSpeed * Time.deltaTime);
    }
}

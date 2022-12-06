using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float RotationSpeed = 0.1f;
    private InputHandler Input;

    private void Awake()
    {
        Input = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        var targetVector = new Vector3(Input.InputVector.x, 0, Input.InputVector.y);

        var movementVector = MoveTowardTarget(targetVector);
        RotateTowardMovementVector(movementVector);

    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0)
            return;
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
            var speed = MoveSpeed  * Time.deltaTime;
            var targetPosition = transform.position + targetVector * speed;
            transform.position = targetPosition;
        return targetVector;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private  InputHandler _input;

  public float moveSpeed;

   private void Awake(){
       _input = GetComponent<InputHandler>();
   }

    // Update is called once per frame
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        MoveTowardTarget(targetVector);
    }

    private void MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;
        transform.Translate(targetVector * moveSpeed);
    }
}

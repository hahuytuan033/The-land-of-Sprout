using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed;
    public Animator animator;
    //get input from player
    
    private void Update()
    {
        float horizontal= Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");

        Vector3 direction= new Vector3(horizontal, vertical);

        AnimateMovement(direction);

        transform.position+= direction* speed* Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator!= null)
        {
            if(direction.magnitude> 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("moveX", direction.x);
                animator.SetFloat("moveY", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}

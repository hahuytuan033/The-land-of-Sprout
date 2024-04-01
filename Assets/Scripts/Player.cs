using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed;
    //get input from player
    
    private void Update()
    {
        float horizontal= Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");

        Vector3 direction= new Vector3(horizontal, vertical);

        transform.position+= direction* speed* Time.deltaTime;
    }
}
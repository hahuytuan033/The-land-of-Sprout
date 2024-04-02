using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    private Vector3 offest= new Vector3(0f, 0f, -10f);
    private float smoothTime= 0.25f;
    private Vector3 velocity= Vector3.zero;

    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition= player.position+ offest;
        transform.position= Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

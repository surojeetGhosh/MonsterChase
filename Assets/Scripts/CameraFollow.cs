using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // following player with camera
    private Transform player;
    private Vector3 tempPosition;

    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        minX = -60;
        maxX = 60;
    }

    // Works when update is finished
    void LateUpdate()
    {
        // taking care of null pointer exception after destroying player
        if(!player) return;

        tempPosition = transform.position;
        tempPosition.x = player.position.x;
        if(tempPosition.x < minX) tempPosition.x =  minX;
        if(tempPosition.x > maxX) tempPosition.x = maxX;
        transform.position = tempPosition;
    }
}

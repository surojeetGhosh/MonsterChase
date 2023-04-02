using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// change the rigibody type of ghost to kinematic which does'nt apply gravity on it, so we can make it floaty
public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public Rigidbody2D body;
    // Start is called before the first frame update
    // freeze z rotation
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = new Vector2(speed, body.velocity.y);
    }
}

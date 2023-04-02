using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// destroy player and enemy for going out of bound
public class Collider : MonoBehaviour
{
    private string ENEMY_TAG = "Enemy";
    private string PLAYER_TAG = "Player";
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(ENEMY_TAG) || other.CompareTag(PLAYER_TAG))
            Destroy(other.gameObject);
    }
}

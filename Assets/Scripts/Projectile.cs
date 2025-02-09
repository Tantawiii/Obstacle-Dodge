using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 playerPosition;
    [SerializeField] float moveBy = 15f;

    void Start() {
        playerPosition = player.transform.position;
    }


    void Update()
    {
        FlyingToPlayer();
        DestroyWhenHit();
    }

    private void FlyingToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveBy * Time.deltaTime);
    }
    void DestroyWhenHit()
    {
        if(transform.position == playerPosition){
            Destroy(gameObject);
        }
    }
}

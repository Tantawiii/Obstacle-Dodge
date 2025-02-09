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
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveBy * Time.deltaTime);
    }
}

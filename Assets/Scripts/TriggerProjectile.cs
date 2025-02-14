using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    [SerializeField] GameObject[] projectile;
    // private void Start() {
    //     foreach (GameObject i in projectile){
    //         i?.SetActive(false);
    //     }
    // }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            foreach (GameObject i in projectile){
                i?.SetActive(true);
            }
        }
    }
}

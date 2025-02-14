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
                if (i == null)
                    continue;
                i?.SetActive(true); //weirdly works for some prefabs and some do not!
            }
        }
    }
}

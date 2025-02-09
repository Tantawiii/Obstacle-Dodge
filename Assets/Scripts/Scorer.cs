using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hitScore = 0;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Hit"){return;}
        hitScore++;
    }
    public int GetHitScore(){
        return hitScore;
    }
}

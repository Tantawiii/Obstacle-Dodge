using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scorerUI;
    Scorer scorer;

    [System.Obsolete]
    void Start() {
        scorer = FindObjectOfType<Scorer>();
        if (scorerUI == null)
            Debug.LogError("Scorer UI is not assigned in the Inspector!");
        if (scorer == null)
            Debug.LogError("Scorer script not found in the scene!");
    }

    void Update() {
        if (scorerUI != null && scorer != null) {
            scorerUI.text = "Score: " + scorer.GetHitScore().ToString();
        }
    }
}
using Unity.Cinemachine;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] GameObject ourPlayer;
    Command move;
    CinemachineCamera cinemachineCam;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        move = new MoveForward();
        anim = ourPlayer.GetComponent<Animator>();
        cinemachineCam = FindObjectOfType<CinemachineCamera>();
        if (cinemachineCam != null && ourPlayer != null)
        {
            cinemachineCam.Target.TrackingTarget = ourPlayer.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
            move.Execute(anim);
        }
    }
}

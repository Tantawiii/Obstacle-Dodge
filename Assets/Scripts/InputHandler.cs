using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] GameObject ourPlayer;
    Command move, back, right, left;
    CinemachineCamera cinemachineCam;
    Animator anim;
    List<Command> oldCommands = new List<Command>();
    Coroutine replayCoroutine;
    bool shouldStartReplay, isReplaying;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        move = new MoveForward();
        back = new MoveBackward();
        right = new MoveRightward();
        left = new MoveLeftward();
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
        if(!isReplaying){
            HandleInput();
        }
        StartReplay();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            move.Execute(anim, true);
            oldCommands.Add(move);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            back.Execute(anim, true);
            oldCommands.Add(move);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            right.Execute(anim, true);
            oldCommands.Add(move);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            left.Execute(anim, true);
            oldCommands.Add(move);
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            shouldStartReplay = true;
        }
        if (Input.GetKeyDown(KeyCode.Z)){
            UndoLastCommand();
        }
    }

    void UndoLastCommand(){
        if(oldCommands.Count > 0){
            Command c = oldCommands[oldCommands.Count - 1];
            c.Execute(anim, false);
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }

    void StartReplay(){
        if(shouldStartReplay && oldCommands.Count > 0){
            shouldStartReplay = false;
            if(replayCoroutine != null){
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    IEnumerator ReplayCommands(){
        isReplaying = true;
        for (int i = 0; i < oldCommands.Count; i++){
            oldCommands[i].Execute(anim, true);
            yield return new WaitForSeconds(1.0f);
        }
        isReplaying = false;
    }
}

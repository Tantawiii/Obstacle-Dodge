using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator anim, bool correct);
}

public class MoveForward : Command
{
    public override void Execute(Animator anim, bool correct)
    {
        if(correct){
            anim.SetTrigger("Walking");
        }
        else
        {
            anim.SetTrigger("Backing");
        }
    }
}

public class MoveBackward : Command
{
    public override void Execute(Animator anim, bool correct)
    {
        if(correct){
            anim.SetTrigger("Backing"); 
        }
        else
        {
            anim.SetTrigger("Walking");
        }
    }
}

public class MoveRightward : Command
{
    public override void Execute(Animator anim, bool correct)
    {
        if(correct){
            anim.SetTrigger("GoingRight");
        }
        else{
            anim.SetTrigger("GoingLeft");
        }
    }
}

public class MoveLeftward : Command
{
    public override void Execute(Animator anim, bool correct)
    {
        if(correct){
            anim.SetTrigger("GoingLeft");
        }
        else{
            anim.SetTrigger("GoingRight");
        }
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator anim, bool correct)
    {
    }
}

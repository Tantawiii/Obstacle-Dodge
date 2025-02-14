using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator anim);
}

public class MoveForward : Command
{
    public override void Execute(Animator anim)
    {
        anim.SetTrigger("Walking");
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator anim)
    {

    }
}

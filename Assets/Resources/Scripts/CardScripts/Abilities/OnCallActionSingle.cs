using UnityEngine;
using System.Collections;

//"When you put this creature in the battle zone, you may [simple action]" ability
//action invoked on enter, dismissed on backspace
public class OnCallActionSingle : OnCallAbility
{
    private System.Action simpleAction { get; set; }
    private int actionCount { get; set; }
    private System.Func<bool> conditionFunction { get; set; }

    public OnCallActionSingle(System.Action action)
    {
        simpleAction = action;
        actionCount = 1;
        conditionFunction = null;
    }

    public OnCallActionSingle(System.Action action, int count)
    {
        simpleAction = action;
        actionCount = count;
        conditionFunction = null;
    }

    public OnCallActionSingle(System.Action action, int count, System.Func<bool> condition)
    {
        simpleAction = action;
        actionCount = count;
        conditionFunction = condition;
    }

    public override IEnumerator OnCallCoroutine(PlayerScript currentPlayer, PlayerScript otherPlayer, InputController inputController)
    {
        int count = actionCount;
        if (conditionFunction != null ? conditionFunction.Invoke() : true)
        {
            while (count > 0)
            {
                if (inputController.isEnterPressed)
                {
                    simpleAction.Invoke();
                    count -= 1;
                }
                if (inputController.isBackspacePressed)
                {
                    count -= 1;
                }
                yield return null;
            }
        }
        QueueControl.SignalCoroutineEnd();
    }

}

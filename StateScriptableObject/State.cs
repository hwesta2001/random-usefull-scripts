using UnityEngine;

[CreateAssetMenu(menuName = "MyState/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;
    public Color color = Color.gray;
    public int forward = 1;
    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        ChackTransitions(controller);
    }

    void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    void ChackTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucced = transitions[i].decision.Decide(controller);
            if (decisionSucced)
            {
                controller.TransitiontoState(transitions[i].trueState);
                DoActionsStart(controller);
                return;
            }
            else
            {
                controller.TransitiontoState(transitions[i].falseState);
            }
        }
    }

    void DoActionsStart(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].ActStart(controller);
        }
    }
}

using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract void Act(StateController controller);
    public abstract void ActStart(StateController controller);
}

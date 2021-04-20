using UnityEngine;

[CreateAssetMenu(menuName = "MyState/Actions/Act1")]
public class Act1 : Action
{
    public override void Act(StateController controller) 
	{ 
		// buraya update olacak
	}

    public override void ActStart(StateController controller)
    {
       // action startta calışacak
    }

}

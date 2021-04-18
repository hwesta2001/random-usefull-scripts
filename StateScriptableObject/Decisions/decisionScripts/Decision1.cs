using UnityEngine;

[CreateAssetMenu(menuName = "MyState/Decision/Decision1")]
public class Decision1 : Decision
{
    public override bool Decide(StateController controller)
    {
        return DecisionControl(controller);
    }

    bool DecisionControl(StateController controller)
    {
		bool someBool = true; // StateController da vs bir bool true olunca mesela
        if (someBool)
        {
            return true;
        }
        return false;
    }
}

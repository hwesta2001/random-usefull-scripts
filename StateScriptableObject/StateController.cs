using UnityEngine;

public class StateController : MonoBehaviour
{
    public State currentState;
    public float speed;
    public float range;
    public Renderer rend;
    public State remainState;

    void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitiontoState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}

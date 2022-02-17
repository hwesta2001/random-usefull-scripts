using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BasicFpsMovement : MonoBehaviour
{
    [SerializeField] bool turnWithRightClick;
    [SerializeField] Transform cam;
    [SerializeField] float speed = 7;
    [SerializeField] float camVerticalSpeed = 150;
    [SerializeField] float camHorizontalSpeed = 200;
   
    Vector3 vert;
    CharacterController controller;
    bool canTurn = false;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        if (cam == null) cam = Camera.main.transform;
    }

    void Start()
    {
        vert = Vector3.zero;
        if (cam == null) return;
        cam.parent = transform;
        //cam.localPosition = new Vector3(0, 2, 0);
        cam.localEulerAngles = new Vector3(0,0,0);
    }


    Vector3 MoveThis()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        return transform.forward * vertical + transform.right * horizontal;
    }


    Vector3 VerticalTurn()
    {
        float verDelta = Input.GetAxis("Mouse Y");
        verDelta *= (camVerticalSpeed * Time.deltaTime);
        float invertY = -1;
        verDelta *= invertY;
        return new Vector3(verDelta, 0, 0);
    }

    Vector3 HorizontalTurn()
    {
        float horDelta = Input.GetAxis("Mouse X");
        horDelta *= (camHorizontalSpeed * Time.deltaTime);
        return new Vector3(0, horDelta, 0);
    }

    void Update()
    {
        controller.Move(MoveThis());
        TurnControl();
        if (!canTurn) return;
        transform.localEulerAngles += HorizontalTurn();
        vert += VerticalTurn();
        //float x = vert.x;
        float x = Mathf.Clamp(vert.x, -80, 80);
        vert.x = x;
        cam.localEulerAngles = vert;
    }



    void TurnControl()
    {
        if (turnWithRightClick)
        {
            if (Input.GetMouseButton(1))
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
                canTurn = true;
            }
            else
            {

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                canTurn = false;
            }
        }
        else
        {
            if (Input.GetMouseButton(1))
            {

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                canTurn = false;
            }
            else
            {

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                canTurn = true;
            }
        }
    }

}

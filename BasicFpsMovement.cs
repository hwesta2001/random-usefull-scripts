using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BasicFpsMovement : MonoBehaviour
{
    [SerializeField] bool turnWithRightClick = true;
    [SerializeField] Transform cam;
    [SerializeField] float speed = 8;
    [SerializeField] float camVerticalSpeed = 300;
    [SerializeField] float camHorizontalSpeed = 300;

    CharacterController controller;
    bool tik = false;
    bool canTurn = false;
    void Awake()
    {
        controller = GetComponent<CharacterController>();

        if (cam == null) cam = Camera.main.transform;

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
        return new Vector3(verDelta * invertY, 0, 0);
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
        cam.localEulerAngles += VerticalTurn();
    }



    void TurnControl()
    {
        if (turnWithRightClick)
        {
            if (Input.GetMouseButton(1))
            {
                Cursor.lockState = CursorLockMode.Confined;
                canTurn = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                canTurn = false;
            }
        }
        else
        {
            if (tik) return;
            tik = true;
            Cursor.lockState = CursorLockMode.Confined;
            canTurn = true;
        }
    }





}

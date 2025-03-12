using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonController : MonoBehaviour
{
    public float speed = 5f;
    public float SmoothTime = 0.1f;
    public float RotationVelocity;
    public Transform Camera;
    private Rigidbody RB;
    private float VelocityY;
    public float FallFactor = 1.2f;
    public CinemachineFreeLook FL;
    /*public float TopR = 10;
    public float MiddleR = 5;
    public float BottomR = -5;*/
    public float Rig;
    public Vector3 FMovement = Vector3.zero;


    //transform.localScale.y / 2
    bool IsGrounded()
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), -Vector3.up, Color.green, 10f, false);
        return Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), -Vector3.up, transform.localScale.y / 2f);
    }
    void Start()
    {
        RB = transform.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!gameObject.GetComponent<PlayerController>().ControlState.Equals("ThirdPerson"))
        {
            return;
        }
        if (FMovement.magnitude > 0)
        {
            RB.AddForce(FMovement);
            return;
        }

        if (Input.mouseScrollDelta.magnitude > 0)
        {
            FL.m_Orbits[0].m_Height = Rig;
            FL.m_Orbits[1].m_Height = Rig;
            FL.m_Orbits[2].m_Height = Rig;
            if (Input.mouseScrollDelta.y > 0)
            {
                Rig += 1;
            }
            else
            {
                Rig -= 1;
            }
            if (Rig >= 20)
            {
                Rig = 20;
            }
            if (Rig <= -10)
            {
                Rig = -10; 
            }
        }
        
        if (IsGrounded())
        {
            VelocityY = 0;
        }
        else
        {
            VelocityY += Physics.gravity.y * Time.deltaTime * FallFactor;
        }
        //print(VelocityY);
        float Vertical = Input.GetAxisRaw("Vertical");
        float Horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 Direction = new Vector3(Horizontal, 0, Vertical).normalized;
        float TargetAngle = Mathf.Atan2(Camera.forward.x, Camera.forward.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
        float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref RotationVelocity, SmoothTime);
        transform.rotation = Camera.rotation;
        if (Direction.magnitude > 0)
        {
            float VelocityX = 0;
            float VelocityZ = 0;
            if (Vertical != 0)
            {
                VelocityX += transform.forward.x * Vertical;
                VelocityZ += transform.forward.z * Vertical;
            }
            if (Horizontal != 0)
            {
                VelocityZ += transform.right.z * Horizontal;
                VelocityX += transform.right.x * Horizontal;
            }
            RB.velocity = new Vector3(VelocityX * speed, RB.velocity.y + VelocityY, VelocityZ * speed);
        }
        else
        {
            RB.velocity = new Vector3(0,RB.velocity.y + VelocityY,0);
        }


    }
}

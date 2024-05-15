using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour

{
    private bool IsTouchingBall;
    void Start()
    {

    }
    Collider Ball;

    void Update()
    {
        int ForcePush = transform.parent.parent.gameObject.GetComponent<PlayerController>().GetForcePush();
        if (Input.GetKeyDown("f") && IsTouchingBall == true && ForcePush > 0)
        {
            Vector3 Force = transform.right * -3000;
            Ball.GetComponent<Rigidbody>().AddForce(Force);
            ForcePush = transform.parent.parent.gameObject.GetComponent<PlayerController>().UseForcePush();
            print(Force);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Ball = other;
            IsTouchingBall = true;
        }
        else
        {
            IsTouchingBall = false;
        }
    }
}

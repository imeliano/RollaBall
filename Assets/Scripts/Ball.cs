using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 BallRespawn;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BallRespawn = transform.position;
    }

    void Update()
    {

    }
    public void Respawn()
    {
        transform.position = BallRespawn;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (other.gameObject.GetComponent<MeshRenderer>().material.name == GetComponent<MeshRenderer>().material.name)
            {
                other.gameObject.SetActive(true);
            }
            else
            {
                Respawn();
            }
        }
    }
}

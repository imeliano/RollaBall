using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTunnel : MonoBehaviour
{
    private Vector3 Top;
    private Vector3 Bottom;
    private Vector3 WindPath;
    public float WTSpeed = 100;

    void Start()
    {
        Top = transform.Find("Top").transform.position;
        Bottom = transform.Find("Bottom").transform.position;
        WindPath = Top - Bottom;
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<ThirdPersonController>().FMovement = WindPath.normalized * WTSpeed;
        }
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(WindPath.normalized * WTSpeed * 10);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<ThirdPersonController>().FMovement = Vector3.zero;
        }
        if (other.gameObject.tag == "Ball")
        {
            
        }
    }
}

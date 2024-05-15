using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMass : MonoBehaviour
{

    public float UpForce; 
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody>().AddForce(0, UpForce, 0);
            print("(:");
        }
    }
}

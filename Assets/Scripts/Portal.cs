using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portal;
    private GameObject player;
    public float forcepower;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            forcepower *= 1 + Time.deltaTime;
            Vector3 Force = (gameObject.transform.position - player.transform.position) * forcepower; 
            player.GetComponent<Rigidbody>().AddForce(Force.normalized, ForceMode.Impulse);
        }
    }
}

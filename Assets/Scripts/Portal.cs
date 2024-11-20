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
        player.GetComponent<Rigidbody>().useGravity = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("yay");
            player = other.gameObject;
            //transform.DOMove(/*homescreen room*/, 5, false)
            //.SetEase(Ease.easeOutBack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            player.GetComponent<Rigidbody>().useGravity = false;
            forcepower += Time.deltaTime;
            forcepower = Mathf.Clamp(forcepower, 5f, 10f);
            Vector3 side = new Vector3 (0, 0, 0);
            Vector3 Force = (gameObject.transform.position - player.transform.position + side) * forcepower;
            player.GetComponent<Rigidbody>().AddForce(Force.normalized * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}

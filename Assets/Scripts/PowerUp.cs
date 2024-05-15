using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
       {
            gameObject.SetActive(false);
            Player.AddForcePush();
       }
    }
}

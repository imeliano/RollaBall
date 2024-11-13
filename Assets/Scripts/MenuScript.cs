using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public Button Print;
    public GameObject Player;

    void Start()
    {
        gameObject.SetActive(true);
        Player.SetActive(false);
    }
    public void OnClick()
    {
        Print.GetComponent<AudioSource>().Play();
        Player.SetActive(true);
        gameObject.SetActive(false);
        print("yay");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

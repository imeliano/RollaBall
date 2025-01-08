using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PortalV2 : MonoBehaviour
{
    public GameObject Ramp1;
    public GameObject Ramp2;
    public GameObject Ramp3;
    public GameObject Ramp4;
    public GameObject Ramp5;

    public GameObject Roof1;
    public GameObject Roof2;

    public GameObject YellowGoal;
    public GameObject CreamGoal;
    public GameObject GreenGoal;
    public GameObject BlueGoal;
    public GameObject PurpleGoal;


    public GameObject PowerUp1;
    public GameObject PowerUp2;
    public GameObject PowerUp3;
    public GameObject PowerUp4;
    public GameObject PowerUp5;
    public GameObject PowerUp6;
    public GameObject PowerUp7;
    public GameObject PowerUp8;
    public GameObject PowerUp9;
    public GameObject PowerUp10;

    public GameObject GreenBall;
    public GameObject PurpleBall;
    public GameObject CreamBall;
    public GameObject BlueBall;
    public GameObject YellowBall;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PortalActivate()
    {
        BlueGoal.transform.DOMove(new Vector3(-229.4f, -148.9f, 106.8f), 4f, false);

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PortalActivate")
        {
            PortalActivate();
        }
    }
}

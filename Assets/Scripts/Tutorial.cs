using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UI;


public class Tutorial : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;
    public GameObject Text7;
    public GameObject Text8;
    public GameObject Text9;
    public GameObject Text10;
    public GameObject Text11;
    private bool PickUpT = false;
    private bool PickUp_T = false;
    private bool FallingT = false;
    private bool Part2 = false;
    private bool DeathBlock = false;
    public MeshCollider Simple;
    public MeshCollider Complex;
    public BoxCollider TFirstPersonCC;
    public int CameraTests; 
    public GameObject Portal; 
    public GameObject Sphere1;
    public GameObject Sphere2;
    public GameObject Sphere3;

    void Start()
    {

    }


    IEnumerator StartPart2()
    {
        yield return new WaitForSeconds(6);
        transform.position = new Vector3(0, 14, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Text4.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text1.SetActive(false);
    }
    IEnumerator StartPart3()
    {
        yield return new WaitForSeconds(4);
        transform.position = new Vector3(0.07f, 27.41f, -21.82f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Text6.SetActive(true);
        Text5.SetActive(false);
        Text4.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text1.SetActive(false);
    }
    IEnumerator StartPart4()
    {
        yield return new WaitForSeconds(3);
        Text7.SetActive(false);
        Text8.SetActive(true);
        yield return new WaitForSeconds(3);
        Text8.SetActive(false);
        Text9.SetActive(true);
        yield return new WaitForSeconds(4);
        Simple.isTrigger = true;
        Complex.isTrigger = true;
    }

    IEnumerator GoBackToCameraSelector()
    {
        yield return new WaitForSeconds(5); //30
        PlayerController PC = GetComponent<PlayerController>();
        PC.SetState("Normal");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Text10.SetActive(false);
        
        if (CameraTests == 1) //5
        {
            TransitionToMenu();
            Text9.SetActive(false);
            /*Portal.SetActive(true);
            Sphere1.SetActive(true);
            Sphere2.SetActive(true);
            Sphere3.SetActive(true);
            GameObject.Find("DeathPlane").SetActive(false);*/
        }
        else
        {
            Text9.SetActive(true);
            transform.position = new Vector3(0.33f, 39.77f, -21.1f);
        }
    }
    private void TransitionToMenu()
    {
        PlayerController PC = GetComponent<PlayerController>();
        PC.SetState("ThirdPerson");
        transform.position = new Vector3(-201.88f, -11.29f, 141.04f);
    }
    void Update()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        if (!Part2 && PickUpT && PickUp_T && FallingT)
        {
            Part2 = true;
            StartCoroutine(StartPart2());
        }
        if (DeathBlock == true)
        {
            DeathBlock = false;
            StartCoroutine(StartPart3());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "-PickUp")
        {
            PickUp_T = true;
            if (PickUpT == true)
            {
                Text2.SetActive(false);
                Text3.SetActive(false);
            }
            else
            {
                Text1.SetActive(false);
                Text2.SetActive(true);
            }
            Text4.SetActive(false);
        }
        if (other.gameObject.tag == "PickUp" && PickUpT == false)
        {
            PickUpT = true;
            if (PickUp_T == true)
            {
                Text2.SetActive(false);
                Text2.SetActive(true);
                Text3.SetActive(true);
            }
            else
            {
                Text2.SetActive(true);
                Text3.SetActive(true);
            }
            Text1.SetActive(false);
            Text4.SetActive(false);
        }
        if (other.gameObject.tag == "TextTrigger")
        {
            FallingT = true;
            Text4.SetActive(true);
            Text2.SetActive(false);
            Text3.SetActive(false);
        }
        if (other.gameObject.tag == "TextTrigger2")
        {
            PickUp_T = false; 
            Text5.SetActive(true);
            other.gameObject.SetActive(false);
            Text4.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
            Text1.SetActive(false);
        }
        if (other.gameObject.tag == "DeathTrigger")
        {
            DeathBlock = true; 
        }
        if (other.gameObject.tag == "GoToPart4")
        {
            transform.position = new Vector3(0f, 38f, -20f);
            Text6.SetActive(false);
            Text7.SetActive(true);
            StartCoroutine(StartPart4());
        }
        if (other.gameObject.name == "CameraChange" || other.gameObject.GetComponent<BoxCollider>() == TFirstPersonCC)
        {
            Text10.SetActive(false);
            print("yay");
        }
        if (other.gameObject.tag == "CameraDownTP")
        {
            transform.position = new Vector3(-78.37f, -9, 124);
            Text9.SetActive(false);
            Text10.SetActive(true);
            CameraTests += 1; 
            StartCoroutine(GoBackToCameraSelector());
        }

        if (other.gameObject.tag == "CameraLeftTP")
        {
            transform.position = new Vector3(-156, -9, 14);
            Text9.SetActive(false);
            Text10.SetActive(true);
            CameraTests += 1; 
            StartCoroutine(GoBackToCameraSelector());
        }

        if (other.gameObject.tag == "CameraFlipTP")
        {
            transform.position = new Vector3(-38, -9, -114);
            Text9.SetActive(false);
            Text10.SetActive(true);
            CameraTests += 1; 
            StartCoroutine(GoBackToCameraSelector());
        }

        if (other.gameObject.tag == "FirstPersonTP")
        {
            transform.position = new Vector3(117, -9, -41);
            Text9.SetActive(false);
            Text10.SetActive(true);
            CameraTests += 1; 
            StartCoroutine(GoBackToCameraSelector());
        }

        if (other.gameObject.tag == "ThirdPersonTP")
        {
            transform.position = new Vector3(66, -9, 102);
            Text9.SetActive(false);
            Text10.SetActive(true);
            CameraTests += 1; 
            StartCoroutine(GoBackToCameraSelector()); 
        }
        //other.gameObject.SetActive(false);
    }
}
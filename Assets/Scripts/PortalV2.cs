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

    public GameObject Portal;
    public GameObject EerieLight;
    public GameObject PortalPS;
    public GameObject Miniture;

    public GameObject MainGameTP;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.SetTweensCapacity(3125, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PortalActivate")
        {
            StartCoroutine(PortalActivate());
            other.gameObject.SetActive(false);
            print("yay");
        }
    }
    IEnumerator PortalActivate()
    {
        BlueGoal.transform.DOLocalMove(new Vector3(-229.4f, -148.9f, 106.8f), 0.5f, false);
        yield return new WaitForSeconds(0.2f);

        Ramp5.transform.DOLocalMove(new Vector3(259.5f, 22.5f, -348.9f), 0.5f, false);
        yield return new WaitForSeconds(0.2f);

        Ramp1.transform.DOLocalMove(new Vector3(-270.3f, 213.9f, 40.3f), 0.5f, false);
        yield return new WaitForSeconds(0.2f);
        
        //EerieLight.DOIntensity(Color to, float duration);
        
        

        Roof2.transform.DOLocalMove(new Vector3(87f, -126.3f, 0.6f), 0.5f, false);
        yield return new WaitForSeconds(0.2f);

        Ramp2.transform.DOLocalMove(new Vector3(238.4f, 68.4f, -258.6f), 0.5f, false);
        yield return new WaitForSeconds(0.2f);

        CreamBall.transform.DOLocalMove(new Vector3(186.6f, 58.8f, -55.9f), 0.5f, false);
        yield return new WaitForSeconds(0.2f);

        PurpleGoal.transform.DOLocalMove(new Vector3(217.9f, 116.6f, 135.8f), 0.5f, false);
        yield return new WaitForSeconds(0.2f);

        Roof1.transform.DOLocalMove(new Vector3(-41.3f, 48.6f, 234.9f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        Ramp3.transform.DOLocalMove(new Vector3(-142.2f, 1.5f, 32.2f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        YellowGoal.transform.DOLocalMove(new Vector3(331.9f, -6.9f, 33.3f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        GreenBall.transform.DOLocalMove(new Vector3(44.9f, 89.9f, 113.1f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        CreamGoal.transform.DOLocalMove(new Vector3(337f, 24.3f, 181f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        PurpleBall.transform.DOLocalMove(new Vector3(-268.9f, 13f, -14.7f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        YellowBall.transform.DOLocalMove(new Vector3(92f, 0.5f, -37.6f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        BlueBall.transform.DOLocalMove(new Vector3(447.3f, 6.3f, 408f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        GreenGoal.transform.DOLocalMove(new Vector3(30.6f, -0.6f, 19.4f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        PowerUp1.transform.DOLocalMove(new Vector3(89f, 15.22f, 124.88f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        PowerUp2.transform.DOLocalMove(new Vector3(96.3f, 35.6f, 137.8f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        PowerUp3.transform.DOLocalMove(new Vector3(106.8f, 62.2f, 119.7f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        PowerUp4.transform.DOLocalMove(new Vector3(127.46f, 84.29f, 145.14f), 0.5f, false);
        yield return new WaitForSeconds(0.2f);

        PowerUp5.transform.DOLocalMove(new Vector3(153.06f, 88.39f, 108.02f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        PowerUp6.transform.DOLocalMove(new Vector3(205.5f, 61.38f, 121.06f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        PowerUp7.transform.DOLocalMove(new Vector3(221.3f, 13.1f, 123.2f), 0.51f, false);
        yield return new WaitForSeconds(0.2f);

        //Portal.DOFade(float to, float duration);
        Portal.SetActive(true);
        EerieLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);


        Ramp4.transform.DOLocalMove(new Vector3(-144f, 14.2f, 5.6f), 0.5f, false);

        PowerUp8.transform.DOLocalMove(new Vector3(0, -5f, 0), 0.2f, false);

        PowerUp9.transform.DOLocalMove(new Vector3(0, -5f, 0), 0.2f, false);

        PowerUp10.transform.DOLocalMove(new Vector3(0, -5f, 0), 0.2f, false);
        
        yield return new WaitForSeconds(0.5f);

        MainGameTP.SetActive(true);
        //PortalPS.SetActive(true);
        yield return new WaitForSeconds(1f);
        Miniture.SetActive(true);



    }


}

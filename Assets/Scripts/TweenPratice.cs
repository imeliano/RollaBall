using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TweenPratice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DOTween.To(()=> transform.position.y,x=> transform.position = new Vector3(transform.position.x, x, transform.position.z), 50, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (Mathf.Cos(Time.deltaTime), Mathf.Sin(Time.deltaTime), 0);
    }
}

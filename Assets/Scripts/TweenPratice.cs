using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TweenPratice : MonoBehaviour
{
    public Vector3[] Pathwaypoints;

    // Start is called before the first frame update

    void Start()
    {
        //DOTween.To(()=> transform.position.y,x=> transform.position = new Vector3(transform.position.x, x, transform.position.z), 50, 1). SetEase(Ease.myAnimationCurve);
        //transform.DOBlendableMoveBy(new Vector3(-3, 3, 0), 2);
        //﻿﻿﻿﻿﻿DOTween.RewindAll();
        transform.DOLocalPath(Pathwaypoints, 2f, PathType.CatmullRom).SetLoops(-1);

    }

    // Update is called once per frame
    void Update()
    {
        //new Vector3 = Vector3.angle(transform.forward, refrence);
        

        //transform.position = new Vector3 (Mathf.Cos(Time.deltaTime), Mathf.Sin(Time.deltaTime), 0);
    }
}

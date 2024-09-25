using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTween : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject centerDirection; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(centerDirection.transform.position);
    }
}

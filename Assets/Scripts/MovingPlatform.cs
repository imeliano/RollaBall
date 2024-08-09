using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float Distance;
    public bool IsRepeating;
    public Vector3 Direction;
    public bool IsMoving;
    private float TotalDistance = 0f;
    public float Delay = 0f;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(true);
            IsMoving = true;
        }
    }
    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(Delay);
        IsMoving = true;
    }
    void FixedUpdate()
    {

        if (IsMoving == true)
        {
            transform.position += Direction;
            TotalDistance += Direction.magnitude;
            if (TotalDistance >= Distance)
            {
                if (IsRepeating == true)
                {
                    Direction *= -1f;
                    TotalDistance = 0f;
                    IsMoving = false;
                    StartCoroutine(StartMoving());
                }
                else
                {
                    IsMoving = false;
                }
            }
        }
    }
    public void Activate()
    {
        IsMoving = true;
    }
}

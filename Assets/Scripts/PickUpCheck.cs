using UnityEngine;
using System.Collections;
using System;
using System.Numerics;

public class PickUpCheck : MonoBehaviour
{
public int CombineTotal;
public PlayerController player;
private bool Active = false;
void Start()
{
}

void Update()
{
    if (player.InvisCount > CombineTotal && Active == false)
    {
        foreach (Transform Child in transform)
        {
            var renderer = Child.gameObject.GetComponent<Renderer>();
            renderer.material.color = Color.green;
        }
        Active = true;
        transform.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }
}
}
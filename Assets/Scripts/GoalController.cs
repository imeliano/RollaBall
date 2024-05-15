using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private Material m;
    private PlayerController PC;
    private ParticleSystem PS;
 

    void Start()
    {
        m = GetComponent<MeshRenderer>().material;
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        PS = GetComponent<ParticleSystem>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            var main = PS.main;
            if (other.gameObject.GetComponent<MeshRenderer>().material.name == m.name)
            {
                PC.AddGoals();
                main.startColor = new Color(169 / 255f, 229 / 255f, 187 / 255f);
                other.gameObject.SetActive(false);
                //animate dotween
            }
            else
            {
                other.gameObject.GetComponent<Ball>().Respawn();
                main.startColor = new Color(247 / 255f, 44 / 255f, 37 / 255f);
            }
            PS.Play();
        }
    }
}

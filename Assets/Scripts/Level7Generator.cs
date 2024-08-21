using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Level7Generator : MonoBehaviour
{
    //static private GameObject Goals;
    private PlayerController PC;
    public int GoalsNeeded;
    static private GameObject P;
    public int TotalTime;
    private static GameObject Preset;

    void Start()
    {
        //Goals = GameObject.Find("Goals");
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        PC.timer.timeRemaining = TotalTime;
        PC.TimerTextObject.SetActive(true);
        PC.timer.IsRunning = true;
        Preset = (GameObject)Resources.Load("Prefabs/" + gameObject.name, typeof(GameObject));
    }
    static public void Randomize()
    {
        P = GameObject.Find("Presets").GetComponent<PresetArrays>().GetPreset();
        P.SetActive(true);
    }

    void Update()
    {
        if (!PC.ControlState.Equals("ThirdPerson"))
        {
            return;
        }
        if (PC.GetGoals() == GoalsNeeded)
        {
            print("yay");
            P.SetActive(false);
            Randomize();
            PC.ResetGoals();
        }
        if (PC.timer.timeRemaining == 0)
        {
            print("reset");
           
            Destroy(gameObject);
            P = Instantiate(Preset, transform.parent, false);
            P.name = gameObject.name;
            P.SetActive(true);
            return;
        }
    }
}

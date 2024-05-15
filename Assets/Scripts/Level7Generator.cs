using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Level7Generator : MonoBehaviour
{
    static private GameObject Goals;
    private PlayerController PC;
    public int GoalsNeeded;
    static private GameObject P;
    public int TotalTime;
    private static Object Preset;

    void Start()
    {
        Goals = GameObject.Find("Goals");
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        PC.timer.timeRemaining = TotalTime;
        PC.TimerTextObject.SetActive(true);
        PC.timer.IsRunning = true;
    }
    static public void Randomize()
    {
        P = GameObject.Find("Presets").GetComponent<PresetArrays>().GetPreset();
        Preset = Resources.Load("Prefabs/" + P.name);
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
            P.SetActive(false);
            Randomize();
            PC.ResetGoals();
        }
        if (PC.timer.timeRemaining == 0)
        {
            Destroy(gameObject);
            Instantiate(Preset, transform.parent, false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetArrays : MonoBehaviour
{

    public List<GameObject> Presets;

    public GameObject GetPreset()
    {
        int PresetNumber = Random.Range(0, Presets.Count - 1);
        PresetNumber = 0; 
        GameObject PresetLevel = Presets[PresetNumber];
        Presets.RemoveAt(PresetNumber);
        return PresetLevel;
    }
}

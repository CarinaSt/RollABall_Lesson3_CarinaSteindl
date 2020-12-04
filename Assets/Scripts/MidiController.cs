using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MidiController : MonoBehaviour
{
    private float knob1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        knob1 = MidiMaster.GetKnob(0, 2);
        Debug.Log(knob1);
    }
}

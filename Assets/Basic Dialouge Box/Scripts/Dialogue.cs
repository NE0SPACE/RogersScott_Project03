using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    //Enter the speeds in seconds. Reccomended default speed is 0.02.
    //Make sure the number of txtSpeedForEeachSentance matches the number of pages.
    public float[] txtSpeedForEachPage;

    [TextArea(3, 10)]
    public string[] page;
}

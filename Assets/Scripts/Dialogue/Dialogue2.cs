using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue2
{
    public string name;
    [TextArea(3,5)] public string[] sentences;
}

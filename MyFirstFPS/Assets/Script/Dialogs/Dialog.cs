using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [HideInInspector]
    public bool isEnded = false;
    [TextArea]
    public string[] msg;
}

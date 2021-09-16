using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue{

    public string speaker;

    [TextArea(3, 10)]//3 is min number of lines used 10 the maximum
    public string[] sentences;


}

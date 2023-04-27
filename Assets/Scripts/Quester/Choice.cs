using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    public bool HasChoiceDone { get; private set; }
    public bool IsComingToRacing { get; private set; }

    public void ToLesson()
    {
        IsComingToRacing = false;
        HasChoiceDone = true;
    }

    public void ToRacing()
    {
        IsComingToRacing = true;
        HasChoiceDone = true;
    }
}

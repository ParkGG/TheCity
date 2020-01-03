using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCount : MonoBehaviour
{
    public int count = 0;

    public int Counting
    {
        get
        {
            return count;
        }
        set
        {
            count += 1;
        }
    }
}

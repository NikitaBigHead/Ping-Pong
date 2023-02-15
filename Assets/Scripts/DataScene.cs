using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class DataScene
{
    public static int countPlayer = 0;

    public static int Players
    {
        get
        {
            return countPlayer;
        }
        set
        { 
            countPlayer = value;
        } 
    }

    
}

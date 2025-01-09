using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    int[] intArray = new int[5];
    public void Method()
    {
        intArray[0] = 0;
        intArray[1] = 1;
        intArray[2] = 2;
        intArray[3] = 3;
        intArray[4] = 4;

        foreach (int i in intArray)
        {
            Debug.Log(i);   
        }
        List<int> list = new List<int>() { 0, 1, 2, 3, 4 };
        foreach (int i in list)
        {
            Debug.Log(i);
        }
    }
}

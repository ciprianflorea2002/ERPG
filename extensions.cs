using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class extensions 
{
    public static void Shuffle(this int[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int i = Random.Range(0,n + 1);
            int temp = array[i];
            array[i] = array[n];
            array[n] = temp;
        }
    }
}

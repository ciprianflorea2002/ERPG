using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Extenions
{
    public static Vector3 ToVector3(this Movement.Direction dir){
        Vector3 step = Vector3.zero;
        switch (dir) {
            case Movement.Direction.Up:
                step.y = 1; break;
            case Movement.Direction.Down:
                step.y = -1; break;
            case Movement.Direction.Right:
                step.x = 1; break;
            case Movement.Direction.Left:
                step.x = -1; break;
            default: break;
        }
        return step;
    }

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

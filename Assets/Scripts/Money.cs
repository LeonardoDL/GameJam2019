using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Money
{
    public static int value = 0;
    public static int times = 0;

    public static void SetValue(int v)
    {
        value = v;
    }

    public static void Increment()
    {
        value++;
        times++;
    }

    public static void Subtract(int v)
    {
        value -= v;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMarket : MonoBehaviour
{
    public Text text;
    void Update()
    {
        text.text = "You died " + Money.times + " times\nYou have " + Money.value + " gold";
    }
}

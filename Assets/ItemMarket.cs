using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMarket : MonoBehaviour
{
    public int price;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Money.Subtract(price);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMarket : MonoBehaviour
{
    public int price;
    public Text text;
    public int i;
    //public UpgradeManager um;

    void Update()
    {
        text.text = "" + price;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Money.Subtract(price);
        GameObject.Find("Player").GetComponent<UpgradeManager>().Upgrade(i);
        Destroy(gameObject);
    }
}

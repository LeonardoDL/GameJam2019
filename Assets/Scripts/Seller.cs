using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public Transform[] itemSpots;
    public GameObject[] items;
    public UpgradeManager um;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lembrando que os itens na loja tem que estar na mesma ordem que os upgrades do player");
        for (int i = 0; i < items.Length; i++)
        {
            GameObject g = Instantiate(items[i], itemSpots[i].position, itemSpots[i].rotation);
            SpriteRenderer s = g.GetComponent<SpriteRenderer>();
            ItemMarket im = g.GetComponent<ItemMarket>();
            if (um.HasUpgrade(i))
            {
                im.price = 0;
                s.color = new Color(s.color.r, s.color.g, s.color.b, .5f);
            }
            
            if (Money.value < im.price)
            {
                g.GetComponent<Collider2D>().enabled = false;
                im.enabled = false;
            }
        }
    }
}

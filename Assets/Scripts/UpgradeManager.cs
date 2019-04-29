using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject[] prefabs;

    [SerializeField] private int coins;
    [SerializeField] private bool[] upgrades;
    // Start is called before the first frame update
    void Start()
    {
        if (upgrades[0])
        {
            upgrades[1] = false;
            upgrades[2] = false;
            GetComponent<Shoot>().bulletPrefab = prefabs[0];
            GetComponent<Shoot>().cooldown = 0.3f;
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }

        if (upgrades[1])
        {
            upgrades[0] = false;
            upgrades[2] = false;
            GetComponent<Shoot>().bulletPrefab = prefabs[1];
            GetComponent<Shoot>().cooldown = 1.6f;
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }

        if (upgrades[2])
        {
            upgrades[0] = false;
            upgrades[1] = false;
            GetComponent<Shoot>().bulletPrefab = prefabs[2];
            GetComponent<Shoot>().cooldown = .8f;
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }

        if (upgrades[3])
        {
            GetComponent<PlayerMovement>().rSpeed = 60f;
            GetComponent<CharacterController2D>().doubleJump = true;
        }
        else
        {
            GetComponent<PlayerMovement>().rSpeed = 40f;
            GetComponent<CharacterController2D>().doubleJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasUpgrade(int i)
    {
        return upgrades[i];
    }
}

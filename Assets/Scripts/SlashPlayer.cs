using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Animator>().SetTrigger("Slash");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSentence : MonoBehaviour
{
    public Text t;
    public string[] txts;
    // Start is called before the first frame update
    void Start()
    {
        t.text = txts[Random.Range(0, txts.Length)];
    }
}

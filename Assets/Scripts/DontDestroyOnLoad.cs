using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if (gos.Length < 2)
            DontDestroyOnLoad(this);
        else
            Destroy(gameObject);
    }
}

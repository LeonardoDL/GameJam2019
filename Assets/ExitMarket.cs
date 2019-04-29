using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMarket : MonoBehaviour
{
    public int sceneNumber = 1;

    void OnTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}

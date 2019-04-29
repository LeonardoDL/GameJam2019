using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Storyboard : MonoBehaviour
{
    public SpriteRenderer front;
    public SpriteRenderer back;
    public Sprite[] sprites;
    public float cooldown;

    private int i;
    private float nextSpriteTime;
    // Start is called before the first frame update
    void Start()
    {
        front.sprite = sprites[0];
        back.sprite = sprites[1];
        nextSpriteTime = Time.time + cooldown;
        i = 1;
    }

    public void NextSprite()
    {
        Debug.Log(i);
        front.sprite = sprites[i];
        front.color = new Color(front.color.r, front.color.g, front.color.b, 1f);

        if (i == 2)
            SoundManager.SM.PlayEffect("street+brake");

        if (i < sprites.Length - 1)
        {
            back.sprite = sprites[i + 1];
            i++;
        }
        else
            SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (Time.time > nextSpriteTime)
        {
            NextSprite();
            nextSpriteTime = Time.time + cooldown;
        }
        front.color = new Color(front.color.r, front.color.g, front.color.b, front.color.a - 0.01f);
    }
}

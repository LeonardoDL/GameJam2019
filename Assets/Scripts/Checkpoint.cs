using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite imageOn;
    public AudioSource audioSource;
    private bool isOn = false;

    public void Activate() {
        //audioSource.Play();
        //gameObject.GetComponent<SpriteRenderer>().sprite = imageOn;
        isOn = true;
    }

    public bool GetIsOn() {
        return isOn;
    }
}

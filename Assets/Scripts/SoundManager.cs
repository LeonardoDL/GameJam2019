using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] tracks;
    public AudioClip[] effects;
    public AudioSource audSource;

    private Dictionary<string, AudioClip> tracksTable;
    private Dictionary<string, AudioClip> effectsTable;
    public static SoundManager SM;

    void Start()
    {
        SM = this;
        tracksTable = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in tracks)
            tracksTable.Add(a.name, a);

        effectsTable = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in effects)
            effectsTable.Add(a.name, a);
    }

    public void PlayTrack(int i)
    {
        audSource.clip = tracks[i];
        audSource.Play();
    }

    public void PlayTrack(string s)
    {
        AudioClip a = tracksTable[s];
        audSource.clip = a;
        audSource.Play();
    }

    public void PlayEffect(int i)
    {
        audSource.clip = effects[i];
        audSource.Play();
    }

    public void PlayEffect(string s)
    {
        audSource.clip = effectsTable[s];
        audSource.Play();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] tracks;
    public AudioClip[] effects;
    public AudioSource trackSource;
    public AudioSource effectSource;

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
        StopTracks();
        trackSource.clip = tracks[i];
        trackSource.Play();
    }

    public void PlayTrack(string s)
    {
        StopTracks();
        AudioClip a = tracksTable[s];
        trackSource.clip = a;
        trackSource.Play();
    }

    public void PlayEffect(int i)
    {
        effectSource.clip = effects[i];
        effectSource.Play();
    }

    public void PlayEffect(string s)
    {
        effectSource.clip = effectsTable[s];
        effectSource.Play();
    }

    public void StopTracks()
    {
        trackSource.Stop();
    }

    public void StopEffects()
    {
        effectSource.Stop();
    }
}
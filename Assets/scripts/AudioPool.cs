using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPool : MonoBehaviour
{
    public List<AudioSource> audioPool = new List<AudioSource>();

    private void OnLevelWasLoaded(int level)
    {
        audioPool.Clear();
    }
    public AudioSource GetAvailableAudio(Vector3 pos)
    {

        foreach (AudioSource current in audioPool)
        {

            if (!current.isPlaying)
            {
                current.transform.position = pos;
                return current;
            }
        }
        AudioSource newSource = new GameObject().AddComponent<AudioSource>();
        newSource.volume = newSource.volume / 2;
        newSource.transform.position = pos;
        audioPool.Add(newSource);
        return newSource;
    }
}

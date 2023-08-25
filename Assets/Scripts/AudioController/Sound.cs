using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;
   
    private AudioSource source; 
    public bool loop = false;
    
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
       // Debug.Log(source.clip.name);
        source.loop = loop;
    }
    public void Play()
    {
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }
}

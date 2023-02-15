using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string name;
    [Range(0f, 1f)]
    public float volume=0.78f;
    [Range(0.1f,3f)]
    public float pitch=1f;

    public bool isLoop;
    
    [HideInInspector]
    public AudioSource source;
    // Start is called before the first frame update
  
}

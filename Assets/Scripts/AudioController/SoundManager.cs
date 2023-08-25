using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    // Singleton instance.
    public static SoundManager Instance = null;

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Awake()
    {
        
        if(Instance != null)
        {
          //  Debug.LogError("More than one AudiManager in the scene");
            if(Instance != this)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this); 
        }
        // makeSingleton();

        // Load the saved volume settings from PlayerPrefs (if available)
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Set the slider values to the loaded volume settings
        masterVolumeSlider.value = masterVolume;
        musicVolumeSlider.value = musicVolume;
        sfxVolumeSlider.value = sfxVolume;

        // Add listeners to the sliders to update the volumes when they change
        masterVolumeSlider.onValueChanged.AddListener(UpdateMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(UpdateSFXVolume);

        // Apply the initial volume settings
       // ApplyVolumeSettings();

    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<sounds.Length;i++)
        {
            GameObject _gObj = new GameObject("Sound_" + i + "_" + sounds[i].name);
           // _gObj.AddComponent<AudioSource>();
            _gObj.transform.SetParent(this.transform);
            sounds[i].SetSource(_gObj.AddComponent<AudioSource>()); 
        }
        playSound("MusicGameplay");
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void playSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
       // Debug.LogWarning("Audiomanager : Sound not found in sounds array : " + _name);
    }
    public void stopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }
        Debug.LogWarning("Audiomanager : Sound not found in sounds array : " + _name);
    }
   private void makeSingleton()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

       
    }


    private void ApplyVolumeSettings()
    {

        // Apply the volume settings to the appropriate audio listeners or audio sources
         AudioListener.volume = masterVolumeSlider.value;
      
    }
    public void UpdateMasterVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("MasterVolume", newVolume);
        AudioListener.volume = masterVolumeSlider.value;
    }

    public void UpdateMusicVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.clip.name == "MusicGameplay")
            {
                audioSource.volume = musicVolumeSlider.value;
            }
            
        }
    }
    public void UpdateSFXVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("SFXVolume", newVolume);
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.clip.name != "MusicGameplay")
            {
                audioSource.volume = sfxVolumeSlider.value;
            }
            // audioSource.volume = newVolume;
            // PlayerPrefs.SetFloat("Volume", newVolume);
        }
      

    }
    
}

//Sound_0_ MusicGameplay
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public Sound[] sounds;
        public AudioMixerGroup sfxMixerGroup, musicMixerGroup;
       

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
            DontDestroyOnLoad(gameObject);


          
        }

        private void Start()
        {
            foreach (var sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.playOnAwake = false;
                sound.source.loop = sound.loop;
                if (sound.loop == true)
                {
                    sound.source.outputAudioMixerGroup =musicMixerGroup;
                }
                else
                {
                    sound.source.outputAudioMixerGroup =sfxMixerGroup;
                }
               
            }
        }

        public void Play(string name)
        {
          Sound s =  Array.Find(sounds, sound => sound.name == name);
          if (s == null)
          {
              Debug.LogWarning("Sound :" + name + " not found!");
              return;
          }
          s.source.Play();
        }
        
    }

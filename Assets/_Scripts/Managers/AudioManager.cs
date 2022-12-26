using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public Sound[] sounds;
        public AudioMixerGroup sfxMixerGroup, musicMixerGroup;
        public  bool startMusic;
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
        private void Start()
        {
          
        }
        public void Play(string name)
        {
          Sound s =  Array.Find(sounds, sound => sound.name == name);
          if (s == null)
          {
              Debug.LogWarning("Sound :" + name + " not found!");
              return;
          }

          s.pitch =(UnityEngine.Random.Range(s.pitch - 0.2f, s.pitch + 0.2f));
          s.source.Play();
        }
        public void Stop(string name)
        {
            Sound s =  Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound :" + name + " not found!");
                return;
            }

            s.pitch =(UnityEngine.Random.Range(s.pitch - 0.2f, s.pitch + 0.2f));
            s.source.Stop();
        }
    }

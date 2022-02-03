using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    //prevent duplicate audiomanagers
    public static AudioManager instance;

    //for scene transition stuff like music



    // Start is called before the first frame update
    void Awake()
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


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Ocean");
        StartCoroutine(FadeIn("Ocean"));
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    //Only works for Volume 0->1
    public IEnumerator FadeIn(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound not found: " + name);
            yield break;
        }

        s.volume = 0;
        s.source.volume = 0;
        float speed = 0.01f;

        for (float i = 0; i < 1; i += speed)
        {
            s.volume = i;
            s.source.volume = i;
            yield return null;
        }
    }

    //Only works for Volume 1->0
    public IEnumerator FadeOut(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound not found: " + name);
            yield break;
        }

        s.volume = 1;
        s.source.volume = 1;
        float speed = 0.01f;

        for (float i = 1; i > 0; i -= speed)
        {
            s.volume = i;
            s.source.volume = i;
            yield return null;
        }
    }
}

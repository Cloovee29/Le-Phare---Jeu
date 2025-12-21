using UnityEngine;
using System.Collections;



public class AudioManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource doorSound;
    public AudioSource music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        doorSound.Play();
        yield return new WaitUntil(() => !doorSound.isPlaying);
        music.Play();
    }


    // Update is called once per frame
    void Update()
    {

    }
}

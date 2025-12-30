using UnityEngine;

public class JournalAudioManager : MonoBehaviour
{
    public static JournalAudioManager Instance; // singleton

    public AudioClip openSound;
    //public AudioClip closeSound;
    public AudioClip pageTurn;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayOpenSound()
    {
        audioSource.PlayOneShot(openSound);
    }

    //public void PlayCloseSound()
    //{
    //    audioSource.PlayOneShot(closeSound);
    //}

    public void PlayPageTurn()
    {
        audioSource.PlayOneShot(pageTurn);
    }
}

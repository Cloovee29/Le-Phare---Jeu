using UnityEngine;

public class MusicManagerEnd : MonoBehaviour
{
    private static MusicManagerEnd instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ne détruit pas le GameObject entre cinématique fin et crédits

            AudioSource audio = GetComponent<AudioSource>();
            if (audio != null && !audio.isPlaying)
                audio.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
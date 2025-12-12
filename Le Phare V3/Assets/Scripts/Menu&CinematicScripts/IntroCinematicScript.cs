using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroCinematicScript : MonoBehaviour
{
    public Image displayImage;
    public Sprite[] images;

    public float delay = 3f;

    public string Level1;

    public FadeController fadeController;

    // --- AUDIOOOO ---
    [Header("Sound")]
    public AudioSource doorAudio;  // jsp pourquoi ça veut pas fonctionner sans, je pensais pouvoir utiliser que l'audioclip comme des exemples vu sur internet mais marche pas
    public AudioClip doorClip;
    public float blackScreenDuration = 5f;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(PlayCinematic());
    }

    IEnumerator PlayCinematic()
    {
        // boucle sur les images
        for (int i = 0; i < images.Length; i++)
        {
            displayImage.sprite = images[i];

            yield return StartCoroutine(fadeController.FadeIn());

            // attente skippable
            float elapsed = 0f;
            bool skip = false;
            while (elapsed < delay && !skip)
            {
                if (Input.GetMouseButtonDown(0))
                    skip = true;

                elapsed += Time.deltaTime;
                yield return null;
            }

            yield return StartCoroutine(fadeController.FadeOut());
        }

        // ---- Écran noir ----
        // ici on peut garder le noir affiché pendant blackScreenDuration
        Color temp = displayImage.color;
        temp.a = 1f; // s'assurer que l'écran est noir
        displayImage.color = temp;

        // jouer le son de la porte
        if (doorAudio != null && doorClip != null)
        {
            doorAudio.PlayOneShot(doorClip);
        }

        // attendre la durée du noir
        yield return new WaitForSeconds(blackScreenDuration);

        // charger la scène
        SceneManager.LoadScene("01 - HouseScene");
    }
}
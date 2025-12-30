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

    [Header("Cursor")]
    public GameObject clickIndicator;

    // --- AUDIOOOO ---
    [Header("Sound")]
    public AudioSource doorAudio;  // jsp pourquoi ça veut pas fonctionner sans, je pensais pouvoir utiliser que l'audioclip comme des exemples vu sur internet mais marche pas
    public AudioClip doorClip;
    public AudioSource audioSource;

    void Start()
    {
            if (clickIndicator != null)
                clickIndicator.SetActive(false);

            StartCoroutine(PlayCinematic());
    }

    IEnumerator PlayCinematic()  // ---- POUR LE COUP CA FAIT PASSER TOUTES LES FRAMES  ------
    {
        // boucle sur les images
        for (int i = 0; i < images.Length; i++)
        {
            displayImage.sprite = images[i];

            yield return StartCoroutine(fadeController.FadeIn());

            // si c'est les deux premières images, attendre le clic //NB Anto: j'ai changé à trois pour les trois parties de la lettre
            if (i < 3)
            {
                if (clickIndicator != null)   // pour mon curseur
                    clickIndicator.SetActive(true);

                bool clicked = false;
                while (!clicked)
                {
                    if (Input.GetMouseButtonDown(0))
                        clicked = true;

                    yield return null;
                }

                if (clickIndicator != null)   // pour mon curseur à désafficher
                    clickIndicator.SetActive(false);
            }
            else
            {
                // pour les autres images, le ptit fade auto
                float elapsed = 0f;
                while (elapsed < delay)
                {
                    elapsed += Time.deltaTime;
                    yield return null;
                }
            }

            yield return StartCoroutine(fadeController.FadeOut());
        }

        // -------- ECRAN NOIR ----
        Color temp = displayImage.color;
        temp.a = 1f; 
        displayImage.color = temp;

        if (doorAudio != null && doorClip != null)
        {
            doorAudio.PlayOneShot(doorClip);
        }

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("01 - HouseScene");
    }
}
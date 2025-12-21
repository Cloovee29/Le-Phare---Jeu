using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndCinematicScript : MonoBehaviour
{
    public Image displayImage;
    public Sprite[] images;

    public float delay = 3f;

    public string EndCinematic;

    public FadeController fadeController;

    void Start()
    {
            StartCoroutine(PlayCinematic());
    }

    IEnumerator PlayCinematic()  // ---- POUR LE COUP CA FAIT PASSER TOUTES LES FRAMES  ------
    {
        // boucle sur les images
        for (int i = 0; i < images.Length; i++)
        {
            displayImage.sprite = images[i];

            yield return StartCoroutine(fadeController.FadeIn());

            float elapsed = 0f;
            while (elapsed < delay)
            {
                elapsed += Time.deltaTime;
                yield return null;
            }

            yield return StartCoroutine(fadeController.FadeOut());
        }

        // -------- ECRAN NOIR ----
        Color temp = displayImage.color;
        temp.a = 1f; 
        displayImage.color = temp;

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("05 - Credits");
    }
}
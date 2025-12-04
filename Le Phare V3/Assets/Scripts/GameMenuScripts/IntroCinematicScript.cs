using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroCinematic : MonoBehaviour
{
    public Image displayImage;
    public Sprite[] images;

    public float delay = 3f;

    public string Level1;

    public FadeController fadeController;

    void Start()
    {
        StartCoroutine(PlayCinematic());
    }

    IEnumerator PlayCinematic()
    {
        for (int i = 0; i < images.Length; i++)
        {
            displayImage.sprite = images[i];

            yield return StartCoroutine(fadeController.FadeIn()); // j'ai ajouté le fade in ici

            yield return new WaitForSeconds(delay);

            //if (i < images.Length - 1)  // je teste pour que le fade out ait lieu sauf si c'est la dernière image
            yield return StartCoroutine(fadeController.FadeOut());  // et le fade out là
        }

        SceneManager.LoadScene(Level1);
    }
}
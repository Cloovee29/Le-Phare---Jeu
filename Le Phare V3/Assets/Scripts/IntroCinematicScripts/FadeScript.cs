using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeScript : MonoBehaviour
{
    public Image fadeImage;

    public float fadeDuration = 1.5f;


    // ----LES LIGNES SUIVANTES NE FONCTIONNENT PAS MAIS JE GARDE AU CAS OU ---- //

    // private Image _sceneFadeImage;

    //private void Awake()
    //{
    //    _sceneFadeImage = GetComponent<Image>();
    //}

    //public IEnumerator FadeInCoroutine(float duration)
    //{
    //    Color startColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 1);
    //    Color targetColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 0);

    //    yield return FadeCoroutine(startColor, targetColor, duration);

    //    gameObjet.SetActive(false);
    //}

    //public IEnumerator FadeOutCoroutine(float duration)
    //{
    //    Color startColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 0);
    //    Color targetColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 1);
    //}


    //private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration)
    //{
    //    float elapsedTime = 0;
    //    float elapsedPercentage = 0;

    //    while (elapsedTime < duration) {
    //        elapsedPercentage = elapsedTime / duration;
    //        _sceneFadeImage.color = Color.Lerp(startColor, targetColor, elapsedPercentage);

    //        yield return null;
    //        elapsedTime += Time.deltaTime;
    //}

    public IEnumerator FadeIn()  // pour quand elle arrive (coroutine)
    {
        Color temporaryColor = fadeImage.color;  // je créé une variable qui stock temporairement la couleur actuelle

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {  // pdt que le temps t écoulé est plus petit que la durée du fade, la boucle tourne et augmente t selon le temps réel

            temporaryColor.a = Mathf.Lerp(1f, 0f, t / fadeDuration);  // a c'est pour la propriété d'une couleur en alpha, ensuite une interpolation linéaire pour si "1" ça renvoie start, sinon ça renvoie "end" ou si "0.5" ça renvoie la valeur entre deux

            fadeImage.color = temporaryColor;
            yield return null;
        }

        temporaryColor.a = 0f;

        fadeImage.color = temporaryColor;

    }

    public IEnumerator FadeOut()  // pour quand elle part
    {
        Color temporaryColor = fadeImage.color;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {

            temporaryColor.a = Mathf.Lerp(0f, 1f, t / fadeDuration);

            fadeImage.color = temporaryColor;

            yield return null;
        }

        temporaryColor.a = 1f;

        fadeImage.color = temporaryColor;
    }
}

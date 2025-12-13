using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorStartThirdScene : MonoBehaviour
{
    public AudioSource startAudio;
    public Image blackOverlay;
    public float blackDuration = 4.5f; // temps avant de montrer la scène
    public float fadeDuration = 1.5f; // durée du fade

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (startAudio != null)
            startAudio.Play();

        if (blackOverlay != null)
            StartCoroutine(FadeBlackOverlay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeBlackOverlay()
    {
        yield return new WaitForSeconds(blackDuration);           // on atteing la durée du noir avant le fade

        Color tempColor = blackOverlay.color;  //encore un fade
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            tempColor.a = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            blackOverlay.color = tempColor;
            elapsed += Time.deltaTime;
            yield return null;
        }

        tempColor.a = 0f;          // là je m'assure que l'alpha est bien à 0

        blackOverlay.color = tempColor;

        blackOverlay.gameObject.SetActive(false);  //j'ai eu des pb du coup je m'assure de vraiment désactiver l'overlay après le fade
    }
}

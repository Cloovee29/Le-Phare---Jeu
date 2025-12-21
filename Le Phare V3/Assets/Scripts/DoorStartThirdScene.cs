using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorStartThirdScene : MonoBehaviour
{
    public AudioSource startAudio;
    public Image blackOverlay;
    public float blackDuration = 4.5f; // temps avant de montrer la scène
    public float fadeDuration = 1.5f; // durée du fade

    public ClickMove2D character;
    private BoxCollider2D[] decorsBoxCollider2D;
    public GameObject decors;
    public GameObject arrows;

    bool transitionEnd = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackOverlay.gameObject.SetActive(true);
        if (startAudio != null)
            startAudio.Play();

        if (blackOverlay != null)
            StartCoroutine(FadeBlackOverlay());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transitionEnd)
        {
            decorsBoxCollider2D = decors.GetComponentsInChildren<BoxCollider2D>();
            foreach (BoxCollider2D col in decorsBoxCollider2D)
                col.enabled = true;
            character.enabled = true;
            arrows.SetActive(true);
        }
        else
        {
            decorsBoxCollider2D = decors.GetComponentsInChildren<BoxCollider2D>();
            foreach (BoxCollider2D col in decorsBoxCollider2D)
                col.enabled = false;
            character.enabled = false;
            arrows.SetActive(false);
        }
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
        transitionEnd = true;
        print("transi");
    }
}

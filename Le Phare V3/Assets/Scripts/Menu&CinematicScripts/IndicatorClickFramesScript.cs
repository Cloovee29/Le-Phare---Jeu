using UnityEngine;

public class IndicatorClickFramesScript : MonoBehaviour
{
    // Affiche l'indicateur
    public void Show()
    {
        gameObject.SetActive(true);
    }

    // Cache l'indicateur
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
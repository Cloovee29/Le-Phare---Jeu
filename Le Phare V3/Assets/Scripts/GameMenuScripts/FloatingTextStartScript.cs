using UnityEngine;
using UnityEngine.UI;

public class FloatingTextStartScript : MonoBehaviour
{
    public float amplitude = 5f; // ma hauteur max du mouvement
    public float speed = 1.5f;      // sa vitesse

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // oscillation continue entre -1 et 1 multipliée par sa vitesse le tout multiplié par son amplitude
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;

        transform.localPosition = startPos + new Vector3(0, yOffset, 0);
    }
}
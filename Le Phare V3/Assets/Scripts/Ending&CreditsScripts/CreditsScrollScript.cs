using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsScrollScript : MonoBehaviour
{

    public float scrollSpeed = 10f;
    public float endPositionY = 1900f; // quand la musique se finissait, j'y arrivais pas, je fais avec la position mnt

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        if (transform.position.y >= endPositionY)
        {
            SceneManager.LoadScene("00 - GameMenu");
        }
    }
}




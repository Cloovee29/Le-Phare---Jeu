using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsScript : MonoBehaviour
{

    public float scrollSpeed = 10f;
    public float endPositionY = 2000f;   // j'ai voulu faire en end time mais ça colle pas avec la musique, du coup je jo


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        if (transform.position.y > endPositionY)
        {
            SceneManager.LoadScene("00 - GameMenu");
        }
    }
}




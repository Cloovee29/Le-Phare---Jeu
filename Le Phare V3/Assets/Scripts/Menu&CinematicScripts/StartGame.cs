using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string IntroCinematicScene;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("00 - IntroCinematicScene"); // ici ça charge la scène cinématique d'intro
        }
    }
}
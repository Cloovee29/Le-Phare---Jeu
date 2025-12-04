using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public string IntroCinematicScene;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(IntroCinematicScene); // ici ça charge la scène cinématique d'intro
        }
    }
}
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using System.Collections; 

public class ClickMove2D : MonoBehaviour
{
    public float speed = 2f;  // vitesse 
    public float groundY = -1.72f;    // position sur axe des Y et hauteur du sol
    private Vector3 targetPosition;

    private SpriteRenderer spriteRenderer;

    private Vector3 initialPosition;

    public GameObject Arrows;
    public EventSystem eventSystem;

    private AudioSource footstepsAudio;


    void Start()
    {
        targetPosition = transform.position;   // début à son emplacement actuel sur scene

        spriteRenderer = GetComponent<SpriteRenderer>();

        initialPosition = transform.position;

        footstepsAudio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (transform.position != targetPosition)
        {
            if (!footstepsAudio.isPlaying)
                footstepsAudio.Play();
        }
        else
        {
            if (footstepsAudio.isPlaying)
                footstepsAudio.Stop();
        }

            if (Input.GetMouseButtonDown(0) && eventSystem.currentSelectedGameObject == null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   // position de mon curseur sur mon écran retranscris en position sur Unity

            mousePos.y = groundY;

            mousePos.z = 0;   // pas retirer sinon perso bouge sur les murs

            // là je veux qu'il flip si je clique dans le sens inverse de là où il regarde (sprite initial)

            if (mousePos.x < transform.position.x){
                Vector3 scale = transform.localScale;

                scale.x = -Mathf.Abs(scale.x);

                transform.localScale = scale;
            }
            else
            {

                Vector3 scale = transform.localScale;

                scale.x = Mathf.Abs(scale.x);

                transform.localScale = scale;
            }

            //fonctionne pas donc j'ai fait fonction au dessus
            //if (mousePos.x < transform.position.x)
            //    spriteRenderer.flipX = true;  // regarde à gauche 
            //else
            //    spriteRenderer.flipX = false; // regarde à droite   

            targetPosition = mousePos;
        }

        transform.position = Vector3.MoveTowards(

        transform.position,

        targetPosition,
        speed * Time.deltaTime);
    }
    // Pour quand on clique sur une flèche
    public void HideAndResetCharacter()
    {
        // ça rend dora invisible
        spriteRenderer.enabled = false;

        // ça la remet à sa position de tout début
        transform.position = initialPosition;
        targetPosition = initialPosition;
    }

    public void ShowCharacter()      // c'est à la fin de l'animation de défilement
    {
        spriteRenderer.enabled = true;
    }
}
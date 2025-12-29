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

    SpriteRenderer spriteRenderer;

    private Vector3 initialPosition;

    public GameObject Arrows;
    public EventSystem eventSystem;

    private AudioSource footstepsAudio;

    public AudioSource characterFeedback;

    public float distanceMarieTarget;


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

            // flip

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
            Vector3 direction = (mousePos - transform.position).normalized;

            targetPosition = mousePos - direction * distanceMarieTarget; //permet de gérer la distance de Marie par rapport au point où l'on clique pour éviter que les deux se superposent.

        }

        transform.position = Vector3.MoveTowards(

        transform.position,

        targetPosition,
        speed * Time.deltaTime);
    }
    // Pour quand on clique sur une flèche
    public void HideAndResetCharacter()
    {
        spriteRenderer.enabled = false;

        transform.position = initialPosition;
        targetPosition = initialPosition;
    }

    public void ShowCharacter()      // c'est à la fin de l'animation de défilement
    {
        spriteRenderer.enabled = true;
    }
}
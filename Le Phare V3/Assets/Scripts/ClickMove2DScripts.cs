using UnityEngine;

public class ClickMove2D : MonoBehaviour
{


    public float speed = 2f;  // vitesse 
    public float groundY = -1.06f;    // position sur axe des Y et hauteur du sol
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;   // début à son emplacement actuel sur scene (parler des emplacements des flèches qui dérangent le LD
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   // position de mon curseur sur mon écran retranscris en position sur Unity

            mousePos.y = groundY;

            mousePos.z = 0;   // pas retirer sinon perso bouge sur les murs

            targetPosition = mousePos;
        }
        transform.position = Vector3.MoveTowards(

            transform.position,

            targetPosition,
            speed * Time.deltaTime
        );
    }
}
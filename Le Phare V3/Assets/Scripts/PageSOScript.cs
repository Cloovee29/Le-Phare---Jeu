using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable object/Pages")]
public class PageSOScript : ScriptableObject
{
   // public List<GameObject> listHoles; //liste de trous associés à une page
    public List<string> listWords; //liste des mots à placer dans le journal
    public int numbPage; //numéro de la page du carnet
    public List<HoleSOScript> listHoles;

    public string textPage1;
    public string textPage2;

    public Sprite imageValidation;
}


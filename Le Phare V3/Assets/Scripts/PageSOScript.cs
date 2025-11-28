using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Scriptable object/Pages")]
public class Page : ScriptableObject
{
    public List<GameObject> listHoles; //liste de trous associés à une page
    public List<GameObject> listWordsToDrag; //liste des mots à placer dans le journal
    public int numbPage; //numéro de la page du carnet
}

public enum PageName
{
    Page1,
    Page2,
}

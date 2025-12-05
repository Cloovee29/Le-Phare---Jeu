using Unity.VisualScripting;
using UnityEngine;

public class smallNotesScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public NotesScript manager;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        audioSource.Play();
        manager.NoteClicked(gameObject.tag);
    }
}

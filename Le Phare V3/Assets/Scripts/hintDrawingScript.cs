using UnityEngine;

public class hintDrawingScript : MonoBehaviour
{
    public JournalScript journal;
    public GameObject lookNextPage;
    public GameObject code3numbers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (journal.currentPage == 1)
        {
            lookNextPage.SetActive(true);
            code3numbers.SetActive(false);
        }

        if (journal.currentPage == 2)
        {
            code3numbers.SetActive(true);
            lookNextPage.SetActive(false);
        }
    }
}

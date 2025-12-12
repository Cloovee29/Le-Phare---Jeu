using UnityEngine;

public class FieldGlassInstanciateScript : MonoBehaviour
{

    public GameObject completeFieldglass;
    public GameObject decors;
    public GameObject window;

    public GameObject fieldGlassPiece2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateCompleteFieldglass()
    {
        print("instancie longue-vue");
        GameObject newFieldglass = Instantiate(completeFieldglass);
        newFieldglass.SetActive(true);
        newFieldglass.transform.SetParent(decors.transform, true);
        newFieldglass.transform.position = window.transform.position;
        Destroy(fieldGlassPiece2);
    }
}
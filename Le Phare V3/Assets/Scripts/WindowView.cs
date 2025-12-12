using UnityEngine;

public class WindowView : MonoBehaviour
{
    public GameObject windowViewGO;

   public void CloseWindow()
    {
        windowViewGO.SetActive(false);
    }

}

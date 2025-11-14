using UnityEngine;
using TMPro;

public class JournalTexteScript : MonoBehaviour
{
    public static JournalTexteScript Instance;

    [TextArea(4, 20)]
    public string baseText =
        "Aujourd’hui, j’ai rencontré un {0}. Il m’a offert un {1} " +
        "avant de disparaître dans un énorme {2}.";

    public TextMeshPro display;

    private string[] slotValues;

    void Awake()
    {
        Instance = this;

        // compter automatiquement les trous {0}, {1}, {2}, etc.
        int count = CountSlotsInText(baseText);
        slotValues = new string[count];
        for (int i = 0; i < count; i++)
            slotValues[i] = "____"; // valeur par défaut

        RefreshText();
    }

    public void FillSlot(int id, string value)
    {
        if (id >= 0 && id < slotValues.Length)
        {
            slotValues[id] = value;
            RefreshText();
        }
    }

    void RefreshText()
    {
        display.text = string.Format(baseText, slotValues);
    }

    int CountSlotsInText(string txt)
    {
        int i = 0;
        while (txt.Contains("{" + i + "}"))
            i++;
        return i;
    }
}
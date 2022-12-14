using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellKeyCodeHint : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        ChangeKeyCode();
    }

    private void ChangeKeyCode()
    {
        switch (gameObject.name)
        {
            case "Spell01":
                text.text = InputManager.GetBindingName("Spell01", 0);
                break;
            case "Spell02":
                text.text = InputManager.GetBindingName("Spell02", 0);
                break;
            case "Spell03":
                text.text = InputManager.GetBindingName("Spell03", 0);
                break;
            case "Spell04":
                text.text = InputManager.GetBindingName("Spell04", 0);
                break;
            case "Usable":
                text.text = InputManager.GetBindingName("Usable", 0);
                break;
        }
    }
}

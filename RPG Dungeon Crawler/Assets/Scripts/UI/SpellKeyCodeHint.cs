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
        switch(gameObject.name) {
            case "Spell01":
                text.text = InputManager.Instance.Spell01.ToString();
                break;
            case "Spell02":
                text.text = InputManager.Instance.Spell02.ToString();
                break;
            case "Spell03":
                text.text = InputManager.Instance.Spell03.ToString();
                break;
            case "Spell04":
                text.text = InputManager.Instance.Spell04.ToString();
                break;
        }
    }
}

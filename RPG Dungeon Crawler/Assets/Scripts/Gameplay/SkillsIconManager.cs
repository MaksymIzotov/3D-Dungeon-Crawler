using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsIconManager : MonoBehaviour
{
    public static SkillsIconManager Instance;

    [Serializable]
    public struct Icon
    {
        public string name;
        public Sprite icon;
    }

    public List<Icon> icons = new List<Icon>();

    public Image[] skillsIcons;

    private void Awake()
    {
        Instance = this;
    }

    public void SetupIcon(Spell[] spells)
    {
        for (int i = 0; i < spells.Length; i++)
        {
            foreach(Icon n in icons)
            {
                if(n.name == spells[i].name)
                {
                    skillsIcons[i].sprite = n.icon;
                    break;
                }
            }
        }
    }
}

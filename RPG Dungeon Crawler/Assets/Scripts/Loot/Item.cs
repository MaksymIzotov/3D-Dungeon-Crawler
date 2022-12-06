using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject ingameIconPrefab;
    public GameObject menuButtonPrefab;

    public virtual void ApplyStats()
    {

    }

    public virtual void Use()
    {

    }

    public virtual string Stats()
    {
        return null;
    }
    public virtual string Desription()
    {
        return null;
    }
}

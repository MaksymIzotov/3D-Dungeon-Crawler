using UnityEngine;


public class Spell : ScriptableObject
{
    public string name;

    public float coolDownTime;
    public float activateTime;
    public float afterActivateTime;

    public bool isUpgraded;

    public Sprite icon;


    public virtual void PreCast(Transform spellSpawnpoint)
    {

    }

    public virtual void Cast(Transform spellSpawnpoint)
    {
        
    }

    public virtual void CastUpgraded(Transform spellProperty)
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

using UnityEngine;


public class Spell : ScriptableObject
{
    public float coolDownTime;
    public float activateTime;

    public virtual void PreCast(GameObject parent)
    {

    }

    public virtual void Cast(Transform spellSpawnpoint)
    {
        
    }
}

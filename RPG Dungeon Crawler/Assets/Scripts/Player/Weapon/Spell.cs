using UnityEngine;


public class Spell : ScriptableObject
{
    public enum ScrollType
    {
        Blue = 0,
        Purple = 1,
        Red = 2
    }

    [Header("Main Properties")]
    public string spellName;
    public ScrollType scrollType;
    public bool isDamage;

    public float coolDownTime;
    public float activateTime;
    public float afterActivateTime;

    [Space(10)]
    [Header("UI")]

    public Sprite icon;

    [Space(10)]
    [Header("Upgrades")]
    public Spell spellReference;
    public int upgradePrice;
    public int lvl;
    public int maxLvl;

    [Space(10)]
    [Header("Sounds")]
    public Audio preCastAudio;
    public Audio castAudio;

    public virtual void PreCast(Transform spellSpawnpoint)
    {

    }

    public virtual void Cast(Transform spellSpawnpoint)
    {
        
    }

    public virtual void AfterCast(Transform spellSpawnpoint)
    {

    }

    public virtual void CastUpgraded(Transform spellProperty)
    {

    }

    public virtual void UpgradeStats()
    {

    }

    public virtual void Reset()
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

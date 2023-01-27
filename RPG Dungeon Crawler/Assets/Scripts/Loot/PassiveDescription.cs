using UnityEngine;

[CreateAssetMenu(fileName = "PassiveName", menuName = "Passives/Description", order = 1)]
public class PassiveDescription : ScriptableObject
{
    public Sprite icon;
    [TextArea]
    public string description;
}

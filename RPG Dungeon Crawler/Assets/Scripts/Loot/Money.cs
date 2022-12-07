using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Money", menuName = "Money", order = 1)]
public class Money : ScriptableObject
{
    public int amountBlueScrolls;
    public int amountPurpleScrolls;
    public int amountRedScrolls;
    public int amountCoins;
}

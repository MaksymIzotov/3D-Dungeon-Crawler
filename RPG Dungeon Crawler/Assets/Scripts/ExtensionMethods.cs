using System.Collections;
using System.Collections.Generic;

public static class ExtensionMethods
{
    public struct InventoryFoundItem{
        public string itemName;
        public int amount;
    }

    public enum MoneyType
    {
        Coin = 0,
        ScrollBlue = 1,
        ScrollPurple = 2,
        ScrollRed = 3
    }

    public static int UpgradePriceSetup(int startingPrice, int lvl)
    {
        float newPrice = startingPrice;
        float mult = 1.3f;
        for (int i = 0; i < lvl-1; i++)
        {
            newPrice = startingPrice * mult;
        }
        
        return (int)newPrice;
    }

    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}

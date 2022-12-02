using System.Collections;
using System.Collections.Generic;

public static class ExtensionMethods
{
    public struct InventoryFoundItem{
        public string name;
        public int amount;
    }

    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}

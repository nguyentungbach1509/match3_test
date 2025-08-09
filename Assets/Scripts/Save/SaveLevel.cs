using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NormalItem;

public static class SaveLevel
{
    private static Dictionary<(int, int), eNormalType> textureSave = new Dictionary<(int, int), eNormalType>();

    public static eNormalType GetTexture(int x, int y)
    {
        if(textureSave.TryGetValue((x,y), out var texture)) return texture;
        return eNormalType.TYPE_TWO;
    }

    public static void AddTexture(int x, int y, eNormalType texture)
    {
        if (textureSave.ContainsKey((x, y))) return;
        textureSave.Add((x,y), texture);
    }

    public static void Clear() => textureSave.Clear();
}

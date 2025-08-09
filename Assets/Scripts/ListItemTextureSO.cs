using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListTextureItems", menuName = "Data/ListTexture")]
public class ListItemTextureSO : ScriptableObject
{
    [SerializeField] List<ItemTextureSO> list;
    private Dictionary<string, ItemTextureSO> dictTexture = new Dictionary<string, ItemTextureSO>();

    public Sprite GetSprite(string key, TypeTexture type)
    {
        if(dictTexture.TryGetValue(key, out var value)) return value.GetSprite(type);
        ItemTextureSO textureSO = list.Find(x => x.Key == key);
        dictTexture.Add(key, textureSO);
        return textureSO.GetSprite(type);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeTexture
{
    Food, Fish
}

[CreateAssetMenu(fileName = "TextureSO", menuName = "Data/Texture")]
public class ItemTextureSO : ScriptableObject
{
    [SerializeField] string namePrefab; 
    [SerializeField] List<ItemTexture> listTexture;
    private Dictionary<TypeTexture, Sprite> textureDict = new Dictionary<TypeTexture, Sprite>(); 

    public string Key => namePrefab;

    public Sprite GetSprite(TypeTexture key)
    {
        if(textureDict.TryGetValue(key, out Sprite value)) return value;
        Sprite sprite = listTexture.Find(x => x.Type == key).Sprite;
        textureDict.Add(key, sprite);
        return sprite;
    }
}

[Serializable]
public class ItemTexture
{
    [SerializeField] TypeTexture type;
    [SerializeField] Sprite sprite;

    public TypeTexture Type => type;
    public Sprite Sprite => sprite;
}

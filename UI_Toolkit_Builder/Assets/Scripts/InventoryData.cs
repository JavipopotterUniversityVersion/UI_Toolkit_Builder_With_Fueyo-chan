using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;


[System.Serializable]
public class PalData
{
    public string name;
    public string  description;
    public Color color;
    public Sprite shape;
    public Sprite face;

    public static bool operator==(PalData a, PalData b) {
        return a.name == b.name && a.description == b.description && a.color == b.color && a.shape == b.shape && a.face == b.face;
    }
    public static bool operator!=(PalData a, PalData b) {
        return !(a == b);
    }
    public override bool Equals(object obj) {
        if (obj is PalData pal) {
            return this == pal;
        }
        return false;
    }
    public override int GetHashCode() {
        return name.GetHashCode() ^ description.GetHashCode() ^ color.GetHashCode() ^ shape.GetHashCode() ^ face.GetHashCode();
    }

    public static Texture2D GetPalTexture(PalData pal) {
        Texture2D palTex = new Texture2D((int)pal.shape.textureRect.width, (int)pal.shape.textureRect.height);
        palTex.filterMode = FilterMode.Point;

        Sprite[] shape_and_face = new Sprite[2] {pal.shape, pal.face };

        for (int j = 0; j < shape_and_face.Length; j++)
        {
            for (int y = 0; y < shape_and_face[j].textureRect.height; y++)
            {
                for (int x = 0; x < shape_and_face[j].textureRect.width; x++)
                {
                    Color pixelColor = shape_and_face[j].texture.GetPixel((int)shape_and_face[j].textureRect.xMin + x, (int)shape_and_face[j].textureRect.yMin + y);
                    if(pixelColor.a != 0) {
                        if(j == 0) {
                            if(pixelColor == Color.white) pixelColor = pal.color;
                            palTex.SetPixel(x, y, pixelColor);
                        }
                        else {
                            palTex.SetPixel(x + (int)pal.shape.pivot.x - (int)pal.face.textureRect.width/2, y + (int)pal.shape.pivot.y - (int)pal.face.textureRect.height/2, pixelColor);
                        }
                    }
                    else {
                        if(j == 0) palTex.SetPixel(x, y, Color.clear);
                    }
                }
            }
        }

        palTex.Apply();
        return palTex;
    }
}

[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObjects/InventoryData", order = 1)]
public class InventoryData : ScriptableObject
{
    [SerializeField] List<PalData> palDataList = new List<PalData>();

    public void AddPal(PalData palData)
    {
        if (!palDataList.Contains(palData)) palDataList.Add(palData);
        else Debug.LogWarning("PalData already exists in the list.");

        SaveSystem.SaveGame();
    }

    public void RemovePal(PalData palData)
    {
        if (palDataList.Contains(palData)) palDataList.Remove(palData);
        else Debug.LogWarning("PalData not found in the list.");

        SaveSystem.SaveGame();
    }

    public List<PalData> GetPals() => palDataList;
    public bool HasPal(PalData palData) => palDataList.Contains(palData);
}

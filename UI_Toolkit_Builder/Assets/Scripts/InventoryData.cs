using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct PalData
{
    public string name;
    public string  description;
    public Sprite icon;
}

[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObjects/InventoryData", order = 1)]
public class InventoryData : ScriptableObject
{
    List<PalData> palDataList = new List<PalData>();

    public void AddPal(string name, string description, Sprite icon)
    {
        PalData newPalData = new PalData {
            name = name,
            description = description,
            icon = icon
        };
        palDataList.Add(newPalData);
    }

    public void RemovePal(PalData palData)
    {
        if (palDataList.Contains(palData)) palDataList.Remove(palData);
        else Debug.LogWarning("PalData not found in the list.");
    }

    public List<PalData> GetPals() => palDataList;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumball_Machine : MonoBehaviour
{
    [SerializeField] GameObject _palPrefab;
    [SerializeField] Transform _gachaPos;

    string[] _palNames = new string[] { "Fueyo", "Guillermo", "Diego", "Mika", "Chicho", "Hugo", "Marco", "Jordi", "Itadori", "Choso", "Mayte", "Anna", "Mariel", "Muxu", "Alex" };
    string[] _palSurnames = new string[] { "El Guay", "El Gordo", "El Chiquito", "El Grande", "El Enano", "El Alto", "El Bajo", "El Loco", "El Raro", "El Normal" };
    string[] _palDescriptions = new string[] { "A very smart guay, ", "Silly and funny, ", "It's gay," };
    string[] _palDescriptions2 = new string[] { "It likes playing chess", "He's a very good friend", "He likes to play with his friends", "Hates fascism", "Misogynist", "Loves to play with his friends" };

    [SerializeField] Sprite[] _palsShapes;
    [SerializeField] Sprite[] _palsFaces;

    PalData CreatePalData() {
        PalData newPal = new PalData();
        newPal.name = _palNames[Random.Range(0, _palNames.Length)] + " " + _palSurnames[Random.Range(0, _palSurnames.Length)];
        newPal.description = _palDescriptions[Random.Range(0, _palDescriptions.Length)] + _palDescriptions2[Random.Range(0, _palDescriptions2.Length)];
        newPal.shape = _palsShapes[Random.Range(0, _palsShapes.Length)];
        newPal.face = _palsFaces[Random.Range(0, _palsFaces.Length)];
        return newPal;
    }

    [ContextMenu("Create Pal")]
    public void CreatePal() {
        PalData newPal = CreatePalData();
        GameObject newPalObj = Instantiate(_palPrefab, _gachaPos.position, Quaternion.identity);
        newPalObj.GetComponent<Pal>().SetPal(newPal);
    }
}

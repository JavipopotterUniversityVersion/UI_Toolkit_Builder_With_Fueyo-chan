using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CityDocument : MonoBehaviour
{
    DocumentsManager _documentsManager;
    [SerializeField] Sprite[] _housesSprites;
    [SerializeField] InventoryData _equipedPals;
    void OnEnable() {
        _documentsManager = GetComponentInParent<DocumentsManager>();
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement gumball = root.Q("Gumball");
        gumball.RegisterCallback<ClickEvent>(evt => _documentsManager.OpenGachaDocument());
        VisualElement inventario = root.Q("Inventario");
        inventario.RegisterCallback<ClickEvent>(evt => _documentsManager.OpenInventoryDocument());

        VisualElement[] houses = root.Query(className: "house").ToList().ToArray();

        for (int i = 0; i < houses.Length; i++) {
            VisualElement house = houses[i];
            house.style.backgroundImage = new StyleBackground(_housesSprites[i]);
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement[] slots = root.Query(className: "slot").ToList().ToArray();
        List<PalData> pals = _equipedPals.GetPals();
        for(int i = 0; i < slots.Length; i++) {
            if(i >= pals.Count) {
                slots[i].style.backgroundImage = new StyleBackground();
            }else {
                VisualElement slot = slots[i];
                slot.Q<VisualElement>("Img").style.backgroundImage = new StyleBackground(PalData.GetPalTexture(pals[i]));
            }
        }
    }
}

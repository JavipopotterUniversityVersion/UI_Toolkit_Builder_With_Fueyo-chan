using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CityDocument : MonoBehaviour
{
    DocumentsManager _documentsManager;
    [SerializeField] Sprite[] _housesSprites;
    [SerializeField] InventoryData _equipedPals;
    VisualElement[] _slots;
    VisualElement _currentSlot;
    bool _isPalSelected => _currentSlot != null && _currentSlot.userData != null;

    void OnEnable() {
        _documentsManager = GetComponentInParent<DocumentsManager>();
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement gumball = root.Q("Gumball");
        gumball.RegisterCallback<ClickEvent>(evt => _documentsManager.OpenGachaDocument());
        VisualElement inventario = root.Q("Inventario");
        inventario.RegisterCallback<ClickEvent>(evt => _documentsManager.OpenInventoryDocument());
        _slots = root.Query(className: "slot").ToList().ToArray();

        VisualElement[] houses = root.Query(className: "house").ToList().ToArray();

        for (int i = 0; i < houses.Length; i++) {
            VisualElement house = houses[i];
            house.style.backgroundImage = new StyleBackground(_housesSprites[i]);

            house.RegisterCallback<MouseEnterEvent>(evt => {
                if(_isPalSelected) {
                    house.style.scale = new Vector2(1.1f, 1.1f);
                }
            });

            house.RegisterCallback<MouseLeaveEvent>(evt => {
                if(_isPalSelected) {
                    house.style.scale = new Vector2(1, 1);
                }
            });

            house.RegisterCallback<ClickEvent>(evt => {
                if(_isPalSelected) {
                    _equipedPals.RemovePal(_currentSlot.userData as PalData);
                    StartCoroutine(HouseAnimationTween(house));
                    house.style.scale = new Vector2(1, 1);
                    _currentSlot.style.backgroundColor = new StyleColor(Color.white);
                    UpdateUI();
                }
            });
        }

        foreach(VisualElement slot in _slots) {
            slot.RegisterCallback<ClickEvent>(evt => {
                if(slot.userData != null) {
                    if(_currentSlot != null) {
                        _currentSlot.style.backgroundColor = new StyleColor(Color.white);
                    }
                    _currentSlot = slot;
                    slot.style.backgroundColor = new StyleColor(Color.yellow);
                }
            });

            slot.style.backgroundColor = new StyleColor(Color.white);

            slot.RegisterCallback<MouseEnterEvent>(evt => {
                 if(slot != _currentSlot) slot.style.backgroundColor = new StyleColor(Color.gray);
            });

            slot.RegisterCallback<MouseLeaveEvent>(evt => {
                if(slot != _currentSlot) slot.style.backgroundColor = new StyleColor(Color.white);
            });
        }

        UpdateUI();
    }

    IEnumerator HouseAnimationTween(VisualElement house) {
        float TIME = Random.Range(3f, 7f);
        float elapsedTime = 0f;
        Vector2 SCALE_0 = Vector2.one;
        Vector2 SCALE_1 = new Vector2(1.1f, 1.1f);
        float t;

        while (elapsedTime < TIME) {
            elapsedTime += Time.deltaTime;

            t = Mathf.PingPong(elapsedTime, 1);

            house.style.scale = new Vector2(Mathf.Lerp(SCALE_0.x, SCALE_1.x, t), Mathf.Lerp(SCALE_0.y, SCALE_1.y, t));
            yield return new WaitForEndOfFrame();
        }

        _documentsManager.AddMoney(1);
    }

    public void UpdateUI()
    {
        List<PalData> pals = _equipedPals.GetPals();
        for(int i = 0; i < _slots.Length; i++) {
            if(i >= pals.Count) {
                _slots[i].Q<VisualElement>("Img").style.backgroundImage = new StyleBackground();
                _slots[i].userData = null;
            }else {
                VisualElement slot = _slots[i];
                slot.Q<VisualElement>("Img").style.backgroundImage = new StyleBackground(PalData.GetPalTexture(pals[i]));
                slot.Q<VisualElement>("Img").pickingMode = PickingMode.Ignore;
                slot.userData = pals[i];
            }
        }
    }
}

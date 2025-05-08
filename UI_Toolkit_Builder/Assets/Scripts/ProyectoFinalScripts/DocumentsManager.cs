using System.Collections;
using System.Collections.Generic;
using System.IO;
using proyecto_final;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DocumentsManager : MonoBehaviour
{
    [SerializeField] int _money;
    [SerializeField] UIDocument _inventoryDocument;
    [SerializeField] UIDocument _gachaDocument;
    [SerializeField] UIDocument _cityDocument;

    [SerializeField] Notification _notificationDocument;

    void UpdateMoneyUI() {
        _inventoryDocument.rootVisualElement.Q<Label>("Money").text = _money.ToString() + " $";
        _gachaDocument.rootVisualElement.Q<Label>("Money").text = _money.ToString() + " $";
        _cityDocument.rootVisualElement.Q<Label>("Money").text = _money.ToString() + " $";
    }

    public void AddMoney(int amount) {
        _money += amount;
        SaveSystem.SaveInt("Money", _money);
        UpdateMoneyUI();
    }

    public int GetMoney() {
        return _money;
    }

    public void RemoveMoney(int amount) {
        _money -= amount;
        SaveSystem.SaveInt("Money", _money);
        UpdateMoneyUI();
    }

    private void OnEnable() {
        _money = SaveSystem.LoadInt("Money", 0);
        OpenInventoryDocument();
        UpdateMoneyUI();
    }

    public void Notify(string title, string description, UnityAction callback = null)
    {
        _notificationDocument.Notify(title, description, callback);
    }

    public void OpenInventoryDocument()
    {
        _inventoryDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        _gachaDocument.rootVisualElement.style.display = DisplayStyle.None;
        _cityDocument.rootVisualElement.style.display = DisplayStyle.None;
        _inventoryDocument.GetComponent<Inventory>().UpdateUI();
    }

    public void OpenGachaDocument()
    {
        _inventoryDocument.rootVisualElement.style.display = DisplayStyle.None;
        _gachaDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        _cityDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void OpenCityDocument()
    {
        _inventoryDocument.rootVisualElement.style.display = DisplayStyle.None;
        _gachaDocument.rootVisualElement.style.display = DisplayStyle.None;
        _cityDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        _cityDocument.GetComponent<CityDocument>().UpdateUI();
    }
}

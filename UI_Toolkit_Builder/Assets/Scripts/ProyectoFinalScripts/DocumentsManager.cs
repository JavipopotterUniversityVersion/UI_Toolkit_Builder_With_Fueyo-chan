using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DocumentsManager : MonoBehaviour
{
    [SerializeField] UIDocument _inventoryDocument;
    [SerializeField] UIDocument _gachaDocument;
    [SerializeField] UIDocument _cityDocument;

    [SerializeField] Notification _notificationDocument;

    public void Notify(string title, string description, UnityAction callback = null)
    {
        _notificationDocument.Notify(title, description, callback);
    }

    public void OpenInventoryDocument()
    {
        _inventoryDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        _gachaDocument.rootVisualElement.style.display = DisplayStyle.None;
        _cityDocument.rootVisualElement.style.display = DisplayStyle.None;
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
    }
}

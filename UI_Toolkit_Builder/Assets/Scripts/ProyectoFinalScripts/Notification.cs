using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Notification : MonoBehaviour
{
    UIDocument _uiDocument;
    Label _title;
    Label _description;

    private void Awake() {
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void OnEnable() {
        VisualElement root = _uiDocument.rootVisualElement;

        _title = root.Q<Label>("title");
        _description = root.Q<Label>("description");
    }

    public void Notify(string title, string description, UnityAction callback = null)
    {
        _title.text = title;
        _description.text = description;

        StartCoroutine(ShowNotification(callback));
    }

    IEnumerator ShowNotification(UnityAction callback = null)
    {
        _uiDocument.rootVisualElement.style.display = DisplayStyle.Flex;

        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            _uiDocument.rootVisualElement.style.opacity = i;
            yield return new WaitForEndOfFrame();
        }

        _uiDocument.rootVisualElement.style.opacity = 1;
        yield return new WaitForSeconds(2f);

        for (float i = 1; i > 0; i -= Time.deltaTime)
        {
            _uiDocument.rootVisualElement.style.opacity = i;
            yield return new WaitForEndOfFrame();
        }

        _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
        callback?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class IgnoreVisualElements : MonoBehaviour
{
    [SerializeField] string[] ignoreElements;
    private void OnEnable() {
        UIDocument uiDoc = GetComponent<UIDocument>();
        VisualElement root = uiDoc.rootVisualElement;

        foreach (string elementName in ignoreElements)
        {
            VisualElement element = root.Q<VisualElement>(elementName);
            if (element != null) element.pickingMode = PickingMode.Ignore;
            else Debug.LogWarning($"Element '{elementName}' not found in the UI Document.");
        }
    }
}

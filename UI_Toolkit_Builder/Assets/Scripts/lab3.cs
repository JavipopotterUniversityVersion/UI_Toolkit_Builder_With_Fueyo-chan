using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class lab3 : MonoBehaviour
{
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement container = root.Q<VisualElement>("Container");
        container.Query<VisualElement>("item1").ForEach(elem =>
        {
            elem.AddManipulator(new Lab3Manipulator());
            elem.AddManipulator(new Lab3Dragger());
            elem.AddManipulator(new Lab3Resizer());
        });
    }
}

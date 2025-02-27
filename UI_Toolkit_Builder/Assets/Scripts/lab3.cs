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
        container.Query<VisualElement>("Row").ForEach(row =>
        {
            row.RegisterCallback<ClickEvent>(evt =>
            {
                var target = (evt.target as VisualElement);
                if (target != row)
                {
                    //target.style.backgroundColor = new Color(0.5f, 0.5f, 0.5f);
                    
                }
            }, TrickleDown.TrickleDown);

            List<VisualElement> rowElems = row.Children().ToList();
            rowElems.ForEach(elem => {
                elem.AddManipulator(new Lab3Manipulator());
                });
        });
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab4d : VisualElement
{
    public new class UxmlFactory : UxmlFactory<Lab4d, UxmlTraits> { }

    int elementCount = 0;
    public int ElementCount
    {
        get => elementCount;
        set
        {
            elementCount = value;
            UpdateElements();
        }
    }

    int currentElements = 0;
    public int CurrentElements
    {
        get => currentElements;
        set
        {
            currentElements = Math.Clamp(value, 0, elementCount);
            UpdateElements();
        }
    }

    string imageTexture = "";
    public string ImageTexture
    {
        get => imageTexture;
        set
        {
            imageTexture = value;
            UpdateElements();
        }
    }

    public Lab4d()
    {
        UpdateElements();
    }

    void UpdateElements()
    {
        styleSheets.Add(Resources.Load<StyleSheet>("Lab4"));
        Clear();
        for (int i = 0; i < elementCount; i++)
        {
            var elem = new VisualElement();
            elem.style.backgroundImage = Resources.Load<Texture2D>(imageTexture);

            if(i > currentElements - 1) elem.AddToClassList("semi-transparent");

            elem.AddToClassList("atribute");
            Add(elem);
        }
    }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription m_ElementCount = new UxmlIntAttributeDescription { name = "elementCount", defaultValue = 0 };
        UxmlStringAttributeDescription m_ImageTexture = new UxmlStringAttributeDescription { name = "imageTexture", defaultValue = "apple_pie" };
        UxmlIntAttributeDescription m_CurrentElements = new UxmlIntAttributeDescription { name = "currentElements", defaultValue = 0 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);

            var lab4d = (Lab4d)ve;
            lab4d.ElementCount = m_ElementCount.GetValueFromBag(bag, cc);
            lab4d.ImageTexture = m_ImageTexture.GetValueFromBag(bag, cc);
            lab4d.CurrentElements = m_CurrentElements.GetValueFromBag(bag, cc);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab3Manipulator : MouseManipulator
{
    public Lab3Manipulator()
    {
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.RightMouse });
    }
    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseDownEvent>(MouseDown, TrickleDown.TrickleDown);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseDownEvent>(MouseDown, TrickleDown.TrickleDown);
    }

    void MouseDown(MouseDownEvent clk)
    {
        Debug.Log(target.name + ": Click en Elemento");
        if (CanStartManipulation(clk))
        {
            Debug.Log("a");
            target.style.borderBottomColor = new Color(1, 1, 1, 1);
            target.style.borderTopColor = new Color(1, 1, 1, 1);
            target.style.borderLeftColor = new Color(1, 1, 1, 1);
            target.style.borderRightColor = new Color(1, 1, 1, 1);
            clk.StopPropagation();
        }
    }
}

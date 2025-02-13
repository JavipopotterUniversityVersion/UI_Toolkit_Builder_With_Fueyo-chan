using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public struct PestCont
{
    public VisualElement pest;
    public VisualElement cont;
}

public class Lab2 : MonoBehaviour
{
    PestCont[] lista_pc = new PestCont[3];

    private void OnEnable() {
        UIDocument uiDoc = GetComponent<UIDocument>();
        VisualElement root = uiDoc.rootVisualElement;

        VisualElement pestanyas = root.Q<VisualElement>("Pestanyas");
        VisualElement contenido = root.Q<VisualElement>("Contenido");

        lista_pc[0].pest = pestanyas.Q<VisualElement>("Azul");
        Label texto = lista_pc[0].pest.Q<Label>("Texto");
        texto.text = @"<rotate=""2"">Inventario</rotate>";
        lista_pc[0].cont = contenido.Q<VisualElement>("Azul");

        lista_pc[1].pest = pestanyas.Q<VisualElement>("Rojo");
        texto = lista_pc[1].pest.Q<Label>("Texto");
        texto.text = @"<b><gradient=""Fueyo"">Mejoras</gradient></b>";
        lista_pc[1].cont = contenido.Q<VisualElement>("Rojo");

        lista_pc[2].pest = pestanyas.Q<VisualElement>("Verde");
        texto = lista_pc[2].pest.Q<Label>("Texto");
        texto.text = @"Estadísticas";
        lista_pc[2].cont = contenido.Q<VisualElement>("Verde");

        foreach (PestCont pc in lista_pc)
        {
            pc.pest.RegisterCallback<MouseDownEvent>(e => {
                NoContenido();
                pc.cont.style.display = DisplayStyle.Flex;
            });
        }
    }

    void NoContenido()
    {
        foreach (PestCont pc in lista_pc)
        {
            pc.cont.style.display = DisplayStyle.None;
        }
    }
}

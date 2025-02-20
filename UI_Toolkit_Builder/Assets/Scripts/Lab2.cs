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

        VisualElement contenido = root.Q<VisualElement>("Contenido");
        VisualElement pestanyas = contenido.Q<VisualElement>("Pestanyas");
        List<VisualElement> returnButtons = new List<VisualElement>();

        lista_pc[0].pest = pestanyas.Q<VisualElement>("Azul");
        lista_pc[0].cont = contenido.Q<VisualElement>("Azul");
        returnButtons.Add(lista_pc[0].cont.Q<VisualElement>("return"));

        Label texto = lista_pc[0].pest.Q<Label>("Texto");
        texto.text = @"<rotate=""2"">Inventario</rotate>";


        lista_pc[1].pest = pestanyas.Q<VisualElement>("Rojo");
        lista_pc[1].cont = contenido.Q<VisualElement>("Rojo");
        returnButtons.Add(lista_pc[1].cont.Q<VisualElement>("return"));

        texto = lista_pc[1].pest.Q<Label>("Texto");
        texto.text = @"<b><gradient=""Fueyo"">Mejoras</gradient></b>";


        lista_pc[2].pest = pestanyas.Q<VisualElement>("Verde");
        lista_pc[2].cont = contenido.Q<VisualElement>("Verde");
        returnButtons.Add(lista_pc[2].cont.Q<VisualElement>("return"));

        texto = lista_pc[2].pest.Q<Label>("Texto");
        texto.text = @"Estadísticas";

        foreach (PestCont pc in lista_pc)
        {
            pc.pest.RegisterCallback<MouseDownEvent>(e => {
                pestanyas.style.display = DisplayStyle.None;
                NoContenido();
                pc.cont.style.display = DisplayStyle.Flex;
            });
        }

        foreach (VisualElement ret in returnButtons)
        {
            ret.RegisterCallback<MouseDownEvent>(e => {
                NoContenido();
                pestanyas.style.display = DisplayStyle.Flex;
            });
        }

        VisualElement mslider = root.Q<Slider>("sorroco");
        mslider.style.backgroundColor = Color.gray;

        VisualElement mtracker = root.Q<VisualElement>("unity-tracker");
        mtracker.style.backgroundColor = Color.yellow;

        //Label sliderText = mslider.Q<Label>("Label");
        //sliderText.text = @"<color=""FF00FF"">Dificultad</color>";
        //sliderText.style.fontSize = 16;
    }

    void NoContenido()
    {
        foreach (PestCont pc in lista_pc)
        {
            pc.cont.style.display = DisplayStyle.None;
        }
    }
}

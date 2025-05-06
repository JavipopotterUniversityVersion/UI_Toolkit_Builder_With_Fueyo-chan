using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lab6_namespace
{
    public class Lab6 : MonoBehaviour
    {
        VisualElement botonCrear;
        Toggle toggleModificar;
        VisualElement contenedor_dcha;
        VisualElement fotos_izq;
        VisualElement selec_foto;
        TextField input_nombre;
        TextField input_apellido;
        Individuo individuoSelec;
        List<Individuo> lista_individuos = new List<Individuo>();
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            fotos_izq = root.Q<VisualElement>("top");
            selec_foto = fotos_izq.Children().First<VisualElement>();
            contenedor_dcha = root.Q<VisualElement>("Dcha");
            input_nombre = root.Q<TextField>("InputNombre");
            input_apellido = root.Q<TextField>("InputApellido");
            botonCrear = root.Q<Button>("BotonCrear");
            toggleModificar = root.Q<Toggle>("ToggleModificar");

            contenedor_dcha.RegisterCallback<ClickEvent>(seleccionTarjeta);
            fotos_izq.RegisterCallback<ClickEvent>(CambioFoto);
            botonCrear.RegisterCallback<ClickEvent>(NuevaTarjeta);
            input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);
        }

        void NuevaTarjeta(ClickEvent evt)
        {
            if (!toggleModificar.value)
            {
                VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Lab6_Tarjeta");

                VisualElement tarjetaPlantilla = plantilla.Instantiate();

                contenedor_dcha.Add(tarjetaPlantilla);
                tarjetas_borde_negro();
                tarjeta_borde_blanco(tarjetaPlantilla);

                Individuo individuo = new Individuo(input_nombre.value, input_apellido.value, selec_foto.resolvedStyle.backgroundImage);
                Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, individuo);
                individuoSelec = individuo;

                lista_individuos.Add(individuo);
                
                string listaToJson = JsonHelperIndividuo.ToJson(lista_individuos, true);
                
                List<Individuo> jsonToLista = JsonHelperIndividuo.FromJson<Individuo>(listaToJson);
                //jsonToLista.ForEach(elem =>
                //{
                //    Debug.Log(elem.Nombre + " " + elem.Apellido);
                //});
            }
        }

        void seleccionTarjeta(ClickEvent e)
        {
            VisualElement miTarjeta = e.target as VisualElement;
            individuoSelec = miTarjeta.userData as Individuo;

            input_nombre.SetValueWithoutNotify(individuoSelec.Nombre);
            input_apellido.SetValueWithoutNotify(individuoSelec.Apellido);
            toggleModificar.value = true;

            tarjetas_borde_negro();
            tarjeta_borde_blanco(miTarjeta);
        }
        void CambioNombre(ChangeEvent<string> evt)
        {
            if (toggleModificar.value)
            {
                individuoSelec.Nombre = evt.newValue;
            }
        }

        void CambioApellido(ChangeEvent<string> evt)
        {
            if (toggleModificar.value)
            {
                individuoSelec.Apellido = evt.newValue;
            }
        }
        void CambioFoto(ClickEvent evt)
        {
            Debug.Log("Llega");
            selec_foto.style.borderBottomColor = Color.black;
            selec_foto.style.borderRightColor = Color.black;
            selec_foto.style.borderTopColor = Color.black;
            selec_foto.style.borderLeftColor = Color.black;
            VisualElement target = evt.target as VisualElement;
            selec_foto = target;
            target.style.borderBottomColor = Color.white;
            target.style.borderRightColor = Color.white;
            target.style.borderTopColor = Color.white;
            target.style.borderLeftColor = Color.white;
            if (toggleModificar.value)
            {
                individuoSelec.Image = target.resolvedStyle.backgroundImage;
            }
        }

        void tarjetas_borde_negro()
        {
            List<VisualElement> lista_tarjetas = contenedor_dcha.Children().ToList();
            lista_tarjetas.ForEach(elem =>
            {
                VisualElement tarjeta = elem.Q("plantilla");

                tarjeta.style.borderBottomColor = Color.black;
                tarjeta.style.borderRightColor = Color.black;
                tarjeta.style.borderTopColor = Color.black;
                tarjeta.style.borderLeftColor = Color.black;
            });
        }

        void tarjeta_borde_blanco(VisualElement tar)
        {
            VisualElement tarjeta = tar.Q("plantilla");

            tarjeta.style.borderBottomColor = Color.white;
            tarjeta.style.borderRightColor = Color.white;
            tarjeta.style.borderTopColor = Color.white;
            tarjeta.style.borderLeftColor = Color.white;
        }
    }
}

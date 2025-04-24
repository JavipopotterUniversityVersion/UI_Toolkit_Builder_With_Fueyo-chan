using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace proyecto_final
{
    public class Tarjeta
    {
        Individuo miIndividuo;
        VisualElement tarjetaRoot;

        Label nombreLabel;
        Label descripcionLabel;
        VisualElement imagenVE;

        public Tarjeta(VisualElement tarjetaRoot, Individuo individuo)
        {
            this.tarjetaRoot = tarjetaRoot;
            this.miIndividuo = individuo;

            nombreLabel = tarjetaRoot.Q<Label>("nombre");
            descripcionLabel = tarjetaRoot.Q<Label>("descripcion");
            imagenVE = tarjetaRoot.Q("top");
            tarjetaRoot.userData = individuo;

            tarjetaRoot
                .Query(className: "tarjeta")
                .Descendents<VisualElement>()
                .ForEach(elem => elem.pickingMode = PickingMode.Ignore);
            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }

        void UpdateUI()
        {
            nombreLabel.text = miIndividuo.Nombre;
            descripcionLabel.text = miIndividuo.Descripcion;
            imagenVE.style.backgroundImage = miIndividuo.Image;
        }
    }
}

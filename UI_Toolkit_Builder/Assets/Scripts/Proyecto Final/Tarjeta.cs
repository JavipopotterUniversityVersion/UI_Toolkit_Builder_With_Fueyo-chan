using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace proyecto_final
{
    public class Tarjeta
    {
        PalData miPal;
        VisualElement tarjetaRoot;

        Label nombreLabel;
        Label descripcionLabel;
        VisualElement imagenVE;

        public Tarjeta(VisualElement tarjetaRoot, PalData pal)
        {
            this.tarjetaRoot = tarjetaRoot;
            this.miPal = pal;

            nombreLabel = tarjetaRoot.Q<Label>("nombre");
            descripcionLabel = tarjetaRoot.Q<Label>("descripcion");
            imagenVE = tarjetaRoot.Q("foto");
            tarjetaRoot.userData = pal;

            tarjetaRoot
                .Query(className: "tarjeta")
                .Descendents<VisualElement>()
                .ForEach(elem => elem.pickingMode = PickingMode.Ignore);
        }
    }
}

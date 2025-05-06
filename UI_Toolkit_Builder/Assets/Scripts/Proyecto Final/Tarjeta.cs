using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace proyecto_final
{
    public class Tarjeta
    {
        public PalData miPal;

        public Tarjeta(VisualElement tarjetaRoot, PalData pal)
        {
            miPal = pal;

            tarjetaRoot.userData = this;

            tarjetaRoot
                .Query(className: "tarjeta")
                .Descendents<VisualElement>()
                .ForEach(elem => elem.pickingMode = PickingMode.Ignore);
        }
    }
}

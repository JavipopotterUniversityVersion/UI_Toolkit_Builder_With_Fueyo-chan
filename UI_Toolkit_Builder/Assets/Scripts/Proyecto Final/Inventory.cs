using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace proyecto_final
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] InventoryData _palsInventory;
        PalData selectedPal;

        List<VisualElement> tarjetas = new List<VisualElement>();

        Label nombre_elegido;
        Label desc_elegida;
        VisualElement fotoSelec;

        DocumentsManager documentsManager;

        private void OnEnable()
        {
            documentsManager = GetComponentInParent<DocumentsManager>();
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            tarjetas = root.Query(className: "tarjeta").ToList();

            fotoSelec = root.Q("fotoSelec");
            //images.ForEach(elem => elem.RegisterCallback<ClickEvent>(CambioImagen));

            nombre_elegido = root.Q<Label>("nombre");
            desc_elegida = root.Q<Label>("descripcion");

            VisualElement panelDcha = root.Q("derecha");
            panelDcha.RegisterCallback<ClickEvent>(seleccionTarjeta);

            VisualElement gumball = root.Q("Gumball");
            gumball.RegisterCallback<ClickEvent>(evt => documentsManager.OpenGachaDocument());
            VisualElement ciudad = root.Q("City");
            ciudad.RegisterCallback<ClickEvent>(evt => documentsManager.OpenCityDocument());

            //nombre_elegido.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            //desc_elegida.RegisterCallback<ChangeEvent<string>>(CambioApellido);

            UpdateUI();
        }

        //void CambioNombre(ChangeEvent<string> evt)
        //{
        //    selecIndividuo.Nombre = evt.newValue;
        //}

        //void CambioApellido(ChangeEvent<string> evt)
        //{
        //    selecIndividuo.Descripcion = evt.newValue;
        //}

        //void CambioImagen(ClickEvent evt)
        //{
        //    VisualElement target = evt.target as VisualElement;
        //    selecIndividuo.Image = target.resolvedStyle.backgroundImage;
        //}

        void seleccionTarjeta(ClickEvent evt)
        {
            VisualElement tarjeta = evt.target as VisualElement;
            selectedPal = tarjeta.userData as PalData;
            if (selectedPal == null) return;

            nombre_elegido.text = selectedPal.name;
            desc_elegida.text = selectedPal.description;
        }

        public void UpdateUI()
        {
            List<PalData> _pals = _palsInventory.GetPals();
            for(int i = 0; i < _pals.Count; i++)
            {
                PalData pal = _pals[i];
                VisualElement tarjeta = tarjetas[i];
                tarjeta.userData = new Tarjeta(tarjeta, pal);
                
                Texture2D palTex = PalData.GetPalTexture(pal);

                tarjeta.Q("shape").style.backgroundImage = new StyleBackground(palTex);
            }
        }
    }
}

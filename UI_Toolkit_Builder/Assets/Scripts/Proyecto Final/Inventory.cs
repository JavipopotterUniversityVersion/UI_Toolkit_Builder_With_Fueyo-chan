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
        [SerializeField] InventoryData _equippedPals;
        Tarjeta _selectedTarjeta;

        List<VisualElement> tarjetas = new List<VisualElement>();

        Label nombre_elegido;
        Label desc_elegida;
        VisualElement fotoSelec;

        DocumentsManager documentsManager;
        UnityEngine.UIElements.Button _addToEquip;

        private void OnEnable()
        {
            documentsManager = GetComponentInParent<DocumentsManager>();
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            tarjetas = root.Query(className: "tarjeta").ToList();

            fotoSelec = root.Q("fotoSelec");

            nombre_elegido = root.Q<Label>("nombre");
            desc_elegida = root.Q<Label>("descripcion");

            VisualElement panelDcha = root.Q("derecha");
            panelDcha.RegisterCallback<ClickEvent>(seleccionTarjeta);

            VisualElement gumball = root.Q("Gumball");
            gumball.RegisterCallback<ClickEvent>(evt => documentsManager.OpenGachaDocument());
            VisualElement ciudad = root.Q("City");
            ciudad.RegisterCallback<ClickEvent>(evt => documentsManager.OpenCityDocument());

            _addToEquip = root.Q<UnityEngine.UIElements.Button>("addToEquip");
            _addToEquip.RegisterCallback<ClickEvent>(evt =>
            {
                if (_selectedTarjeta == null) return;
                PalData pal = _selectedTarjeta.miPal;

                if(_equippedPals.HasPal(pal) == false)
                {
                    _equippedPals.AddPal(pal);
                    _addToEquip.text = "Quitar";
                }
                else
                {
                    _equippedPals.RemovePal(pal);
                    _addToEquip.text = "Equipar";
                }
                UpdateEquipedPalsUI();
            });

            VisualElement[] slots = root.Query(className: "slot").ToList().ToArray();

            VisualElement deleteButton = root.Q("Delete");
            deleteButton.RegisterCallback<ClickEvent>(evt =>
            {
                if (_selectedTarjeta == null) return;
                PalData pal = _selectedTarjeta.miPal;
                _palsInventory.RemovePal(pal);
                if(_equippedPals.HasPal(pal)) _equippedPals.RemovePal(pal);
                _selectedTarjeta = null;
                fotoSelec.style.backgroundImage = new StyleBackground();
                UpdateEquipedPalsUI();
                UpdateUI();
            });

            UpdateEquipedPalsUI();
            UpdateUI();
        }

        void seleccionTarjeta(ClickEvent evt)
        {
            VisualElement tarjeta = evt.target as VisualElement;
            _selectedTarjeta = tarjeta.userData as Tarjeta;
            if (_selectedTarjeta == null) return;

            nombre_elegido.text = _selectedTarjeta.miPal.name;
            desc_elegida.text = _selectedTarjeta.miPal.description;
            fotoSelec.style.backgroundImage = new StyleBackground(PalData.GetPalTexture(_selectedTarjeta.miPal));

            if(_equippedPals.HasPal(_selectedTarjeta.miPal))
            {
                _addToEquip.text = "Quitar";
            }
            else
            {
                _addToEquip.text = "Equipar";
            }
            UpdateEquipedPalsUI();
        }

        public void UpdateUI()
        {
            List<PalData> _pals = _palsInventory.GetPals();
            for(int i = 0; i < tarjetas.Count; i++)
            {
                if(i >= _pals.Count){
                    VisualElement tarjeta = tarjetas[i];
                    
                    tarjeta.Q("shape").style.backgroundImage = new StyleBackground();
                    tarjeta.userData = null;
                } else {
                    PalData pal = _pals[i];
                    VisualElement tarjeta = tarjetas[i];
                    tarjeta.userData = new Tarjeta(tarjeta, pal);
                    
                    Texture2D palTex = PalData.GetPalTexture(pal);
                    tarjeta.Q("shape").style.backgroundImage = new StyleBackground(palTex);
                }
            }
        }

        public void UpdateEquipedPalsUI()
        {
            VisualElement[] slots = GetComponent<UIDocument>().rootVisualElement.Query(className: "slot").ToList().ToArray();
            PalData[] pals = _equippedPals.GetPals().ToArray();
            for (int i = 0; i < slots.Length; i++)
            {
                VisualElement slot = slots[i];
                if (i >= pals.Length) slot.Q<VisualElement>("Img").style.backgroundImage = new StyleBackground();
                else slot.Q<VisualElement>("Img").style.backgroundImage = new StyleBackground(PalData.GetPalTexture(pals[i]));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

            // _pals = BaseDatos.getData();

            VisualElement panelDcha = root.Q("derecha");
            panelDcha.RegisterCallback<ClickEvent>(seleccionTarjeta);

            VisualElement gumball = root.Q("Gumball");
            gumball.RegisterCallback<ClickEvent>(evt => documentsManager.OpenGachaDocument());
            VisualElement ciudad = root.Q("City");
            ciudad.RegisterCallback<ClickEvent>(evt => documentsManager.OpenCityDocument());

            //nombre_elegido.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            //desc_elegida.RegisterCallback<ChangeEvent<string>>(CambioApellido);

            InitializeUI();
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

        void InitializeUI()
        {
            List<PalData> _pals = _palsInventory.GetPals();
            for(int i = 0; i < _pals.Count; i++)
            {
                PalData pal = _pals[i];
                VisualElement tarjeta = tarjetas[i];
                tarjeta.userData = new Tarjeta(tarjeta, pal);
                Texture2D palTex = new Texture2D((int)pal.shape.textureRect.width, (int)pal.shape.textureRect.height);
                palTex.filterMode = FilterMode.Point;

                Sprite[] shape_and_face = new Sprite[2] {pal.shape, pal.face };

                for (int j = 0; j < shape_and_face.Length; j++)
                {
                    for (int y = 0; y < shape_and_face[j].textureRect.height; y++)
                    {
                        for (int x = 0; x < shape_and_face[j].textureRect.width; x++)
                        {
                            Color pixelColor = shape_and_face[j].texture.GetPixel((int)shape_and_face[j].textureRect.xMin + x, (int)shape_and_face[j].textureRect.yMin + y);
                            if(pixelColor.a != 0) {
                                if(j == 0) {
                                    palTex.SetPixel(x, y, pixelColor);
                                }
                                else {
                                    palTex.SetPixel((int)pal.shape.pivot.x + x - (int)pal.face.textureRect.x, (int)pal.shape.pivot.y + y - (int)pal.face.textureRect.y, pixelColor);
                                }
                            }
                        }
                    }
                }

                palTex.Apply();

                tarjeta.Q("shape").style.backgroundImage = new StyleBackground(palTex);
                // tarjeta.Q("shape").style.backgroundColor = new StyleColor(pal.color);
                // tarjeta.Q("face").style.backgroundImage = new StyleBackground(pal.face);
            }
        }
    }
}

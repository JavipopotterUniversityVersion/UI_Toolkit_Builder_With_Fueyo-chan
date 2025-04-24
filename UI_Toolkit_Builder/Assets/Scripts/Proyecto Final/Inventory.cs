using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace proyecto_final
{
    public class Inventory : MonoBehaviour
    {
        List<Individuo> individuos;
        Individuo selecIndividuo;

        VisualElement tarjeta1;
        VisualElement tarjeta2;
        VisualElement tarjeta3;
        VisualElement tarjeta4;
        VisualElement tarjeta5;
        VisualElement tarjeta6;
        VisualElement tarjeta7;
        VisualElement tarjeta8;
        VisualElement tarjeta9;
        VisualElement tarjeta10;
        VisualElement tarjeta11;
        VisualElement tarjeta12;
        VisualElement tarjeta13;
        VisualElement tarjeta14;
        VisualElement tarjeta15;
        VisualElement tarjeta16;

        Label nombre_elegido;
        Label desc_elegida;
        VisualElement fotoSelec;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            tarjeta1 = root.Q("tarjeta1");
            tarjeta2 = root.Q("tarjeta2");
            tarjeta3 = root.Q("tarjeta3");
            tarjeta4 = root.Q("tarjeta4");
            tarjeta5 = root.Q("tarjeta5");
            tarjeta6 = root.Q("tarjeta6");
            tarjeta7 = root.Q("tarjeta7");
            tarjeta8 = root.Q("tarjeta8");
            tarjeta9 = root.Q("tarjeta9");
            tarjeta10 = root.Q("tarjeta10");
            tarjeta11 = root.Q("tarjeta11");
            tarjeta12 = root.Q("tarjeta12");
            tarjeta13 = root.Q("tarjeta13");
            tarjeta14 = root.Q("tarjeta14");
            tarjeta15 = root.Q("tarjeta15");
            tarjeta16 = root.Q("tarjeta16");

            fotoSelec = root.Q("fotoSelec");
            //images.ForEach(elem => elem.RegisterCallback<ClickEvent>(CambioImagen));

            nombre_elegido = root.Q<Label>("nombre");
            desc_elegida = root.Q<Label>("descripcion");

            individuos = BaseDatos.getData();

            VisualElement panelDcha = root.Q("derecha");
            panelDcha.RegisterCallback<ClickEvent>(seleccionTarjeta);

            //nombre_elegido.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            //desc_elegida.RegisterCallback<ChangeEvent<string>>(CambioApellido);

            regIndividuos();

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
            selecIndividuo = tarjeta.userData as Individuo;
            if (selecIndividuo == null) return;

            nombre_elegido.text = selecIndividuo.Nombre;
            desc_elegida.text = selecIndividuo.Descripcion;
            fotoSelec.style.backgroundImage = selecIndividuo.Image;
        }

        void InitializeUI()
        {
            Tarjeta tar1 = new Tarjeta(tarjeta1, individuos[0]);
            Tarjeta tar2 = new Tarjeta(tarjeta2, individuos[1]);
            Tarjeta tar3 = new Tarjeta(tarjeta3, individuos[2]);
            Tarjeta tar4 = new Tarjeta(tarjeta4, individuos[3]);
            Tarjeta tar5 = new Tarjeta(tarjeta5, individuos[4]);
            Tarjeta tar6 = new Tarjeta(tarjeta6, individuos[5]);
            Tarjeta tar7 = new Tarjeta(tarjeta7, individuos[6]);
            Tarjeta tar8 = new Tarjeta(tarjeta8, individuos[7]);
            Tarjeta tar9 = new Tarjeta(tarjeta9, individuos[8]);
            Tarjeta tar10 = new Tarjeta(tarjeta10, individuos[9]);
            Tarjeta tar11 = new Tarjeta(tarjeta11, individuos[10]);
            Tarjeta tar12 = new Tarjeta(tarjeta12, individuos[11]);
            Tarjeta tar13 = new Tarjeta(tarjeta13, individuos[12]);
            Tarjeta tar14 = new Tarjeta(tarjeta14, individuos[13]);
            Tarjeta tar15 = new Tarjeta(tarjeta15, individuos[14]);
            Tarjeta tar16 = new Tarjeta(tarjeta16, individuos[15]);
        }

        void regIndividuos()
        {
            //Individuo ind = new Individuo("Saracatunga", "aaaaaaaaaaaaaaaaaaaaaaa", tarjeta1.style.backgroundImage);
            //individuos[0] = ind;
        }
    }
}

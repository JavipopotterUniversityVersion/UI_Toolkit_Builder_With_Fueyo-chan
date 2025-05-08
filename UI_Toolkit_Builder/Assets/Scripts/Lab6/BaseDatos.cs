using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lab6_namespace;
using UnityEngine.UIElements;
using System.IO;

namespace Lab6_namespace
{
    public class BaseDatos
    {
        public List<Individuo> getData(VisualElement contenedor_dcha)
        {
            List<Individuo> datos = new List<Individuo>();

            Texture2D texture = Resources.Load<Texture2D>("apple_pie");

            string dataPath = Application.persistentDataPath + Path.DirectorySeparatorChar + "save.json";
            
            if (File.Exists(dataPath))
            {
                StreamReader reader = new StreamReader(dataPath);
                string jsonFile = reader.ReadToEnd();
                List<Individuo> jsonToLista = JsonHelperIndividuo.FromJson<Individuo>(jsonFile);

                jsonToLista.ForEach(elem =>
                {
                    VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Lab6_Tarjeta");

                    VisualElement tarjetaPlantilla = plantilla.Instantiate();

                    contenedor_dcha.Add(tarjetaPlantilla);

                    Individuo individuo = new Individuo(elem.Nombre, elem.Apellido, elem.Image);
                    Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, individuo);

                    datos.Add(individuo);
                });
            }
            return datos;
        }
    }
}
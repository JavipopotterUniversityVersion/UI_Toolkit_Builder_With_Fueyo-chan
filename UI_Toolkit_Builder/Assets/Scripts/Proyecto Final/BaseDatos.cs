using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using proyecto_final;

namespace proyecto_final
{
    public class BaseDatos
    {
        public static List<Individuo> getData()
        {
            List<Individuo> datos = new List<Individuo>();

            Texture2D texture = Resources.Load<Texture2D>("apple_pie");
            Individuo perico = new Individuo(
                "Perico",
                "Palotes",
                texture
            );

            Individuo tornasol = new Individuo(
                "Tornasol",
                "Tornasolado",
                texture
            );

            Individuo luca = new Individuo(
                "Luca",
                "Lucatell",
                texture
            );

            Individuo ivan = new Individuo(
                "Ivan",
                "Ivanovich",
                texture
            ); ;

            datos.Add(perico);
            datos.Add(tornasol);
            datos.Add(luca);
            datos.Add(ivan);

            return datos;
        }
    }
}
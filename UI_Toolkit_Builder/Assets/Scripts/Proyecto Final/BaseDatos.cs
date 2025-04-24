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
            Individuo uno = new Individuo(
                "Perico",
                "Palotes",
                texture
            );

            Individuo dos = new Individuo(
                "Tornasol",
                "Tornasolado",
                texture
            );

            Individuo tres = new Individuo(
                "Luca",
                "Lucatell",
                texture
            );

            Individuo cuatro = new Individuo(
                "Ivan",
                "Ivanovich",
                texture
            );

            Individuo cinco = new Individuo("", "", texture);
            Individuo seis = new Individuo("", "", texture);
            Individuo siete = new Individuo("", "", texture);
            Individuo ocho = new Individuo("", "", texture);
            Individuo nueve = new Individuo("", "", texture);
            Individuo diez = new Individuo("", "", texture);
            Individuo once = new Individuo("", "", texture);
            Individuo doce = new Individuo("", "", texture);
            Individuo trece = new Individuo("", "", texture);
            Individuo catorce = new Individuo("", "", texture);
            Individuo quince = new Individuo("", "", texture);
            Individuo dieciseis = new Individuo("", "", texture);

            datos.Add(uno);
            datos.Add(dos);
            datos.Add(tres);
            datos.Add(cuatro);
            datos.Add(cinco);
            datos.Add(seis);
            datos.Add(siete);
            datos.Add(ocho);
            datos.Add(nueve);
            datos.Add(diez);
            datos.Add(once);
            datos.Add(doce);
            datos.Add(trece);
            datos.Add(catorce);
            datos.Add(quince);
            datos.Add(dieciseis);

            return datos;
        }
    }
}
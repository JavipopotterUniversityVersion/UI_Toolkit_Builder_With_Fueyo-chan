using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

namespace Lab6_namespace
{
    [Serializable]
    public class Individuo
    {
        public event Action Cambio;

        public string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            { 
                if(value != nombre)
                {
                    nombre = value;
                    Cambio?.Invoke();
                }
            }
        }

        public string apellido;
        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (value != apellido)
                {
                    apellido = value;
                    Cambio?.Invoke();
                }
            }
        }

        public string image;

        public string Image
        {
            get { return image; }
            set
            {
                if (value != image)
                {
                    image = value;
                    Cambio?.Invoke();
                }
            }
        }
        public Individuo(string nombre, string apellido, string image)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.image = image;
        }
    }
}

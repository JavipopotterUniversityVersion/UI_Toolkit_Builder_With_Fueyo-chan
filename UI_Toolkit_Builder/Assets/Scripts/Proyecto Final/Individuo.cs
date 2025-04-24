using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

namespace proyecto_final
{
    public class Individuo
    {
        public event Action Cambio;

        private string nombre;
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

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (value != descripcion)
                {
                    descripcion = value;
                    Cambio?.Invoke();
                }
            }
        }

        private Background image;

        public Background Image
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
        public Individuo(string nombre, string descripcion, Background image)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.image = image;
        }
    }
}

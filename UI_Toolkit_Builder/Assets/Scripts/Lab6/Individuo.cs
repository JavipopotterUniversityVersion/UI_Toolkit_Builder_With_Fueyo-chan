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

        public string imageKey;

        public string ImageKey
        {
            get { return imageKey; }
            set
            {
                if (value != imageKey)
                {
                    imageKey = value;
                    Cambio?.Invoke();
                }
            }
        }
        public Individuo(string nombre, string apellido, string imageKey)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.imageKey = imageKey;
        }
    }
}

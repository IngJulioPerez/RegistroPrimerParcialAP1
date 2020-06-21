﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroPrimerParcialAP1.Entidades
{
    public class Articulos
    {
        [Key]

        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public float Costo { get; set; }
        public float ValorInventario { get; set; }


       public Articulos()
        {
            ValorInventario = Costo * Existencia;
        }
        
    }    

}

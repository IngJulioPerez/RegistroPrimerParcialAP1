using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrimerParcialAP1.BLL
{
    public class Utilidades
    {
        public static int ToInt(String valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);
            return retorno;
        }

    }
}

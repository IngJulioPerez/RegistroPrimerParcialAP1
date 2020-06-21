using System;
using System.Collections.Generic;
using System.Text;
using RegistroPrimerParcialAP1.DAL;
using RegistroPrimerParcialAP1.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;


namespace RegistroPrimerParcialAP1.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulo)
        {
            if (!Existe(articulo.ArticuloId))
                return Insertar(articulo);
            else
                return Modificar(articulo);
        }

        private static bool Insertar(Articulos articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Articulos.Add(articulo);
                paso = contexto.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        private static bool Modificar(Articulos articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var articulo = contexto.Articulos.Find(id);

                if (articulo != null)
                {
                    contexto.Articulos.Remove(articulo);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Articulos Buscar(int id)
        {
            Articulos articulo;
            Contexto contexto = new Contexto();

            try
            {
                articulo = contexto.Articulos.Find(id);
                
                contexto.Articulos.Find(id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return articulo;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Articulos.Any(e => e.ArticuloId == id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }              
        
    }
}

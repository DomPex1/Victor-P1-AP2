using System;
using System.Linq;
using System.Linq.Expressions;
using Victor_P1_AP2.DAL;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Victor_P1_AP2.Models;

namespace Victor_P1_AP2.BLL{

    public class CategoriasBLL{

        public static bool Guardar(Categorias categoria)
        {
            if (!Existe(categoria.CategoriaId))
                return Insertar(categoria);
            else
                return Modificar(categoria);
        }
        private static bool Insertar(Categorias categoria)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Categorias.Add(categoria);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        private static bool Modificar(Categorias categorias)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(categorias).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
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
                var categoria = contexto.Categorias.Find(id);
                
                if (categoria != null)
                {
                    contexto.Categorias.Remove(categoria);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static Categorias Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Categorias categoria;

            try
            {
                categoria = contexto.Categorias.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return categoria;
        }
        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> criterio)
        {
            List<Categorias> lista = new List<Categorias>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Categorias.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Categorias.Any(e => e.CategoriaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Categorias> GetCategorias()
        {
            List<Categorias> lista = new List<Categorias>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Categorias.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }



    }




}
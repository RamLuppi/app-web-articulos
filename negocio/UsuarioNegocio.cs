using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public void UsuarioNuevo(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO USERS(email, pass, admin) VALUES(@email, @pass,0)");
                datos.setearParametro("@email",usuario.Email);
                datos.setearParametro("@pass",usuario.Contraseña);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
        }

        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, email, nombre, apellido , urlImagenPerfil, admin FROM USERS WHERE email=@email AND pass=@pass");
                datos.setearParametro("@email",usuario.Email);
                datos.setearParametro("@pass",usuario.Contraseña);
                datos.ejecutarLectura();

                bool encontrado = false;
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Email = (string)datos.Lector["email"];

                    //usuario.Nombre = (string)datos.Lector["nombre"] ?? usuario.Nombre; //coalesencia nula

                    if (datos.Lector["nombre"] is string nombre)
                        usuario.Nombre = nombre;

                    if (datos.Lector["apellido"] is string apellido)
                        usuario.Apellido = apellido;

                    if (datos.Lector["urlImagenPerfil"] is string urlImagenperfil)
                        usuario.ImagenUrl = urlImagenperfil;

                    usuario.Admin = (bool)datos.Lector["admin"];

                    encontrado = true;
                }
                return encontrado;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
        }

        public bool usuarioRegistrado(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT email FROM USERS WHERE email=@email");
                datos.setearParametro("@email", usuario.Email);
                datos.ejecutarLectura();

                bool encontrado = false;
                while (datos.Lector.Read())
                {
                    usuario.Email = (string)datos.Lector["email"];

                    encontrado = true;
                }
                return encontrado;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void ActualizarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USERS SET nombre=@nombre,apellido=@apellido,urlImagenPerfil=@urlImagenPerfil WHERE Id=@id");
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@urlImagenPerfil", usuario.ImagenUrl);
                datos.setearParametro("@id", usuario.Id);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        
    }
}

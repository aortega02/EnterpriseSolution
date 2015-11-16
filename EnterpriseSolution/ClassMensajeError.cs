using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace EnterpriseSolution
{
    //#####  MUESTRA TODOS LOS MENSAJES DE ERROR DE LA APLICACIÓN  #####
    class ClassMensajeError
    {
        public void MsjBox(int Opt, string Texto, string Exp)
        {
            try
            {
                if (File.Exists("C:\\EntSolution\\Logs.txt"))
                {
                    StreamWriter sw = new StreamWriter("C:\\EntSolution\\Logs.txt", true);
                    switch (Opt)
                    {
                        //Para cerrar sistema
                        case 1:
                            MessageBox.Show("Error en Aplicación Cod: " + Texto + " El sistema se cerrará...  Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        //Errores de Base de Datos
                        case 2:
                            MessageBox.Show("Error en Aplicación Cod: " + Texto + " Error generado por el servidor de base de datos... Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        //Error de generacion XML
                        case 3:
                            MessageBox.Show("Error en Aplicación Cod: " + Texto + " Error al generar archivo XML de datos... Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        //Error en modificacion del app.config
                        case 4:
                            MessageBox.Show("Error en Aplicación Cod: " + Texto + " Error al intentar modificar el archivo de configuracion del sistema, El sistema se cerrará... Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case 5:
                            MessageBox.Show("Alerta en Aplicación Cod: " + Texto + " No se pudo actualizar... Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case 6:
                            MessageBox.Show("Error en Aplicación Cod: " + Texto + " No se pudieron cargar las constantes del sistema, El sistema se cerrará... Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 7:
                            MessageBox.Show("Error en General de Aplicación Cod: " + Texto + " El sistema se cerrará...  Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 8:
                            MessageBox.Show("Error General en Ventana Tareas Cod: " + Texto + " La Ventana Tareas se cerrará...  Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 9:
                            MessageBox.Show("Error General en Aplicación Cod: " + Texto + " Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 10:
                            MessageBox.Show("Error General en Aplicacion Cod: " + Texto + " La Ventana se cerrará...  Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    sw.WriteLine("\n" + DateTime.Now.ToString() + " - " + "Error en Aplicación Cod: " + Texto + " -->> " + Exp);
                    sw.Close();
                }
                else
                {
                    MessageBox.Show("Archivo de logs de errores inexistente... Contacte a su departamento de sistemas", "Información de Eventos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copie el siguiente mensaje y envielo a su administrador de sistemas: " + ex.ToString(), "ATENCION!", MessageBoxButtons.OK);
            }

        }
    }
}

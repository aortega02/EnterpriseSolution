using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using EnterpriseSolution;

namespace EnterpriseSolution
{
    class ClassModConfig
    {
        private ClassMensajeError MsjErr = new ClassMensajeError();
        private Configuration MiAppConfig = null;
        private AppSettingsSection MiConfig = null;
        private ConnectionStringsSection CadenaConexion = null;

        public ConnectionStringSettings MiCnx = null;
        public string Estado = null;
        public string Licencia = null;
        public string InfEmp = null;
        public string Skins = null;
        public string Update = null;

        //#####  INICIALIZA LOS DATOS DEL APPCONFIG  #####

        public ClassModConfig()
        {
            try
            {
                MiAppConfig = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);    //Se abre el app.config
                CadenaConexion = (ConnectionStringsSection)MiAppConfig.GetSection("connectionStrings"); //Obtengo la cadena de conexion
                MiConfig = (AppSettingsSection)MiAppConfig.GetSection("appSettings");                   //Obtengo la seccion appSettings
                
                MiCnx = ConfigurationManager.ConnectionStrings["EnterpriseSolution.Properties.Settings.bdnominaConnectionString"]; //capturo cadena de conexion
                Estado = ConfigurationManager.AppSettings["Validador"];
                Licencia = ConfigurationManager.AppSettings["Licencia"];
                InfEmp = ConfigurationManager.AppSettings["InfEmp"];
                Skins = ConfigurationManager.AppSettings["Skins"];
                Update = ConfigurationManager.AppSettings["Update"];
            }
            catch (Exception ex)
            {
                MsjErr.MsjBox(1, "ERR001-01", "No se pueden leer todos los valores del app.config - " + ex.ToString());
                Environment.Exit(0);
            }
        }

        //#####  PROTEGE LOS DATOS DE LAS SECCIONES DEL APPCONFIG  #####
        public bool Proteccion(string Opt)
        {
            try
            {
                if (MiAppConfig.GetSection(Opt).SectionInformation.IsProtected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsjErr.MsjBox(1, "ERR001-04", "Error validando la proteccion de la cadena de conexión - " + ex.ToString());
                Environment.Exit(0);
                return false;
            }


        }
        //#####  MODIFICA LA CADENA DE CONEXION  #####
        public bool ModificarCad(string Cad)
        {
            try
            {
                
                if (Cad != "" && Cad != null)
                {
                    if (CadenaConexion.SectionInformation.IsProtected)
                    {
                        CadenaConexion.SectionInformation.UnprotectSection();
                    }
                    CadenaConexion.ConnectionStrings["EnterpriseSolution.Properties.Settings.bdnominaConnectionString"].ConnectionString = Cad;
                    CadenaConexion.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    MiConfig.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    MiAppConfig.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MsjErr.MsjBox(1, "ERR001-06", "Error al intentar grabar los valores de conexion - " + ex.ToString());
                Environment.Exit(0);
                return false;
            }
            return false;
        }

        //#####  MODIFICA LOS DATOS DEL APPCONFIG  #####
        public bool ModificarSet(string Val = "", string Lic = "", string Inf = "", string Sk = "", string Upd = "")
        {

            try
            {
                if (MiConfig.SectionInformation.IsProtected)
                {
                    MiConfig.SectionInformation.UnprotectSection();
                }

                if (!string.IsNullOrEmpty(Val))
                {
                    MiConfig.Settings["Validador"].Value = Val;
                }

                if (!string.IsNullOrEmpty(Lic))
                {
                    MiConfig.Settings["Licencia"].Value = Lic;
                }

                if (!string.IsNullOrEmpty(Inf))
                {
                    MiConfig.Settings["InfEmp"].Value = Inf;
                }

               

                if (!string.IsNullOrEmpty(Sk))
                {
                    MiConfig.Settings["Skins"].Value = Sk;
                }

                if (!string.IsNullOrEmpty(Upd))
                {
                    MiConfig.Settings["Update"].Value = Upd;
                }

                MiConfig.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                MiAppConfig.Save();
                return true;

            }
            catch (Exception ex)
            {
                MsjErr.MsjBox(1, "ERR001-05", "Error al intentar grabar los valores del usuario - " + ex.ToString());
                Environment.Exit(0);
                return false;
            }

        }
        //########### DESTRUCTOR DE LA CLASE ############
        public void Destruc()
        {
            Estado = null;
            Licencia = null;
            InfEmp = null;
            Skins = null;
            Update = null;
            MiCnx = null;
        }

    }
}

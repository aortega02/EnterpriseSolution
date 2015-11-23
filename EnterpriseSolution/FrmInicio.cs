using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using EnterpriseSolution;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace EnterpriseSolution
{
    public partial class FrmInicio : DevExpress.XtraEditors.XtraForm
    {
        private ClassEncriptar Cifrar = new ClassEncriptar();
        private ClassConexion conexion = new ClassConexion();
        private ClassMensajeError MsjErr = new ClassMensajeError();
        private string AuxMsj;
        private int Ban = 0;
        
        public FrmInicio()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");

            string AuxDisco = "";
           
            //#####  Captura información del disco duro de la aplicación  #####
            Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
            Scripting.Drive selected_drive = fso.GetDrive(Application.ExecutablePath.Substring(0, 3));

            AuxMsj = LblError.Text;

            //#####  SE CREA UN DIRECTORIO EN C: PARA GUARDAR LOS XML DE LOS REPORTES  #####
            if (!Directory.Exists("C:\\EntSolution"))
            {
                try
                {
                    Directory.CreateDirectory("C:\\EntSolution");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo crear la Carpeta C:\\EntSolution sin esta carpeta el sistema no podrá generar reportes...  Contacte con su administrador de sistemas...", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //#####  SE CREA UN ARCHIVO PARA GUARDAR LOS LOGS DEL SISTEMA  #####
            if (!File.Exists("C:\\EntSolution\\Logs.txt"))
            {
                try
                {
                    File.Create("C:\\EntSolution\\Logs.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo crear el archivo C:\\EntSolution\\Logs.txt sin este archivo el sistema no podrá generar logs de errores...  Contacte a su administrador de sistemas...", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //#####  SE VALIDA SI LA SECCION ESTA PROTEGIDA EN CASO CONTRARIO SE LLAMA AL CONFIGURADOR  #####

            ClassModConfig Config = new ClassModConfig();
            VarConst.NomSkin = Config.Skins;
            if (Config.Proteccion("connectionStrings") == false)
            {
                FrmConfigCon FrmConfigCon = new FrmConfigCon();
                FrmConfigCon.Text = FrmConfigCon.Text + "Configuración de Conexion";
                FrmConfigCon.OptionConfig(1);
                FrmConfigCon.ShowDialog();
                MessageBox.Show(VarConst.BanError.ToString());
                if (VarConst.BanError == true)
                {
                    VarConst.BanError = false;
                    Environment.Exit(0);
                }
                else
                {
                    Application.Exit();
                }
                return;
            }

            //#####  SE VALIDA LA LICENCIA DEL SISTEMA  #####
            try
            {
                if (Config.Estado == "***")
                {
                    if (selected_drive.IsReady)
                    {
                        if (selected_drive.SerialNumber.ToString().Length <= 15)
                        {
                            AuxDisco = Cifrar.Encriptar(selected_drive.SerialNumber.ToString());
                        }
                        else
                        {
                            string a = selected_drive.SerialNumber.ToString();
                            AuxDisco = a.Substring(0, 3) + "123" + a.Substring(a.Length - 3, 3);
                            AuxDisco = Cifrar.Encriptar(AuxDisco);
                        }
                        AuxDisco = AuxDisco.Substring(0, AuxDisco.Length - 2);
                        FrmConfigCon FrmConfigCon = new FrmConfigCon();
                        FrmConfigCon.Text = "Configuración de Licenciamiento";
                        FrmConfigCon.TxtBloqueo.Text = AuxDisco;
                        FrmConfigCon.OptionConfig(2);
                        FrmConfigCon.ShowDialog();
                        if (VarConst.BanError == true)
                        {
                            VarConst.BanError = false;
                            Environment.Exit(0);
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    if (Cifrar.Desencriptar(Config.Estado) == selected_drive.SerialNumber.ToString())
                    {
                        string AuxLic = Cifrar.Desencriptar(Config.Licencia);
                        DataTable tbl = new DataTable();
                        tbl.Clear();

                        if (conexion.consulta("SELECT EMP_NOMBRE FROM TBLEMPRESA WHERE EMP_BANNOM = 'PRI' AND EMP_RIF LIKE '" + AuxLic.Split('#')[2].Substring(3, 1) + "-%" + AuxLic.Split('#')[2].Substring(4, 3) + "__'"))
                        {
                            tbl = conexion.datos();
                            if (tbl.Rows.Count > 0)
                            {
                                if (AuxLic.Split('#')[2].Substring(0, 3) != "PER")
                                {
                                    if (Convert.ToDateTime(AuxLic.Split('#')[1]).AddDays(-30) < DateTime.Now)
                                    {
                                        //MidPrincipal.TxtMantenimiento.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        //MidPrincipal.TxtMantenimiento.Caption = "Lic. de Mantenimiento: " + DateDiff(DateInterval.Day, Now, CDate(AuxLic.Split("#")(1))).ToString + " Dias"
                                    }
                                    //#####  SE VALIDA ACTUALIZACION  #####
                                    DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                                    DateTime now = DateTime.Now;
                                    Calendar cal = dfi.Calendar;
                                    try
                                    {

                                        bool BanU = false;
                                        switch (Config.Update.Substring(0, 1))
                                        {
                                            case "D":
                                                BanU = true;
                                                break;
                                            case "S":
                                                decimal Semana = cal.GetWeekOfYear(now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                                                if (Convert.ToInt16(Config.Update.Split('#')[0].Split('-')[1]) <= Semana)
                                                {
                                                    BanU = true;
                                                    if (Semana >= 52)
                                                    {
                                                        Config.Update = Config.Update.Split('#')[0].Split('-')[0] + "-" + "1" + "#" + Config.Update.Split('#')[1] + "#" + Config.Update.Split('#')[2];
                                                    }
                                                    else
                                                    {
                                                        Config.Update = Config.Update.Split('#')[0].Split('-')[0] + "-" + (now.Month + 1).ToString() + "#" + Config.Update.Split('#')[1] + "#" + Config.Update.Split('#')[2];
                                                    }
                                                }

                                                break;

                                            case "M":
                                                if (Convert.ToInt16(Config.Update.Split('#')[0].Split('-')[1]) <= now.Month)
                                                {
                                                    BanU = true;
                                                    if (now.Month >= 12)
                                                    {
                                                        Config.Update = Config.Update.Split('#')[0].Split('-')[0] + "-" + "1" + "#" + Config.Update.Split('#')[1] + "#" + Config.Update.Split('#')[2];
                                                    }
                                                    else
                                                    {
                                                        Config.Update = Config.Update.Split('#')[0].Split('-')[0] + "-" + (now.Month + 1).ToString() + "#" + Config.Update.Split('#')[1] + "#" + Config.Update.Split('#')[2];
                                                    }
                                                }

                                                break;
                                        }

                                        if (BanU == true)
                                        {
                                            Config.ModificarSet("", "", "", "", Config.Update);
                                            //FrmActualizador.ShowDialog();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MsjErr.MsjBox(5, "ERR010-01", ex.ToString());
                                    }

                                }
                                else
                                {
                                    VarConst.BanAct = false;
                                }
                            }
                            else
                            {
                                MsjErr.MsjBox(1, "ERR002-01", "La Licencia instalada en este equipo no es valida");
                                MessageBox.Show("La Licencia instalada en este equipo no es valida");
                                Environment.Exit(0);
                            }
                        }

                    }
                    else
                    {
                        MsjErr.MsjBox(1, "ERR002-01", "La Licencia instalada en este equipo no es valida");
                        Environment.Exit(0);
                    }
                }

            }
            catch (Exception ex)
            {
                MsjErr.MsjBox(1, "ERR002-03", ex.ToString());
                Environment.Exit(0);
            }

            try
            {
                VarConst.NumEmp = Cifrar.Desencriptar(Config.InfEmp + "==").Split('#')[1];
                VarConst.NumTra = Cifrar.Desencriptar(Config.InfEmp + "==").Split('#')[2];
            }
            catch (Exception ex)
            {
                MsjErr.MsjBox(1, "ERR007-01", ex.ToString());
                Environment.Exit(0);
            }
            Config.Destruc();
            if (LicEmp())
            {
                conexion.CargarComboBox("SELECT EMP_NOMBRE FROM TBLEMPRESA WHERE EMP_REG = '1' ORDER BY EMP_ID LIMIT " + VarConst.NumEmp + "", CmbEmpresa, "EMP_NOMBRE");
                CmbEmpresa.SelectedIndex = 0;
            }
            else
            {
                MsjErr.MsjBox(1, "ERR007-02", "Hay mas empresas o usuarios registrados que los que admite la licencia");
                Environment.Exit(0);
            }

        }

        //##### FUNCION QUE VALIDA EL NUMERO DE EMPRESAS Y DE EMPLEADOS QUE DEBE TENER LA LICENCIA #####
        private bool LicEmp()
        {
            DataTable tblLic = new DataTable();
            tblLic.Clear();
            if (conexion.consulta("SELECT COUNT(EMP_ID) AS NUM FROM TBLEMPRESA UNION SELECT COUNT(EMP_ID) AS NUM FROM TBLEMPLEADOS"))
            {
                tblLic = conexion.datos();
                if (tblLic.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(tblLic.Rows[0]["NUM"].ToString().Trim()) <= Convert.ToDecimal(VarConst.NumEmp) && Convert.ToDecimal(tblLic.Rows[1]["NUM"].ToString().Trim()) <= Convert.ToDecimal(VarConst.NumTra))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }

        //'#####  BOTON VALIDAR, VALIDA LA INFORMACION DEL USUARIO  #####
        private void BtnValidar_Click(object sender, EventArgs e)
        {
            DataTable tblVal = new DataTable();
            ClassModulos Modulo = new ClassModulos();

            if (dxValidationProvider1.Validate())
            {
                tblVal.Clear();
                if (conexion.consulta("SELECT USU_NOMEMP, PER_NOMBRE, EMP_RIF, EMP_CIERRE, EMP_REGEMP FROM TBLUSUEMP INNER JOIN TBLUSUARIO ON USU_ID = UE_IDUSU AND USU_ESTATUS = '1' " +
                                     "INNER JOIN TBLPERFIL ON PER_ID = UE_IDPER AND PER_REG = '1' INNER JOIN TBLEMPRESA ON EMP_ID =  UE_IDEMP AND EMP_REG = '1' " +
                                     "WHERE UE_STATUS = '1' AND USU_USUARIO = '" + TxtUsuario.Text + "' AND USU_PASSWORD = '" + Cifrar.Encriptar(TxtPassword.Text) + "' AND EMP_NOMBRE = '" + CmbEmpresa.Text + "' "))
                {

                    tblVal = conexion.datos();
                    if (tblVal.Rows.Count > 0)
                    {
                        VarConst.Perfil = tblVal.Rows[0]["PER_NOMBRE"].ToString().Trim();
                        VarConst.Usuario = TxtUsuario.Text;
                        VarConst.Empresa = CmbEmpresa.Text;
                        VarConst.Rif = tblVal.Rows[0]["EMP_RIF"].ToString().Trim();
                        VarConst.CierreFis = tblVal.Rows[0]["EMP_CIERRE"].ToString().Trim();
                        VarConst.CodEmpresa = tblVal.Rows[0]["EMP_REGEMP"].ToString().Trim();
                        VarConst.Empleado = tblVal.Rows[0]["USU_NOMEMP"].ToString().Trim();
                        VarConst.Auditor = "UserPC:" + System.Environment.UserName.ToString().ToUpper() + "_UserAP:" + VarConst.Usuario + "_PC:" + SystemInformation.ComputerName.ToString().ToUpper() + "_" + DateTime.Now.ToString();
                        VarConst.NumEmpresas = CmbEmpresa.Properties.Items.Count;
                        
                        tblVal.Dispose();
                        //Modulo.Constantes();

                        MidPrincipal mdiPrincipal = new MidPrincipal();
                        mdiPrincipal.Text = mdiPrincipal.Text + " - USUARIO: " + VarConst.Usuario + " - PERFIL: " + VarConst.Perfil;
                        this.Hide();
                        mdiPrincipal.Show();

                    }
                    else
                    {
                        Ban = Ban + 1;
                        string cond = (Ban == 1) ? " Intento)" : " Intentos)";
                        LblError.Text = AuxMsj + " (" + Ban.ToString() + cond;
                        MsjError.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        if (Ban == 3)
                        {
                            MessageBox.Show("Superado el numero de intentos maximos permitidos...  El Sistema se cerrará...", "Inicio de Sesion");
                            this.Close();
                        }

                    }

                }

            }
        }

        private void TxtPassword_MouseEnter(object sender, EventArgs e)
        {
            TxtPassword.Properties.PasswordChar = '\0';
        }

        private void TxtPassword_MouseLeave(object sender, EventArgs e)
        {
            TxtPassword.Properties.PasswordChar = '*';
        }
    
    
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using EnterpriseSolution;

namespace EnterpriseSolution
{
    public partial class FrmConfigCon : DevExpress.XtraEditors.XtraForm
    {

        //############ ELIMINA EL BOTON CERRAR DEL FORMULARIO ################
        private bool _enabledCerrar = false;

        [System.ComponentModel.DefaultValue(false), System.ComponentModel.Description("Define si se habilita el botón cerrar en el formulario")]
        public bool EnabledCerrar
        {
            get
            {
                return _enabledCerrar;
            }
            set
            {
                _enabledCerrar = value;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (_enabledCerrar == false)
                {
                    const int CS_NOCLOSE = 0x200;
                    cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                }
                return cp;
            }
        }
        //###################
        private ClassEncriptar Cifrar = new ClassEncriptar();
        private ClassMensajeError MsjErr = new ClassMensajeError();
        private string Cadena = "";
        private int Ban = 0;
        private string LicValida = "";
        private ClassModConfig Config = new ClassModConfig();
        public FrmConfigCon()
        {
            InitializeComponent();

            string Valor = null;
            string AuxCad = "";

            BtnGrabar.Enabled = false;

        }
        //#####  VALIDA CUAL DE LOS DOS LAYOUT DEBE MOSTRAR DEPENDIENDO LA OPCION #####
        //##### OPT 1 = CONFIGRACION DE CONEXION
        public void OptionConfig(int opt)
        {
            if (opt == 1)
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                BtnValidar.Text = "Validar Base de Datos";
                try
                {
                   
                    if (Config.MiCnx.ToString().Split(';').Length == 5)
                    {
                        TxtBD.Text = Config.MiCnx.ToString().Split(';')[0].Split('=')[1];
                        TxtUsuario.Text = Config.MiCnx.ToString().Split(';')[1].Split('=')[1];
                        TxtClave.Text = Config.MiCnx.ToString().Split(';')[2].Split('=')[1];
                    }
                    else
                    {

                        VarConst.BanError = true;
                        MsjErr.MsjBox(1, "ERR001-02", "Cadena de conexion en App.config con valores erroneos");
                        Environment.Exit(0);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    VarConst.BanError = true;
                    MsjErr.MsjBox(1, "ERR001-03", ex.ToString());
                    this.Close();
                    return;
                }
                return;
            }

            //##### OPT 2 = CONFIGRACION DE LICENCIAMIENTO
            if (opt == 2)
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                BtnValidar.Text = "Validar Licencia";

            }
        }

        //#####  BOTON VALIDAR VALIDA LA INFORMACION SUMISTRADA POR EL USUARIO DEPENDIENDO DEL TEXT DEL BOTON #####

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            string Lic = "";
            string Cod = "";

            //##### VALIDA LA INFORMACION DE CONEXION CON LA BASE DE DATOS #####

            if (this.Text == "Configuración de Conexion")
            {
                Cadena = "server=" + TxtBD.Text + ";User Id=" + TxtUsuario.Text + ";password=" + TxtClave.Text + ";Persist Security Info=True;database=bdnomina20151112";
                MySqlConnection _conexion = new MySqlConnection();
                _conexion.ConnectionString = Cadena;
                try
                {
                    _conexion.Open();
                    MessageBox.Show("Conexión al servidor MySQL Verificada, proceda a grabar...", "Conexión MySQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtBD.Enabled = false;
                    TxtClave.Enabled = false;
                    TxtUsuario.Enabled = false;
                    BtnValidar.Enabled = false;
                    BtnGrabar.Enabled = true;
                    _conexion.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("No es posible conectar al servidor MySQL, verifique la información suministrada...", "Conexión MySQL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }


            //#####  VALIDA LA LICENCIA DEL SISTEMA #####
            if (this.Text == "Configuración de Licenciamiento")
            {
                if (TxtLicencia.Text != "")
                {

                    try
                    {
                        Lic = Cifrar.Desencriptar(TxtLicencia.Text.Trim() + "=");

                        Cod = Cifrar.Desencriptar(TxtBloqueo.Text.Trim() + "==");
                        DateTime Now = DateTime.Now;

                        if (Cod.Substring(0, 3) == Lic.Split('#')[0].Substring(3, 3) && Cod.Substring(Cod.Length - 3, 3) == Lic.Split('#')[0].Substring(0, 3) && Now <= Convert.ToDateTime(Lic.Split('#')[1]))
                        {
                            if (Lic.Split('#')[2].Substring(0, 3) == "PER")
                            {
                                LicValida = Lic.Substring(0, 7) + Convert.ToDateTime(Lic.Split('#')[1]).AddYears(50).ToShortDateString() + '#' + Lic.Split('#')[2];
                            }
                            else
                            {
                                LicValida = Lic.Substring(0, 7) + Convert.ToDateTime(Lic.Split('#')[1]).AddDays(Int32.Parse(Lic.Split('#')[2].Substring(0, 3))).ToShortDateString() + '#' + Lic.Split('#')[2];
                            }
                            MessageBox.Show("Licencia valida... Proceda a Grabar", "Activación del Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnGrabar.Enabled = true;
                            BtnValidar.Enabled = false;
                            TxtLicencia.Properties.ReadOnly = true;
                        }

                        else
                        {
                            Ban = Ban + 1;
                            if (Ban == 3)
                            {
                                VarConst.BanError = true;
                                MsjErr.MsjBox(1, "ERR002-06", "Numero de intentos de licencia superados");
                                this.Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Licencia invalida vuelva a intentarlo", "Activación del Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Ban = Ban + 1;
                        if (Ban == 3)
                        {
                            VarConst.BanError = true;
                            MsjErr.MsjBox(1, "ERR002-06", "Numero de intentos de licencia superados");

                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Licencia invalida vuelva a intentarlo", "Activación del Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("El campo licencia no puede estar en blanco", "Activación del Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

        }
        //#####  BOTON GRABAR, GRABA LA INFORMACION YA VALIDADA ANTERIORMENTE  #####
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            //#####  MODIFICA CADENA DE CONEXION  #####
            if (this.Text == "Configuración de Conexion")
            {
                if (Config.ModificarCad(Cadena))
                {
                    MessageBox.Show("Modificaciones Realizadas correctamente...", "Cadena de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    Application.Restart();
                }

            }
            //#####  MODIFICA INFORMACION DE LICENCIAMIENTO  #####
            if (this.Text == "Configuración de Licenciamiento")
            {
                if (Config.ModificarSet(TxtBloqueo.Text + "==", Cifrar.Encriptar(LicValida)))
                {
                    MessageBox.Show("Modificaciones Realizadas correctamente...", "Activación del Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    Application.Restart();
                }
            }

            Config.Destruc();
        }

        //#####  BOTON SALIR, SALE DE LA VENTANA ACTIVA
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            VarConst.BanError = true;
            Config.Destruc();
            this.Close();
            return;
        }


        //'#####  MUESTRA EL PASSWORD #####
        private void labelControl1_MouseEnter(object sender, EventArgs e)
        {
            TxtClave.Properties.PasswordChar = '\0';
        }
        //'#####  OCULTA EL PASSWORD  #####
        private void labelControl1_MouseLeave(object sender, EventArgs e)
        {
            TxtClave.Properties.PasswordChar = '*';
        }


    }
}
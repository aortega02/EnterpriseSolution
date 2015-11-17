using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace EnterpriseSolution
{
    
    public partial class MidPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private ClassEncriptar Cifrar = new ClassEncriptar();
        private ClassMensajeError MsjErr = new ClassMensajeError();
        private int BanCer = 0;

        //#####  FUNCION PARA ANTES DE CERRAR EL FORMULARIO, GUARDA EL SKIN ACTUAL Y CIERRA LOS HILOS  #####
        private void MidPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            

            if (defaultLookAndFeel1.LookAndFeel.SkinName != VarConst.NomSkin)
            {
                ClassModConfig config = new ClassModConfig();
                config.ModificarSet("","","", defaultLookAndFeel1.LookAndFeel.SkinName,"");
            }
            if (BanCer == 0)
            {
                Application.ExitThread();
            }
        }


        public MidPrincipal()
        {
            InitializeComponent();
        }

        private void MidPrincipal_Load(object sender, EventArgs e)
        {

        }


        
    }
}
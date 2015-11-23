using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;

namespace EnterpriseSolution
{
    
    public partial class MidPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private ClassEncriptar Cifrar = new ClassEncriptar();
        private ClassMensajeError MsjErr = new ClassMensajeError();
        private int BanCer = 0;

        //#####  FUNCION PARA ANTES DE CERRAR EL FORMULARIO, GUARDA EL SKIN ACTUAL Y CIERRA LOS HIJOS  #####
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
        //#####  FUNCION PARA CUANDO SE ESTE CERRANDO EL FORMULARIO, GUARDA EL LAYOUT DEL SISTEMA Y CIERRA LOS HIJOS DEL MDI  #####
        private void MidPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists("C:\\EntSolution"))
                {
                    RibbonControl.Toolbar.SaveLayoutToXml("C:\\EntSolution\\LayoutEnt.xml");
                }
        }

        public MidPrincipal()
        {
            InitializeComponent();
        }
        //#####  FUNCION INICIAL DE CARGA DE FORMULARIO  #####
        private void MidPrincipal_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            SkinHelper.InitSkinGallery(RpbSkins, true);
            if (File.Exists("C:\\EntSolution\\LayoutEnt.xml"))
            {
                RibbonControl.Toolbar.RestoreLayoutFromXml("C:\\EntSolution\\LayoutEnt.xml");
            }
            defaultLookAndFeel1.LookAndFeel.SkinName = VarConst.NomSkin;
            
        }

        


        
    }
}
namespace EnterpriseSolution
{
    partial class MidPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip12 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem12 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MidPrincipal));
            this.RibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.BtnEmpCla = new DevExpress.XtraBars.BarButtonItem();
            this.BtnCamUsu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.RpbSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.LblEmpresa = new DevExpress.XtraBars.BarStaticItem();
            this.BtnUsuarios = new DevExpress.XtraBars.BarButtonItem();
            this.BtnPerfil = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAsigPol = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RbpUtilitarios = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RpgSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RpgAccesos = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.RgbSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonControl
            // 
            this.RibbonControl.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.RibbonControl.ApplicationButtonText = null;
            this.RibbonControl.ApplicationIcon = global::EnterpriseSolution.Properties.Resources.home3;
            // 
            // 
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.ExpandCollapseItem.Name = "";
            this.RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.RibbonControl.ExpandCollapseItem,
            this.BtnEmpCla,
            this.barButtonItem1,
            this.RpbSkins,
            this.LblEmpresa,
            this.BtnCamUsu,
            this.BtnUsuarios,
            this.BtnPerfil,
            this.BtnAsigPol});
            this.RibbonControl.Location = new System.Drawing.Point(0, 0);
            this.RibbonControl.MaxItemId = 12;
            this.RibbonControl.Name = "RibbonControl";
            this.RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.RbpUtilitarios});
            this.RibbonControl.SelectedPage = this.RbpUtilitarios;
            this.RibbonControl.Size = new System.Drawing.Size(1016, 149);
            this.RibbonControl.StatusBar = this.ribbonStatusBar;
            this.RibbonControl.Toolbar.ItemLinks.Add(this.barButtonItem1);
            this.RibbonControl.Toolbar.ItemLinks.Add(this.LblEmpresa);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.BtnEmpCla);
            this.applicationMenu1.ItemLinks.Add(this.BtnCamUsu);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.RibbonControl;
            // 
            // BtnEmpCla
            // 
            this.BtnEmpCla.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmpCla.Appearance.Options.UseFont = true;
            this.BtnEmpCla.Caption = "Cambiar Clave";
            this.BtnEmpCla.Id = 2;
            this.BtnEmpCla.Name = "BtnEmpCla";
            // 
            // BtnCamUsu
            // 
            this.BtnCamUsu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCamUsu.Appearance.Options.UseFont = true;
            this.BtnCamUsu.Caption = "Cambiar Usuario";
            this.BtnCamUsu.Id = 7;
            this.BtnCamUsu.Name = "BtnCamUsu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // RpbSkins
            // 
            this.RpbSkins.Caption = "ribbonGalleryBarItem1";
            this.RpbSkins.Id = 4;
            this.RpbSkins.Name = "RpbSkins";
            // 
            // LblEmpresa
            // 
            this.LblEmpresa.Caption = "Empresa";
            this.LblEmpresa.Id = 5;
            this.LblEmpresa.Name = "LblEmpresa";
            this.LblEmpresa.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // BtnUsuarios
            // 
            this.BtnUsuarios.Caption = "Usuarios";
            this.BtnUsuarios.Id = 8;
            this.BtnUsuarios.Name = "BtnUsuarios";
            // 
            // BtnPerfil
            // 
            this.BtnPerfil.Caption = "Perfiles de Usuario";
            this.BtnPerfil.Id = 10;
            this.BtnPerfil.Name = "BtnPerfil";
            // 
            // BtnAsigPol
            // 
            this.BtnAsigPol.Caption = "Asignacion de Politicas";
            this.BtnAsigPol.Id = 11;
            this.BtnAsigPol.Name = "BtnAsigPol";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Inicio";
            // 
            // RbpUtilitarios
            // 
            this.RbpUtilitarios.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RpgSkins,
            this.RpgAccesos});
            this.RbpUtilitarios.Name = "RbpUtilitarios";
            this.RbpUtilitarios.Tag = "PER_UTILITARIOS";
            this.RbpUtilitarios.Text = "Utilitarios";
            // 
            // RpgSkins
            // 
            this.RpgSkins.ItemLinks.Add(this.RpbSkins);
            this.RpgSkins.Name = "RpgSkins";
            this.RpgSkins.Tag = "PER_SKINS";
            this.RpgSkins.Text = "Skins";
            // 
            // RpgAccesos
            // 
            this.RpgAccesos.ItemLinks.Add(this.BtnUsuarios);
            this.RpgAccesos.ItemLinks.Add(this.BtnPerfil);
            this.RpgAccesos.ItemLinks.Add(this.BtnAsigPol);
            this.RpgAccesos.Name = "RpgAccesos";
            toolTipTitleItem12.Text = "Control de Acceso";
            superToolTip12.Items.Add(toolTipTitleItem12);
            this.RpgAccesos.SuperTip = superToolTip12;
            this.RpgAccesos.Tag = "PER_CONACCESO";
            this.RpgAccesos.Text = "Control de Acceso";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 744);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.RibbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1016, 23);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // RgbSkins
            // 
            this.RgbSkins.Caption = "RibbonGalleryBarItem1";
            this.RgbSkins.Id = 2;
            this.RgbSkins.Name = "RgbSkins";
            // 
            // MidPrincipal
            // 
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 767);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.RibbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MidPrincipal";
            this.Ribbon = this.RibbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Roboust App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MidPrincipal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MidPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.MidPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl RibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        internal DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem BtnEmpCla;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        internal DevExpress.XtraBars.Ribbon.RibbonPage RbpUtilitarios;
        internal DevExpress.XtraBars.RibbonGalleryBarItem RpbSkins;
        internal DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        internal DevExpress.XtraBars.RibbonGalleryBarItem RgbSkins;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup RpgSkins;
        internal DevExpress.XtraBars.BarStaticItem LblEmpresa;
        internal DevExpress.XtraBars.BarButtonItem BtnCamUsu;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        internal DevExpress.XtraBars.BarButtonItem BtnUsuarios;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup RpgAccesos;
        internal DevExpress.XtraBars.BarButtonItem BtnPerfil;
        private DevExpress.XtraBars.BarButtonItem BtnAsigPol;
    }
}
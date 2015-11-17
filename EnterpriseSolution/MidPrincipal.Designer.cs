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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MidPrincipal));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.BtnCamUsu = new DevExpress.XtraBars.BarButtonItem();
            this.BtnEmpCla = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.RpbSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.RbpUtilitarios = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RpgSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.RgbSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ApplicationIcon = global::EnterpriseSolution.Properties.Resources.star_full1;
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.BtnCamUsu,
            this.BtnEmpCla,
            this.barButtonItem1,
            this.RpbSkins});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.RbpUtilitarios});
            this.ribbon.SelectedPage = this.RbpUtilitarios;
            this.ribbon.Size = new System.Drawing.Size(1016, 149);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItem1);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.BtnCamUsu);
            this.applicationMenu1.ItemLinks.Add(this.BtnEmpCla);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // BtnCamUsu
            // 
            this.BtnCamUsu.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCamUsu.Appearance.Options.UseFont = true;
            this.BtnCamUsu.Caption = "Cambiar de Usuario";
            this.BtnCamUsu.Glyph = global::EnterpriseSolution.Properties.Resources.user_manage;
            this.BtnCamUsu.Id = 1;
            this.BtnCamUsu.Name = "BtnCamUsu";
            // 
            // BtnEmpCla
            // 
            this.BtnEmpCla.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmpCla.Appearance.Options.UseFont = true;
            this.BtnEmpCla.Caption = "Cambiar Clave";
            this.BtnEmpCla.Glyph = global::EnterpriseSolution.Properties.Resources.security_lock;
            this.BtnEmpCla.Id = 2;
            this.BtnEmpCla.Name = "BtnEmpCla";
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
            // RbpUtilitarios
            // 
            this.RbpUtilitarios.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RpgSkins});
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
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 744);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
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
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MidPrincipal";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Roboust App";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MidPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.MidPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        internal DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        internal DevExpress.XtraBars.BarButtonItem BtnCamUsu;
        private DevExpress.XtraBars.BarButtonItem BtnEmpCla;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        internal DevExpress.XtraBars.Ribbon.RibbonPage RbpUtilitarios;
        internal DevExpress.XtraBars.RibbonGalleryBarItem RpbSkins;
        internal DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        internal DevExpress.XtraBars.RibbonGalleryBarItem RgbSkins;
        internal DevExpress.XtraBars.Ribbon.RibbonPageGroup RpgSkins;
    }
}
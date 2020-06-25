namespace Proyecto1_Compi_20187335
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cargaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLTABLASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteErroresTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.verTablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargaToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cargaToolStripMenuItem
            // 
            this.cargaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPestañaToolStripMenuItem,
            this.abrirToolStripMenuItem});
            this.cargaToolStripMenuItem.Name = "cargaToolStripMenuItem";
            this.cargaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.cargaToolStripMenuItem.Text = "Carga";
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            this.nuevaPestañaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevaPestañaToolStripMenuItem.Text = "Nueva Pestaña";
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.nuevaPestañaToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLTABLASToolStripMenuItem,
            this.sQLConsultaToolStripMenuItem,
            this.reporteErroresTokensToolStripMenuItem,
            this.arbolToolStripMenuItem,
            this.verTablasToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // sQLTABLASToolStripMenuItem
            // 
            this.sQLTABLASToolStripMenuItem.Name = "sQLTABLASToolStripMenuItem";
            this.sQLTABLASToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.sQLTABLASToolStripMenuItem.Text = "SQL TABLAS";
            this.sQLTABLASToolStripMenuItem.Click += new System.EventHandler(this.sQLTABLASToolStripMenuItem_Click);
            // 
            // sQLConsultaToolStripMenuItem
            // 
            this.sQLConsultaToolStripMenuItem.Name = "sQLConsultaToolStripMenuItem";
            this.sQLConsultaToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.sQLConsultaToolStripMenuItem.Text = "SQL Consulta";
            this.sQLConsultaToolStripMenuItem.Click += new System.EventHandler(this.sQLConsultaToolStripMenuItem_Click);
            // 
            // reporteErroresTokensToolStripMenuItem
            // 
            this.reporteErroresTokensToolStripMenuItem.Name = "reporteErroresTokensToolStripMenuItem";
            this.reporteErroresTokensToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.reporteErroresTokensToolStripMenuItem.Text = "Reporte Errores && Tokens";
            this.reporteErroresTokensToolStripMenuItem.Click += new System.EventHandler(this.reporteErroresTokensToolStripMenuItem_Click);
            // 
            // arbolToolStripMenuItem
            // 
            this.arbolToolStripMenuItem.Name = "arbolToolStripMenuItem";
            this.arbolToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.arbolToolStripMenuItem.Text = "Arbol";
            this.arbolToolStripMenuItem.Click += new System.EventHandler(this.arbolToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(298, 346);
            this.tabControl1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 20);
            this.textBox1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(348, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 132);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // verTablasToolStripMenuItem
            // 
            this.verTablasToolStripMenuItem.Name = "verTablasToolStripMenuItem";
            this.verTablasToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.verTablasToolStripMenuItem.Text = "Ver Tablas";
            this.verTablasToolStripMenuItem.Click += new System.EventHandler(this.verTablasToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cargaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLTABLASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteErroresTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTablasToolStripMenuItem;
    }
}


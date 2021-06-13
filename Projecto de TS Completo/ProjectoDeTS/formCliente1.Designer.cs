
namespace ProjectoDeTS
{
    partial class formCliente1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCliente1));
            this.tbxMensagem = new System.Windows.Forms.TextBox();
            this.btnFicheiro = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.tbxConversa = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbxMensagem
            // 
            this.tbxMensagem.Location = new System.Drawing.Point(12, 531);
            this.tbxMensagem.Multiline = true;
            this.tbxMensagem.Name = "tbxMensagem";
            this.tbxMensagem.Size = new System.Drawing.Size(308, 54);
            this.tbxMensagem.TabIndex = 11;
            // 
            // btnFicheiro
            // 
            this.btnFicheiro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFicheiro.BackgroundImage")));
            this.btnFicheiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFicheiro.FlatAppearance.BorderSize = 0;
            this.btnFicheiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFicheiro.Location = new System.Drawing.Point(399, 531);
            this.btnFicheiro.Name = "btnFicheiro";
            this.btnFicheiro.Size = new System.Drawing.Size(70, 54);
            this.btnFicheiro.TabIndex = 10;
            this.btnFicheiro.UseVisualStyleBackColor = true;
            this.btnFicheiro.Click += new System.EventHandler(this.btnFicheiro_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEnviar.Location = new System.Drawing.Point(326, 531);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(70, 54);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // tbxConversa
            // 
            this.tbxConversa.Location = new System.Drawing.Point(12, 12);
            this.tbxConversa.Multiline = true;
            this.tbxConversa.Name = "tbxConversa";
            this.tbxConversa.ReadOnly = true;
            this.tbxConversa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxConversa.Size = new System.Drawing.Size(443, 510);
            this.tbxConversa.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // formCliente1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 597);
            this.Controls.Add(this.tbxMensagem);
            this.Controls.Add(this.btnFicheiro);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.tbxConversa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formCliente1";
            this.Text = "Garage Manager Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formCliente1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxMensagem;
        private System.Windows.Forms.Button btnFicheiro;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox tbxConversa;
        private System.Windows.Forms.Timer timer1;
    }
}
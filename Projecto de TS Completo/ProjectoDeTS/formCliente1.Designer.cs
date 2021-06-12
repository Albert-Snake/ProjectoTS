
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
            this.tbxMensagem = new System.Windows.Forms.TextBox();
            this.btnFicheiro = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.tbxConversa = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbxMensagem
            // 
            this.tbxMensagem.Location = new System.Drawing.Point(12, 384);
            this.tbxMensagem.Multiline = true;
            this.tbxMensagem.Name = "tbxMensagem";
            this.tbxMensagem.Size = new System.Drawing.Size(531, 54);
            this.tbxMensagem.TabIndex = 11;
            // 
            // btnFicheiro
            // 
            this.btnFicheiro.Location = new System.Drawing.Point(558, 384);
            this.btnFicheiro.Name = "btnFicheiro";
            this.btnFicheiro.Size = new System.Drawing.Size(112, 54);
            this.btnFicheiro.TabIndex = 10;
            this.btnFicheiro.Text = "&Carregar Ficheiro";
            this.btnFicheiro.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(676, 384);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(112, 54);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // tbxConversa
            // 
            this.tbxConversa.Location = new System.Drawing.Point(12, 12);
            this.tbxConversa.Multiline = true;
            this.tbxConversa.Name = "tbxConversa";
            this.tbxConversa.ReadOnly = true;
            this.tbxConversa.Size = new System.Drawing.Size(776, 366);
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
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxMensagem);
            this.Controls.Add(this.btnFicheiro);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.tbxConversa);
            this.Name = "formCliente1";
            this.Text = "formCliente1";
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
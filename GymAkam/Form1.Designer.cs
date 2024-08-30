namespace GymAkam
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
            this.btn_register = new System.Windows.Forms.Button();
            this.btn_renew = new System.Windows.Forms.Button();
            this.btn_paymentType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(66, 102);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(172, 73);
            this.btn_register.TabIndex = 0;
            this.btn_register.Text = "Registrar Cliente";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_renew
            // 
            this.btn_renew.Location = new System.Drawing.Point(379, 102);
            this.btn_renew.Name = "btn_renew";
            this.btn_renew.Size = new System.Drawing.Size(172, 73);
            this.btn_renew.TabIndex = 1;
            this.btn_renew.Text = "Renovar Cliente";
            this.btn_renew.UseVisualStyleBackColor = true;
            this.btn_renew.Click += new System.EventHandler(this.btn_renew_Click);
            // 
            // btn_paymentType
            // 
            this.btn_paymentType.Location = new System.Drawing.Point(224, 257);
            this.btn_paymentType.Name = "btn_paymentType";
            this.btn_paymentType.Size = new System.Drawing.Size(172, 73);
            this.btn_paymentType.TabIndex = 2;
            this.btn_paymentType.Text = "Tipo de Pago";
            this.btn_paymentType.UseVisualStyleBackColor = true;
            this.btn_paymentType.Click += new System.EventHandler(this.btn_paymentType_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 430);
            this.Controls.Add(this.btn_paymentType);
            this.Controls.Add(this.btn_renew);
            this.Controls.Add(this.btn_register);
            this.Name = "Form1";
            this.Text = "GymAKAM - Inicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Button btn_renew;
        private System.Windows.Forms.Button btn_paymentType;
    }
}


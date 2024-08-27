namespace GymAkam
{
    partial class Contabilidad
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
            this.dt_client = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_surname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_paymentDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_enabled = new System.Windows.Forms.TextBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.txt_delete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_clientID = new System.Windows.Forms.TextBox();
            this.txt_dni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dt_client)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_client
            // 
            this.dt_client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_client.Location = new System.Drawing.Point(12, 12);
            this.dt_client.Name = "dt_client";
            this.dt_client.ReadOnly = true;
            this.dt_client.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_client.Size = new System.Drawing.Size(639, 184);
            this.dt_client.TabIndex = 0;
            this.dt_client.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_client_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(12, 266);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(148, 20);
            this.txt_name.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido";
            // 
            // txt_surname
            // 
            this.txt_surname.Location = new System.Drawing.Point(213, 266);
            this.txt_surname.Name = "txt_surname";
            this.txt_surname.Size = new System.Drawing.Size(142, 20);
            this.txt_surname.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha de Pago";
            // 
            // txt_paymentDay
            // 
            this.txt_paymentDay.Location = new System.Drawing.Point(395, 331);
            this.txt_paymentDay.Name = "txt_paymentDay";
            this.txt_paymentDay.Size = new System.Drawing.Size(136, 20);
            this.txt_paymentDay.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Habilitado";
            // 
            // txt_enabled
            // 
            this.txt_enabled.Location = new System.Drawing.Point(395, 266);
            this.txt_enabled.Name = "txt_enabled";
            this.txt_enabled.Size = new System.Drawing.Size(136, 20);
            this.txt_enabled.TabIndex = 8;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(567, 321);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(84, 30);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "Actualizar";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // txt_delete
            // 
            this.txt_delete.Location = new System.Drawing.Point(567, 261);
            this.txt_delete.Name = "txt_delete";
            this.txt_delete.Size = new System.Drawing.Size(84, 29);
            this.txt_delete.TabIndex = 10;
            this.txt_delete.Text = "Borrar";
            this.txt_delete.UseVisualStyleBackColor = true;
            this.txt_delete.Click += new System.EventHandler(this.txt_delete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "ID";
            // 
            // txt_clientID
            // 
            this.txt_clientID.Location = new System.Drawing.Point(15, 331);
            this.txt_clientID.Name = "txt_clientID";
            this.txt_clientID.Size = new System.Drawing.Size(145, 20);
            this.txt_clientID.TabIndex = 12;
            // 
            // txt_dni
            // 
            this.txt_dni.Location = new System.Drawing.Point(213, 331);
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.Size = new System.Drawing.Size(142, 20);
            this.txt_dni.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "DNI";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(412, 443);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(119, 39);
            this.btn_search.TabIndex = 15;
            this.btn_search.Text = "Buscar";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Buscar por DNI:";
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(213, 453);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(142, 20);
            this.txt_search.TabIndex = 17;
            // 
            // Contabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 530);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_dni);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_clientID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.txt_enabled);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_paymentDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_surname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_client);
            this.Name = "Contabilidad";
            this.Text = "Contabilidad";
            ((System.ComponentModel.ISupportInitialize)(this.dt_client)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dt_client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_surname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_paymentDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_enabled;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button txt_delete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_clientID;
        private System.Windows.Forms.TextBox txt_dni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_search;
    }
}
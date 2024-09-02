namespace GymAkam
{
    partial class Ganancias
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_from = new System.Windows.Forms.TextBox();
            this.txt_to = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.gv_transactions = new System.Windows.Forms.DataGridView();
            this.lbl_profit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gv_transactions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde (AAAA-MM-DD)";
            // 
            // txt_from
            // 
            this.txt_from.Location = new System.Drawing.Point(27, 30);
            this.txt_from.Name = "txt_from";
            this.txt_from.Size = new System.Drawing.Size(138, 20);
            this.txt_from.TabIndex = 1;
            // 
            // txt_to
            // 
            this.txt_to.Location = new System.Drawing.Point(201, 30);
            this.txt_to.Name = "txt_to";
            this.txt_to.Size = new System.Drawing.Size(138, 20);
            this.txt_to.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta (AAAA-MM-DD)";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(713, 15);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(110, 35);
            this.btn_search.TabIndex = 4;
            this.btn_search.Text = "Buscar";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // gv_transactions
            // 
            this.gv_transactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_transactions.Location = new System.Drawing.Point(27, 71);
            this.gv_transactions.Name = "gv_transactions";
            this.gv_transactions.Size = new System.Drawing.Size(796, 470);
            this.gv_transactions.TabIndex = 5;
            // 
            // lbl_profit
            // 
            this.lbl_profit.AutoSize = true;
            this.lbl_profit.Location = new System.Drawing.Point(697, 573);
            this.lbl_profit.Name = "lbl_profit";
            this.lbl_profit.Size = new System.Drawing.Size(0, 13);
            this.lbl_profit.TabIndex = 7;
            // 
            // Ganancias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 595);
            this.Controls.Add(this.lbl_profit);
            this.Controls.Add(this.gv_transactions);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_to);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_from);
            this.Controls.Add(this.label1);
            this.Name = "Ganancias";
            this.Text = "Ganancias";
            ((System.ComponentModel.ISupportInitialize)(this.gv_transactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_from;
        private System.Windows.Forms.TextBox txt_to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView gv_transactions;
        private System.Windows.Forms.Label lbl_profit;
    }
}
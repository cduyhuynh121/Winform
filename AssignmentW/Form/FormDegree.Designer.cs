
namespace AssignmentW
{
    partial class FormDegree
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
            this.buttonsearch = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttondelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNAme = new System.Windows.Forms.TextBox();
            this.buttonedit = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsearch
            // 
            this.buttonsearch.Location = new System.Drawing.Point(716, 12);
            this.buttonsearch.Name = "buttonsearch";
            this.buttonsearch.Size = new System.Drawing.Size(71, 23);
            this.buttonsearch.TabIndex = 43;
            this.buttonsearch.Text = "Search";
            this.buttonsearch.UseVisualStyleBackColor = true;
            this.buttonsearch.Click += new System.EventHandler(this.buttonsearch_Click);
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(547, 14);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(163, 20);
            this.textBoxFind.TabIndex = 42;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(537, 385);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ID";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(110, 354);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(58, 23);
            this.buttonCancel.TabIndex = 21;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttondelete
            // 
            this.buttondelete.Location = new System.Drawing.Point(175, 304);
            this.buttondelete.Name = "buttondelete";
            this.buttondelete.Size = new System.Drawing.Size(64, 23);
            this.buttondelete.TabIndex = 19;
            this.buttondelete.Text = "Delete";
            this.buttondelete.UseVisualStyleBackColor = true;
            this.buttondelete.Click += new System.EventHandler(this.buttondelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxNAme);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttondelete);
            this.panel1.Controls.Add(this.buttonedit);
            this.panel1.Controls.Add(this.buttonCreate);
            this.panel1.Location = new System.Drawing.Point(542, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 385);
            this.panel1.TabIndex = 36;
            // 
            // textBoxType
            // 
            this.textBoxType.Location = new System.Drawing.Point(14, 103);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(225, 20);
            this.textBoxType.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Name";
            // 
            // textBoxNAme
            // 
            this.textBoxNAme.Location = new System.Drawing.Point(14, 37);
            this.textBoxNAme.Name = "textBoxNAme";
            this.textBoxNAme.Size = new System.Drawing.Size(225, 20);
            this.textBoxNAme.TabIndex = 23;
            // 
            // buttonedit
            // 
            this.buttonedit.Location = new System.Drawing.Point(95, 304);
            this.buttonedit.Name = "buttonedit";
            this.buttonedit.Size = new System.Drawing.Size(59, 23);
            this.buttonedit.TabIndex = 18;
            this.buttonedit.Text = "Edit";
            this.buttonedit.UseVisualStyleBackColor = true;
            this.buttonedit.Click += new System.EventHandler(this.buttonedit_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(14, 304);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(58, 23);
            this.buttonCreate.TabIndex = 17;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // FormDegree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonsearch);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormDegree";
            this.Text = "FormDegree";
            this.Load += new System.EventHandler(this.FormDegree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Button buttonsearch;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttondelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNAme;
        private System.Windows.Forms.Button buttonedit;
        private System.Windows.Forms.Button buttonCreate;
    }
}
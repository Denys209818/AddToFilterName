
namespace AddElementToFilterName
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.tvFilter = new System.Windows.Forms.TreeView();
            this.lblMain = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.tvFilter);
            this.gbFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbFilter.ForeColor = System.Drawing.Color.Red;
            this.gbFilter.Location = new System.Drawing.Point(13, 13);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(345, 425);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Актуальний список фільтрів";
            // 
            // tvFilter
            // 
            this.tvFilter.Location = new System.Drawing.Point(7, 34);
            this.tvFilter.Name = "tvFilter";
            this.tvFilter.Size = new System.Drawing.Size(332, 385);
            this.tvFilter.TabIndex = 0;
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblMain.Location = new System.Drawing.Point(459, 105);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(259, 35);
            this.lblMain.TabIndex = 1;
            this.lblMain.Text = "Додати новий фільтр";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFilter.Location = new System.Drawing.Point(419, 159);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PlaceholderText = "Назва фільтру";
            this.txtFilter.Size = new System.Drawing.Size(336, 41);
            this.txtFilter.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.Location = new System.Drawing.Point(459, 223);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(259, 70);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Додати";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.gbFilter);
            this.Name = "MainForm";
            this.Text = "Головна сторінка";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbFilter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TreeView tvFilter;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnSubmit;
    }
}


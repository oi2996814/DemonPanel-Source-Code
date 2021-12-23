namespace Demon_Panel
{
    partial class SimpleInjector
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
            this.siticoneRoundedNumericUpDown1 = new Siticone.UI.WinForms.SiticoneRoundedNumericUpDown();
            this.siticoneRoundedButton1 = new Siticone.UI.WinForms.SiticoneRoundedButton();
            this.Legacy = new Siticone.UI.WinForms.SiticoneCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.siticoneRoundedNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // siticoneRoundedNumericUpDown1
            // 
            this.siticoneRoundedNumericUpDown1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneRoundedNumericUpDown1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(44)))), ((int)(((byte)(29)))));
            this.siticoneRoundedNumericUpDown1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.siticoneRoundedNumericUpDown1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.siticoneRoundedNumericUpDown1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.siticoneRoundedNumericUpDown1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.siticoneRoundedNumericUpDown1.DisabledState.Parent = this.siticoneRoundedNumericUpDown1;
            this.siticoneRoundedNumericUpDown1.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.siticoneRoundedNumericUpDown1.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.siticoneRoundedNumericUpDown1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.siticoneRoundedNumericUpDown1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneRoundedNumericUpDown1.FocusedState.Parent = this.siticoneRoundedNumericUpDown1;
            this.siticoneRoundedNumericUpDown1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneRoundedNumericUpDown1.ForeColor = System.Drawing.Color.White;
            this.siticoneRoundedNumericUpDown1.Location = new System.Drawing.Point(116, 91);
            this.siticoneRoundedNumericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.siticoneRoundedNumericUpDown1.Name = "siticoneRoundedNumericUpDown1";
            this.siticoneRoundedNumericUpDown1.ShadowDecoration.Parent = this.siticoneRoundedNumericUpDown1;
            this.siticoneRoundedNumericUpDown1.Size = new System.Drawing.Size(248, 36);
            this.siticoneRoundedNumericUpDown1.TabIndex = 0;
            this.siticoneRoundedNumericUpDown1.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(44)))), ((int)(((byte)(29)))));
            this.siticoneRoundedNumericUpDown1.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // siticoneRoundedButton1
            // 
            this.siticoneRoundedButton1.CheckedState.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.CustomImages.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(44)))), ((int)(((byte)(29)))));
            this.siticoneRoundedButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneRoundedButton1.ForeColor = System.Drawing.Color.White;
            this.siticoneRoundedButton1.HoveredState.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.Location = new System.Drawing.Point(116, 184);
            this.siticoneRoundedButton1.Name = "siticoneRoundedButton1";
            this.siticoneRoundedButton1.ShadowDecoration.Parent = this.siticoneRoundedButton1;
            this.siticoneRoundedButton1.Size = new System.Drawing.Size(248, 36);
            this.siticoneRoundedButton1.TabIndex = 1;
            this.siticoneRoundedButton1.Text = "Inject";
            this.siticoneRoundedButton1.Click += new System.EventHandler(this.siticoneRoundedButton1_Click);
            // 
            // Legacy
            // 
            this.Legacy.AutoSize = true;
            this.Legacy.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Legacy.CheckedState.BorderRadius = 2;
            this.Legacy.CheckedState.BorderThickness = 0;
            this.Legacy.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Legacy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Legacy.ForeColor = System.Drawing.Color.White;
            this.Legacy.Location = new System.Drawing.Point(116, 147);
            this.Legacy.Name = "Legacy";
            this.Legacy.Size = new System.Drawing.Size(103, 21);
            this.Legacy.TabIndex = 2;
            this.Legacy.Text = "With Legacy";
            this.Legacy.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Legacy.UncheckedState.BorderRadius = 2;
            this.Legacy.UncheckedState.BorderThickness = 0;
            this.Legacy.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Legacy.UseVisualStyleBackColor = true;
            // 
            // SimpleInjector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(485, 392);
            this.Controls.Add(this.Legacy);
            this.Controls.Add(this.siticoneRoundedButton1);
            this.Controls.Add(this.siticoneRoundedNumericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SimpleInjector";
            this.Text = "SimpleInjector";
            ((System.ComponentModel.ISupportInitialize)(this.siticoneRoundedNumericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.UI.WinForms.SiticoneRoundedNumericUpDown siticoneRoundedNumericUpDown1;
        private Siticone.UI.WinForms.SiticoneRoundedButton siticoneRoundedButton1;
        private Siticone.UI.WinForms.SiticoneCheckBox Legacy;
    }
}
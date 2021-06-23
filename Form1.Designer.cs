
namespace project
{
    partial class MainMenu
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
            this.Create_button = new System.Windows.Forms.Button();
            this.Play_button = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.Play_Button_2 = new System.Windows.Forms.Button();
            this.C_button = new System.Windows.Forms.Button();
            this.Pause_button_2 = new System.Windows.Forms.Button();
            this.duration_field = new System.Windows.Forms.TextBox();
            this.frequency_field = new System.Windows.Forms.TextBox();
            this.amplitude_field = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.filename_field = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Done_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Create_button
            // 
            this.Create_button.Location = new System.Drawing.Point(12, 12);
            this.Create_button.Name = "Create_button";
            this.Create_button.Size = new System.Drawing.Size(242, 80);
            this.Create_button.TabIndex = 0;
            this.Create_button.Text = "Create a WAV FIle";
            this.Create_button.UseVisualStyleBackColor = true;
            this.Create_button.Click += new System.EventHandler(this.Create_button_Click);
            // 
            // Play_button
            // 
            this.Play_button.Enabled = false;
            this.Play_button.Location = new System.Drawing.Point(12, 110);
            this.Play_button.Name = "Play_button";
            this.Play_button.Size = new System.Drawing.Size(242, 40);
            this.Play_button.TabIndex = 1;
            this.Play_button.Text = "Play / Pause";
            this.Play_button.UseVisualStyleBackColor = true;
            this.Play_button.Click += new System.EventHandler(this.Play_button_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(302, 12);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(242, 80);
            this.OpenButton.TabIndex = 2;
            this.OpenButton.Text = "Open a WAV FIle";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // Play_Button_2
            // 
            this.Play_Button_2.Enabled = false;
            this.Play_Button_2.Location = new System.Drawing.Point(302, 236);
            this.Play_Button_2.Name = "Play_Button_2";
            this.Play_Button_2.Size = new System.Drawing.Size(242, 40);
            this.Play_Button_2.TabIndex = 3;
            this.Play_Button_2.Text = "Play choosen wavfile";
            this.Play_Button_2.UseVisualStyleBackColor = true;
            this.Play_Button_2.Click += new System.EventHandler(this.Play_Button_2_Click);
            // 
            // C_button
            // 
            this.C_button.Location = new System.Drawing.Point(302, 179);
            this.C_button.Name = "C_button";
            this.C_button.Size = new System.Drawing.Size(242, 40);
            this.C_button.TabIndex = 4;
            this.C_button.Text = "Choose a wavfile to play";
            this.C_button.UseVisualStyleBackColor = true;
            this.C_button.Click += new System.EventHandler(this.C_button_Click);
            // 
            // Pause_button_2
            // 
            this.Pause_button_2.Enabled = false;
            this.Pause_button_2.Location = new System.Drawing.Point(302, 290);
            this.Pause_button_2.Name = "Pause_button_2";
            this.Pause_button_2.Size = new System.Drawing.Size(242, 40);
            this.Pause_button_2.TabIndex = 5;
            this.Pause_button_2.Text = "Stop playing choosen wavfile";
            this.Pause_button_2.UseVisualStyleBackColor = true;
            this.Pause_button_2.Click += new System.EventHandler(this.Pause_button_2_Click);
            // 
            // duration_field
            // 
            this.duration_field.Location = new System.Drawing.Point(141, 177);
            this.duration_field.Name = "duration_field";
            this.duration_field.Size = new System.Drawing.Size(113, 23);
            this.duration_field.TabIndex = 6;
            this.duration_field.Visible = false;
            // 
            // frequency_field
            // 
            this.frequency_field.Location = new System.Drawing.Point(141, 221);
            this.frequency_field.Name = "frequency_field";
            this.frequency_field.Size = new System.Drawing.Size(113, 23);
            this.frequency_field.TabIndex = 7;
            this.frequency_field.Visible = false;
            // 
            // amplitude_field
            // 
            this.amplitude_field.Location = new System.Drawing.Point(141, 263);
            this.amplitude_field.Name = "amplitude_field";
            this.amplitude_field.Size = new System.Drawing.Size(113, 23);
            this.amplitude_field.TabIndex = 8;
            this.amplitude_field.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(2, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "duration (s) :";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(2, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "frequency (Hz) :";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "amplitude (1-49) :";
            this.label3.Visible = false;
            // 
            // filename_field
            // 
            this.filename_field.Location = new System.Drawing.Point(105, 304);
            this.filename_field.Name = "filename_field";
            this.filename_field.Size = new System.Drawing.Size(149, 23);
            this.filename_field.TabIndex = 12;
            this.filename_field.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(7, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "file name:";
            this.label4.Visible = false;
            // 
            // Done_button
            // 
            this.Done_button.Enabled = false;
            this.Done_button.Location = new System.Drawing.Point(178, 344);
            this.Done_button.Name = "Done_button";
            this.Done_button.Size = new System.Drawing.Size(75, 23);
            this.Done_button.TabIndex = 14;
            this.Done_button.Text = "Done";
            this.Done_button.UseVisualStyleBackColor = true;
            this.Done_button.Visible = false;
            this.Done_button.Click += new System.EventHandler(this.Done_button_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 381);
            this.Controls.Add(this.Done_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filename_field);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.amplitude_field);
            this.Controls.Add(this.frequency_field);
            this.Controls.Add(this.duration_field);
            this.Controls.Add(this.Pause_button_2);
            this.Controls.Add(this.C_button);
            this.Controls.Add(this.Play_Button_2);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.Play_button);
            this.Controls.Add(this.Create_button);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Create_button;
        private System.Windows.Forms.Button Play_button;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button Play_Button_2;
        private System.Windows.Forms.Button C_button;
        private System.Windows.Forms.Button Pause_button_2;
        private System.Windows.Forms.TextBox duration_field;
        private System.Windows.Forms.TextBox frequency_field;
        private System.Windows.Forms.TextBox amplitude_field;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox filename_field;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Done_button;
    }
}


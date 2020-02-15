namespace MessageTranscriber
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAudioFile = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTranscribe = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.txtServiceAcct = new System.Windows.Forms.Button();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "mp3";
            this.openFileDialog1.Title = "Select Audio";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Audio File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblAudioFile
            // 
            this.lblAudioFile.AutoSize = true;
            this.lblAudioFile.Location = new System.Drawing.Point(214, 77);
            this.lblAudioFile.Name = "lblAudioFile";
            this.lblAudioFile.Size = new System.Drawing.Size(0, 13);
            this.lblAudioFile.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResponse);
            this.groupBox1.Controls.Add(this.btnTranscribe);
            this.groupBox1.Location = new System.Drawing.Point(60, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 299);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transcribe";
            // 
            // btnTranscribe
            // 
            this.btnTranscribe.Location = new System.Drawing.Point(20, 20);
            this.btnTranscribe.Name = "btnTranscribe";
            this.btnTranscribe.Size = new System.Drawing.Size(75, 23);
            this.btnTranscribe.TabIndex = 0;
            this.btnTranscribe.Text = "Transcribe File";
            this.btnTranscribe.UseVisualStyleBackColor = true;
            this.btnTranscribe.Click += new System.EventHandler(this.btnTranscribe_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(6, 49);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(696, 244);
            this.txtResponse.TabIndex = 1;
            // 
            // txtServiceAcct
            // 
            this.txtServiceAcct.Location = new System.Drawing.Point(80, 48);
            this.txtServiceAcct.Name = "txtServiceAcct";
            this.txtServiceAcct.Size = new System.Drawing.Size(146, 23);
            this.txtServiceAcct.TabIndex = 3;
            this.txtServiceAcct.Text = "Select Service Account File";
            this.txtServiceAcct.UseVisualStyleBackColor = true;
            this.txtServiceAcct.Click += new System.EventHandler(this.txtServiceAcct_Click);
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(80, 120);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(35, 13);
            this.lblElapsedTime.TabIndex = 4;
            this.lblElapsedTime.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.txtServiceAcct);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAudioFile);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblAudioFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btnTranscribe;
        private System.Windows.Forms.Button txtServiceAcct;
        private System.Windows.Forms.Label lblElapsedTime;
    }
}


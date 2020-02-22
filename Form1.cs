using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Speech.V1;
using MessageTranscriber.Models;

namespace MessageTranscriber
{
    public partial class Form1 : Form
    {
        private GCPStorageManager manager;
        public Form1()
        {
            
            InitializeComponent();
            manager = new GCPStorageManager();
            if (!manager.LoadCredentials())
            {
                MessageBox.Show("Select a settings file to connect to the associated gcp account.");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.lblAudioFile.Text = string.Empty;
            this.openFileDialog1.Title = "Select Audio File";
            this.openFileDialog1.ShowDialog();
            
            displayLoader(true);
            if (manager.UploadFile(this.openFileDialog1.FileName))
            {
                this.lblAudioFile.Text = this.openFileDialog1.SafeFileName;                
            }
            else
            {
                this.lblAudioFile.Text = "There was an error saving your file!";
            }
            displayLoader(false);
        }

        private void btnTranscribe_Click(object sender, EventArgs e)
        {

            // send speech to text request
            displayLoader(true);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                // the code that you want to measure comes here
                
                var speech = SpeechClient.Create();
                var longOperation = speech.LongRunningRecognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.EncodingUnspecified,
                    SampleRateHertz = 16000,
                    LanguageCode = "en-US",
                    Model="video"
                   
                }, RecognitionAudio.FromStorageUri("gs://rho-transcribe-files/"+ this.openFileDialog1.SafeFileName));

                longOperation = longOperation.PollUntilCompleted();
                var response = longOperation.Result;
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                TimeSpan t = TimeSpan.FromMilliseconds(elapsedMs);
                string processTime = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                        t.Hours,
                                        t.Minutes,
                                        t.Seconds,
                                        t.Milliseconds);

                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        txtResponse.Text += alternative.Transcript + " \n";
                    }
                }

                lblElapsedTime.Text = processTime;
            
            displayLoader(false);
            SaveTextToFile();
            

        }

      
        private void displayLoader(bool isVisible)
        {
            this.pictureBox1.Visible = isVisible;

        }

        private void addGCPSettingsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "Select GCP credentials file";
            this.openFileDialog1.ShowDialog();
            if (manager.setExternalCredentialFile(this.openFileDialog1.FileName))
            {
                MessageBox.Show("GCP Credentials updated!", "Success");
            }
            else
            {
                MessageBox.Show("Unable to set credentials.", "Error");
            }
        }


        private void SaveTextToFile()
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, txtResponse.Text);
                    MessageBox.Show(sfd.FileName + " Saved!", "Success");
                }
            }
        }
    }
}

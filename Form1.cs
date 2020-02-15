using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Speech.V1;

namespace MessageTranscriber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "Select Audio File";
            this.openFileDialog1.ShowDialog();
            this.lblAudioFile.Text = this.openFileDialog1.SafeFileName;
        }

        private void btnTranscribe_Click(object sender, EventArgs e)
        {

            if(this.openFileDialog1.FileNames.Length > 0)
            {
                // send speech to text request

                var speech = SpeechClient.Create();
                var longOperation = speech.LongRunningRecognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.EncodingUnspecified,
                    SampleRateHertz = 16000,
                    LanguageCode = "en",
                    Model="video"
                   
                }, RecognitionAudio.FromStorageUri("gs://rho-transcribe-files/EngagingMsg.mp3"));

                longOperation = longOperation.PollUntilCompleted();
                var response = longOperation.Result;

                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        txtResponse.Text += alternative.Transcript + " \n";
                    }
                }

            }
        }

        private void txtServiceAcct_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "Select Service Account File";
            this.openFileDialog1.ShowDialog();
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", this.openFileDialog1.FileName);
        }
    }
}

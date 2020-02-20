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
            manager.LoadCredentials();

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
                var watch = System.Diagnostics.Stopwatch.StartNew();
                // the code that you want to measure comes here
                
                var speech = SpeechClient.Create();
                var longOperation = speech.LongRunningRecognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.EncodingUnspecified,
                    SampleRateHertz = 16000,
                    LanguageCode = "en-US",
                    Model="video"
                   
                }, RecognitionAudio.FromStorageUri("gs://rho-transcribe-files/EngaingthePowerofPrayerSmall.mp3"));

                longOperation = longOperation.PollUntilCompleted();
                var response = longOperation.Result;
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                TimeSpan t = TimeSpan.FromMilliseconds(elapsedMs);
                string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
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

                lblElapsedTime.Text = answer;
            }
        }

      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace AppRequestGenerator
{
    public partial class ControlSmtpRequest : UserControl
    {
        public ControlSmtpRequest()
        {
            InitializeComponent();

            // Enable the first available protocol
            this.toolStripComboBoxRequestFormat.SelectedIndex = 0;

            // Select the first output tab
            if (this.tabControlResponse.TabPages.Count > 0)
            {
                this.tabControlResponse.SelectedTab = this.tabControlResponse.TabPages[0];
            }

#if DEBUG
            this.textBoxURI.Text = "http://10.143.45.158:9200";
#endif
        }

        public ControlSmtpRequest(TabSettings settings)
        {
            InitializeComponent();

            // Enable the first available protocol
            this.toolStripComboBoxRequestFormat.SelectedIndex = 0;

            // Select the first output tab
            if (this.tabControlResponse.TabPages.Count > 0)
            {
                this.tabControlResponse.SelectedTab = this.tabControlResponse.TabPages[0];
            }

            this.textBoxURI.Text = (string)settings.Settings["URL"];
        }

        public TabSettings SaveControlSettings()
        {
            string url = this.textBoxURI.Text.Trim();

            TabSettings settings = new TabSettings(String.Format("HTTP: {0}", url));
            settings.Settings.Add("URL", url);
            return settings;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            dynamic requestInfos = e.Argument;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestInfos.URL);
            request.Method = requestInfos.RequestMethod;
            foreach (string str in requestInfos.RequestHeaders)
            {
                if ((str == null) || (str.Length < 1))
                {
                    continue;
                }
                request.Headers.Add(str);
            }
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            e.Result = response;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            var requestInfos = new {
                URL = this.textBoxURI.Text.Trim(),
                RequestMethod = "POST",
                RequestHeaders = this.textBoxRequestHeaders.Text.Split(System.Environment.NewLine.ToCharArray())
            };
            this.backgroundWorker1.RunWorkerAsync(requestInfos);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(String.Format("Error: {0}", e.Error.Message.ToString()));
                return;
            }

            HttpWebResponse response = (HttpWebResponse)e.Result;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                this.textBoxResponseRaw.Text = responseText;

                // Convert the string to an JSON object and reconvert the object to a pretty formatted string
                var tmpJsonObject = JsonConvert.DeserializeObject(responseText);
                var tmpJsonString = JsonConvert.SerializeObject(tmpJsonObject, Formatting.Indented);
                this.textBoxRepsonsePretty.Text = tmpJsonString;
            }

            /*
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII))
            {
                writer.Write("content=" + dlc_content);
            }
            */
        }
    }
}

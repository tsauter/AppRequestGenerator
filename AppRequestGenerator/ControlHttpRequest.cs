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
using System.Text.RegularExpressions;

namespace AppRequestGenerator
{
    public partial class ControlHttpRequest : UserControl
    {
        public ControlHttpRequest()
        {
            InitializeComponent();

            this.Name = "HTTP/HTTPS";

            int gridWidth = this.dataGridView1.Size.Width;
            this.dataGridView1.Columns[0].Width = gridWidth / 3;
            this.dataGridView1.Columns[1].Width = gridWidth- this.dataGridView1.Columns[0].Width;

            // Enable the first available protocol
            this.comboBoxProtocol.SelectedIndex = 0;
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

        public ControlHttpRequest(TabSettings settings)
        {
            InitializeComponent();

            // Enable the first available protocol
            this.comboBoxProtocol.SelectedIndex = 0;
            this.toolStripComboBoxRequestFormat.SelectedIndex = 0;

            // Select the first output tab
            if (this.tabControlResponse.TabPages.Count > 0)
            {
                this.tabControlResponse.SelectedTab = this.tabControlResponse.TabPages[0];
            }

            if (settings.Settings.ContainsKey("URL"))
            {
                this.textBoxURI.Text = (string)settings.Settings["URL"];
            }
            if (settings.Settings.ContainsKey("Protocol"))
            {
                if(!this.comboBoxProtocol.Items.Contains((string)settings.Settings["Protocol"]))
                {
                    MessageBox.Show(string.Format("Stored protocol {0} not supported. Please verify restored settings before starting the request.", (string)settings.Settings["Protocol"]),
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.comboBoxProtocol.Text = (string)settings.Settings["Protocol"];
            }
        }

        public TabSettings SaveControlSettings()
        {
            string url = this.textBoxURI.Text.Trim();

            TabSettings settings = new TabSettings(this.Name);
            settings.Settings.Add("Protocol", this.comboBoxProtocol.Text);
            settings.Settings.Add("URL", url);
            return settings;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            dynamic requestInfos = e.Argument;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestInfos.URL);
            request.Method = requestInfos.RequestMethod;
            /*
            foreach (string str in requestInfos.RequestHeaders)
            {
                if ((str == null) || (str.Length < 1))
                {
                    continue;
                }

                Regex splitRegex = new Regex(@"(.*):\s*(.*)");
                Match headerParts = splitRegex.Match(str);

                if (headerParts.Groups[1].Value.ToLower() == "content-type")
                {
                    request.ContentType = headerParts.Groups[2].Value;
                }
                else
                {
                    try
                    {
                        request.Headers.Add(headerParts.Groups[1].Value, headerParts.Groups[2].Value);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(String.Format("Unable to add header: {0}.", ex.Message.ToString()));
                    }
                }
            }
            */

            if (request.Accept == null)
            {
                request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                e.Result = response;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Web request failed: {0}.", ex.Message.ToString()));
            }

            return;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            var requestInfos = new {
                URL = this.textBoxURI.Text.Trim(),
                RequestMethod = this.comboBoxProtocol.Text.Trim().ToUpper(),
            };

            //RequestHeaders = this.textBoxRequestHeaders.Text.Split(System.Environment.NewLine.ToCharArray())

            if (this.backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Request is already running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.backgroundWorker1.RunWorkerAsync(requestInfos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Failed to start new request: {0}", ex.Message.ToString()));
                return;
            }

            SetMouseCursorOnAllControls(this, Cursors.WaitCursor);
            this.toolStripButton1.Enabled = false;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetMouseCursorOnAllControls(this, Cursors.Default);
            this.toolStripButton1.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show(String.Format("Error: {0}", e.Error.Message.ToString()));
                return;
            }

            HttpWebResponse response = (HttpWebResponse)e.Result;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd().Replace("\n", "\r\n");
                this.textBoxResponseRaw.Text = responseText;

                // Convert the string to an JSON object and reconvert the object to a pretty formatted string
                string tmpJsonString = responseText; // default is the raw response text
                try
                {
                    var tmpJsonObject = JsonConvert.DeserializeObject(responseText);
                    tmpJsonString = JsonConvert.SerializeObject(tmpJsonObject, Formatting.Indented);
                }
                catch (Exception)
                {
                    //MessageBox.Show("Unable to parse response as JSON object.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.textBoxRepsonsePretty.Text = tmpJsonString;

                this.webBrowser1.DocumentText = tmpJsonString;
            }

            /*
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII))
            {
                writer.Write("content=" + dlc_content);
            }
            */
        }

        private void SetMouseCursorOnAllControls(Control startControl, Cursor newCursor)
        {
            try
            {
                startControl.Cursor = newCursor;
            }
            catch (NotSupportedException)
            {
            }

            foreach (Control c in startControl.Controls)
            {
                try {
                    c.Cursor = newCursor;
                }
                catch(NotSupportedException)
                {
                }
                this.SetMouseCursorOnAllControls(c, newCursor);
            }
        }

        private void textBoxURI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var parentTab = this.textBoxURI.Parent.Parent.Parent.Parent;
                parentTab.Text = String.Format("{0}: {1}", this.Name, this.textBoxURI.Text.Trim().ToLower());
            }
            catch 
            {
            }
        }

        private void textBoxURI_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                toolStripButton1_Click_1(sender, e);
            }
        }
    }
}

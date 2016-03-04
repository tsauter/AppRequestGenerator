using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppRequestGenerator
{
    public partial class MainForm : Form
    {
        // TODO, can we create these to variables dynamically?
        private enum RequestType { Http_Https, Smtp };
        private Dictionary<RequestType, Type> AvailableRequests = new Dictionary<RequestType, Type> {
            { RequestType.Http_Https, typeof(ControlHttpRequest) },
            { RequestType.Smtp, typeof(ControlSmtpRequest) }
        };

        public MainForm()
        {
            InitializeComponent();

            // Sizing the main window and positioning the main splitter
            this.Width = 1000;
            this.Height = 600;
            this.splitContainer1.SplitterDistance = 200;
        }

        private void CreateNewTab(RequestType requestType)
        {
            UserControl dynamicControl;
            try
            {
                Type selectedRequestType = this.AvailableRequests[requestType];
                dynamicControl = (UserControl)Activator.CreateInstance(selectedRequestType);
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Invalid request type: {0}", ex.Message.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TabPage protocolTabPage = new TabPage();
            protocolTabPage.Text = dynamicControl.Name;
            dynamicControl.Dock = DockStyle.Fill;
            protocolTabPage.Controls.Add(dynamicControl);

            this.tabControl1.TabPages.Add(protocolTabPage);
            this.tabControl1.SelectedTab = protocolTabPage;

            this.ActiveControl = this.tabControl1;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.treeView1.SelectedNode;
            if(selectedNode == null)
            {
                return;
            }

            TabSettings settings = (TabSettings)selectedNode.Tag;

            TabPage protocolTabPage = new TabPage();
            protocolTabPage.Text = settings.Name;
            ControlHttpRequest dynamicControl = new ControlHttpRequest(settings);
            dynamicControl.Dock = DockStyle.Fill;
            protocolTabPage.Controls.Add(dynamicControl);

            this.tabControl1.TabPages.Add(protocolTabPage);
            this.tabControl1.SelectedTab = protocolTabPage;
        }

        private void toolStripSplitButtonNewRequest_ButtonClick(object sender, EventArgs e)
        {
            this.CreateNewTab(RequestType.Http_Https);
        }

        private void bnmhgToolStripMenuItemNewHttpRequest_Click(object sender, EventArgs e)
        {
            this.CreateNewTab(RequestType.Http_Https);
        }

        private void sMTPToolStripMenuItemNewSmtpRequest_Click(object sender, EventArgs e)
        {
            this.CreateNewTab(RequestType.Smtp);
        }

        private void toolStripButtonBookmarkTab_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab == null)
            {
                MessageBox.Show("No Request tab selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TabPage currentTab = this.tabControl1.SelectedTab;
            ControlHttpRequest controlRequest = (ControlHttpRequest)currentTab.Controls[0];
            TabSettings settings = (TabSettings)controlRequest.SaveControlSettings();

            TreeNode newNode = new TreeNode();
            newNode.Text = settings.Name;
            newNode.Tag = settings;
            this.treeView1.Nodes.Add(newNode);
        }
    }
}

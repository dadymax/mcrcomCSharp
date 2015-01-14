using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mcrconCSharp
{
    public partial class RconForm : Form
    {
        public RconForm()
        {
            InitializeComponent();
        }

        Rcon rcon;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text;
            if (!host.Contains(':'))
            {
                Message("\"Host\" field did non contain port information. Example: 127.0.0.1:25575");
                return;
            }

            if (host.Count(c => c == ':') > 1)
            {
                Message("\"Host\" field contain too many ':' symbols. Example: 127.0.0.1:25575");
                return;
            }

            var splitted = host.Split(':');

            try
            {
                rcon = new Rcon(splitted[0], int.Parse(splitted[1]), txtPass.Text);
            }
            catch (Exception ex)
            {
                Message(ex.Message + Environment.NewLine + ex.StackTrace);
                return;
            }

            rcon.onConnectionAliveChange += new Rcon.ConnectionStateChanged(rcon_onConnectionAliveChange);
        }

        void rcon_onConnectionAliveChange(bool state)
        {
            radbtnConnectionState.Checked = state;
        }

        private void Message(string msg, string caption = "Error")
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            txtResponse.Text = rcon.ProcessCommand(txtCommand.Text);
        }
    }
}

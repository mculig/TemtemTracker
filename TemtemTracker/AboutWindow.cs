using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemtemTracker
{
    public partial class AboutWindow : Form
    {

        private readonly string GITHUB_URL = "https://github.com/mculig";
        private readonly string ALICE_URL_1 = "https://alicepeters.de/";
        private readonly string ALICE_URL_2 = "https://parou.moe/";

        public AboutWindow()
        {
            InitializeComponent();
        }

        private void AboutWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void LinkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(GITHUB_URL);
            linkGithub.LinkVisited = true;
        }

        private void LinkAlice1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ALICE_URL_1);
            linkAlice1.LinkVisited = true;
        }

        private void LinkAlice2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ALICE_URL_2);
            linkAlice2.LinkVisited = true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMGLibrary;

namespace RMGLibrary
{
    namespace Forms
    {
        public partial class About : Form
        {
            public string r = null;

            public About(string a, Image b, Image c, string d)
            {
                InitializeComponent();
                r = a;
                pictureBox1.Image = b;
                pictureBox2.Image = c;
                label1.Text = "Made by RMGRich.\n" + d;
            }

            private void showChangelog(object sender, EventArgs e)
            {
                if (Internet.isConnected() == false)
                {
                    MessageBox.Show("Not connected to the internet.", "Not Connected", MessageBoxButtons.OK);
                    return;
                }
                Console.WriteLine("fetching");
                string[][] data = RMGLibrary.Changelog.getData(r, 0);
                Console.WriteLine("fetched");
                new Changelog(data).ShowDialog();
            }
        }
    }
}
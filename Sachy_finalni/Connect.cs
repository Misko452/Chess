using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sachy_finalni
{
    public partial class Connect : Form
    {
        public Connect()
        {
            InitializeComponent();
        }

        //Proměnné pro připojení

        string IP = "";
        string cizIP = "";

        int port = 0;
        int cizport = 0;

        string strana = "";

        Form1 form1;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //načte všechny potřebné proměnné a připojí se
                IP = mistniIP.Text;
                cizIP = ciziIP.Text;

                port = int.Parse(mistniPort.Text);
                cizport = int.Parse(ciziPort.Text);

                strana = comboBox1.Text;

                IPAddress mistniip = IPAddress.Parse(IP);
                IPAddress ciziip = IPAddress.Parse(cizIP);

                if (strana != "")
                {
                    form1 = new Form1(IP, cizIP, port, cizport, strana);
                    this.Hide();
                    form1.ShowDialog();
                    this.Show();
                }
                else
                    MessageBox.Show("Musíš si vybrat stranu!", "POZOR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception chyba)
            {
                MessageBox.Show(chyba.Message);
            }
        }
    }
}

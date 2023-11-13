using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace Sachy_finalni
{
    public partial class Form1 : Form
    {

        //Proměnné pro funkci hry

        public Button[,] sachovnice = new Button[8, 8];

        public Bunka[,] bunka;

        Sachovnice vnitreksachovnice;

        int x;
        int y;

        int minuleX;
        int minuleY;

        int pocetkliknuti = 0;

        string typ = "";
        string kliknutatyp = "";


        int velikost = 8;

        //Proměnné pro síťovou komunikaci

        string IP = "";
        string cizIP = "";

        int port = 0;
        int cizport = 0;

        string strana = "";

        private Socket komunikace;
        EndPoint lokalnibod;
        EndPoint cizibod;
        byte[] buffer = null;

        string infoprosend = "";

        bool narade = false;
            
        public Form1(string IP, string cizIP, int port, int cizport, string strana)
        {
            //Základ hrací plochy
            InitializeComponent();
            vnitreksachovnice = new Sachovnice(velikost);
            Vygenerujpolicka();

            //Inicializace proměnných pro komuikaci
            this.IP = IP;
            this.cizIP = cizIP;
            this.port = port;
            this.cizport = cizport;
            this.strana = strana;

            textBox1.Text = strana;

            //Rozhodnutí kdo je na řadě
            if (strana == "Bílý")
            {
                narade = true;
            }
            else if (strana == "Černý")
            {
                narade = false;  
            }
            
            //Metoda která podle toho povolí hrát 
            Prepnitlacitka();
        }

        private void Vygenerujpolicka()
        {
            //Propojí lokální buňky s těma z jiné třídy
            bunka = vnitreksachovnice.bunka;

            //nastavi velikost generovaných tlačítek
            int velikost_tlacitka = panel1.Width / 8;
            panel1.Height = panel1.Width;

            //generování tlačítkek
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    sachovnice[i, j] = new Button();
                    sachovnice[i, j].Name = "prazdnepolicko";
                    sachovnice[i, j].Height = velikost_tlacitka;
                    sachovnice[i, j].Width = velikost_tlacitka;
                    sachovnice[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    typ = sachovnice[i, j].Name;
                    bunka[i, j].Typ = typ;

                    //Prebarvi policka podle pravidel šachu
                    if (j % 2 == 0 && i % 2 == 1)
                    {
                        sachovnice[i,j].BackColor = Color.DarkKhaki;
                    }
                    else if (j % 2 == 1 && i % 2 == 0)
                    {
                        sachovnice[i, j].BackColor = Color.DarkKhaki;
                    }

                    //Přidáme click event ke každému tlačítku
                    sachovnice[i, j].Click += Kliknuti_na_tlacitko;

                    //prida tlacitko do panelu
                    panel1.Controls.Add(sachovnice[i, j]);

                    //Nastavi lokaci lokaci tlacitka
                    sachovnice[i,j].Location = new Point(i * velikost_tlacitka, j * velikost_tlacitka);

                    sachovnice[i, j].Tag = new Point(i, j);

                }
            }

            //Rozestaví figurky na základní pozice
            RozestavNazacatek();
        }

        private void Kliknuti_na_tlacitko(object sender, EventArgs e)
        {
            //Ziska x a y kliknuteho tlacitka
            
            Button Stisknutetlacitko = (Button) sender;
            Point lokace = (Point)Stisknutetlacitko.Tag;

            x = lokace.X;
            y = lokace.Y;

            kliknutatyp = sachovnice[x, y].Name;
            Bunka soucasna = vnitreksachovnice.bunka[x, y];


            if (pocetkliknuti == 0)
            {
                //urci legalni pohyby
                vnitreksachovnice.UkazDalsipohyb(soucasna, typ, kliknutatyp, strana);

                //Vyznačí legální pohyby
                for (int i = 0; i < vnitreksachovnice.Velikost; i++)
                {
                    for (int j = 0; j < vnitreksachovnice.Velikost; j++)
                    {
                        if (vnitreksachovnice.bunka[i, j].Dalsitah == true)
                        {
                            
                            sachovnice[i, j].Image = Properties.Resources.teckaaa; 
                            
                        }
                        
                    }
                }


                //Vypne všechna tlačítka krom legálních pohybů a stisknutého
                for (int m = 0; m < vnitreksachovnice.Velikost; m++)
                {
                    for (int n = 0; n < vnitreksachovnice.Velikost; n++)
                    {
                        if (vnitreksachovnice.bunka[m, n].Dalsitah == false)
                        {
                            sachovnice[m, n].Enabled = false;
                            Stisknutetlacitko.Enabled = true;
                        }
                        else
                        {
                            sachovnice[m, n].Enabled = true;
                        }
                    }
                }

                minuleX = x;
                minuleY = y;

                pocetkliknuti++;
            }
            else
            {
                //Stará se o funkce tlačítek zda se vypínaj a nebo zapínaj 
                if (Stisknutetlacitko == sachovnice[minuleX, minuleY])
                {
                    for (int m = 0; m < vnitreksachovnice.Velikost; m++)
                    {
                        for (int n = 0; n < vnitreksachovnice.Velikost; n++)
                        {
                            if (vnitreksachovnice.bunka[m, n].Dalsitah == false)
                            {
                                if (strana == "Bílý")
                                { 
                                    if (sachovnice[m, n].Name.Contains("Cerna") || sachovnice[m, n].Name == "prazdnepolicko")
                                    {
                                         sachovnice[m, n].Enabled = false;
                                    }
                                    else
                                    {
                                        sachovnice[m, n].Enabled = true;
                                    }
                                }
                                else if (strana == "Černý")
                                {
                                    if (sachovnice[m, n].Name.Contains("Bila") || sachovnice[m, n].Name == "prazdnepolicko")
                                    {
                                        sachovnice[m, n].Enabled = false;
                                    }
                                    else
                                    {
                                        sachovnice[m, n].Enabled = true;
                                    }

                                }
                            }
                            else
                            {
                                sachovnice[m, n].Image = null;
                                vnitreksachovnice.bunka[m, n].Dalsitah = false;
                            }
                        }
                    }
                }
                else
                {
                    //Metoda která se postará o přesun figurky
                    Presunfigurky();

                    //Zobrazení tlačítek v případě že něčí pěšák dojde na konec
                    if (sachovnice[x, y].Name == "Pesak;Bila" && y == 0)
                    {
                        pictureBoxVyberKraloB.Visible = true;
                        pictureBoxVyberKunB.Visible = true;
                        pictureBoxVyberStrelecB.Visible = true;
                        pictureBoxVyberVezB.Visible = true;

                    }
                    else if (sachovnice[x, y].Name == "Pesak;Cerna" && y == 7)
                    {
                        pictureBoxVyberKraloC.Visible = true;
                        pictureBoxVyberKunC.Visible = true;
                        pictureBoxVyberStrelecC.Visible = true;
                        pictureBoxVyberVezC.Visible = true;

                    }
                    else
                    {
                        narade = false;

                        Prepnitlacitka();

                        //odešle potřebné souřadnice po síti
                        infoprosend = minuleX + ";" + minuleY + ";" + x + ";" + y + ";";

                        Odesli();

                    }

                    //Vyresetuje všechny stopy po legálních pohybech před pohybem
                    for (int a = 0; a < vnitreksachovnice.Velikost; a++)
                    {
                        for (int b = 0; b < vnitreksachovnice.Velikost; b++)
                        {
                            sachovnice[a, b].Image = null;
                        }
                    }

                }
                //Vyresetuje počítadlo kliknutí
                pocetkliknuti = 0;
            }
           

        }

        public void Presunfigurky()
        {
            //Přesune obrázek i parametry políček
            sachovnice[x, y].BackgroundImage = sachovnice[minuleX, minuleY].BackgroundImage;
            sachovnice[x, y].Name = sachovnice[minuleX, minuleY].Name;
            bunka[x, y].Typ = sachovnice[x, y].Name;

            //vynuluje stopy po staré pozici
            sachovnice[minuleX, minuleY].BackgroundImage = null;
            sachovnice[minuleX, minuleY].Name = "prazdnepolicko";
            bunka[minuleX, minuleY].Typ = "prazdnepolicko";
        }

        //Nejvíc nepřehledná a zmatená metoda v tomhle kódu ale funguje to :D
        //Přepíná tlačítka a řeší kdo je na řadě
        public void Prepnitlacitka()
        {
            if (narade == true)
            {
                for (int v = 0; v < 8; v++)
                {
                    for (int u = 0; u < 8; u++)
                    {
                        if (sachovnice[v, u].Name == "prazdnepolicko")
                        {
                            sachovnice[v, u].Enabled = false;
                        }
                        else
                        {
                            sachovnice[v, u].Enabled = true;
                        }
                        
                    }
                }

                if (strana == "Bílý")
                {
                    for (int o = 0; o < 8; o++)
                    {
                        for (int p = 0; p < 8; p++)
                        {
                            if (sachovnice[o, p].Name.Contains("Cerna"))
                            {
                                sachovnice[o, p].Enabled = false;
                            }
                        }
                    }
                }
                else if (strana == "Černý")
                {
                    for (int o = 0; o < 8; o++)
                    {
                        for (int p = 0; p < 8; p++)
                        {
                            if (sachovnice[o, p].Name.Contains("Bila"))
                            {
                                sachovnice[o, p].Enabled = false;
                            }
                        }
                    }

                }

            }
            else if (narade == false)
            {
                for (int o = 0; o < 8; o++)
                {
                    for (int p = 0; p < 8; p++)
                    {
                        sachovnice[o, p].Enabled = false;  
                    }
                }

                narade = true;
            }
        }

        public void RozestavNazacatek()
        {
            //Rozestaví políčka
           
            //Věže
            typ = "Vez";
            sachovnice[0, 7].BackgroundImage = Properties.Resources.Bvez;
            sachovnice[0, 7].Name = "Vez;Bila";
            bunka[0, 7].Typ = "Vez;Bila";

            sachovnice[7, 7].BackgroundImage = Properties.Resources.Bvez;
            sachovnice[7, 7].Name = "Vez;Bila";
            bunka[7, 7].Typ = "Vez;Bila";

            sachovnice[0, 0].BackgroundImage = Properties.Resources.CVez;
            sachovnice[0, 0].Name = "Vez;Cerna";
            bunka[0, 0].Typ = "Vez;Cerna";

            sachovnice[7, 0].BackgroundImage = Properties.Resources.CVez;
            sachovnice[7, 0].Name = "Vez;Cerna";
            bunka[7, 0].Typ = "Vez;Cerna";

            //Koně
            typ = "Kun";
            sachovnice[1, 7].BackgroundImage = Properties.Resources.Bkun;
            sachovnice[1, 7].Name = "Kun;Bila";
            bunka[1, 7].Typ = "Kun;Bila";

            sachovnice[6, 7].BackgroundImage = Properties.Resources.Bkun;
            sachovnice[6, 7].Name = "Kun;Bila";
            bunka[6, 7].Typ = "Kun;Bila";

            sachovnice[1, 0].BackgroundImage = Properties.Resources.Ckun;
            sachovnice[1, 0].Name = "Kun;Cerna";
            bunka[1, 0].Typ = "Kun;Cerna";

            sachovnice[6, 0].BackgroundImage = Properties.Resources.Ckun;
            sachovnice[6, 0].Name = "Kun;Cerna";
            bunka[6, 0].Typ = "Kun;Cerna";

            //Střelci
            typ = "Strelec";
            sachovnice[5, 7].BackgroundImage = Properties.Resources.Bbishop;
            sachovnice[5, 7].Name = "Strelec;Bila";
            bunka[5, 7].Typ = "Strelec;Bila";

            sachovnice[2, 7].BackgroundImage = Properties.Resources.Bbishop;
            sachovnice[2, 7].Name = "Strelec;Bila";
            bunka[2, 7].Typ = "Strelec;Bila";

            sachovnice[2, 0].BackgroundImage = Properties.Resources.Cbishop;
            sachovnice[2, 0].Name = "Strelec;Cerna";
            bunka[2, 0].Typ = "Strelec;Cerna";

            sachovnice[5, 0].BackgroundImage = Properties.Resources.Cbishop;
            sachovnice[5, 0].Name = "Strelec;Cerna";
            bunka[5, 0].Typ = "Strelec;Cerna";

            //Královny
            typ = "Kralovna";
            sachovnice[3, 7].BackgroundImage = Properties.Resources.Bkralovna;
            sachovnice[3, 7].Name = "Kralovna;Bila";
            bunka[3, 7].Typ = "Kralovna;Bila";

            sachovnice[3, 0].BackgroundImage = Properties.Resources.Ckralovna;
            sachovnice[3, 0].Name = "Kralovna;Cerna";
            bunka[3, 0].Typ = "Kralovna;Cerna";

            //Králové
            typ = "Kral";
            sachovnice[4, 7].BackgroundImage = Properties.Resources.Bkral;
            sachovnice[4, 7].Name = "Kral;Bila";
            bunka[4, 7].Typ = "Kral;Bila";

            sachovnice[4, 0].BackgroundImage = Properties.Resources.Ckral;
            sachovnice[4, 0].Name = "Kral;Cerna";
            bunka[4, 0].Typ = "Kral;Cerna";

            //Pěšáci
            typ = "Pesak";
            for (int i = 0; i < 8; i++)
            {
                sachovnice[i, 6].BackgroundImage = Properties.Resources.Bpawn;
                sachovnice[i, 6].Name = "Pesak;Bila";
                bunka[i, 6].Typ = "Pesak;Bila";

                sachovnice[i, 1].BackgroundImage = Properties.Resources.Cpawn;
                sachovnice[i, 1].Name = "Pesak;Cerna";
                bunka[i, 1].Typ = "Pesak;Cerna";

            }
        }

        //Kód který se postará o pěšáka na konci
        private void pictureBoxVyberKraloB_Click(object sender, EventArgs e)
        {
            sachovnice[x, y].BackgroundImage = Properties.Resources.Bkralovna;
            sachovnice[x, y].Name = "Kralovna;";

            pictureBoxVyberKraloB.Visible = false;
            pictureBoxVyberKunB.Visible = false;
            pictureBoxVyberStrelecB.Visible = false;
            pictureBoxVyberVezB.Visible = false;

            infoprosend = minuleX + ";" + minuleY + ";" + x + ";" + y + ";" + "BKralovna";

            Odesli();
        }

        private void pictureBoxVyberVezB_Click(object sender, EventArgs e)
        {
            sachovnice[x, y].BackgroundImage = Properties.Resources.Bvez;
            sachovnice[x, y].Name = "Vez;";

            pictureBoxVyberKraloB.Visible = false;
            pictureBoxVyberKunB.Visible = false;
            pictureBoxVyberStrelecB.Visible = false;
            pictureBoxVyberVezB.Visible = false;

            infoprosend = minuleX + ";" + minuleY + ";" + x + ";" + y + ";" + "BVez";

            Odesli();
        }

        private void pictureBoxVyberKunB_Click(object sender, EventArgs e)
        {
            sachovnice[x, y].BackgroundImage = Properties.Resources.Bkun;
            sachovnice[x, y].Name = "Kun;";

            pictureBoxVyberKraloB.Visible = false;
            pictureBoxVyberKunB.Visible = false;
            pictureBoxVyberStrelecB.Visible = false;
            pictureBoxVyberVezB.Visible = false;

            infoprosend = minuleX + ";" + minuleY + ";" + x + ";" + y + ";" + "BKun";

            Odesli();
        }

        private void pictureBoxVyberStrelecB_Click(object sender, EventArgs e)
        {
            sachovnice[x, y].BackgroundImage = Properties.Resources.Bbishop;
            sachovnice[x, y].Name = "Strelec;";

            pictureBoxVyberKraloB.Visible = false;
            pictureBoxVyberKunB.Visible = false;
            pictureBoxVyberStrelecB.Visible = false;
            pictureBoxVyberVezB.Visible = false;

            infoprosend = minuleX + ";" + minuleY + ";" + x + ";" + y + ";" + "BStrelec";

            Odesli();
        }

        private void pictureBoxVyberKraloC_Click(object sender, EventArgs e)
        {
            sachovnice[x, y].BackgroundImage = Properties.Resources.Ckralovna;
            sachovnice[x, y].Name = "Kralovna;";

            pictureBoxVyberKraloC.Visible = false;
            pictureBoxVyberKunC.Visible = false;
            pictureBoxVyberStrelecC.Visible = false;
            pictureBoxVyberVezC.Visible = false;

            infoprosend = minuleX + ";" + minuleY + ";" + x + ";" + y + ";" + "CKralovna";

            Odesli();
        }

        private void pictureBoxVyberVezC_Click(object sender, EventArgs e)
        {
            sachovnice[x, y].BackgroundImage = Properties.Resources.CVez;
            sachovnice[x, y].Name = "Vez;";

            pictureBoxVyberKraloC.Visible = false;
            pictureBoxVyberKunC.Visible = false;
            pictureBoxVyberStrelecC.Visible = false;
            pictureBoxVyberVezC.Visible = false;

            infoprosend = minuleX + ";" + minuleY + ";" + x + ";" + y + ";" + "CVez";

            Odesli();
        }

        private void pictureBoxVyberKunC_Click(object sender, EventArgs e)
        {
            sachovnice[x, y].BackgroundImage = Properties.Resources.Ckun;
            sachovnice[x, y].Name = "Kun;";

            pictureBoxVyberKraloC.Visible = false;
            pictureBoxVyberKunC.Visible = false;
            pictureBoxVyberStrelecC.Visible = false;
            pictureBoxVyberVezC.Visible = false;

            infoprosend = minuleX + ";" + minuleY + ";" + x + ";" + y + ";" + "CKun";

            Odesli();
        }

        private void pictureBoxVyberStrelecC_Click(object sender, EventArgs e)
        {
            sachovnice[x, y].BackgroundImage = Properties.Resources.Cbishop;
            sachovnice[x, y].Name = "Strelec;";

            pictureBoxVyberKraloC.Visible = false;
            pictureBoxVyberKunC.Visible = false;
            pictureBoxVyberStrelecC.Visible = false;
            pictureBoxVyberVezC.Visible = false;

            infoprosend = minuleX + ";" + minuleY + ";" + x + ";" + y + ";" + "CStrelec";

            Odesli();
        }

        //Metody pro síťovou komunikaci
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Inicializuje komunikaci a naváže jí
                komunikace = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                komunikace.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                //Přiřadí a načte IP adresy a porty
                IPAddress lokalniIp = IPAddress.Parse(IP);
                int lokalniport = port;
                lokalnibod = new IPEndPoint(lokalniIp, lokalniport);

                IPAddress CiziIp = IPAddress.Parse(cizIP);
                int Ciziport = cizport;
                cizibod = new IPEndPoint(CiziIp, Ciziport);

                //Připojí
                komunikace.Bind(lokalnibod);
                komunikace.Connect(cizibod);

                buffer = new byte[2500];

                ZahajKomunikaci();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "CHYBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZahajKomunikaci()
        {
            //Načte velikost bufferu
            buffer = new byte[2500];

            //Začne odposlech komunikace a v případě přijmu se odkáže na metodu zpracování
            komunikace.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref cizibod,
                new AsyncCallback(Zpracovani), buffer);
        }

        private void Zpracovani(IAsyncResult vysledek)
        {
            try
            {
                //Načte si velikost zprávy
                int velikostzpravy = komunikace.EndReceiveFrom(vysledek, ref cizibod);

                bool vyrizeno = false;

                while(vyrizeno == false)
                {
                    if (velikostzpravy > 0)
                    {
                        //Vytvoří si pomocné pole
                        byte[] pomocnepole = new byte[buffer.Length];
                        pomocnepole = (byte[])vysledek.AsyncState;

                        //dekoduje zpravu
                        UTF8Encoding dekodovac = new UTF8Encoding();
                        string zprava = dekodovac.GetString(pomocnepole);

                        //pošle zpátky na vlákno kde je grafické rozhraní
                        Invoke(new Action(() =>
                        {
                            //pracuje se zprávou

                            //načte si proměnné ze zprávy
                            string[] kouskyzpravy = zprava.Split(';');
                            minuleX = int.Parse(kouskyzpravy[0]);
                            minuleY = int.Parse(kouskyzpravy[1]);
                            x = int.Parse(kouskyzpravy[2]);
                            y = int.Parse(kouskyzpravy[3]);

                            //přesune figurku podle těch proměnných
                            Presunfigurky();

                            //Další zmatečný ify, ale starají se o to aby komunikace počítala i s proměnama pěšáků
                            if (kouskyzpravy[4] != "")
                            {
                                if (kouskyzpravy[4].Contains("Kralovna"))
                                {
                                    if (kouskyzpravy[4].Contains("B"))
                                    {
                                        sachovnice[x, y].BackgroundImage = Properties.Resources.Bkralovna;
                                    }
                                    else
                                    {
                                        sachovnice[x, y].BackgroundImage = Properties.Resources.Ckralovna;
                                    }


                                }
                                else if (kouskyzpravy[4].Contains("Vez"))
                                {
                                    if (kouskyzpravy[4].Contains("B"))
                                    {
                                        sachovnice[x, y].BackgroundImage = Properties.Resources.Bvez;
                                    }
                                    else
                                    {
                                        sachovnice[x, y].BackgroundImage = Properties.Resources.CVez;
                                    }


                                }
                                else if (kouskyzpravy[4].Contains("Kun"))
                                {
                                    if (kouskyzpravy[4].Contains("B"))
                                    {
                                        sachovnice[x, y].BackgroundImage = Properties.Resources.Bkun;
                                    }
                                    else
                                    {
                                        sachovnice[x, y].BackgroundImage = Properties.Resources.Ckun;
                                    }


                                }
                                else if (kouskyzpravy[4].Contains("Strelec"))
                                {
                                    if (kouskyzpravy[4].Contains("B"))
                                    {
                                        sachovnice[x, y].BackgroundImage = Properties.Resources.Bbishop;
                                    }
                                    else
                                    {
                                        sachovnice[x, y].BackgroundImage = Properties.Resources.Cbishop;
                                    }

                                }
                            }

                            Prepnitlacitka();
                        }
                        ));

                        //Resetuje velikost bufferu
                        buffer = new byte[2500];

                        vyrizeno = true;
                    }
                }
                
                ZahajKomunikaci();

                vyrizeno = false;
            }
            catch (Exception chyba)
            {
                MessageBox.Show(chyba.Message, "CHYBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Zakóduje a odešle zprávu
        private void Odesli()
        {
            UTF8Encoding kodovac = new UTF8Encoding();
            byte[] zprava = new byte[buffer.Length];

            zprava = kodovac.GetBytes(infoprosend);

            komunikace.Send(zprava);
            //richTextBoxKonzole.Text = richTextBoxKonzole.Text + nick + ": " + infoprosend + "\n";
        }
    }
}

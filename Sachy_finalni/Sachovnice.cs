using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sachy_finalni
{
    public class Sachovnice
    {
        //2d pole buněk 
        public Bunka[,] bunka { get; set; }

        //Velikost buňky
        public int Velikost { get; set; }

        //typ do kterého se ukládá co je v buňce za figurku
        string typ;

        string strana = "";

        //Konstruktor
        public Sachovnice(int velikost)
        {
            //Velikost plochy je definována Skem
            Velikost = velikost;          

            //vytvoření 2d Arraye
            bunka = new Bunka[Velikost, Velikost];


            //Naplnění arraye buňkami
            for (int i = 0; i < Velikost; i++)
            {
                for (int j = 0; j < Velikost; j++)
                {
                    bunka[i, j] = new Bunka(i, j, typ);
                    
                }
            }
            
        }

        public void UkazDalsipohyb(Bunka soucasna,string typ, string kliknutatyp, string strana)
        {
            //Pročistí všechny předchozí pohyby
            for (int i = 0; i < Velikost; i++)
            {
                for (int j = 0; j < Velikost; j++)
                {
                    bunka[i, j].Dalsitah = false;
                    bunka[i, j].Zabrano = false;
                }
            }

            //Načte si typ ze jména tlčítka které se načetlo do typu ve formu
            this.typ = typ;
            string[] rodelenitypu = kliknutatyp.Split(';');
            this.strana = strana;

            //Najde další možné pohyby
            switch (rodelenitypu[0])
            {
                //konik je nejtežší na výpočet ale má společně s pěšákem a králem nejjednodušší kód
                case "Kun":

                    if (strana == "Bílý")
                    {
                        //nahoru
                        if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna")
                               || bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna")
                               || bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }


                        //strany1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce + 2 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 2].Typ.Contains("Cerna")
                               || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 2].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce - 2 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 2].Typ.Contains("Cerna")
                               || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 2].Dalsitah = true;
                            }
                        }

                        //dolu
                        if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna")
                               || bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna")
                               || bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }

                        //strany2
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce + 2 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 2].Typ.Contains("Cerna")
                               || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 2].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce - 2 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 2].Typ.Contains("Cerna")
                               || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 2].Dalsitah = true;
                            }
                        }
                    }
                    else if (strana == "Černý")
                    {
                        //nahoru
                        if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 1].Typ.Contains("Bila")
                               || bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 1].Typ.Contains("Bila")
                               || bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }


                        //strany1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce + 2 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 2].Typ.Contains("Bila")
                               || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 2].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce - 2 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 2].Typ.Contains("Bila")
                               || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 2].Dalsitah = true;
                            }
                        }

                        //dolu
                        if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 1].Typ.Contains("Bila")
                               || bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 1].Typ.Contains("Bila")
                               || bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }

                        //strany2
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce + 2 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 2].Typ.Contains("Bila")
                               || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 2].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce - 2 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 2].Typ.Contains("Bila")
                               || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 2].Dalsitah = true;
                            }
                        }
                    }

                    break;
                case "Kral":
                    

                    if (strana == "Bílý")
                    {
                        //Šikmo
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna")
                                || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            } 
                        }
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna")
                                || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna")
                                || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }                            
                        }
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna")
                                || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }

                        //Strany
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ.Contains("Cerna")
                                || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ.Contains("Cerna")
                                || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna")
                                || bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna")
                                || bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }
                    }
                    else if (strana == "Černý")
                    {
                        //Šikmo
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ.Contains("Bily")
                                || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ.Contains("Bily")
                                || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ.Contains("Bily")
                                || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ.Contains("Bily")
                                || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }

                        //Strany
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ.Contains("Bily")
                                || bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ.Contains("Bily")
                                || bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        { 
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ.Contains("Bily")
                                || bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                        }
                        if (soucasna.CisloRadky <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ.Contains("Bily")
                                || bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                        }
                    }

                    break;

                case "Kralovna":

                    if (strana == "Bílý")
                    {
                        //1,1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //2,2
                                if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //3,3
                                        if (soucasna.CisloRadky + 3 <= 7 && soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //4,4
                                                if (soucasna.CisloRadky + 4 <= 7 && soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //5,5
                                                        if (soucasna.CisloRadky + 5 <= 7 && soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //6,6
                                                                if (soucasna.CisloRadky + 6 <= 7 && soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //7,7
                                                                        if (soucasna.CisloRadky + 7 <= 7 && soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,-1
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //-2,-2
                                if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //-3,-3
                                        if (soucasna.CisloRadky - 3 >= 0 && soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //-4,-4
                                                if (soucasna.CisloRadky - 4 >= 0 && soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //-5,-5
                                                        if (soucasna.CisloRadky - 5 >= 0 && soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - +5, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //-6,-6
                                                                if (soucasna.CisloRadky - 6 >= 0 && soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //-7,-7
                                                                        if (soucasna.CisloRadky - 7 >= 0 && soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //1,-1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //2,-2
                                if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //3,-3
                                        if (soucasna.CisloRadky + 3 <= 7 && soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //4,-4
                                                if (soucasna.CisloRadky + 4 <= 7 && soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //5,-5
                                                        if (soucasna.CisloRadky + 5 <= 7 && soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //6,-6
                                                                if (soucasna.CisloRadky + 6 <= 7 && soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //7,-7
                                                                        if (soucasna.CisloRadky + 7 <= 7 && soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,1
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //-2,2
                                if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //-3,3
                                        if (soucasna.CisloRadky - 3 >= 0 && soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //-4,4
                                                if (soucasna.CisloRadky - 4 >= 0 && soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //-5,5
                                                        if (soucasna.CisloRadky - 5 >= 0 && soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //-6,6
                                                                if (soucasna.CisloRadky - 6 >= 0 && soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //-7,7
                                                                        if (soucasna.CisloRadky - 7 >= 0 && soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //1,0
                        if (soucasna.CisloRadky + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;

                                //2,0
                                if (soucasna.CisloRadky + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Dalsitah = true;

                                        //3,0
                                        if (soucasna.CisloRadky + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Dalsitah = true;

                                                //4,0
                                                if (soucasna.CisloRadky + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Dalsitah = true;

                                                        //5,0
                                                        if (soucasna.CisloRadky + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Dalsitah = true;

                                                                //6,0
                                                                if (soucasna.CisloRadky + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Dalsitah = true;

                                                                        //7,0
                                                                        if (soucasna.CisloRadky + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //0,1
                        if (soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //0,2
                                if (soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //0,3
                                        if (soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //0,4
                                                if (soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //0,5
                                                        if (soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //0,6
                                                                if (soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //0,7
                                                                        if (soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,0
                        if (soucasna.CisloRadky - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;

                                //-2,0
                                if (soucasna.CisloRadky - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Dalsitah = true;

                                        //-3,0
                                        if (soucasna.CisloRadky - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Dalsitah = true;

                                                //-4,0
                                                if (soucasna.CisloRadky - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Dalsitah = true;

                                                        //-5,0
                                                        if (soucasna.CisloRadky - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Dalsitah = true;

                                                                //-6,0
                                                                if (soucasna.CisloRadky - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Dalsitah = true;

                                                                        //-7,0
                                                                        if (soucasna.CisloRadky - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //0,-1
                        if (soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //0,-2
                                if (soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //0,-3
                                        if (soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //0,-4
                                                if (soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //0,-5
                                                        if (soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //0,-6
                                                                if (soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //0,-7
                                                                        if (soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (strana == "Černý")
                    {
                        //1,1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //2,2
                                if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //3,3
                                        if (soucasna.CisloRadky + 3 <= 7 && soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //4,4
                                                if (soucasna.CisloRadky + 4 <= 7 && soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //5,5
                                                        if (soucasna.CisloRadky + 5 <= 7 && soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //6,6
                                                                if (soucasna.CisloRadky + 6 <= 7 && soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //7,7
                                                                        if (soucasna.CisloRadky + 7 <= 7 && soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,-1
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //-2,-2
                                if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //-3,-3
                                        if (soucasna.CisloRadky - 3 >= 0 && soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //-4,-4
                                                if (soucasna.CisloRadky - 4 >= 0 && soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //-5,-5
                                                        if (soucasna.CisloRadky - 5 >= 0 && soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - +5, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //-6,-6
                                                                if (soucasna.CisloRadky - 6 >= 0 && soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //-7,-7
                                                                        if (soucasna.CisloRadky - 7 >= 0 && soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //1,-1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //2,-2
                                if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //3,-3
                                        if (soucasna.CisloRadky + 3 <= 7 && soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //4,-4
                                                if (soucasna.CisloRadky + 4 <= 7 && soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //5,-5
                                                        if (soucasna.CisloRadky + 5 <= 7 && soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //6,-6
                                                                if (soucasna.CisloRadky + 6 <= 7 && soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //7,-7
                                                                        if (soucasna.CisloRadky + 7 <= 7 && soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,1
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //-2,2
                                if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //-3,3
                                        if (soucasna.CisloRadky - 3 >= 0 && soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //-4,4
                                                if (soucasna.CisloRadky - 4 >= 0 && soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //-5,5
                                                        if (soucasna.CisloRadky - 5 >= 0 && soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //-6,6
                                                                if (soucasna.CisloRadky - 6 >= 0 && soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //-7,7
                                                                        if (soucasna.CisloRadky - 7 >= 0 && soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //1,0
                        if (soucasna.CisloRadky + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;

                                //2,0
                                if (soucasna.CisloRadky + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Dalsitah = true;

                                        //3,0
                                        if (soucasna.CisloRadky + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Dalsitah = true;

                                                //4,0
                                                if (soucasna.CisloRadky + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Dalsitah = true;

                                                        //5,0
                                                        if (soucasna.CisloRadky + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Dalsitah = true;

                                                                //6,0
                                                                if (soucasna.CisloRadky + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Dalsitah = true;

                                                                        //7,0
                                                                        if (soucasna.CisloRadky + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //0,1
                        if (soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //0,2
                                if (soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //0,3
                                        if (soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //0,4
                                                if (soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //0,5
                                                        if (soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //0,6
                                                                if (soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //0,7
                                                                        if (soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,0
                        if (soucasna.CisloRadky - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;

                                //-2,0
                                if (soucasna.CisloRadky - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Dalsitah = true;

                                        //-3,0
                                        if (soucasna.CisloRadky - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Dalsitah = true;

                                                //-4,0
                                                if (soucasna.CisloRadky - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Dalsitah = true;

                                                        //-5,0
                                                        if (soucasna.CisloRadky - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Dalsitah = true;

                                                                //-6,0
                                                                if (soucasna.CisloRadky - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Dalsitah = true;

                                                                        //-7,0
                                                                        if (soucasna.CisloRadky - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //0,-1
                        if (soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //0,-2
                                if (soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //0,-3
                                        if (soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //0,-4
                                                if (soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //0,-5
                                                        if (soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //0,-6
                                                                if (soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //0,-7
                                                                        if (soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }



                    break;

                case "Strelec":

                    if (strana == "Bílý")
                    {
                        //1,1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //2,2
                                if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //3,3
                                        if (soucasna.CisloRadky + 3 <= 7 && soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //4,4
                                                if (soucasna.CisloRadky + 4 <= 7 && soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //5,5
                                                        if (soucasna.CisloRadky + 5 <= 7 && soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //6,6
                                                                if (soucasna.CisloRadky + 6 <= 7 && soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //7,7
                                                                        if (soucasna.CisloRadky + 7 <= 7 && soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,-1
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //-2,-2
                                if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //-3,-3
                                        if (soucasna.CisloRadky - 3 >= 0 && soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //-4,-4
                                                if (soucasna.CisloRadky - 4 >= 0 && soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //-5,-5
                                                        if (soucasna.CisloRadky - 5 >= 0 && soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - +5, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //-6,-6
                                                                if (soucasna.CisloRadky - 6 >= 0 && soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //-7,-7
                                                                        if (soucasna.CisloRadky - 7 >= 0 && soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //1,-1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //2,-2
                                if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //3,-3
                                        if (soucasna.CisloRadky + 3 <= 7 && soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //4,-4
                                                if (soucasna.CisloRadky + 4 <= 7 && soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //5,-5
                                                        if (soucasna.CisloRadky + 5 <= 7 && soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //6,-6
                                                                if (soucasna.CisloRadky + 6 <= 7 && soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //7,-7
                                                                        if (soucasna.CisloRadky + 7 <= 7 && soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,1
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //-2,2
                                if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //-3,3
                                        if (soucasna.CisloRadky - 3 >= 0 && soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //-4,4
                                                if (soucasna.CisloRadky - 4 >= 0 && soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //-5,5
                                                        if (soucasna.CisloRadky - 5 >= 0 && soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //-6,6
                                                                if (soucasna.CisloRadky - 6 >= 0 && soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //-7,7
                                                                        if (soucasna.CisloRadky - 7 >= 0 && soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (strana == "Černý")
                    {
                        //1,1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //2,2
                                if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //3,3
                                        if (soucasna.CisloRadky + 3 <= 7 && soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //4,4
                                                if (soucasna.CisloRadky + 4 <= 7 && soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //5,5
                                                        if (soucasna.CisloRadky + 5 <= 7 && soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //6,6
                                                                if (soucasna.CisloRadky + 6 <= 7 && soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //7,7
                                                                        if (soucasna.CisloRadky + 7 <= 7 && soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,-1
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //-2,-2
                                if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //-3,-3
                                        if (soucasna.CisloRadky - 3 >= 0 && soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //-4,-4
                                                if (soucasna.CisloRadky - 4 >= 0 && soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //-5,-5
                                                        if (soucasna.CisloRadky - 5 >= 0 && soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - +5, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //-6,-6
                                                                if (soucasna.CisloRadky - 6 >= 0 && soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //-7,-7
                                                                        if (soucasna.CisloRadky - 7 >= 0 && soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //1,-1
                        if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //2,-2
                                if (soucasna.CisloRadky + 2 <= 7 && soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //3,-3
                                        if (soucasna.CisloRadky + 3 <= 7 && soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //4,-4
                                                if (soucasna.CisloRadky + 4 <= 7 && soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //5,-5
                                                        if (soucasna.CisloRadky + 5 <= 7 && soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //6,-6
                                                                if (soucasna.CisloRadky + 6 <= 7 && soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //7,-7
                                                                        if (soucasna.CisloRadky + 7 <= 7 && soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,1
                        if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //-2,2
                                if (soucasna.CisloRadky - 2 >= 0 && soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //-3,3
                                        if (soucasna.CisloRadky - 3 >= 0 && soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //-4,4
                                                if (soucasna.CisloRadky - 4 >= 0 && soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //-5,5
                                                        if (soucasna.CisloRadky - 5 >= 0 && soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //-6,6
                                                                if (soucasna.CisloRadky - 6 >= 0 && soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //-7,7
                                                                        if (soucasna.CisloRadky - 7 >= 0 && soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "Pesak":
                    if (rodelenitypu[1] == "Bila")
                    {
                        if (soucasna.CisloSLoupce + 1 <= 7 && soucasna.CisloRadky + 1 >= 0)
                        {   
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            if (soucasna.CisloSLoupce == 6)
                            {
                                if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                {
                                    bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                }
                                
                            }
                            if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce - 1 >= 0)
                            {
                                if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ != "prazdnepolicko" 
                                    && bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna"))
                                {
                                    bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                                }
                            }
                            if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce - 1 >= 0)
                            {
                                if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ != "prazdnepolicko"
                                    && bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna"))
                                {
                                    bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce - 1].Dalsitah = true;
                                }
                            }

                        }

                    }
                    else if (rodelenitypu[1] == "Cerna")
                    {
                        if (soucasna.CisloSLoupce + 1 <= 7)
                        {

                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            if (soucasna.CisloSLoupce == 1)
                            {
                                if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                {
                                    bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                }
                            }
                            if (soucasna.CisloRadky + 1 <= 7 && soucasna.CisloSLoupce + 1 <= 7)
                            {
                                if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ != "prazdnepolicko"
                                    && bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Typ.Contains("Bila"))
                                {
                                    bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                                }
                            }
                            if (soucasna.CisloRadky - 1 >= 0 && soucasna.CisloSLoupce + 1 <= 7)
                            {
                                if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ != "prazdnepolicko"
                                    && bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Typ.Contains("Bila"))
                                {
                                    bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce + 1].Dalsitah = true;
                                }
                            }
                        }
                    }
                    break;

                case "Vez":

                    if (strana == "Bílý")
                    {
                        //1,0
                        if (soucasna.CisloRadky + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;

                                //2,0
                                if (soucasna.CisloRadky + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Dalsitah = true;

                                        //3,0
                                        if (soucasna.CisloRadky + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Dalsitah = true;

                                                //4,0
                                                if (soucasna.CisloRadky + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Dalsitah = true;

                                                        //5,0
                                                        if (soucasna.CisloRadky + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Dalsitah = true;

                                                                //6,0
                                                                if (soucasna.CisloRadky + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Dalsitah = true;

                                                                        //7,0
                                                                        if (soucasna.CisloRadky + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //0,1
                        if (soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //0,2
                                if (soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //0,3
                                        if (soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //0,4
                                                if (soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //0,5
                                                        if (soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //0,6
                                                                if (soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //0,7
                                                                        if (soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,0
                        if (soucasna.CisloRadky - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;

                                //-2,0
                                if (soucasna.CisloRadky - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Dalsitah = true;

                                        //-3,0
                                        if (soucasna.CisloRadky - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Dalsitah = true;

                                                //-4,0
                                                if (soucasna.CisloRadky - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Dalsitah = true;

                                                        //-5,0
                                                        if (soucasna.CisloRadky - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Dalsitah = true;

                                                                //-6,0
                                                                if (soucasna.CisloRadky - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Dalsitah = true;

                                                                        //-7,0
                                                                        if (soucasna.CisloRadky - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //0,-1
                        if (soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ.Contains("Cerna"))
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //0,-2
                                if (soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Typ.Contains("Cerna"))
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //0,-3
                                        if (soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Typ.Contains("Cerna"))
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //0,-4
                                                if (soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Typ.Contains("Cerna"))
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //0,-5
                                                        if (soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Typ.Contains("Cerna"))
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //0,-6
                                                                if (soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Typ.Contains("Cerna"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //0,-7
                                                                        if (soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Typ.Contains("Cerna"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (strana == "Černý")
                    {
                        //1,0
                        if (soucasna.CisloRadky + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky + 1, soucasna.CisloSLoupce].Dalsitah = true;

                                //2,0
                                if (soucasna.CisloRadky + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky + 2, soucasna.CisloSLoupce].Dalsitah = true;

                                        //3,0
                                        if (soucasna.CisloRadky + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky + 3, soucasna.CisloSLoupce].Dalsitah = true;

                                                //4,0
                                                if (soucasna.CisloRadky + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky + 4, soucasna.CisloSLoupce].Dalsitah = true;

                                                        //5,0
                                                        if (soucasna.CisloRadky + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky + 5, soucasna.CisloSLoupce].Dalsitah = true;

                                                                //6,0
                                                                if (soucasna.CisloRadky + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky + 6, soucasna.CisloSLoupce].Dalsitah = true;

                                                                        //7,0
                                                                        if (soucasna.CisloRadky + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky + 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //0,1
                        if (soucasna.CisloSLoupce + 1 <= 7)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 1].Dalsitah = true;

                                //0,2
                                if (soucasna.CisloSLoupce + 2 <= 7)
                                {
                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 2].Dalsitah = true;

                                        //0,3
                                        if (soucasna.CisloSLoupce + 3 <= 7)
                                        {
                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 3].Dalsitah = true;

                                                //0,4
                                                if (soucasna.CisloSLoupce + 4 <= 7)
                                                {
                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 4].Dalsitah = true;

                                                        //0,5
                                                        if (soucasna.CisloSLoupce + 5 <= 7)
                                                        {
                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 5].Dalsitah = true;

                                                                //0,6
                                                                if (soucasna.CisloSLoupce + 6 <= 7)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 6].Dalsitah = true;

                                                                        //0,7
                                                                        if (soucasna.CisloSLoupce + 7 <= 7)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce + 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //-1,0
                        if (soucasna.CisloRadky - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky - 1, soucasna.CisloSLoupce].Dalsitah = true;

                                //-2,0
                                if (soucasna.CisloRadky - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky - 2, soucasna.CisloSLoupce].Dalsitah = true;

                                        //-3,0
                                        if (soucasna.CisloRadky - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky - 3, soucasna.CisloSLoupce].Dalsitah = true;

                                                //-4,0
                                                if (soucasna.CisloRadky - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky - 4, soucasna.CisloSLoupce].Dalsitah = true;

                                                        //-5,0
                                                        if (soucasna.CisloRadky - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky - 5, soucasna.CisloSLoupce].Dalsitah = true;

                                                                //-6,0
                                                                if (soucasna.CisloRadky - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky - 6, soucasna.CisloSLoupce].Dalsitah = true;

                                                                        //-7,0
                                                                        if (soucasna.CisloRadky - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                            else if (bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky - 7, soucasna.CisloSLoupce].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //0,-1
                        if (soucasna.CisloSLoupce - 1 >= 0)
                        {
                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ.Contains("Bila"))
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;
                            }
                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Typ == "prazdnepolicko")
                            {
                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 1].Dalsitah = true;

                                //0,-2
                                if (soucasna.CisloSLoupce - 2 >= 0)
                                {
                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Typ.Contains("Bila"))
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Dalsitah = true;
                                    }
                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Typ == "prazdnepolicko")
                                    {
                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 2].Dalsitah = true;

                                        //0,-3
                                        if (soucasna.CisloSLoupce - 3 >= 0)
                                        {
                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Typ.Contains("Bila"))
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Dalsitah = true;
                                            }
                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Typ == "prazdnepolicko")
                                            {
                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 3].Dalsitah = true;

                                                //0,-4
                                                if (soucasna.CisloSLoupce - 4 >= 0)
                                                {
                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Typ.Contains("Bila"))
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Dalsitah = true;
                                                    }
                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Typ == "prazdnepolicko")
                                                    {
                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 4].Dalsitah = true;

                                                        //0,-5
                                                        if (soucasna.CisloSLoupce - 5 >= 0)
                                                        {
                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Typ.Contains("Bila"))
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Dalsitah = true;
                                                            }
                                                            else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Typ == "prazdnepolicko")
                                                            {
                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 5].Dalsitah = true;

                                                                //0,-6
                                                                if (soucasna.CisloSLoupce - 6 >= 0)
                                                                {
                                                                    if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Typ.Contains("Bila"))
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Dalsitah = true;
                                                                    }
                                                                    else if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Typ == "prazdnepolicko")
                                                                    {
                                                                        bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 6].Dalsitah = true;

                                                                        //0,-7
                                                                        if (soucasna.CisloSLoupce - 7 >= 0)
                                                                        {
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Typ.Contains("Bila"))
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                            if (bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Typ == "prazdnepolicko")
                                                                            {
                                                                                bunka[soucasna.CisloRadky, soucasna.CisloSLoupce - 7].Dalsitah = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                        break;

                default:

                    break;
            }
            bunka[soucasna.CisloRadky, soucasna.CisloSLoupce].Zabrano = true;
        }


    }
}

﻿//INFORMAZIONI IMPORTANTI DA NON TOCCARE:
/*
 if you use the hash (outdated md5) of a secret string (too short to be secure) to encrypt the password there is no point in hashing the secret here I think
 tripleDES is also deprecated
 storing secrets in code is security issue,
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;

//https://www.youtube.com/watch?v=5Anto1N_FSs
namespace sceriffo0
{
    public partial class Tasse1 : Form
    {
        // DA FINIRE *non toccare*:
        // Login e registrazione    completati
        // UI                       semi-completa mancano solo decorazioni
        // Tassazione               incompleta
        // Stipendi                 completati
        // Gestione MortiNascite    completati
        // Eventi casuali           incompleta
        // ORA: Tassazione

        Utente User = new Utente(); //utente con password
        Liste Lista = new Liste(); //creazione oggetto lista
        Stato Contea = new Stato(); //creazione oggetto stato

        //inizializzazione array nomi Maschili & femminili
        string[] NomiMaschili = new string[70];
        string[] NomiFemminili = new string[70];
        string[] Cognomi = new string[57];

       

        public Tasse1()
        {
            InitializeComponent();

        }

        private void Tasse1_Load(object sender, EventArgs e)
        {

            pannelRegistrazione.Visible = false;
            panelLogIn.Visible = false;
            PannelloAltoDX.Visible = false;
            PannelloAltoSX.Visible = false;
            PannelloBassoSX.Visible = false;
            PannelloBassoDX.Visible = false;
            if (Directory.Exists(@"Login") == true)
            {
                //deserializzazione del file 
                panelLogIn.Visible = true;
                User = JsonConvert.DeserializeObject<Utente>(File.ReadAllText(String.Format(@"Login\\datilogin.json")));
                //la password viene decrittata secondo lo stesso hash con cui è stata crittata
                string hashDecritt = "cr1tt0gr4f1@";

                byte[] datiPasswordDec = Convert.FromBase64String(User.Password);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] chiavi = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashDecritt));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = chiavi, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform convertitoreDecritto = tripDes.CreateDecryptor();
                        byte[] convertitoDecritto = convertitoreDecritto.TransformFinalBlock(datiPasswordDec, 0, datiPasswordDec.Length);
                        //prima si deserializza, poi si decodifica

                        User.Password = UTF8Encoding.UTF8.GetString(convertitoDecritto);

                    }

                }
            }
            else
            {
                Directory.CreateDirectory(@"Login");
                pannelRegistrazione.Visible = true;
            }
            //creazione array nomi maschili

            NomiMaschili[0] = "Hugh";
            NomiMaschili[1] = "Baudwin";
            NomiMaschili[2] = "Everard";
            NomiMaschili[3] = "Nicholas";
            NomiMaschili[4] = "Joseph";
            NomiMaschili[5] = "Leofwin";
            NomiMaschili[6] = "Amis";
            NomiMaschili[7] = "Ranulf";
            NomiMaschili[8] = "Fulke";
            NomiMaschili[9] = "Theobald";
            NomiMaschili[10] = "Rowan";
            NomiMaschili[11] = "Geoffrey";
            NomiMaschili[12] = "Gervase";
            NomiMaschili[13] = "Gerard";
            NomiMaschili[14] = "Godwyn";
            NomiMaschili[15] = "Philip";
            NomiMaschili[16] = "Warin";
            NomiMaschili[17] = "Warner";
            NomiMaschili[18] = "Thomas";
            NomiMaschili[19] = "Brom";
            NomiMaschili[20] = "Hamon";
            NomiMaschili[21] = "Thurstan";
            NomiMaschili[22] = "Robert";
            NomiMaschili[23] = "Roland";
            NomiMaschili[24] = "Rolf";
            NomiMaschili[25] = "Walter";
            NomiMaschili[26] = "Laurence";
            NomiMaschili[27] = "Reginald";
            NomiMaschili[28] = "Aglovale";
            NomiMaschili[29] = "Sayer";
            NomiMaschili[30] = "Timm";
            NomiMaschili[31] = "Piers";
            NomiMaschili[32] = "Cerdic";
            NomiMaschili[33] = "Randel";
            NomiMaschili[34] = "Daniel";
            NomiMaschili[35] = "Denis";
            NomiMaschili[36] = "Elias";
            NomiMaschili[37] = "Gabriel";
            NomiMaschili[38] = "Hector";
            NomiMaschili[39] = "Humphrey";
            NomiMaschili[40] = "Gamel";
            NomiMaschili[41] = "Gregory";
            NomiMaschili[42] = "James";
            NomiMaschili[43] = "Jasper";
            NomiMaschili[44] = "Jeremy";
            NomiMaschili[45] = "Isaac";
            NomiMaschili[46] = "Ingram";
            NomiMaschili[47] = "Isembard";
            NomiMaschili[48] = "Manfred";
            NomiMaschili[49] = "Ives";
            NomiMaschili[50] = "William";
            NomiMaschili[51] = "Lucius";
            NomiMaschili[52] = "Wymond";
            NomiMaschili[53] = "Lambert";
            NomiMaschili[54] = "Blaise";
            NomiMaschili[55] = "Griffith";
            NomiMaschili[56] = "Mabon";
            NomiMaschili[57] = "Hubert";
            NomiMaschili[58] = "Gerald";
            NomiMaschili[59] = "Eustace";
            NomiMaschili[60] = "Adam";
            NomiMaschili[61] = "Adelard";
            NomiMaschili[62] = "Alphonse";
            NomiMaschili[63] = "Turstin";
            NomiMaschili[64] = "Guy";
            NomiMaschili[65] = "Peter";
            NomiMaschili[66] = "Osric";
            NomiMaschili[67] = "Ogier";
            NomiMaschili[68] = "Gareth";
            NomiMaschili[69] = "Maynard";

            NomiFemminili[0] = "Elaine";
            NomiFemminili[1] = "Sarah";
            NomiFemminili[2] = "Sela";
            NomiFemminili[3] = "Sigga";
            NomiFemminili[4] = "Susanna";
            NomiFemminili[5] = "Althea";
            NomiFemminili[6] = "Alma";
            NomiFemminili[7] = "Artemisia";
            NomiFemminili[8] = "Anne";
            NomiFemminili[9] = "Anais";
            NomiFemminili[10] = "Acelina";
            NomiFemminili[11] = "Aelina";
            NomiFemminili[12] = "Aldita";
            NomiFemminili[13] = "Audry";
            NomiFemminili[14] = "Augusta";
            NomiFemminili[15] = "Brangwine";
            NomiFemminili[16] = "Bridget";
            NomiFemminili[17] = "Genevieve";
            NomiFemminili[18] = "Guinevere";
            NomiFemminili[19] = "Catelin";
            NomiFemminili[20] = "Caterina";
            NomiFemminili[21] = "Dionisia";
            NomiFemminili[22] = "Mary";
            NomiFemminili[23] = "Martha";
            NomiFemminili[24] = "Elizabeth";
            NomiFemminili[25] = "Elysande";
            NomiFemminili[26] = "Christina";
            NomiFemminili[27] = "Giselle";
            NomiFemminili[28] = "Regina";
            NomiFemminili[29] = "Richolda";
            NomiFemminili[30] = "Roana";
            NomiFemminili[31] = "Barbetta";
            NomiFemminili[32] = "Bertha";
            NomiFemminili[33] = "Clare";
            NomiFemminili[34] = "Amelina";
            NomiFemminili[35] = "Cecily";
            NomiFemminili[36] = "Edith";
            NomiFemminili[37] = "Ella";
            NomiFemminili[38] = "Juliana";
            NomiFemminili[39] = "Ivette";
            NomiFemminili[40] = "Adelina";
            NomiFemminili[41] = "Agnes";
            NomiFemminili[42] = "Alice";
            NomiFemminili[43] = "Alyson";
            NomiFemminili[44] = "Dameta";
            NomiFemminili[45] = "Paulina";
            NomiFemminili[46] = "Petronilla";
            NomiFemminili[47] = "ElaEdevaine";
            NomiFemminili[48] = "Eglenti";
            NomiFemminili[49] = "Evelune";
            NomiFemminili[50] = "Emily";
            NomiFemminili[51] = "Emma";
            NomiFemminili[52] = "Joan";
            NomiFemminili[53] = "Johanna";
            NomiFemminili[54] = "Lavina";
            NomiFemminili[55] = "Lena";
            NomiFemminili[56] = "Lovota";
            NomiFemminili[57] = "Lillian";
            NomiFemminili[58] = "Maude";
            NomiFemminili[59] = "Milicent";
            NomiFemminili[60] = "Magdalen";
            NomiFemminili[61] = "Isabeau";
            NomiFemminili[62] = "Caesaria";
            NomiFemminili[63] = "Tephania";
            NomiFemminili[64] = "Sapphira";
            NomiFemminili[65] = "Ida";
            NomiFemminili[66] = "Rosamund";
            NomiFemminili[67] = "Leticia";
            NomiFemminili[68] = "Gwendolen";
            NomiFemminili[69] = "Legarda";

            Cognomi[0] = "Achard";
            Cognomi[1] = "Ashdown";
            Cognomi[2] = "Baker";
            Cognomi[3] = "Baxter";
            Cognomi[4] = "Burrel";
            Cognomi[5] = "Burrel";
            Cognomi[6] = "Carter";
            Cognomi[7] = "Bouchard";
            Cognomi[8] = "Ballard";
            Cognomi[9] = "Draper";
            Cognomi[10] = "Bigge";
            Cognomi[11] = "de Bethencourt";
            Cognomi[12] = "de Logris";
            Cognomi[13] = "de Maris";
            Cognomi[14] = "Challenge";
            Cognomi[15] = "Clarke";
            Cognomi[16] = "Cook";
            Cognomi[17] = "Fletcher";
            Cognomi[18] = "Bosc";
            Cognomi[19] = "Brooker";
            Cognomi[20] = "Browne";
            Cognomi[21] = "Brickenden";
            Cognomi[22] = "Cecil";
            Cognomi[23] = "Capron";
            Cognomi[24] = "Challener";
            Cognomi[25] = "Griffen";
            Cognomi[26] = "Canouville";
            Cognomi[27] = "Beringar";
            Cognomi[28] = "Bellecote";
            Cognomi[29] = "Bertran";
            Cognomi[30] = "Hachet";
            Cognomi[31] = "Carpenter";
            Cognomi[32] = "Cooper";
            Cognomi[33] = "Foreman";
            Cognomi[34] = "Hughes";
            Cognomi[35] = "Duval";
            Cognomi[36] = "Durville";
            Cognomi[37] = "de La Reue";
            Cognomi[38] = "Bauldry";
            Cognomi[39] = "Godart";
            Cognomi[40] = "Webber";
            Cognomi[41] = "Weaver";
            Cognomi[42] = "Faintrer";
            Cognomi[43] = "Renold";
            Cognomi[44] = "Hauville";
            Cognomi[45] = "Medley";
            Cognomi[46] = "Lucy";
            Cognomi[47] = "Lamb";
            Cognomi[48] = "Burroughs";
            Cognomi[49] = "Nesdin";
            Cognomi[50] = "Giffard";
            Cognomi[51] = "Becker";
            Cognomi[52] = "Paschal";
            Cognomi[53] = "Perroy";
            Cognomi[54] = "Lee";
            Cognomi[55] = "Brewer";
            Cognomi[56] = "Sawyer";
        }

        private void bottoneAccedi_Click(object sender, EventArgs e)
        {
            User = JsonConvert.DeserializeObject<Utente>(File.ReadAllText(String.Format(@"Login\\datilogin.json")));
            string hashDecritt = "cr1tt0gr4f1@";

            byte[] datiPasswordDec = Convert.FromBase64String(User.Password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] chiavi = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashDecritt));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = chiavi, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform convertitoreDecritto = tripDes.CreateDecryptor();
                    byte[] convertitoDecritto = convertitoreDecritto.TransformFinalBlock(datiPasswordDec, 0, datiPasswordDec.Length);
                    //prima si deserializza, poi si decodifica

                    User.Password = UTF8Encoding.UTF8.GetString(convertitoDecritto);
                }
            }
            if (contenitorePasswordLogin.Text == User.Password)
            {
                //la password è corretta e corrisponde con quella salvata nella registrazione
                panelLogIn.Visible = false;
                PannelloAltoDX.Visible = true;
                PannelloAltoSX.Visible = true;
                PannelloBassoSX.Visible = true;
                PannelloBassoDX.Visible = true;
            }
            else
            {
                MessageBox.Show("La password inserita non è corretta", "ERRORE DI AUTENTICAZIONE", MessageBoxButtons.OK);
            }
        }

        private void BottoneInvioRegistrazione_Click(object sender, EventArgs e)
        {
            bool passwordAccettata = false;
            char lettpass;
            int lettCAPS = 0;
            int lettNum = 0;
            if (string.IsNullOrWhiteSpace(contenitorePasswordInserita.Text) == false)
            {
                //facciamo che la password deve contenere almeno 1 numero e 1 lettera maiuscola
                for (int i = 0; i < contenitorePasswordInserita.TextLength; i++)
                {
                    //si preleva ogni singolo carattere dalla password
                    lettpass = Convert.ToChar(contenitorePasswordInserita.Text.Substring(i, 1));
                    if (Char.IsUpper(lettpass) == true)
                    {
                        lettCAPS++;
                    }
                    if (Char.IsDigit(lettpass) == true)
                    {
                        lettNum++;
                    }
                }
                if (lettCAPS >= 1 && lettNum >= 1)
                {
                    if (contenitorePasswordInserita.TextLength >= 8 & contenitorePasswordInserita.TextLength <= 16)
                    {
                        //allora la password va bene e viene salvata
                        User.Password = contenitorePasswordInserita.Text;
                        //la password va crittata, serializzata e messa in datilogin.json
                        string hashCritt = "cr1tt0gr4f1@";
                        byte[] datiPasswordEnc = UTF8Encoding.UTF8.GetBytes(User.Password);
                        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                        {
                            byte[] chiavi = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashCritt));
                            using (TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider() { Key = chiavi, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                            {
                                ICryptoTransform convertitoreCritto = tripDES.CreateEncryptor();
                                byte[] ConvertitoCritto = convertitoreCritto.TransformFinalBlock(datiPasswordEnc, 0, datiPasswordEnc.Length);
                                User.Password = Convert.ToBase64String(ConvertitoCritto, 0, ConvertitoCritto.Length);
                            }
                        }
                        //la password crittata viene serializzata
                        File.Create(@"Login\\datilogin.json").Close();
                        File.WriteAllText(@"Login\\datilogin.json", JsonConvert.SerializeObject(User, Formatting.Indented));
                        passwordAccettata = true;

                        pannelRegistrazione.Visible = false;
                        PannelloAltoDX.Visible = true;
                        PannelloAltoSX.Visible = true;
                        PannelloBassoSX.Visible = true;
                        PannelloBassoDX.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("La password deve contenere tra gli 8 e i 16 caratteri", "ERRORE:", MessageBoxButtons.OK);
                        contenitorePasswordInserita.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("La password deve contenere almeno una lettera maiuscola e un numero", "ERRORE", MessageBoxButtons.OK);
                    contenitorePasswordInserita.Clear();
                }
            }
            else
            {
                MessageBox.Show("La password non può contenere spazi vuoti", "ERRORE", MessageBoxButtons.OK);

            }

            if (passwordAccettata == true)
            {
                //generazione degli abitanti alla prima registrazione
                Suddito NuovoSuddito;
                Random SceltaMestiere = new Random();
                Random SceltaNome = new Random();
                Random SceltaCognome = new Random();
                Random SceltaSesso = new Random();
                Random SceltaEtaLav = new Random();

                for (int i = 0; i < 3000; i++)
                {
                    NuovoSuddito = new Suddito();
                    if (SceltaSesso.Next(0, 1) == 1)
                    {
                        //scelta nome casuale maschile
                        int sceltanomeintM = SceltaNome.Next(0, 69);
                        NuovoSuddito.Nome = NomiMaschili[sceltanomeintM];
                    }
                    else
                    {
                        //scelta nome casuale femminile
                        int sceltanomeintF = SceltaNome.Next(0, 69);
                        NuovoSuddito.Nome = NomiFemminili[sceltanomeintF];

                    }
                    //scelta cognome casuale
                    int sceltacognomeint = SceltaCognome.Next(0, 55);
                    NuovoSuddito.Cognome = Cognomi[sceltacognomeint];

                    //età lavorativa?

                    int sceltaEtaLavint = SceltaEtaLav.Next(0, 100);
                    if (sceltaEtaLavint < 70)
                    {
                        //nuova nascita
                        NuovoSuddito.Etàlavorativa = false;
                    }
                    else
                    {
                        //immigrato
                        NuovoSuddito.Etàlavorativa = true;
                    }

                    int sceltamestiereint = SceltaMestiere.Next(0, 3);
                    //saldo basato sul mestiere
                    if (sceltamestiereint == 0)
                    {
                        NuovoSuddito.Mestiere = "Agricoltore";
                        NuovoSuddito.Saldo = 50;
                    }
                    else
                    {
                        if (sceltamestiereint == 1)
                        {
                            NuovoSuddito.Mestiere = "Fabbro";
                            NuovoSuddito.Saldo = 80;
                        }
                        else
                        {
                            if (sceltamestiereint == 2)
                            {
                                NuovoSuddito.Mestiere = "Guerriero";
                                NuovoSuddito.Saldo = 100;
                            }
                            else
                            {

                                NuovoSuddito.Mestiere = "Altro";
                                NuovoSuddito.Saldo = 50;
                            }
                        }
                    }
                    //inserimento abitante nella lista
                    Lista.ListaSudditi.Add(NuovoSuddito);


                }
                //serializzare listasudditi
                Directory.CreateDirectory(@"Data");
                File.Create(@"Data\\ListaAbitanti.json").Close();
                File.WriteAllText(@"Data\\ListaAbitanti.json", JsonConvert.SerializeObject(Lista, Formatting.Indented));


            }
        }

        private void AvantiMeseBtn_Click(object sender, EventArgs e)
        {
            Tempo Orologio = new Tempo();
            Orologio.Anno = 0;
            Orologio.Mese = Orologio.Mese + 1;
            if (Orologio.Mese == 12)
            {
                Orologio.Anno = Orologio.Anno + 1;
                //si resettano i 500 denari non tassabili
                for (int i = 0; i < Lista.ListaSudditi.Count(); i++)
                {
                    Lista.ListaSudditi[i].DenariSuddTassabile = 0;
                    Lista.ListaSudditi[i].Tassabile = false;
                }
            }

            //GESTIONE NASCITE
            int SudditiTotali = Lista.ListaSudditi.Count();
            int SudditiLavoratori = Lista.ListaSudditi.FindAll(X => X.Etàlavorativa == true).Count();
            int SudditiNonLavoratori = Lista.ListaSudditi.FindAll(X => X.Etàlavorativa == false).Count();

            int SudditiInsolventi=0; //si aggiungono dopo il conto dele tasse

            int SudditiNuovi;
            int SudditiMorti;
            //nascite
            SudditiNuovi = (8 / 100) * SudditiTotali;
            SudditiTotali = SudditiTotali + SudditiNuovi;
            //morti
            SudditiMorti = (5 / 100) * SudditiTotali;
            SudditiTotali = SudditiTotali - SudditiMorti;

            //VARIABILI TASSAZIONE
            float TassazioneTotale=0;
            float IntroitiMensili = 0;
            float IntroitiPersi = 0;

            Suddito NuovoSuddito;

            //GENERARE I NATI & IMMIGRATI
            for (int i = 0; i < SudditiNuovi; i++)
            {
                Random CaratteristicheNati = new Random();
                NuovoSuddito = new Suddito();
                if (CaratteristicheNati.Next(0, 1) == 1)
                {
                    //scelta nome casuale maschile
                    int sceltanomeintM = CaratteristicheNati.Next(0, 69);
                    NuovoSuddito.Nome = NomiMaschili[sceltanomeintM];
                }
                else
                {
                    //scelta nome casuale femminile
                    int sceltanomeintF = CaratteristicheNati.Next(0, 69);
                    NuovoSuddito.Nome = NomiFemminili[sceltanomeintF];

                }
                //scelta cognome casuale
                int sceltacognomeint = CaratteristicheNati.Next(0, 55);
                NuovoSuddito.Cognome = Cognomi[sceltacognomeint];

                //età lavorativa?

                int sceltaEtaLavint = CaratteristicheNati.Next(0, 100);
                if (sceltaEtaLavint < 70)
                {
                    //nuova nascita
                    NuovoSuddito.Etàlavorativa = false;
                }
                else
                {
                    //immigrato
                    NuovoSuddito.Etàlavorativa = true;
                }

                int sceltamestiereint = CaratteristicheNati.Next(0, 3);
                //saldo basato sul mestiere
                if (sceltamestiereint == 0)
                {
                    NuovoSuddito.Mestiere = "Agricoltore";
                    NuovoSuddito.Saldo = 50;
                }
                else
                {
                    if (sceltamestiereint == 1)
                    {
                        NuovoSuddito.Mestiere = "Fabbro";
                        NuovoSuddito.Saldo = 80;
                    }
                    else
                    {
                        if (sceltamestiereint == 2)
                        {
                            NuovoSuddito.Mestiere = "Guerriero";
                            NuovoSuddito.Saldo = 100;
                        }
                        else
                        {

                            NuovoSuddito.Mestiere = "Altro";
                            NuovoSuddito.Saldo = 50;
                        }
                    }
                }
                //inserimento abitante nella lista
                Lista.ListaSudditi.Add(NuovoSuddito);


            }
            //si serializza alla fine di tutto
            //il 20% di coloro che non lavorano diventano lavoratori ogni anno (stima)
            int Apprendisti;
            Apprendisti = (20 / 100) * SudditiNonLavoratori;
            SudditiLavoratori = SudditiLavoratori + Apprendisti;

            //i sudditi non lavoratori non sono tassabili

            //STIPENDI
            for (int i = 0; i < Lista.ListaSudditi.Count(); i++)
            {
                //controllo se tassabile, i mestieri li hanno dalla nascita, la differenza sta nel fatto
                //gli stipendi vanno dati se sono lavoratori
                if (Lista.ListaSudditi[i].Etàlavorativa == true)
                {
                    //in base al mestiere si assegna lo stipendio
                    switch (Lista.ListaSudditi[i].Mestiere)
                    {
                        case "Agricoltore":
                            //stipendio
                            Lista.ListaSudditi[i].Saldo = Lista.ListaSudditi[i].Saldo + 300;
                            //controllo se sono i prmi 500 denari dell'anno non tassabili
                            if (Lista.ListaSudditi[i].DenariSuddTassabile < 500)
                            {
                                Lista.ListaSudditi[i].DenariSuddTassabile = Lista.ListaSudditi[i].DenariSuddTassabile + 300;
                            }
                            else
                                Lista.ListaSudditi[i].Tassabile = true;
                            
                            break;

                        case "Fabbro":
                            Lista.ListaSudditi[i].Saldo = Lista.ListaSudditi[i].Saldo + 400;
                            if (Lista.ListaSudditi[i].DenariSuddTassabile < 500)
                            {
                                Lista.ListaSudditi[i].DenariSuddTassabile = Lista.ListaSudditi[i].DenariSuddTassabile + 300;
                            }
                            else
                                Lista.ListaSudditi[i].Tassabile = true;
                            break;
                        case "Guerriero":
                            Lista.ListaSudditi[i].Saldo = Lista.ListaSudditi[i].Saldo + 450;
                            if (Lista.ListaSudditi[i].DenariSuddTassabile < 500)
                            {
                                Lista.ListaSudditi[i].DenariSuddTassabile = Lista.ListaSudditi[i].DenariSuddTassabile + 300;
                            }
                            else
                                Lista.ListaSudditi[i].Tassabile = true;
                            break;

                        case "Altro":
                            Lista.ListaSudditi[i].Saldo = Lista.ListaSudditi[i].Saldo + 300;
                            if (Lista.ListaSudditi[i].DenariSuddTassabile < 500)
                            {
                                Lista.ListaSudditi[i].DenariSuddTassabile = Lista.ListaSudditi[i].DenariSuddTassabile + 300;
                            }
                            else
                                Lista.ListaSudditi[i].Tassabile = true;
                            break;
                    }
                    //TASSAZIONE
                    //tassabile significa che ha già ricevuto i 500 denari non tassabili annui
                    if (Lista.ListaSudditi[i].Tassabile == true)
                    {
                        //Si assegnano le tasse da pagare come "tasseNonPagate"
                        Lista.ListaSudditi[i].TasseNonPagate= Lista.ListaSudditi[i].TasseNonPagate+(15 / 100) * Lista.ListaSudditi[i].Saldo;
                        //queste sono le tasse del mese
                        float TasseEffettive = (15 / 100) * Lista.ListaSudditi[i].Saldo;
                        //spese random del suddito per variati motivi( cibo, alloggio, ecc)
                        Random SpeseAbitante = new Random();
                        int SpeseAbitanteint = SpeseAbitante.Next(0, 3);
                        //si potrebbe fare che queste spese esterne non rientrino nelle tassenonpagate, e che vengano sottratte subito
                        switch (SpeseAbitanteint)
                        {
                            case 0:
                                Lista.ListaSudditi[i].TasseNonPagate = Lista.ListaSudditi[i].TasseNonPagate+60;
                                break;
                            case 1:
                                Lista.ListaSudditi[i].TasseNonPagate = Lista.ListaSudditi[i].TasseNonPagate+100;
                                break;
                            case 2:
                                Lista.ListaSudditi[i].TasseNonPagate = Lista.ListaSudditi[i].TasseNonPagate+150;
                                break;
                            case 3:
                                Lista.ListaSudditi[i].TasseNonPagate = Lista.ListaSudditi[i].TasseNonPagate+200;
                                break;
                        }
                        //si controlla se il suddito ha abbastanza denaro per pagare le spese mensili+tasse
                        if (Lista.ListaSudditi[i].Saldo - Lista.ListaSudditi[i].TasseNonPagate <= 0)
                        {
                            //gli viene data la possibilità di pagarne il 30%, se riesce
                            if (Lista.ListaSudditi[i].Saldo - (30 / 100) * Lista.ListaSudditi[i].TasseNonPagate >= 0)
                            {
                                //WIP
                                
                            }
                            //il suddito non ha abbastanza soldi per pagare
                            Lista.ListaSudditi[i].MesiNonPagati++;
                            //se i mesi non pagati sono >=1 si sa che è in ritardo
                            if (Lista.ListaSudditi[i].MesiNonPagati == 12||Lista.ListaSudditi[i].MesiNonPagati==24)
                            {
                                //ogni anno si calcola un interesse del 30% di tutte le tasse non pagate 
                                Lista.ListaSudditi[i].TasseNonPagate = Lista.ListaSudditi[i].TasseNonPagate + (30 / 100) * Lista.ListaSudditi[i].TasseNonPagate;
                            }
                            else
                            if (Lista.ListaSudditi[i].MesiNonPagati == 36)
                            {
                                //il suddito va ucciso
                                Contea.SaldoRe = Contea.SaldoRe + Lista.ListaSudditi[i].Saldo;
                                SudditiInsolventi++;
                                SudditiMorti++;
                                //si rimuove dalla lista degli abitanti
                                Lista.ListaSudditi.Remove(Lista.ListaSudditi[i]);
                            }
                        }
                        else
                        {
                            //è riuscito a pagare tutto in un colpo e non ha debiti
                            Lista.ListaSudditi[i].Saldo = Lista.ListaSudditi[i].Saldo - Lista.ListaSudditi[i].TasseNonPagate;
                            //calcolo ricavi totali dello stato (Costi Totali-spese esterne alle tasse)
                            TassazioneTotale = TassazioneTotale + TasseEffettive;
                            Lista.ListaSudditi[i].TasseNonPagate = 0;
                            
                        }
                    }

                }
            }
        }
}   }

public class Liste
{
    public List<Suddito> ListaSudditi = new List<Suddito>();
}
//creazione classi
public class Suddito
{
    protected string nome;
    protected string cognome;
    protected bool etàlavorativa; //si o no
    protected float saldo; //float al posto di double perché occupa 32 bit e non 64
    protected string mestiere;  //anche se non in età lavorativa, nella casta medievale il figlio sapeva già che avrebbe svolto il mestiere del padre
    protected int mesiNonPagati;
    protected float tasseNonPagate;
    protected int denariSuddTassabile;
    protected bool tassabile;

    public string Nome
    {
        set { nome = value; }
        get { return nome; }
    }
    public string Cognome
    {
        set { cognome = value; }
        get { return cognome; }
    }
    public bool Etàlavorativa
    {
        set { etàlavorativa =value; }
        get { return etàlavorativa; }
    }
    public float Saldo
    {
        set { saldo = value; }
        get { return saldo; }
    }
    public string Mestiere
    {
        set { mestiere = value; }
        get { return mestiere; }
    }
    public int MesiNonPagati
    {
        set { mesiNonPagati = value; }
        get { return mesiNonPagati; }
    }
    public float TasseNonPagate
    {
        set { tasseNonPagate = value; }
        get { return tasseNonPagate; }
    }
    public int DenariSuddTassabile
    {
        set { denariSuddTassabile = value; }
        get { return denariSuddTassabile; }
    }
    public bool Tassabile
    {
        set { tassabile = value; }
        get { return tassabile; }
    }
}
public class Tempo
{
    protected int mese;
    protected int anno;

    public int Mese
    {
        set { mese = value; }
        get { return mese; }
    }
    public int Anno
    {
        set { anno = value; }
        get { return anno; }
    }
}
public class Stato
{
    protected float saldoRE;
    protected float tesoroStato;
    protected string condizioneStato;

    public float SaldoRe
    {
        set { saldoRE = value; }
        get { return saldoRE; }
    }
    public float TesoroStato
    {
        set { tesoroStato = value; }
        get { return tesoroStato; }
    }
    public string CondizioneStato
    {
        set { condizioneStato = value; }
        get { return condizioneStato; }
    }
}
public class Utente
{
    protected string password;
    public string Password
    {
        set { password = value; }
        get { return password; }
    }
}
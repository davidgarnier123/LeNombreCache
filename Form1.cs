using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NombreCacheWForm
{

    public partial class Form1 : Form
    {
    
        private int phase = 1; //variable globale pour la phase joueur 1 ou 2
        private int NombreCache = 0; //le nombre a chercher
        private int essai = 0; //nombre d'essai
        private void efface()
        {
            txtValeur.Text = "";
            txtValeur.Focus();
        }
        private void initialiser()
        {
            
            if (phase == 1)
            {
                grpReponse.Visible = false;
                grpValeur.Text = "Saisir un nombre entre 0 et 100";
               
            }
            else
            {
                grpReponse.Visible = true;
                grpValeur.Text = "Essai     (entre 0 et 100)";
                grpReponse.Text = "Essai n°" + (essai +1);
                lblMessage.Text = "";
                txtValeur.Text = "";
                lblMessage.Text = "Joueur 2, c'est parti !";
            }
        }
        public Form1()
        {
            InitializeComponent();
            initialiser();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (phase == 1) {
                try
                {
                    NombreCache = int.Parse(txtValeur.Text);
                    phase = 2;
                    initialiser();
                }
              catch (Exception) { lblMessage.Text = "Erreur de saisie !"; txtValeur.Text = ""; }
            }
                
            
            else
            {
                try
                {
                    // si c'est juste
                    if (int.Parse(txtValeur.Text) == NombreCache) { essai++; lblMessage.Text = "Bravo en " + essai + " essais " + "! --> " + NombreCache; }
                    // si c'est faux
                    else
                    {

                        if (int.Parse(txtValeur.Text) > NombreCache) { lblMessage.Text = int.Parse(txtValeur.Text) + " est trop grand !"; essai++; grpReponse.Text = "Essai n°" + (essai+1); }
                        if (int.Parse(txtValeur.Text) < NombreCache) { lblMessage.Text = int.Parse(txtValeur.Text) + " est trop petit !"; essai++; grpReponse.Text = "Essai n°" + (essai+1); }
                    }
                    txtValeur.Text = "";
                }
                catch (Exception) { lblMessage.Text = "Erreur de saisie !"; txtValeur.Text = ""; }
            }
        }

        private void btnRejouer_Click(object sender, EventArgs e)
        {
            phase = 1;
            NombreCache = 0;
            essai = 0;
            txtValeur.Text = "";
            grpReponse.Text = "";
            initialiser();
        }

        private void txtValeur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnValider_Click(null,null);
            }
        }
    }
}

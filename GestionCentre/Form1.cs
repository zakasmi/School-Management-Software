using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.Lib;

namespace GestionCentre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*  FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;*/

            this.Bounds = Screen.PrimaryScreen.WorkingArea;
            Provider.FillSpecialite();
            CB_Stagiaire_Filiere.DataSource = Provider.GetAllSpecialite;
            CB_Stagiaire_Filiere.DisplayMember = "Designation";
            CB_Stagiaire_Filiere.ValueMember = "IdSpecialite";

            Provider.FillGroupe();
            Provider.FillStagiaire();





        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTN_ModifierMotPass_Connecter_Click(object sender, EventArgs e)
        {
            DGV_Stagiaire1.DataSource = Provider.GetStagiareByGroupe(CB_Stagiaire_Groupe.SelectedValue.ToString());
        }

        private void CB_Stagiaire_Filiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Stagiaire_Filiere.SelectedIndex != -1 && CB_Stagiaire_Niveau.SelectedIndex!=-1)
            {
                CB_Stagiaire_Groupe.DataSource=Provider.GetGroupeByFSpecialiteAndNiveau(CB_Stagiaire_Filiere.SelectedValue.ToString(),CB_Stagiaire_Niveau.Text);
                CB_Stagiaire_Groupe.DisplayMember = "NomGroupe";
                CB_Stagiaire_Groupe.ValueMember = "IdGroupe";
            }
        }

        private void CB_Stagiaire_Niveau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Stagiaire_Filiere.SelectedIndex != -1 && CB_Stagiaire_Niveau.SelectedIndex != -1)
            {
                CB_Stagiaire_Groupe.DataSource = Provider.GetGroupeByFSpecialiteAndNiveau(CB_Stagiaire_Filiere.SelectedValue.ToString(), CB_Stagiaire_Niveau.Text);
                CB_Stagiaire_Groupe.DisplayMember = "NomGroupe";
                CB_Stagiaire_Groupe.ValueMember = "IdGroupe";
            }
        }
    }
}

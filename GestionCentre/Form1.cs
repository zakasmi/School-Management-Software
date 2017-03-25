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
using System.Data.SqlClient;

namespace GestionCentre
{
    public partial class Form1 : Form
    {

        public static bool AjouterStagiaireClicked = false;
       
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
        //------------------------ Load ---------------------------------------
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



           // check month 
            if (DateTime.Now.Month < 9)
            {
                Provider.RecentYear = (DateTime.Now.Year - 1);
                CB_Stagiaire_Annee.SelectedItem = Provider.RecentYear.ToString();

            }
            else {
                Provider.RecentYear = DateTime.Now.Year ;
                CB_Stagiaire_Annee.SelectedItem = DateTime.Now.Year.ToString();

            }

            Provider.FillGroupe();
            //fill 'stagiaire' with recent year 'stagiaires'
            Provider.FillStagiaire(Provider.RecentYear.ToString());
            CB_Stagiaire_Niveau.SelectedIndex = 0;
            CB_Stagiaire_Filiere.SelectedIndex = -1;


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
            tabControl2_Stagiaire.SelectTab(0);

            if (CB_Stagiaire_Annee.SelectedIndex !=-1)
            {
                if (CB_Stagiaire_Groupe.Items.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CB_Stagiaire_Groupe.SelectedValue.ToString()) && CB_Stagiaire_Groupe.SelectedIndex != -1)
                    {
                        if (Provider.RecentStagiareYearinDataSet.ToString() == CB_Stagiaire_Annee.SelectedItem.ToString())
                        {
                            // if you clicked "valider" for the second time (simultantly) . and didn't change the year(Annee) . the databse dataset table StagiarePersonne already filled 
                            DGV_Stagiaire1.DataSource = Provider.GetStagiareByGroupe(CB_Stagiaire_Groupe.SelectedValue.ToString());
                            Provider.InitialiserDataGrid(DGV_Stagiaire1);
                        }
                        else
                        {   // if you  change the year and you click valider .
                            
                            Provider.FillStagiaire(CB_Stagiaire_Annee.SelectedItem.ToString());
                            DGV_Stagiaire1.DataSource = Provider.GetStagiareByGroupe(CB_Stagiaire_Groupe.SelectedValue.ToString());
                            Provider.InitialiserDataGrid(DGV_Stagiaire1);
                        }
                    }
                    else MessageBox.Show("Please select a groupe ");
                }
                else MessageBox.Show("makayan ta Groupe . kolchi khawii"); 
            }
        }

        private void CB_Stagiaire_Filiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroups(1);
        }

        private void CB_Stagiaire_Niveau_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroups(1);
        }
        private void CB_Stagiaire_Annee_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroups(1);
            if (CB_Stagiaire_Annee.SelectedItem.ToString() !=Provider.RecentYear.ToString()) {

                BTN_Stagiaire_Modifier.Enabled = false;
                BTN_Stagiaire_Ajouter.Enabled = false;
                BTN_Stagiaire_Supprimer.Enabled = false;
            }
        }
        // Stagiaire : Methode Get Groups pour remplir CB_Stagiaire_Groupe  
        public void GetGroups(int x)
        {
            if (x==1) {
                // Stagiaire : Top Menu 
                if (CB_Stagiaire_Filiere.SelectedIndex != -1 && CB_Stagiaire_Niveau.SelectedIndex != -1 && CB_Stagiaire_Annee.SelectedIndex != -1)
                {
                    CB_Stagiaire_Groupe.DataSource = Provider.GetGroupeByFSpecialiteAndNiveauAndAnnee(CB_Stagiaire_Filiere.SelectedValue.ToString(), CB_Stagiaire_Niveau.Text, CB_Stagiaire_Annee.Text);
                    CB_Stagiaire_Groupe.DisplayMember = "NomGroupe";
                    CB_Stagiaire_Groupe.ValueMember = "IdGroupe";
                }
                
            }else if (x == 2)
            {
                //Stagiaire : Ajouter => remplir Combobox Groupe
                if (CB_Stagiaire_Ajouter_Specialite.SelectedIndex != -1 && CB_Stagiaire_Ajouter_Niveau.SelectedIndex != -1 && CB_Stagiaire_Ajouter_Annee.SelectedIndex != -1)
                {
                    CB_Stagiaire_Ajouter_Groupe.DataSource = Provider.GetGroupeByFSpecialiteAndNiveauAndAnnee(CB_Stagiaire_Ajouter_Specialite.SelectedValue.ToString(), CB_Stagiaire_Ajouter_Niveau.Text, CB_Stagiaire_Ajouter_Annee.Text);
                    CB_Stagiaire_Ajouter_Groupe.DisplayMember = "NomGroupe";
                    CB_Stagiaire_Ajouter_Groupe.ValueMember = "IdGroupe";

                }


            }

        }
        private void BTN_Stagiaire_Consulter_Click(object sender, EventArgs e)
        {
            tabControl2_Stagiaire.SelectTab(2);
            if (!string.IsNullOrEmpty(LBL_Stagiaire_Id_Clicked.Text) && LBL_Stagiaire_Nom_Clicked.Text != "Nom") {
                SqlCommand cmd = new SqlCommand("select S.IdStagiaire,P.Cin,P.Nom,P.Prenom,P.Tel,P.Email,P.DateNaissance,P.Adresse,P.sexe,S.DateInscription,S.idspecialite,G.NomGroupe,S.Question,S.Reponse  from Personne P  inner join Stagiaire S on P.Cin = S.cin  inner join Groupe G on G.IdGroupe=S.idgroupe where S.IdStagiaire=" + LBL_Stagiaire_Id_Clicked.Text + " ", Provider.cnx);
                Provider.cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                
                    TB_Stagiaire_Consulter_Id.Text = dr[0].ToString();
                    TB_Stagiaiare_Consulter_Cin.Text = dr[1].ToString();
                    TB_Stagiaire_Consulter_Nom.Text = dr[2].ToString();
                    TB_Stagiaire_Consulter_Prenom.Text = dr[3].ToString();
                    TB_Stagiaire_Consulter_Telephone.Text = dr[4].ToString();
                    TB_Stagiaire_Consulter_Email.Text = dr[5].ToString();
                    TB_Stagiaire_Consulter_DateNaissance.Text = dr[6].ToString();
                    TB_Stagiaire_Consulter_Adresse.Text = dr[7].ToString();
                    TB_Stagiaire_Consulter_Sexe.Text = dr[8].ToString();
                    TB_Stagiaire_Consulter_DateInscription.Text = dr[9].ToString();
                    TB_Stagiaire_Consulter_Specialite.Text = dr[10].ToString();
                    TB_Stagiaire_Consulter_Groupe.Text = dr[11].ToString();
                    TB_Stagiaire_Consulter_Question.Text = dr[12].ToString();
                    TB_Stagiaire_Consulter_Reponse.Text = dr[13].ToString();

                    LBL_Stagiaire_Consulter_NomPrenom.Text = dr[2].ToString() +" " + dr[3].ToString();
                    LBL_Stagiaire_Consulter_Cin1.Text = dr[1].ToString();
                    LBL_Stagiaire_Consulter_ID1.Text = dr[0].ToString();

                
                Provider.cnx.Close();
            }

        }

        private void BTN_Stagiaire_Ajouter_Click(object sender, EventArgs e)
        {
            CB_Stagiaire_Ajouter_Niveau.SelectedIndex = -1;
            tabControl2_Stagiaire.SelectTab(1);
            if (!AjouterStagiaireClicked) {

                CB_Stagiaire_Ajouter_Specialite.DataSource = Provider.GetAllSpecialite;
                CB_Stagiaire_Ajouter_Specialite.DisplayMember = "Designation";
                CB_Stagiaire_Ajouter_Specialite.ValueMember = "IdSpecialite";
               // CB_Stagiaire_Ajouter_Specialite.SelectedIndex = -1;

            }
        }

        private void BTN_Stagiaire_Liste_Click(object sender, EventArgs e)
        {
            tabControl2_Stagiaire.SelectTab(0);
        }

        private void BTN_Menu_Professeur_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void BTN_Menu_Stagiaire_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void BTN_Prof_Liste_Click(object sender, EventArgs e)
        {
            tabControl3_Professeur.SelectTab(0);
        }

        private void BTN_Prof_Ajouter_Click(object sender, EventArgs e)
        {
            tabControl3_Professeur.SelectTab(1);
        }

        private void BTN_Prof_Consulter_Click(object sender, EventArgs e)
        {
            tabControl3_Professeur.SelectTab(2);
        }

        private void BTN_Load_Click(object sender, EventArgs e)
        {
            this.Form1_Load(sender,e);
        }

     

        private void DGV_Stagiaire1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_Stagiaire1.Rows.Count >0) {

                LBL_Stagiaire_Id_Clicked.Text = DGV_Stagiaire1.Rows[e.RowIndex].Cells[1].Value.ToString();
                LBL_Stagiaire_Cin_Clicked.Text = DGV_Stagiaire1.Rows[e.RowIndex].Cells[2].Value.ToString();
                LBL_Stagiaire_Prenom_Clicked.Text = DGV_Stagiaire1.Rows[e.RowIndex].Cells[3].Value.ToString();
                LBL_Stagiaire_Nom_Clicked.Text = DGV_Stagiaire1.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }

        private void Vider_Panel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DGV_Stagiaire1.Rows.Count.ToString());
        }
        // Stagiaire : Ajouter => Vider 
        private void BTN_Stagiaire_Ajouter_Vider_Click(object sender, EventArgs e)
        {
            Provider.ViderTabPage(tabControl2_Stagiaire_tabpage2_Ajouter);
            BIBTN_Stagiaire_Image.BackgroundImage = new Bitmap(Properties.Resources.stagiaire2);
            CB_Stagiaire_Ajouter_Annee.SelectedItem = DateTime.Now.Year.ToString();
            MessageBox.Show("Hello worlsd ");
        }
        // Stagiaire : Ajouter => Select Image 
        private void BIBTN_Stagiaire_SelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fdg = new OpenFileDialog()) {

                fdg.Filter = "PNG|*.png|Jpeg jpg|*.jpg;*jpeg";
                if (fdg.ShowDialog()==DialogResult.OK) {

                    BIBTN_Stagiaire_Image.BackgroundImage = new Bitmap(fdg.FileName);
                    BIBTN_Stagiaire_Image.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
        }
        // Stagiaire : Supprimer ------------ 
        private void BTN_Stagiaire_Supprimer_Click(object sender, EventArgs e)
        {

            if (tabControl2_Stagiaire.SelectedIndex != 0)
            {
                tabControl2_Stagiaire.SelectTab(0);
                MessageBox.Show("Cocher Les Stagiaire que vous voulez Supprimer !!");
            }
            else
            {
                string Deletedstring = "";
                if (Provider.DeleteStagiaireFromDataGrid(DGV_Stagiaire1, ref Deletedstring))
                {
                    MessageBox.Show("delete from Stagiaire where IdStagiaire  in (" + Deletedstring + ")");
                    int x;
                    using (SqlCommand cmd = new SqlCommand("delete from Stagiaire where IdStagiaire  in (" + Deletedstring + ")", Provider.cnx))
                    {
                        Provider.cnx.Open();
                        x = cmd.ExecuteNonQuery();
                        MessageBox.Show(x.ToString());
                        Provider.cnx.Close();
                    }
                    if (x <= 0) { Provider.ds.Tables["StagPersonne"].RejectChanges();
                        MessageBox.Show("Erreur De Communication avec le serveur");
                    }else
                    {
                        MessageBox.Show("Les Stagiaires Sont Supprimer avec Succes Rest :total :" + Provider.ds.Tables["StagPersonne"].Rows.Count);
                    }
                }

            }
        }

        private void CB_Stagiaire_Ajouter_Niveau_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroups(2);
        }

       

        private void CB_Stagiaire_Ajouter_Specialite_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetGroups(2);
        }

        private void CB_Stagiaire_Ajouter_Annee_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroups(2);
        }
        private void BTN_Stagiaire_Ajouter_Enregistrer_Click(object sender, EventArgs e)
        {

        }

        private void tabControl2_Stagiaire_tabpage2_Ajouter_Click(object sender, EventArgs e)
        {

        }
    }
}

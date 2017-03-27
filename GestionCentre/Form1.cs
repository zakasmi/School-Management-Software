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
        public static bool ModifierStagiaireClicked = false;
        public static string ModifierPersonneOriginCin = null;
        public static string ModifierStagiaireIdStagiaire = null;
        public static bool ProfesseurClicked = false;
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
            //Fill Specialite Of All time
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
            else
            {
                Provider.RecentYear = DateTime.Now.Year;
                CB_Stagiaire_Annee.SelectedItem = DateTime.Now.Year.ToString();

            }

            Provider.FillGroupe();
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
        //Stagiaire : Download Valider Click---------
        private void BTN_ModifierMotPass_Connecter_Click(object sender, EventArgs e)
        {
            tabControl2_Stagiaire.SelectTab(0);

            if (CB_Stagiaire_Annee.SelectedIndex != -1)
            {
                if (CB_Stagiaire_Groupe.Items.Count > 0)
                {

                    if (!string.IsNullOrEmpty(CB_Stagiaire_Groupe.SelectedValue.ToString()) && CB_Stagiaire_Groupe.SelectedIndex != -1)
                    {
                        if (Provider.LastStagiaireGroup.ToString() == CB_Stagiaire_Groupe.SelectedValue.ToString())
                        {
                            // if you clicked "valider" for the second time (simultantly) . and didn't change the year(Annee) . the databse dataset table StagiarePersonne already filled 
                            DGV_Stagiaire1.DataSource = Provider.GetStagiaire;
                            Provider.InitialiserDataGrid(DGV_Stagiaire1);
                            MessageBox.Show("The Same Groupe");
                        }
                        else
                        {   // if you  change the Groupe and you click valider .

                            try
                            {
                                Provider.FillStagiaireByGroupe(CB_Stagiaire_Groupe.SelectedValue.ToString());
                                DGV_Stagiaire1.DataSource = Provider.GetStagiaire;
          
                                Provider.InitialiserDataGrid(DGV_Stagiaire1);
                                MessageBox.Show("nombre de stagiaire de cette Groupe " + Provider.ds.Tables["StagPersonne"].Rows.Count + " \n year:" + CB_Stagiaire_Annee.SelectedItem.ToString() + " \n groupe Name:" + CB_Stagiaire_Groupe.Text + "Premier " + DGV_Stagiaire1.Rows[0].Cells[0].Value.ToString() + "");
                            }
                            catch (Exception e1)
                            {
                                Provider.LastStagiaireGroup = "";
                                MessageBox.Show("e1 Stagiaire Valider :" + e1.Message);
                            }
                            finally
                            {

                            }

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
            if (CB_Stagiaire_Annee.SelectedItem.ToString() != Provider.RecentYear.ToString())
            {

                BTN_Stagiaire_Modifier.Enabled = false;
                BTN_Stagiaire_Ajouter.Enabled = false;
                BTN_Stagiaire_Supprimer.Enabled = false;
            }
            else
            {
                BTN_Stagiaire_Modifier.Enabled = true;
                BTN_Stagiaire_Ajouter.Enabled = true;
                BTN_Stagiaire_Supprimer.Enabled = true;
            }
        }
        // Stagiaire : Methode-------------- Get Groups pour remplir CB_Stagiaire_Groupe  
        public void GetGroups(int x)
        {
            if (x == 1)
            {
                // Stagiaire : Top Menu 
                if (CB_Stagiaire_Filiere.SelectedIndex != -1 && CB_Stagiaire_Niveau.SelectedIndex != -1 && CB_Stagiaire_Annee.SelectedIndex != -1)
                {
                    CB_Stagiaire_Groupe.DataSource = Provider.GetGroupeByFSpecialiteAndNiveauAndAnnee(CB_Stagiaire_Filiere.SelectedValue.ToString(), CB_Stagiaire_Niveau.Text, CB_Stagiaire_Annee.Text);
                    CB_Stagiaire_Groupe.DisplayMember = "NomGroupe";
                    CB_Stagiaire_Groupe.ValueMember = "IdGroupe";
                }

            }
            else if (x == 2)
            {
                //Stagiaire : Ajouter => remplir Combobox Groupe
                if (CB_Stagiaire_Ajouter_Specialite.SelectedIndex != -1 && CB_Stagiaire_Ajouter_Niveau.SelectedIndex != -1 && CB_Stagiaire_Ajouter_Annee.SelectedIndex != -1)
                {
                    CB_Stagiaire_Ajouter_Groupe.DataSource = Provider.GetGroupeByFSpecialiteAndNiveauAndAnnee(CB_Stagiaire_Ajouter_Specialite.SelectedValue.ToString(), CB_Stagiaire_Ajouter_Niveau.Text, CB_Stagiaire_Ajouter_Annee.Text);
                    CB_Stagiaire_Ajouter_Groupe.DisplayMember = "NomGroupe";
                    CB_Stagiaire_Ajouter_Groupe.ValueMember = "IdGroupe";

                }

            }
            else if (x == 3)
            {
                if (CB_Stagiaire_Modifier_Specialite.SelectedIndex != -1 && CB_Stagiaire_Modifier_Niveau.SelectedIndex != -1 && CB_Stagiaire_Modifier_Annee.SelectedIndex != -1)
                {
                    CB_Stagiaire_Modifier_Groupe.DataSource = Provider.GetGroupeByFSpecialiteAndNiveauAndAnnee(CB_Stagiaire_Modifier_Specialite.SelectedValue.ToString(), CB_Stagiaire_Modifier_Niveau.Text, CB_Stagiaire_Modifier_Annee.Text);
                    CB_Stagiaire_Modifier_Groupe.DisplayMember = "NomGroupe";
                    CB_Stagiaire_Modifier_Groupe.ValueMember = "IdGroupe";


                }

            }
        }
        //Stagiaire => Consulter Click ------
        private void BTN_Stagiaire_Consulter_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(LBL_Stagiaire_Id_Clicked.Text) && LBL_Stagiaire_Nom_Clicked.Text != "----------")
            {
                // SqlCommand cmd = new SqlCommand("select S.IdStagiaire,P.Cin,P.Nom,P.Prenom,P.Tel,P.Email,P.DateNaissance,P.Adresse,P.sexe,S.DateInscription,S.idspecialite,G.NomGroupe,S.Question,S.Reponse  from Personne P  inner join Stagiaire S on P.Cin = S.cin  inner join Groupe G on G.IdGroupe=S.idgroupe where S.IdStagiaire=" + LBL_Stagiaire_Id_Clicked.Text + " ", Provider.cnx);
                //Provider.cnx.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                DataRow[] dr = Provider.ds.Tables["StagPersonne"].Select("Cin ='" + LBL_Stagiaire_Cin_Clicked.Text + "'");
                if (dr.Length > 0)
                {
                    TB_Stagiaire_Consulter_Id.Text = dr[0][0].ToString();
                    TB_Stagiaiare_Consulter_Cin.Text = dr[0][1].ToString();
                    TB_Stagiaire_Consulter_Nom.Text = dr[0][2].ToString();
                    TB_Stagiaire_Consulter_Prenom.Text = dr[0][3].ToString();
                    TB_Stagiaire_Consulter_Telephone.Text = dr[0][4].ToString();
                    TB_Stagiaire_Consulter_Email.Text = dr[0][5].ToString();
                    TB_Stagiaire_Consulter_DateNaissance.Text = dr[0][6].ToString();
                    TB_Stagiaire_Consulter_Adresse.Text = dr[0][7].ToString();
                    TB_Stagiaire_Consulter_Sexe.Text = dr[0][8].ToString();
                    TB_Stagiaire_Consulter_DateInscription.Text = dr[0][9].ToString();
                    TB_Stagiaire_Consulter_Specialite.Text = dr[0][10].ToString();
                    TB_Stagiaire_Consulter_Groupe.Text = dr[0][12].ToString();
                    TB_Stagiaire_Consulter_Question.Text = dr[0][13].ToString();
                    TB_Stagiaire_Consulter_Reponse.Text = dr[0][14].ToString();
                    LBL_Stagiaire_Consulter_NomPrenom.Text = dr[0][2].ToString() + " " + dr[0][3].ToString();
                    LBL_Stagiaire_Consulter_Cin1.Text = dr[0][1].ToString();
                    LBL_Stagiaire_Consulter_ID1.Text = dr[0][0].ToString();
                    tabControl2_Stagiaire.SelectTab(3);
                }
                else { MessageBox.Show("Ce Stagiaire n'existe Pas dans Le Groupe "); }


                // Provider.cnx.Close();
            }
            else MessageBox.Show("Clicker Dans La Liste sur un Stagiaire , puis ressayer");

        }
        //Stagiaire : Ajouter => Click 
        private void BTN_Stagiaire_Ajouter_Click(object sender, EventArgs e)
        {
            CB_Stagiaire_Ajouter_Niveau.SelectedIndex = -1;
            tabControl2_Stagiaire.SelectTab(1);
            if (!AjouterStagiaireClicked)
            {
                //if ajouter is clicked for the first time the comboboxes will be initiilised
                CB_Stagiaire_Ajouter_Specialite.DataSource = Provider.GetAllSpecialite;
                CB_Stagiaire_Ajouter_Specialite.DisplayMember = "Designation";
                CB_Stagiaire_Ajouter_Specialite.ValueMember = "IdSpecialite";
                CB_Stagiaire_Ajouter_Specialite.SelectedIndex = -1;
            }
        }

        private void BTN_Stagiaire_Liste_Click(object sender, EventArgs e)
        {
            tabControl2_Stagiaire.SelectTab(0);
        }

        private void BTN_Menu_Professeur_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            Stagiaire_Header_Panel.Visible = false;
            if (!ProfesseurClicked) {
                Provider.FillProfesseur();
                DGV_Professeur1.DataSource = Provider.GetProf;
                ProfesseurClicked = true;
            }

        }

        private void BTN_Menu_Stagiaire_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            Stagiaire_Header_Panel.Visible = true;
        }

        private void BTN_Prof_Liste_Click(object sender, EventArgs e)
        {
            tabControl2_Professeur.SelectTab(0);
        }

        private void BTN_Prof_Ajouter_Click(object sender, EventArgs e)
        {
            tabControl2_Professeur.SelectTab(1);
        }

        private void BTN_Prof_Consulter_Click(object sender, EventArgs e)
        {
            tabControl2_Professeur.SelectTab(4);
        }

        private void BTN_Load_Click(object sender, EventArgs e)
        {
            this.Form1_Load(sender, e);
        }



        private void DGV_Stagiaire1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_Stagiaire1.Rows.Count > 0)
            {

                LBL_Stagiaire_Id_Clicked.Text = DGV_Stagiaire1.Rows[e.RowIndex].Cells[1].Value.ToString();
                LBL_Stagiaire_Cin_Clicked.Text = DGV_Stagiaire1.Rows[e.RowIndex].Cells[2].Value.ToString();
                LBL_Stagiaire_Prenom_Clicked.Text = DGV_Stagiaire1.Rows[e.RowIndex].Cells[3].Value.ToString();
                LBL_Stagiaire_Nom_Clicked.Text = DGV_Stagiaire1.Rows[e.RowIndex].Cells[4].Value.ToString();
                ModifierPersonneOriginCin = DGV_Stagiaire1.Rows[e.RowIndex].Cells[2].Value.ToString();
                ModifierStagiaireIdStagiaire = DGV_Stagiaire1.Rows[e.RowIndex].Cells[1].Value.ToString();
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

        }
        // Stagiaire : Ajouter => Select Image 
        private void BIBTN_Stagiaire_SelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fdg = new OpenFileDialog())
            {

                fdg.Filter = "PNG|*.png|Jpeg jpg|*.jpg;*jpeg";
                if (fdg.ShowDialog() == DialogResult.OK)
                {

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
                if (Provider.ds.Tables.Contains("StagPersonne"))
                {
                    if (Provider.GetStagiaire.Rows.Count > 0)
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
                            if (x <= 0)
                            {
                                Provider.ds.Tables["StagPersonne"].RejectChanges();
                                MessageBox.Show("Erreur De Communication avec le serveur");
                            }
                            else
                            {
                                MessageBox.Show("Les Stagiaires Sont Supprimer avec Succes Rest :total :" + Provider.ds.Tables["StagPersonne"].Rows.Count);
                                ModifierPersonneOriginCin = null;
                                ModifierStagiaireIdStagiaire = null;
                                Provider.InitialiserPanel(P_Stagiaire_Preview2);
                            }
                        }
                    }
                    else MessageBox.Show("Le Group est Vide !! Rien A supprimer");
                }
                else { MessageBox.Show("Selectionner un Groupe !!", "Pas De Groupe ", MessageBoxButtons.OK, MessageBoxIcon.Error); }

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
            string IdStagiaire = "x";
            string sexe;

            if (TB_Stagiaire_Ajouter_F.Checked) sexe = "F";
            else sexe = "M";
            if (Provider.AjouterStagiaire(TB_Stagiaire_Ajouter_Cin.Text, TB_Stagiaire_Ajouter_Nom.Text, TB_Stagiaire_Ajouter_Prenom.Text, TB_Stagiaire_Ajouter_Tel.Text, TB_Stagiaire_Ajouter_Email.Text, DTP_Stagiaire_Ajouter_DateNaissance2.Value.ToString(), TB_Stagiaire_Ajouter_Adresse.Text, sexe, CB_Stagiaire_Ajouter_Specialite.SelectedValue.ToString(), CB_Stagiaire_Ajouter_Groupe.SelectedValue.ToString(), CB_Stagiaire_Ajouter_Question.Text, TB_Stagiaire_Ajouter_Reponse.Text, ref IdStagiaire))
            {
                if (CB_Stagiaire_Ajouter_Groupe.SelectedValue.ToString() == Provider.LastStagiaireGroup)
                {
                    Provider.FillStagiaireByGroupe(Provider.LastStagiaireGroup);
                    DGV_Stagiaire1.DataSource = Provider.GetStagiaire;
                    Provider.InitialiserDataGrid(DGV_Stagiaire1);
                }
            }

        }

        private void tabControl2_Stagiaire_tabpage2_Ajouter_Click(object sender, EventArgs e)
        {

        }

        private void BTN_Stagiaire_Modifier_Click(object sender, EventArgs e)
        {
           
            if (!ModifierStagiaireClicked)
            {
                CB_Stagiaire_Modifier_Specialite.DataSource = Provider.GetAllSpecialite;
                CB_Stagiaire_Modifier_Specialite.DisplayMember = "Designation";
                CB_Stagiaire_Modifier_Specialite.ValueMember = "IdSpecialite";

            }
            if (ModifierPersonneOriginCin != null && ModifierStagiaireIdStagiaire != null)
            {

                DataRow[] dr = Provider.ds.Tables["StagPersonne"].Select("Cin ='" + ModifierPersonneOriginCin + "'");
                if (dr.Length > 0)
                {

                    TB_Stagiaire_Modifier_IdStagiaire.Text = dr[0][0].ToString();
                    TB_Stagiaire_Modifier_Cin.Text = dr[0][1].ToString();
                    TB_Stagiaire_Modifier_Nom.Text = dr[0][2].ToString();
                    TB_Stagiaire_Modifier_Prenom.Text = dr[0][3].ToString();
                    TB_Stagiaire_Modifier_Tel.Text = dr[0][4].ToString();
                    TB_Stagiaire_Modifier_Email.Text = dr[0][5].ToString();
                    DTP_Stagiaire_Modifier_DateNaissance.Text = dr[0][6].ToString();
                    TB_Stagiaire_Modifier_Adresse.Text = dr[0][7].ToString();
                    if (dr[0][8].ToString() == "F") TB_Stagiaire_Modifier_F.Checked = true;
                    else TB_Stagiaire_Modifier_M.Checked = true;
                    TB_Stagiaire_Modifier_DateInsciption.Text = dr[0][9].ToString();
                    CB_Stagiaire_Modifier_Specialite.SelectedValue = dr[0][10].ToString();
                    CB_Stagiaire_Modifier_Question.SelectedValue = dr[0][13].ToString();
                    CB_Stagiaire_Modifier_Reponse.Text = dr[0][14].ToString();
                    DataRow dr2 = Provider.GetGroupeById(dr[0][11].ToString());
                    CB_Stagiaire_Modifier_Niveau.SelectedItem = dr2[4].ToString();
                    CB_Stagiaire_Modifier_Annee.SelectedItem = dr2[3].ToString();
                    GetGroups(3);
                    CB_Stagiaire_Modifier_Groupe.SelectedValue = dr2[0].ToString();
                    tabControl2_Stagiaire.SelectTab(2);
                }

            }
            else
            {
                tabControl2_Stagiaire.SelectTab(0);
                MessageBox.Show("Clicker  Dans La liste sur le stagiaire que vous voulez Modifier  si la liste est vide . Selectionner un Groupe  ");
            }
        }
        // Stagiaire :Modifier => enrejistrer
        private void BTN_Stagiaire_Modifier_Enregistrer_Click(object sender, EventArgs e)
        {
            if (CB_Stagiaire_Modifier_Question.SelectedIndex != -1)
            {
                if (CB_Stagiaire_Modifier_Groupe.SelectedIndex != -1)
                {
                    if (Provider.ModifierStagiaire(TB_Stagiaire_Modifier_IdStagiaire.Text, TB_Stagiaire_Modifier_Cin.Text, TB_Stagiaire_Modifier_Nom.Text, TB_Stagiaire_Modifier_Prenom.Text, TB_Stagiaire_Modifier_Tel.Text, TB_Stagiaire_Modifier_Email.Text, DTP_Stagiaire_Modifier_DateNaissance.Value.ToString(), TB_Stagiaire_Modifier_Adresse.Text, TB_Stagiaire_Modifier_F.Checked ?"F":"M", CB_Stagiaire_Modifier_Specialite.SelectedValue.ToString(), CB_Stagiaire_Modifier_Groupe.SelectedValue.ToString(), CB_Stagiaire_Modifier_Question.SelectedItem.ToString(), CB_Stagiaire_Modifier_Reponse.SelectedText, ModifierPersonneOriginCin))
                    {
                        MessageBox.Show("Le stagiaire a été Modifier avec succès");
                        Provider.InitialiserPanel(P_Stagiaire_Preview2);
                        ModifierPersonneOriginCin = null;
                        ModifierStagiaireIdStagiaire = null;
                        MessageBox.Show("Last Groupe:"+Provider.LastStagiaireGroup+"new "+ CB_Stagiaire_Modifier_Groupe.SelectedValue.ToString());
                       
                            Provider.FillStagiaireByGroupe(Provider.LastStagiaireGroup);
                            DGV_Stagiaire1.DataSource = Provider.GetStagiaire;
                            Provider.InitialiserDataGrid(DGV_Stagiaire1);
                            MessageBox.Show("I will Refresh DataGrid");
                        
                        tabControl2_Stagiaire.SelectTab(0);
                        Provider.ViderTabPage(tabControl2_Stagiaire_tabpage2_Modifier);

                    }
                    else MessageBox.Show("Le stagiaire n'est pas Modifier");

                }
                else MessageBox.Show("Selectionné un groupe");
            }
            else MessageBox.Show("Selectionner Un Question de securité");
        }

        private void CB_Stagiaire_Modifier_Specialite_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroups(3);
        }

        private void CB_Stagiaire_Modifier_Niveau_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroups(3);
        }

        private void CB_Stagiaire_Modifier_Annee_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroups(3);
        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void BTN_Stagiaire_Modifier_Annuler_Click(object sender, EventArgs e)
        {
            Provider.ViderTabPage(tabControl2_Stagiaire_tabpage2_Modifier);
            tabControl2_Stagiaire.SelectTab(0);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CB_Stagiaire_Chercher_ChercherPar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Stagiaire_Chercher_ChercherPar.SelectedIndex == 0)
            {
                TB_Stagiaire_Chercher_Chercher_Nom.Visible = true;
                LBL_Chercher_Nom.Visible = true;
                TB_Stagiaire_Chercher_Chercher_Nom.text = "";
                TB_Stagiaire_Chercher_Chercher_CinOuPrenom.text = "";
                LBL_Stagiaire_Chercher_CinOuNom.Text = "Prenom";

            }
            else if (CB_Stagiaire_Chercher_ChercherPar.SelectedIndex == 1)
            {
                TB_Stagiaire_Chercher_Chercher_Nom.Visible = false; ;
                LBL_Chercher_Nom.Visible = false;
                TB_Stagiaire_Chercher_Chercher_CinOuPrenom.text = "";
                LBL_Stagiaire_Chercher_CinOuNom.Text = "Cin";

            }

        }

        private void BFBTN8CB_Stagiaire_Chercher_Click(object sender, EventArgs e)
        {
            if (CB_Stagiaire_Chercher_ChercherPar.SelectedIndex!=-1)
            {
                if (TB_Stagiaire_Chercher_Chercher_Nom.Visible==true)
                {
                        if (!string.IsNullOrEmpty(TB_Stagiaire_Chercher_Chercher_CinOuPrenom.text) && !string.IsNullOrEmpty(TB_Stagiaire_Chercher_Chercher_Nom.text))
                        {
                          Provider.dtStagiaireChercher.Rows.Clear();
                            DGV_Stagiaire_Chercher.DataSource = Provider.ChercherStagiaireByNomPrenom(TB_Stagiaire_Chercher_Chercher_CinOuPrenom.text, TB_Stagiaire_Chercher_Chercher_Nom.text);

                        }
                        else MessageBox.Show("Remplir Les Champs Vide", "Chercher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                }else
                {
                    if (!string.IsNullOrEmpty(TB_Stagiaire_Chercher_Chercher_CinOuPrenom.text))
                    {

                        DGV_Stagiaire_Chercher.DataSource = Provider.ChercherStagiaireByCin(TB_Stagiaire_Chercher_Chercher_CinOuPrenom.text);
                        if (Provider.dtStagiaireChercher.Rows.Count<=0)
                        {
                            MessageBox.Show("Ce Stagiaire n'existe Pas","Chercher",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

                        }
                    }
                    else MessageBox.Show("Remlir Le Cin ","Chercher",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            } else
            {
                MessageBox.Show("Selectionner Un Type De Recherche : Chercher par ");
            }
                      
        }

        private void BTN_Stagiaire_Chercher_Click(object sender, EventArgs e)
        {
            tabControl2_Stagiaire.SelectTab(4);
        }

        private void DGV_Stagiaire_Chercher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void DGV_Stagiaire_Chercher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_Stagiaire_Chercher.Rows.Count > 0 && e.RowIndex >=0 && e.ColumnIndex==0)
            {
                if (e.ColumnIndex == 0)
                {
                    DataRow[] dr = Provider.dtStagiaireChercher.Select("IdStagiaire ='" + DGV_Stagiaire_Chercher.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    if (dr.Length > 0)
                    {
                        TB_Stagiaire_Consulter_Id.Text = dr[0][0].ToString();
                        TB_Stagiaiare_Consulter_Cin.Text = dr[0][1].ToString();
                        TB_Stagiaire_Consulter_Nom.Text = dr[0][2].ToString();
                        TB_Stagiaire_Consulter_Prenom.Text = dr[0][3].ToString();
                        TB_Stagiaire_Consulter_Telephone.Text = dr[0][4].ToString();
                        TB_Stagiaire_Consulter_Email.Text = dr[0][5].ToString();
                        TB_Stagiaire_Consulter_DateNaissance.Text = dr[0][6].ToString();
                        TB_Stagiaire_Consulter_Adresse.Text = dr[0][7].ToString();
                        TB_Stagiaire_Consulter_Sexe.Text = dr[0][8].ToString();
                        TB_Stagiaire_Consulter_DateInscription.Text = dr[0][9].ToString();
                        TB_Stagiaire_Consulter_Specialite.Text = dr[0][10].ToString();
                        TB_Stagiaire_Consulter_Groupe.Text = dr[0][12].ToString();
                        TB_Stagiaire_Consulter_Question.Text = dr[0][13].ToString();
                        TB_Stagiaire_Consulter_Reponse.Text = dr[0][14].ToString();
                        LBL_Stagiaire_Consulter_NomPrenom.Text = dr[0][2].ToString() + " " + dr[0][3].ToString();
                        LBL_Stagiaire_Consulter_Cin1.Text = dr[0][1].ToString();
                        LBL_Stagiaire_Consulter_ID1.Text = dr[0][0].ToString();
                        tabControl2_Stagiaire.SelectTab(3);
                    }
                    else MessageBox.Show("La Liste est Vide Rien a afficher !!!", "Consulter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void BTN_Prof_Modifier_Click(object sender, EventArgs e)
        {
            tabControl2_Professeur.SelectTab(2);
        }

        private void BTN_Prof_Supprimer_Click(object sender, EventArgs e)
        {
            tabControl2_Professeur.SelectTab(0);
        }

        private void BTN_Prof_Chercher_Click(object sender, EventArgs e)
        {
            tabControl2_Professeur.SelectTab(3);
        }

        private void BTN_Prof_Ajouter_Ajouter_Click(object sender, EventArgs e)
        {

        }
    }
}

      
    

    

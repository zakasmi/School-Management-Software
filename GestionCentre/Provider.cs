using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace GestionCentre
{
    public static class Provider
    {
        public static SqlConnection cnx = new SqlConnection(@"Data Source = DELL; Initial Catalog = GestCentre07; Integrated Security = True");
        public static DataSet ds = new DataSet();
        public static int RecentYear;
        public static bool originalstagiaredeleted = false;
        public static string RecentGroupeYearInStagiaire = "";
        public static string LastStagiaireGroup ="";
        public static  int ConsulterType =0;
        public static DataTable dtStagiaireChercher = new DataTable();

        //----------------------Specialite ------------------------------------
        //fill All Specialite Table 
        public static  void FillSpecialite()
        {
            if (ds.Tables.Contains("Specialite")) { ds.Tables["Specialite"].Rows.Clear(); }

            using (SqlDataAdapter da = new SqlDataAdapter("select * from Specialite", cnx))
            {
                da.Fill(ds, "Specialite");
                ds.Tables["Specialite"].PrimaryKey = new DataColumn[] { ds.Tables["Specialite"].Columns["IdSpecialite"] };
                
            }
        }
        // Get All Specialite Table 

        public static DataTable GetAllSpecialite {

            get { return ds.Tables["Specialite"]; }

        }
        //-------------------------- Groupe --------------------------------------------------

        //Fill all groupe 
        public static void FillGroupe() {

            if (ds.Tables.Contains("Groupe")) { ds.Tables["Groupe"].Rows.Clear(); }
            using (SqlDataAdapter da = new SqlDataAdapter("select * from Groupe",cnx)) {
                da.Fill(ds, "Groupe");
                ds.Tables["Groupe"].PrimaryKey = new DataColumn[] { ds.Tables["Groupe"].Columns["IdGroupe"] };

            }
        }

        //Get All Groupe 
        public static DataTable GetAllGroupe {
            get { return ds.Tables["Groupe"]; }
        }
        //Get Groupes by IdGroupe
        public static DataRow GetGroupeById(string IdGroupe)
        {
       
            DataRow[] dr = ds.Tables["Groupe"].Select("IdGroupe = " + IdGroupe );
            return dr[0];
        }

        public static DataTable GetGroupeByFSpecialiteAndNiveauAndAnnee(string Specialite ,string niveau,string Annee)
        {
        // MessageBox.Show(niveau);
            DataRow[] dr = ds.Tables["Groupe"].Select("idspecialite = '"+ Specialite+ "' and NiveauGroupe= " +niveau+ " and Annee = '"+Annee+"'" );


            DataTable dt=ds.Tables["Groupe"].Clone();
            foreach(DataRow r in dr) { dt.ImportRow(r); }
 
            return dt;

        }

        // --------------------------- Stagiaire ---------------------------------------------------------

        //FIll  all Stagiaire of a specific year year
        /*  public static void FillStagiaire(string Year)
         {
             if (ds.Tables.Contains("StagPersonne")) { ds.Tables["StagPersonne"].Rows.Clear(); }
             using (SqlDataAdapter da = new SqlDataAdapter("select S.IdStagiaire,P.Cin,P.Nom,P.Prenom,P.Tel,P.Email,P.DateNaissance,P.Adresse,P.sexe,S.DateInscription,S.idspecialite,S.idgroupe,S.Question,S.Reponse from  Personne P inner join Stagiaire S  on P.Cin=S.cin inner join Groupe G on G.IdGroupe=S.idgroupe where  G.Annee= " + Year + "", cnx))
             {
                 da.Fill(ds, "StagPersonne");
                 MessageBox.Show("nombre de stagiaire de cette année " + ds.Tables["StagPersonne"].Rows.Count + " : " + Year);
                 RecentStagiareYearinDataSet = int.Parse(Year);
                 ds.Tables["StagPersonne"].PrimaryKey = new DataColumn[] { ds.Tables["StagPersonne"].Columns["IdStagiaire"] };      
             }

         }*/
        //Stagiaire  Method : Fill table Stagiaire with a specific Groupe-----------------
        public static void FillStagiaireByGroupe(string Groupe)
        {
            if (ds.Tables.Contains("StagPersonne")) { ds.Tables["StagPersonne"].Rows.Clear(); }
            using (SqlDataAdapter da = new SqlDataAdapter("select S.IdStagiaire,P.Cin,P.Nom,P.Prenom,P.Tel,P.Email,P.DateNaissance,P.Adresse,P.sexe,S.DateInscription,S.idspecialite,S.idgroupe,G.NomGroupe,S.Question,S.Reponse from  Personne P inner join Stagiaire S  on P.Cin=S.cin inner join Groupe G on G.IdGroupe=S.idgroupe where  G.IdGroupe=" + Groupe + "", cnx))
            {
                da.Fill(ds, "StagPersonne");
                LastStagiaireGroup = Groupe;
                ds.Tables["StagPersonne"].PrimaryKey = new DataColumn[] { ds.Tables["StagPersonne"].Columns["IdStagiaire"] };
            }
        }
        //Stagiaire : Methode =>Modifier -------------------------------
        public static bool ModifierStagiaire(string IdStagiaire,string Cin, string Nom, string Prenom, string Tel, string Email, string DateNaissance, string Adresse, string Sexe, string idspecialite, string idgroupe, string Question, string Reponse,string OriginalCin)
        {
            int x = 0;
            int y = 0;
            using (SqlCommand cmd = new SqlCommand("Update Personne set Cin ='"+Cin+"' ,Nom ='"+Nom+"' ,Prenom ='"+ Prenom + "',Tel ='"+ Tel + "',Email='"+ Email + "',DateNaissance='"+ DateNaissance + "',Adresse='"+ Adresse + "',sexe='"+ Sexe + "' where Cin='"+OriginalCin+"'", cnx))
            {
                cnx.Open();
                x = cmd.ExecuteNonQuery();
                cnx.Close();
            }
            if (x > 0)
            {
                using (SqlCommand cmd = new SqlCommand("Update Stagiaire set idspecialite = '" + idspecialite + "', idgroupe = '" + idgroupe + "', Question = '" + Question + "' where  IdStagiaire= " + IdStagiaire + "", cnx))
                {
                    cnx.Open();
                    y = cmd.ExecuteNonQuery();
                    cnx.Close();
                    if (y > 0)
                    {
                        return true;
                    }

                }
            }
            else return false;

            return false;
        }
        //Stagiaire  Method : Chercher Stagiaire par Nom et Prenom=>>


        public static DataTable ChercherStagiaireByNomPrenom(string Prenom,string Nom)
        {    
                using (SqlDataAdapter da = new SqlDataAdapter("select S.IdStagiaire,P.Cin,P.Nom,P.Prenom,P.Tel,P.Email,P.DateNaissance,P.Adresse,P.sexe,S.DateInscription,S.idspecialite,S.idgroupe,G.NomGroupe,S.Question,S.Reponse from  Personne P inner join Stagiaire S  on P.Cin=S.cin inner join Groupe G on G.IdGroupe=S.idgroupe where  P.Prenom='" + Prenom + "' and P.Nom='" + Nom + "'", cnx))
                {
                    da.Fill(dtStagiaireChercher);
                }
            return dtStagiaireChercher;
        }
        //Stagiaire :Method : Chercher Stagiaire : Cin
        public static DataTable ChercherStagiaireByCin(string Cin)
        {

            using (SqlDataAdapter da = new SqlDataAdapter("select S.IdStagiaire,P.Cin,P.Nom,P.Prenom,P.Tel,P.Email,P.DateNaissance,P.Adresse,P.sexe,S.DateInscription,S.idspecialite,S.idgroupe,G.NomGroupe,S.Question,S.Reponse from  Personne P inner join Stagiaire S  on P.Cin=S.cin inner join Groupe G on G.IdGroupe=S.idgroupe where  P.Cin='" +Cin+"'", cnx))
                {
                    da.Fill(dtStagiaireChercher);
                }
            return dtStagiaireChercher;
        }
        //Stagiaire :Getter : Get ALl Stagiaire Recently in StagePersonne
        public static DataTable GetStagiaire
        {
            get { return ds.Tables["StagPersonne"]; }
        }
        // Stagiaire :Methode =>Ajouter Stagiaire 

            public static bool AjouterStagiaire(string Cin,string Nom,string Prenom,string Tel,string Email,string DateNaissance,string Adresse,string Sexe,string idspecialite,string idgroupe,string Question,string Reponse,ref string IdStagiaire )
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Declare @x int  Exec AjouterStagiaire '" + Cin + "','" + Nom + "','" + Prenom + "','" + Tel + "','" + Email + "','" + DateNaissance + "','" + Adresse + "','" + Sexe + "','" + idspecialite + "','" + idgroupe + "','" + Question + "','" + Reponse + "',@x output", Provider.cnx))
                {
                    cnx.Open();
                    var c = cmd.ExecuteNonQuery();
                        if (c.ToString() == "1") MessageBox.Show(c.ToString() + " Le stagiaire a été inscrit dans le groupe avec succée \n N.B ce stagiaire est deja Inscrit dans ce centre , ancien donnée  n'est pas modifier . Penser a modifier les donnée necessaire");
                        if (c.ToString() == "2") MessageBox.Show(c.ToString() + " Le stagiaire a éte inscrit avec succes .\n N.B Nouveau Stagiare ");
                        if (c.ToString() == "0") MessageBox.Show(c.ToString() + " Erreur !! Le stagiaire n'est pas inscrit .", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cnx.Close();
                    return true;
                }
             }
           catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
                return false;
            }
            finally
            {
                cnx.Close();
            }
        }
        //check if personne existe 
        public static bool CheckIfPersonneExiste(string Cin)
        {
            int x = 0;
            using (SqlCommand cmd = new SqlCommand("Select *from Personne where Cin=" + Cin + "", Provider.cnx))
            {
                x=cmd.ExecuteNonQuery();
            }
            if (x > 0) { return true; }
            else { return true; }
        }

        //get Stagiare by groupe------------
        /*   public static DataTable GetStagiareByGroupe(string Groupe)
           {
              // MessageBox.Show("idgroupe=" + Groupe);
               DataRow[] dr = ds.Tables["StagPersonne"].Select("idgroupe="+ Groupe);
               DataTable dt = ds.Tables["StagPersonne"].Clone();
               foreach (DataRow r in dr) { dt.ImportRow(r); }
               return dt;
           }*/

        //Stagiaire :Method => Delete Stagiaire from DataGrid and ds.TAbles["StagPersonne"] By IdStagiaire --------

        public static bool DeleteStagiaireFromDataGrid(DataGridView DGV,ref string DeletedString) {
            int k = 0;          
            //Check if you checked any checkbox. it will Break for the first CHecked checkBox 
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if (DGV.Rows[i].Cells[0].Value.ToString() =="T") {
                    k = 1;
                    break;
                }
            }
            if (k == 1)
            {
                if (MessageBox.Show("Voulez Vous Supprimer", "Supprimer ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    List<string> DeletedIds = new List<string>();
                    for (int i = DGV.Rows.Count - 1; i >= 0; i--)
                    {
                        if (DGV.Rows[i].Cells[0].Value.ToString() == "T")
                        {
                            DeletedIds.Add(DGV.Rows[i].Cells[1].Value.ToString());
                            ds.Tables["StagPersonne"].Rows.Find(DGV.Rows[i].Cells[1].Value.ToString()).Delete();
                        }
                    }
                    DeletedString = string.Join(",", DeletedIds.ToArray());
                    return true;
                }
                else return false;
            }
            else
            {
                MessageBox.Show("Cocher Au minimum 1 Stagiaire !!", "Stagiaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }
        //---------------------------------- Professeur ---------------------------------------------------------
        //Professeur : Method FillProfesseur
        public static void FillProfesseur()
        {
            if (ds.Tables.Contains("Professeur")) { ds.Tables["Professeur"].Rows.Clear(); }
            using(SqlDataAdapter da = new SqlDataAdapter("select *from Professeur", cnx)){
                da.Fill(ds, "Professeur");
                ds.Tables["Professeur"].PrimaryKey = new DataColumn[] { ds.Tables["Professeur"].Columns["Cin"] };
            }
        }
        // Professeur Getter : GetProfesseur

            public static DataTable GetProf
        {
            get { return ds.Tables["Professeur"]; }
        }
        //
        //Professeur :Method => Ajouter
        public static void AjouterProf(string Cin, string Nom, string Prenom, string Tel, string Email, string DateNaissance, string Adresse, string Sexe, string DateEmbauche, string MotDePasse, string Question, string Reponse)
        {

            try
            {
                DataRow dr = ds.Tables["Professeur"].NewRow();
                dr[0] = Cin;
                dr[1] = Nom;
                dr[2] = Prenom;
                dr[3] = Tel;
                dr[4] = Email;
                dr[5] = DateNaissance;
                dr[6] = Adresse;
                dr[7] = Sexe;
                dr[8] = DateEmbauche;
                dr[9] = MotDePasse;
                dr[10] = Question;
                dr[11] = Reponse;

                ds.Tables["Professeur"].Rows.Add(dr);
                using (SqlDataAdapter da = new SqlDataAdapter("Select *from Professeur", cnx))
                {
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "Professeur");
                }
                MessageBox.Show("Le Professeur a été ajouter ");
            }
            catch (Exception e3)
            {
                MessageBox.Show("Le Professeur n'est pas ajouter", e3.Message);
                throw;
            }
        }



        // ---------------------- Methods ---------- ViderTabPage--------------------
        public static void ViderTabPage(TabPage P)
        {
            foreach (Control C in P.Controls)
            {
                if (C is TextBox) { C.Text = null; }
                else if (C is MetroFramework.Controls.MetroTextBox)
                {

                    var C2 = C as MetroFramework.Controls.MetroTextBox;
                    C2.Text = null;
                }
                else if (C is MetroFramework.Controls.MetroComboBox)
                {
                    var C2 = C as MetroFramework.Controls.MetroComboBox;
                    C2.SelectedIndex = -1;

                }
                else if (C is RadioButton)
                {
                    var C2 = C as RadioButton;
                    C2.Checked = false;

                }
                else if (C is MetroFramework.Controls.MetroDateTime)
                {
                    var C2 = C as MetroFramework.Controls.MetroDateTime;
                    C2.Value = DateTime.Now;
                }
                /*  if (C is MetroFramework.Controls.MetroLabel ) {
                      var C2 = C as MetroFramework.Controls.MetroLabel;
                      C2.Text = "Iam a MetroLabel";
                  }*/
            }

        } 

       //initialiser datagrid view 
       public static void InitialiserDataGrid(DataGridView DGV) {
            foreach (DataGridViewRow R in DGV.Rows) {
                R.Cells[0].Value = "F";
            }
        }
        // initialiser Panel avec -----
        public static void InitialiserPanel(Panel P)
        {
            foreach(Label L in P.Controls)
            {
                L.Text = "----------";
            }
        }


    }
}

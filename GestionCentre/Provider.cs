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
        public static int RecentStagiareYearinDataSet ; 

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
        //Get Groupes by Specialitee and Niveau 

        public static DataTable GetGroupeByFSpecialiteAndNiveauAndAnnee(string Specialite ,string niveau,string Annee)
        {
        // MessageBox.Show(niveau);
            DataRow[] dr = ds.Tables["Groupe"].Select("idspecialite = '"+ Specialite+ "' and NiveauGroupe= " +niveau+ " and Annee = '"+Annee+"'" );


            DataTable dt=ds.Tables["Groupe"].Clone();
            foreach(DataRow r in dr) { dt.ImportRow(r); }
 
            return dt;

        }

        // --------------------------- Stagiaire ---------------------------------------------------------

        //FIll  all Stagiaire 
         public static void FillStagiaire()
        {
            if (ds.Tables.Contains("StagPersonne")) { ds.Tables["StagPersonne"].Rows.Clear(); }
            using (SqlDataAdapter da = new SqlDataAdapter("select S.IdStagiaire,P.Cin,P.Nom,P.Prenom,P.Tel,P.Email,P.DateNaissance,P.Adresse,P.sexe,S.DateInscription,S.idspecialite,S.idgroupe,S.Question,S.Reponse from  Personne P inner join Stagiaire S  on P.Cin=S.cin inner join Groupe G on G.IdGroupe=S.idgroupe where  G.Annee= '" + RecentYear+"'", cnx)) {
                da.Fill(ds, "StagPersonne");
                MessageBox.Show("nombre de stagiaire de cette année " + ds.Tables["StagPersonne"].Rows.Count + " : " + RecentYear);
             
                ds.Tables["StagPersonne"].PrimaryKey = new DataColumn[] { ds.Tables["StagPersonne"].Columns["IdStagiaire"] };      
            }

        }
        public static void FillStagiaireDifferentYear(string Year)
        {
            if (ds.Tables.Contains("StagPersonne")) { ds.Tables["StagPersonne"].Rows.Clear(); }
            using (SqlDataAdapter da = new SqlDataAdapter("select S.IdStagiaire,P.Cin,P.Nom,P.Prenom,P.Tel,P.Email,P.DateNaissance,P.Adresse,P.sexe,S.DateInscription,S.idspecialite,S.idgroupe,S.Question,S.Reponse from  Personne P inner join Stagiaire S  on P.Cin=S.cin inner join Groupe G on G.IdGroupe=S.idgroupe where  G.Annee= " + Year + "", cnx))
            {
                
                da.Fill(ds, "StagPersonne");
                MessageBox.Show("nombre de stagiaire de cette année " + ds.Tables["StagPersonne"].Rows.Count + " : " + Year);
                MessageBox.Show(RecentYear + "  ;" + ds.Tables["StagPersonne"].Rows.Count);
                ds.Tables["StagPersonne"].PrimaryKey = new DataColumn[] { ds.Tables["StagPersonne"].Columns["IdStagiaire"] };
            }

        }
        //

        //get all Stagiaire

        //get Stagiare by groupe
        public static DataTable GetStagiareByGroupe(string Groupe)
        {
           // MessageBox.Show("idgroupe=" + Groupe);
            DataRow[] dr = ds.Tables["StagPersonne"].Select("idgroupe="+ Groupe);
            DataTable dt = ds.Tables["StagPersonne"].Clone();
            foreach (DataRow r in dr) { dt.ImportRow(r); }


            return dt;
        }

        // ---------------------- Methods ---------- ViderTabPage--------------------
        public static void ViderTabPage(TabPage P)
        {
            foreach (Control C in P.Controls) {
                if (C is TextBox)  { C.Text = null;  }
                else if(C is MetroFramework.Controls.MetroTextBox){

                    var C2 = C as MetroFramework.Controls.MetroTextBox;
                    C2.Text = null;
                }
                else if(C is MetroFramework.Controls.MetroComboBox)
                {
                    var C2 = C as MetroFramework.Controls.MetroComboBox;
                    C2.SelectedIndex = -1;
                    
                }else if (C is RadioButton) {
                    var C2 = C as RadioButton;
                    C2.Checked = false;
                    
                }else if (C is MetroFramework.Controls.MetroDateTime) {
                    var C2 = C as MetroFramework.Controls.MetroDateTime;
                    C2.Value = DateTime.Now;
                    

                }




              /*  if (C is MetroFramework.Controls.MetroLabel ) {
                    var C2 = C as MetroFramework.Controls.MetroLabel;
                    C2.Text = "Iam a MetroLabel";
                }*/
            }

          


        } 


    }
}

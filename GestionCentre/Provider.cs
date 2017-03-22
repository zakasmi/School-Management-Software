using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace GestionCentre
{
    class Provider
    {
        public static SqlConnection cnx = new SqlConnection(@"Data Source = DELL; Initial Catalog = GestCentre06; Integrated Security = True");
        public static DataSet ds = new DataSet();

      
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

        public static DataTable GetGroupeByFSpecialiteAndNiveau(string Specialite ,string niveau)
        {
        // MessageBox.Show(niveau);
            DataRow[] dr = ds.Tables["Groupe"].Select("idspecialite = '"+ Specialite+ "' and NiveauGroupe= " +niveau);
            
            DataTable dt=ds.Tables["Groupe"].Clone();
            foreach(DataRow r in dr) { dt.ImportRow(r); }
 
            return dt;

        }

        // --------------Stagiaire ---------------------------------------------------------

        //FIll  all Stagiaire 
         public static void FillStagiaire()
        {
            if (ds.Tables.Contains("Stagiaire")) { ds.Tables["Stagiaire"].Rows.Clear(); }
            using (SqlDataAdapter da = new SqlDataAdapter("select * from Stagiaire S  inner join Personne P on P.Cin=S.cin ",cnx)) {
                da.Fill(ds, "StagPersonne");

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


        


    }
}

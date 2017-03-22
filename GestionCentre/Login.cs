using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCentre
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

      

       

        private void BTN_Login_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTN_Login_Connecter_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
           
          /*  Form1 frm = new Form1();
            this.Hide();
            frm.Show();*/
            
            
        }

        private void LBL_Login_MotDePasseOublie_Click(object sender, EventArgs e)
        {

            Tab.SelectTab(1);
            /* MotDePasseOublie mpo = new MotDePasseOublie();
             mpo.ShowDialog();*/

        }

        private void BTN_MotDePasseOublie_Ok_Click(object sender, EventArgs e)
        {
            Tab.SelectTab(2);
        }

        private void BIB_Modifiermp_Retour_Click(object sender, EventArgs e)
        {
            Tab.SelectTab(1);
            TXB_Mmp_nouveumotpasse.Text = "";
            TXB_Mmp_Confirmémotpasse.Text = "";
        }

        private void BIB_Oubliemp_Retour_Click(object sender, EventArgs e)
        {
            Tab.SelectTab(0);
            TXB_MotDePasseOublie_Reponse.Text = "";
        }

        private void BTN_ModifierMotPass_Connecter_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();

        }
    }
}

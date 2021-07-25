using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security;

namespace GestionVacataire
{
    public partial class Login : Form
    {
        string strcon = "Data Source=.;initial catalog=GestionVacataire;Integrated security=true";
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        public Login()
        {
            InitializeComponent();
        }
        

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.ConnectionString = strcon;
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Utilisateur where Email='" + textBox1.Text + "' and MotPasse='"+textBox2.Text+"' ", con);
            int nbre = (int)cmd.ExecuteScalar();
            if (nbre != 0)
            {
                MessageBox.Show("Connecté");
                Menu M = new Menu();
                M.Show();
            }
            else
                MessageBox.Show("Email ou Password Incorrecte");
            con.Close();
            
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("vous voulez vraiment Quitter", "Quitter", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utilisateur U = new Utilisateur();
            U.Show();
        }
    }
}

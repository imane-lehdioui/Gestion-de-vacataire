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

namespace GestionVacataire
{
    public partial class Absence : Form
    {
        string strcon = "Data Source=.;initial catalog=GestionVacataire;Integrated security=true";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Absence()
        {
            InitializeComponent();
        }

        private void Absence_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            con.ConnectionString = strcon;
            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct(Nom)from Vacataire", con);
            dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                comboBox1.Items.Add(dr["Nom"]);

            }
            con.Close();


            con.Open();
            SqlCommand cmd1 = new SqlCommand("select distinct(Justification)from Absence", con);
            dr = cmd1.ExecuteReader();
            while (dr.Read() == true)
            {
                comboBox2.Items.Add(dr["Justification"]);

            }
            con.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Vacataire", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                if (comboBox1.Text.Equals(dr[1]))
                {
                    label4.Text = dr[0].ToString();
                    break;
                }
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            con.Open();
            if (radioButton1.Checked)
                str = "OUI";
            else
                str = "NON";
            SqlCommand cmd = new SqlCommand("insert into Absence(NVacataire,DateAbsence,Justification) values(" + label4.Text + ",'" + dateTimePicker1.Text + "','" + str + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Enregistrer éfecté");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("vous voulez vraiment Quitter", "Fermer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}

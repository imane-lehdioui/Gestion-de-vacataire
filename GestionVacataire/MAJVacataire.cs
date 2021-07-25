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
    public partial class MAJVacataire : Form
    {
        string strcon = "Data Source=.;initial catalog=GestionVacataire;Integrated security=true";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        int position;

        public MAJVacataire()
        {
            InitializeComponent();
        }

        public void naviger()
     {
            if(con.State==ConnectionState.Closed)
         con.Open();
       cmd.Connection = con;
       cmd.CommandText = "select * from Vacataire";
       dr = cmd.ExecuteReader();
       
           for (int i = 0; i <= position; i++)
           {
               dr.Read();
           }

           textBox1.Text = dr[0].ToString();
           textBox2.Text = (string)dr[1];
           textBox3.Text = (string)dr[2];
           textBox4.Text = ((DateTime)dr[3]).ToString();
           comboBox1.Text = (string)dr[4];
           textBox5.Text = (string)dr[5];
           comboBox2.Text = (string)dr[6];
           con.Close();
       }
        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = strcon;
            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct(Spécialité)from Vacataire", con);
            dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                comboBox1.Items.Add(dr["Spécialité"]);

            }
            con.Close();


            con.Open();
            SqlCommand cmd1 = new SqlCommand("select distinct(Niveau)from Vacataire", con);
            dr = cmd1.ExecuteReader();
            while (dr.Read() == true)
            {
                comboBox2.Items.Add(dr["Niveau"]);

            }
            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string strsql = "insert into Vacataire(NVacataire,Nom,Prénom,DateNaissance,Spécialité,ModePasse,Niveau)" + "values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(strsql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ajout effectué");
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string strsql="update Vacataire set Nom='"+textBox2.Text+"',Prénom='"+textBox3.Text+"',DateNaissance='"+textBox4.Text+"',Spécialité='"+comboBox1.Text+"',ModePasse='"+textBox5.Text+"',Niveau='"+comboBox2.Text+"' where NVacataire='"+textBox1.Text+"'";
            SqlCommand cmd=new SqlCommand(strsql,con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Information Vacataire Modifié avec succés");
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Vacataire", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                dataGridView1.Rows.Add(rd[0], rd[1], rd[2], rd[3], rd[4], rd[5], rd[6]);
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Boolean trouve = false;
            con.Open();
            SqlCommand cmd = new SqlCommand("select* from Vacataire", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if
                    (rd[0].ToString().Equals(textBox1.Text))
                {
                    trouve = true;
                    break;
                }
            }
                if (trouve == true)
                {
                    textBox2.Text = Convert.ToString(rd[1]);
                    textBox3.Text = Convert.ToString(rd[2]);
                    textBox4.Text = Convert.ToString(rd[3]);
                    comboBox1.Text = Convert.ToString(rd[4]);
                    textBox5.Text = Convert.ToString(rd[5]);
                    comboBox2.Text = Convert.ToString(rd[6]);
                }
                else
                    MessageBox.Show("Ce Vacataire n'existe pas");
                rd.Close();
                con.Close();


       

        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("vous voulez vraiment supprimer ce Vacataire", "Suppresion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                con.Open();
                SqlCommand comd = new SqlCommand();
                string strsql = "delete from Vacataire where NVacataire=" + textBox1.Text + "";
                comd.Connection = con;
                comd.CommandText = strsql;
                int N = comd.ExecuteNonQuery();
                if (N != 0)
                    MessageBox.Show("Vacataire supprimé avec succès");
                con.Close();
            }
}

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            position = 0;
            naviger();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                position--;
                naviger();
            }
            catch { dr.Close(); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                position++;
                naviger();
            }
            catch { dr.Close(); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select count(*) from Vacataire";
            position = Convert.ToInt32(cmd.ExecuteScalar()) - 1;
            naviger();
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("vous voulez vraiment Quitter", "Quitter", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }
    }
}

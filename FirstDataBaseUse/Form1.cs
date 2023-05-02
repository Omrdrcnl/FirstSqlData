using System.Data.SqlClient;

namespace FirstDataBaseUse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {

                baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DbFirstData;Integrated Security=True");
                baglanti.Open();

                SqlCommand cmd = new SqlCommand("SELECT Adi, Soyadi, Ogrenci_Id, Not1, Not2 FROM Table_Ogrenci ", baglanti);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string ad = reader[0].ToString();
                    string soyad = reader[1].ToString();
                    string id = reader[2].ToString();
                    string not1 = reader[3].ToString();
                    string not2 = reader[4].ToString();

                    richTextBox1.Text= richTextBox1.Text + ad +" "+ soyad +"    " +"Öðrenci Nu: "+ id 
                        +"  " + "Not-1: "+ not1 + "  Not-2: " + not2 +" \n";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Data alýnýrken hata oluþtu" + ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                { baglanti.Close(); }
            }
           
        }
    }
}
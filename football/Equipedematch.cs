using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace football
{
    public class Equipedematch
    {

       public  List<Equipedematch> liste_equipe = new List<Equipedematch>();
        private long idEquipe;
        private String nom;
        private string logo;
        private String pays;
        public Equipedematch(long idEquipe, String nom, string logo, String pays)
        {

            this.idEquipe = idEquipe;
            this.nom = nom;
            this.logo = logo;
            this.pays = pays;
        }
        public Equipedematch()
        {

        }
        public long getIdEquipe()
        {
            return idEquipe;
        }
        public void setIdEquipe(long idEquipe)
        {
            this.idEquipe = idEquipe;
        }
        public String getNom()
        {
            return nom;
        }
        public void setNom(String nom)
        {
            this.nom = nom;
        }
        public string getLogo()
        {
            return logo;
        }
        public void setLogo(string logo)
        {
            this.logo = logo;
        }
        public String getPays()
        {
            return pays;
        }
        public void setPays(String pays)
        {
            this.pays = pays;
        }


        public void get_equipe()
        {
            SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=D:\\football\\football\\football.mdf;Integrated Security=True");
            {


                string nb = null;

                cnn.Open();
                DataSet ds = new DataSet();
                string requete = "select * from [dbo].[EQUIPEDEMATCH]";

                try
                {
                    SqlCommand command = new SqlCommand(requete, cnn);
                    SqlDataAdapter Adapter = new SqlDataAdapter(command);
                    Adapter.Fill(ds);
                    DataTable Matable = ds.Tables[0];

                    int j = 0;
                    

                    foreach (System.Data.DataRow row in Matable.Rows)
                    {

                        
                            Equipedematch eq = new Equipedematch(Convert.ToInt64(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString());

                            liste_equipe.Add(eq);
                           
                            j++;
                    }
                    cnn.Close();



                }
                catch (Exception ex)
                {

                }


            }

        }
    }
}

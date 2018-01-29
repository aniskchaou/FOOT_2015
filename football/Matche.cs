using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Documents;

namespace football
{
    class Matche
    {
        private int NumMat;
        private DateTime DateMat;
        private String URLvideoMat;
        private String Stade;
        public Matche(int numMat, DateTime dateMat, String uRLvideoMat, String stade)
        {
            
            NumMat = numMat;
            DateMat = dateMat;
            URLvideoMat = uRLvideoMat;
            Stade = stade;
        }
        public Matche()
        {

         
        }
        public int getNumMat()
        {
            return NumMat;
        }
        public void setNumMat(int numMat)
        {
            NumMat = numMat;
        }
        public DateTime getDateMat()
        {
            return DateMat;
        }
        public void setDateMat(DateTime dateMat)
        {
            DateMat = dateMat;
        }
        public String getURLvideoMat()
        {
            return URLvideoMat;
        }
        public void setURLvideoMat(String uRLvideoMat)
        {
            URLvideoMat = uRLvideoMat;
        }
        public String getStade()
        {
            return Stade;
        }
        public void setStade(String stade)
        {
            Stade = stade;
        }
        public DataTable afficher()
        {
            SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=D:\\football\\football\\football.mdf;Integrated Security=True");
            {
                                                

                string nb = null;

                cnn.Open();
                DataSet ds = new DataSet();
                string requete = "select * from [dbo].[MATCHE]";

                try
                {
                    SqlCommand command = new SqlCommand(requete, cnn);
                    SqlDataAdapter Adapter = new SqlDataAdapter(command);
                    Adapter.Fill(ds);
                    DataTable Matable = ds.Tables[0];

                    /*  List<Matche> tabMatche = new List<Matche>();


                      foreach (System.Data.DataRow row in Matable.Rows)
                      {
                          tabMatche.Add(new Matche()
                          {
                              NumMat = int.Parse("" + row[0]),
                              DateMat = DateTime.Parse("" + row[1]),
                              URLvideoMat = "" + row[2],
                              Stade = "" + row[3]
                          });

                      }*/

                    cnn.Close();


                    return Matable;
                }
                catch (Exception ex)
                {
                    return null;
                }


            }

        }
       
        public void ajouter()
        {
            SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\football\\football\\football.mdf;Integrated Security=True");
            {
                try
                {
                    cnn.Open();
                    string requete = "INSERT INTO [dbo].[MATCHE] ([DATEMAT], [URLVIDEOMAT], [STADE]) VALUES ('"+DateMat+"','"+URLvideoMat+"','"+Stade+"')";
                    SqlCommand command = new SqlCommand(requete, cnn);
                    command.ExecuteNonQuery();

                    cnn.Close();

                }
                catch (Exception ex)
                {

                }



            }
        }



     
    }
}

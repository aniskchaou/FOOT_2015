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
    public class Joueur
    {

       public  List<Joueur> liste_de_joueurs = new List<Joueur>();
        private long idJoueur;
        private long idEquipe;
        private int numJo;
        private String nom;
        private String prenom;
        private string photo;
        private int coeff;
        private int age;
        private int taille;
        private int poids;
        private String post;
      
        public Joueur(long idJoueur, long idEquipe, int numJo, String nom,
             String prenom, string photo, int coeff, int age, int taille, int poids,
             String post)
        {
            this.idJoueur = idJoueur;
            this.idEquipe = idEquipe;
            this.numJo = numJo;
            this.nom = nom;
            this.prenom = prenom;
            this.photo = photo;
            this.coeff = coeff;
            this.age = age;
            this.taille = taille;
            this.poids = poids;
            this.post = post;
        }

      public   void liste_de_joueur()
        {
            SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=D:\\football\\football\\football.mdf;Integrated Security=True");
            {


                string nb = null;

                cnn.Open();
                DataSet ds = new DataSet();
                string requete = "select * from [dbo].[JOUEUR]";

                try
                {
                    SqlCommand command = new SqlCommand(requete, cnn);
                    SqlDataAdapter Adapter = new SqlDataAdapter(command);
                    Adapter.Fill(ds);
                    DataTable Matable = ds.Tables[0];


                    int i = 0;

                      foreach (System.Data.DataRow row in Matable.Rows)
                      {

                          Joueur j = new Joueur(Convert.ToInt64(row[0]), Convert.ToInt64(row[1]),
                              Convert.ToInt32(row[2]), row[3].ToString(),
                              row[4].ToString(), row[5].ToString(), Convert.ToInt32(row[6]),
                              Convert.ToInt32(row[7]), Convert.ToInt32(row[8]),
                              Convert.ToInt32(row[9]), row[10].ToString());
                          liste_de_joueurs.Add(j);
                          
                          i++;
                      }
                    cnn.Close();


                   
                }
                catch (Exception ex)
                {
                    
                }


            }

        }
        public Joueur()
        {

        }

    

        public long getIdJoueur()
        {
            return idJoueur;
        }

        public void setIdJoueur(long idJoueur)
        {
            this.idJoueur = idJoueur;
        }

        public long getIdEquipe()
        {
            return idEquipe;
        }

        public void setIdEquipe(long idEquipe)
        {
            this.idEquipe = idEquipe;
        }

        public int getNumJo()
        {
            return numJo;
        }

        public void setNumJo(int numJo)
        {
            this.numJo = numJo;
        }

        public String getNom()
        {
            return nom;
        }

        public void setNom(String nom)
        {
            this.nom = nom;
        }

        public String getPrenom()
        {
            return prenom;
        }

        public void setPrenom(String prenom)
        {
            this.prenom = prenom;
        }

        public string getPhoto()
        {
            return photo;
        }

        public void setPhoto(string photo)
        {
            this.photo = photo;
        }

        public int getCoeff()
        {
            return coeff;
        }

        public void setCoeff(int coeff)
        {
            this.coeff = coeff;
        }

        public int getAge()
        {
            return age;
        }

        public void setAge(int age)
        {
            this.age = age;
        }

        public int getTaille()
        {
            return taille;
        }

        public void setTaille(int taille)
        {
            this.taille = taille;
        }

        public int getPoids()
        {
            return poids;
        }

        public void setPoids(int poids)
        {
            this.poids = poids;
        }

        public String getPost()
        {
            return post;
        }

        public void setPost(String post)
        {
            this.post = post;
        }
   
   

    }
    
    
    
    }


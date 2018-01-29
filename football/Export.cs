using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace football
{
    class Export
    {
      
    public  string pathStringsmil;
    public    string filename;
    public string equipe1,equipe2;
   public int  framenum=0;

       public int get_id_equipe(string equipe)
       { int j = 0;
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


                    

                    foreach (System.Data.DataRow row in Matable.Rows)
                    {
                        if (row[1].ToString() == equipe)
                        {
                            Console.WriteLine(row[1]);
                            j = Convert.ToInt32(row[0]);
                        }
                    }
                    cnn.Close();



                }
                catch (Exception ex)
                {

                }


            }
           return j;
            }


       







        public void afficher_joueur()
        {
            Joueur j = new Joueur();
            long idjoueur, idequipe;
            int numjoueur, age, taille, coef, poids;
            string nom, prenom, photo, post;
            j.liste_de_joueur();
          for (int i = 0; i < j.liste_de_joueurs.Count; i++)
            {
             //Console.WriteLine(j.liste_de_joueurs[i].getNumJo());
             if (j.liste_de_joueurs[i].getNumJo() == get_id_equipe(equipe1))
                {
                
                idjoueur = j.liste_de_joueurs[i].getIdJoueur();
                idequipe = j.liste_de_joueurs[i].getIdEquipe();
                numjoueur = j.liste_de_joueurs[i].getNumJo();
                age = j.liste_de_joueurs[i].getAge();
                taille = j.liste_de_joueurs[i].getTaille();
                coef = j.liste_de_joueurs[i].getCoeff();
                poids = j.liste_de_joueurs[i].getPoids();
                nom = j.liste_de_joueurs[i].getNom();
                prenom = j.liste_de_joueurs[i].getPrenom();
                photo = j.liste_de_joueurs[i].getPhoto();
                post = j.liste_de_joueurs[i].getPost();

               ecrire_nom_joueur(nom,post);
                
                }
             else if (j.liste_de_joueurs[i].getNumJo() == get_id_equipe(equipe2))
                {

                idjoueur = j.liste_de_joueurs[i].getIdJoueur();
                idequipe = j.liste_de_joueurs[i].getIdEquipe();
                numjoueur = j.liste_de_joueurs[i].getNumJo();
                age = j.liste_de_joueurs[i].getAge();
                taille = j.liste_de_joueurs[i].getTaille();
                coef = j.liste_de_joueurs[i].getCoeff();
                poids = j.liste_de_joueurs[i].getPoids();
                nom = j.liste_de_joueurs[i].getNom();
                prenom = j.liste_de_joueurs[i].getPrenom();
                photo = j.liste_de_joueurs[i].getPhoto();
                post = j.liste_de_joueurs[i].getPost();

               ecrire_nom_joueur2(nom,post);
                }
            }
           
        }

        
        public string afficher_information_matche()
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

                    */
                    int NumMat;
                    DateTime DateMat;
                    string Stade, URLvideoMat, Competition, Arbitre;
                    foreach (System.Data.DataRow row in Matable.Rows)
                    {

                        NumMat = int.Parse("" + row[0]);
                        DateMat = DateTime.Parse("" + row[1]);
                        URLvideoMat =row[2].ToString();
                        Stade = row[3].ToString();
                        Competition = row[4].ToString();
                        Arbitre = row[5].ToString();

                        MessageBox.Show(Arbitre);
                        
                        ecrire_information(DateMat.ToString(),"date.txt");
                        ecrire_information(Stade, "stade.txt");
                        ecrire_information(Competition, "competition.txt");
                        ecrire_information(Arbitre, "arbitre.txt");

                    }

                    cnn.Close();


                    

                }
                catch (Exception ex)
                {

                }


            }
            string strr;

            strr="</seq>"+
            "<text  src='arbitre.txt' region='rarbitre'  dur='indefinite'/>" +
            "<text fontSize='16' src='competition.txt' region='rcompetition' dur='indefinite'/>" +
            "<text fontSize='16' src='date.txt' region='rdate' dur='indefinite'/>" +
            "<text fontSize='16' src='stade.txt' region='rstade' dur='indefinite'/>"+
            "<text fontSize='16' src='titre.txt' region='rtitre' dur='indefinite'/>"+
            "<img  fontSize='16' region='rnext'   src='frame9.png'   >"+
            "<area href='#id2'  />"+
            "</img></par>" ;

            return strr;

        }
        public int get_image_frame()
        {
            int numberimage=0;
            SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=D:\\football\\football\\football.mdf;Integrated Security=True");
            {


                string nb = null;

                cnn.Open();
                DataSet ds = new DataSet();
                string requete = "select * from [dbo].[BUT]";
               
                try
                {
                    SqlCommand command = new SqlCommand(requete, cnn);
                    SqlDataAdapter Adapter = new SqlDataAdapter(command);
                    Adapter.Fill(ds);
                    DataTable Matable = ds.Tables[0];

                    /*  List<Matche> tabMatche = new List<Matche>();

                    */
                    
                    foreach (System.Data.DataRow row in Matable.Rows)
                    {
                        numberimage = Convert.ToInt16(row[5]);
                        
                    }
                    
                    cnn.Close();

                    return numberimage;

                }
                catch (Exception ex)
                {
                    return 0;
                }
              
            }

        }
        public void ecrire_information(string param,string file)
        {
            if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, file)))
            {
                File.Create(@"d:\projet_football\" + file).Dispose();
                using (StreamWriter sr = new StreamWriter(@"d:\projet_football\" + file, true))
                {
                    sr.WriteLine(param);

                }
            }
        }
        public void afficher_equipe()
        {
            Equipedematch eq = new Equipedematch();
            eq.get_equipe();
            long idequipe;
            string nom, logo, pays;
            
            for (int i=0;i<eq.liste_equipe.Count;i++)
            {
                idequipe = eq.liste_equipe[i].getIdEquipe();
                nom = eq.liste_equipe[i].getNom();
                logo = eq.liste_equipe[i].getLogo();
                pays = eq.liste_equipe[i].getPays();

                if(nom==MainWindow.equipe1||nom==MainWindow.equipe2)
                {
                    ecrire_nom_equipe(MainWindow.equipe1, MainWindow.equipe2);
                }
                 
            }
            
           
        }
         public void ecrire_nom_equipe(string eq1,string eq2)
         {
             
             if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "titre.txt")))
             {
                 
                 File.Create(@"d:\projet_football\titre.txt").Dispose();
                 using (StreamWriter sr = new StreamWriter(@"d:\projet_football\titre.txt", true))
                 {
                     sr.WriteLine(eq1+"  vs  "+eq2);

                 }
             }

         }
        public void ecrire_nom_joueur(string nom,string post)
        {
 	       switch(post)
           {
               case "attaquant1":
                   
                   
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "attaquant1.txt")))
                   {
                       File.Create(@"d:\projet_football\attaquant1.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\attaquant1.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;

               case  "attaquant2":

                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "attaquant2.txt")))
                   {
                       File.Create(@"d:\projet_football\attaquant2.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\attaquant2.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;

               case "libero1":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "libero1.txt")))
                   {
                       File.Create(@"d:\projet_football\libero1.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\football_project\libero1.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }
                   break;
               case  "libero2":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "libero2.txt")))
                   {
                       File.Create(@"d:\projet_football\libero2.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\libero2.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
               case  "mdeffensif1":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "mdeffensif1.txt")))
                   {
                       File.Create(@"d:\projet_football\mdeffensif1.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\mdeffensif1.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
                case  "mdeffensif2":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "mdeffensif2.txt")))
                   {
                       File.Create(@"d:\projet_football\mdeffensif2.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\mdeffensif2.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
                  case  "moffensif2":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "moffensif2.txt")))
                   {
                       File.Create(@"d:\projet_football\moffensif2.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\moffensif2.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;

                   case  "moffensif1":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "moffensif1.txt")))
                   {
                       File.Create(@"d:\projet_football\moffensif1.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\moffensif1.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
                  case  "gardien":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "gardien.txt")))
                   {
                       File.Create(@"d:\projet_football\gardien.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\gardien.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
                 case  "ardroit":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "ardroit.txt")))
                   {
                       File.Create(@"d:\projet_football\ardroit.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\ardroit.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;

                   case  "argauche":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "argauche.txt")))
                   {
                       File.Create(@"d:\projet_football\argauche.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\argauche.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;


           }
        }
          public void ecrire_nom_joueur2(string nom,string post)
        {
 	       switch(post)
           {
               case "attaquant1":
                   
                   
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2attaquant1.txt")))
                   {
                       File.Create(@"d:\projet_football\2attaquant1.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2attaquant1.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;

               case  "attaquant2":

                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2attaquant2.txt")))
                   {
                       File.Create(@"d:\projet_football\2attaquant2.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2attaquant2.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;

               case "libero1":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2libero1.txt")))
                   {
                       File.Create(@"d:\projet_football\2libero1.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2libero1.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }
                   break;
               case  "libero2":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2libero2.txt")))
                   {
                       File.Create(@"d:\projet_football\2libero2.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2libero2.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
               case  "moffensif1":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2moffensif1.txt")))
                   {
                       File.Create(@"d:\projet_football\2moffensif1.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2moffensif1.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
                case  "moffensif2":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2moffensif2.txt")))
                   {
                       File.Create(@"d:\projet_football\2moffensif2.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2moffensif2.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
                  case  "mdeffensif1":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2mdeffensif1.txt")))
                   {
                       File.Create(@"d:\projet_football\2mdeffensif1.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2mdeffensif1.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;

                   case  "mdeffensif2":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2mdeffensif2.txt")))
                   {
                       File.Create(@"d:\projet_football\2mdeffensif2.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2mdeffensif2.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
                  case  "gardien":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2gardien.txt")))
                   {
                       File.Create(@"d:\projet_football\2gardien.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2gardien.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;
                 case  "ardroit":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2ardroit.txt")))
                   {
                       File.Create(@"d:\projet_football\2ardroit.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2ardroit.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;

                   case  "argauche":
                   if (!System.IO.File.Exists(System.IO.Path.Combine(pathStringsmil, "2argauche.txt")))
                   {
                       File.Create(@"d:\projet_football\2argauche.txt").Dispose();
                       using (StreamWriter sr = new StreamWriter(@"d:\projet_football\2argauche.txt", true))
                       {
                           sr.WriteLine(nom);

                       }
                   }

                   break;


           }
        }




          public void exportation()
          {
              equipe1 = MainWindow.equipe1;
              equipe2 = MainWindow.equipe2;
           
            
             afficher_equipe();

              afficher_joueur();
                  
              // Use Combine again to add the file name to the path.
              string pathstring = System.IO.Path.Combine(pathStringsmil, filename);

              

              if (!System.IO.File.Exists(pathstring))
              {
                  
                  string str, str5 = "</body></smil>";
                  string strr = "<smil><head><layout>";

                  string str2 = "<region fit='fill' id='rvideo' width='300' height='300' top='10' left='10'/>" +
                          "<region fit='fill' id='rtemps' width='150' height='20' top='50' left='320'/>" +
                          "<region fit='fill' id='rarbitre' width='150' height='300' top='100' left='320'/>" +
                          "<region fit='fill' id='rcompetition' width='150' height='300' top='150' left='320'/>" +
                          "<region fit='fill' id='rdate' width='150' height='300' top='200' left='320'/>" +
                          "<region fit='fill' id='rstade' width='150' height='300' top='250' left='320'/>" +
                          "<region fit='fill' zindex='3' id='rnext' width='90' height='20' top='380' left='300'/>" +

                          "<region fit='fill' id='rattaquant1' width='90' height='20' top='100' left='40%'/>" +
                          "<region fit='fill' id='rattaquant2' width='90' height='20' top='100' left='60%'/>" +

                          "<region fit='fill' id='rmilieuoffensifgauche' width='90' height='20' top='200' left='25%'/>" +
                          "<region fit='fill' id='rmilieudeffensif1' width='90' height='20' top='200' left='50%'/>" +
                          "<region fit='fill' id='rmilieudeffensif2' width='90' height='20' top='200' left='75%'/>" +
                          "<region fit='fill' id='rmilieuoffensifdroit' width='90' height='20' top='200' left='90%'/>" +
                          "<region fit='fill' id='rargauche' width='90' height='20' top='280' left='25%'/>" +
                          "<region fit='fill' id='rlibero1' width='90' height='20' top='280' left='50%'/>" +
                          "<region fit='fill' id='rlibero2' width='90' height='20' top='280' left='75%'/>" +
                          "<region fit='fill' id='rardroite' width='90' height='20' top='280' left='90%'/>" +
                         "<region fit='fill' id='rgardien' width='70' height='20' top='350' left='50%'/>" +
                         "<region fit='fill' id='rtitre' width='200' height='20' top='450' left='30%'/>" +
                        "</layout></head><body><par><seq>";



                  string str3 = "", str4 = "",str6="";
                      str6 = afficher_information_matche();

                 framenum = get_image_frame();
                  MessageBox.Show(framenum.ToString());
                  int nbreframe = 3;
                  int maxframe = nbreframe + framenum;
                  int minframe = framenum - nbreframe;
                  
                 

                  for (int j = minframe; j < framenum; j++)
                  {
                      str4 += "<img dur='0.04s' src='frame" + j + ".png' region='rvideo'/>";
                  }

                  for (int i = framenum; i <= maxframe; i++)
                  {
                      str3 += "<img dur='0.04s' src='frame" + i + ".png' region='rvideo'/>";
                  }

                  string str7 = "<par id='id2'>" +

                      "<text src='gardien.txt' region='rgardien' dur='indefinite'/>" +
                      "<text src='argauche.txt' region='rargauche' dur='indefinite'/>" +
                      "<text src='libero1.txt' region='rlibero1' dur='indefinite'/>" +
                      "<text src='libero2.txt' region='rlibero2' dur='indefinite'/>" +

                      "<text src='ardroit.txt' region='rardroite' dur='indefinite'/>" +

                      "<text src='mdeffensif1.txt' region='rmilieuoffensifgauche' dur='indefinite' style='font-size:16px;'/>" +
                      "<text src='mdeffensif2.txt' region='rmilieudeffensif1' dur='indefinite' style='font-size:16px;' />" +
                      "<text src='moffessif1.txt' region='rmilieudeffensif2' dur='indefinite' style='font-size:16px;'  />" +
                      "<text src='moffensif2.txt' region='rmilieuoffensifdroit' dur='indefinite' style='font-size:16px;' />" +

                      "<text src='attaquant1.txt' region='rattaquant1' dur='indefinite'/>" +
                      "<text src='attaquant2.txt' region='rattaquant2' dur='indefinite'/>" +

                      "<img  data='aa' region='rnext'   src='frame3.png'  dur='indefinite'  >" +

                      "<area href='#id3'  /></img></par> ";


                  string str8 = "<par id='id3'>" +
                      "<text src='2gardien.txt' region='rgardien' dur='indefinite'/>" +
                      "<text src='2argauche.txt' region='rargauche' dur='indefinite'/>" +
                      "<text src='2libero1.txt' region='rlibero1' dur='indefinite'/>" +
                      "<text src='2libero2.txt' region='rlibero2' dur='indefinite'/>" +

                      "<text src='ardroit.txt' region='rardroite' dur='indefinite'/>" +

                      "<text src='2moffensif1.txt' region='rmilieuoffensifgauche' dur='indefinite'/>" +
                      "<text src='2mdeffensif1.txt' region='rmilieudeffensif1' dur='indefinite'/>" +
                      "<text src='2mdeffensif2.txt' region='rmilieudeffensif2' dur='indefinite'/>" +
                      "<text src='2moffensif2.txt' region='rmilieuoffensifdroit' dur='indefinite'/>" +
                      "<text src='2attaquant1.txt' region='rattaquant1' dur='indefinite'/>" +
                      "<text src='2attaquant2.txt' region='rattaquant2' dur='indefinite'/></par>";


                  str3 += "<img  src='frame" + (maxframe + 1) + ".png' dur='indefinite' region='rvideo'/>";
                  str = strr + str2 + str4 + str3 + str6 +str7+str8+ str5;

                  
                  string extension = System.IO.Path.GetExtension(pathstring);
                  filename = System.IO.Path.ChangeExtension(pathstring, ".smil");
                   File.WriteAllText(filename, str);
                  

              }

          }
       //System.Drawing.Image InputImg = System.Drawing.Image.FromFile(@"C:\Hydrangeas.jpg");
       //Image<Bgr, byte> ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
            
       //mediaElement1.Source = VCapture;



        public string pathString { get; set; }
    }
    }


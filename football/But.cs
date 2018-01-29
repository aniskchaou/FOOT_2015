using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football
{
    class But
    {


        private long idBut;
        private DateTime taim;
        private String urlVideo;
        private Object imageBut;
        private int idJoueur;
        private int idEquipe;
        public But(long idBut, DateTime taim, String urlVideo, Object imageBut,
                int idJoueur, int idEquipe)
        {

            this.idBut = idBut;
            this.taim = taim;
            this.urlVideo = urlVideo;
            this.imageBut = imageBut;
            this.idJoueur = idJoueur;
            this.idEquipe = idEquipe;
        }
        public But()
        {

        }
        public long getIdBut()
        {
            return idBut;
        }
        public void setIdBut(long idBut)
        {
            this.idBut = idBut;
        }
        public DateTime getTaim()
        {
            return taim;
        }
        public void setTaim(DateTime taim)
        {
            this.taim = taim;
        }
        public String getUrlVideo()
        {
            return urlVideo;
        }
        public void setUrlVideo(String urlVideo)
        {
            this.urlVideo = urlVideo;
        }
        public Object getImageBut()
        {
            return imageBut;
        }
        public void setImageBut(Object imageBut)
        {
            this.imageBut = imageBut;
        }
        public int getIdJoueur()
        {
            return idJoueur;
        }
        public void setIdJoueur(int idJoueur)
        {
            this.idJoueur = idJoueur;
        }
        public int getIdEquipe()
        {
            return idEquipe;
        }
        public void setIdEquipe(int idEquipe)
        {
            this.idEquipe = idEquipe;
        }

    }

}

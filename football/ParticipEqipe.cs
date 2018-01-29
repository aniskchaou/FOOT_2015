using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football
{
    public class ParticipEqipe
    {
        private char partie;
        private int idEquipe;
        private int numMat;
        private int IdMit;
        public ParticipEqipe(char partie, int idEquipe, int numMat, int idMit)
        {
            this.partie = partie;
            this.idEquipe = idEquipe;
            this.numMat = numMat;
            IdMit = idMit;
        }
        public ParticipEqipe()
        {
        }
        public char getPartie()
        {
            return partie;
        }
        public void setPartie(char partie)
        {
            this.partie = partie;
        }
        public int getIdEquipe()
        {
            return idEquipe;
        }
        public void setIdEquipe(int idEquipe)
        {
            this.idEquipe = idEquipe;
        }
        public int getNumMat()
        {
            return numMat;
        }
        public void setNumMat(int numMat)
        {
            this.numMat = numMat;
        }
        public int getIdMit()
        {
            return IdMit;
        }
        public void setIdMit(int idMit)
        {
            IdMit = idMit;
        }

    }
}

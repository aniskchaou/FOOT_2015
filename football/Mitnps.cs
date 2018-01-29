using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace football
{
    public class Mitnps
    {
        private long Idmit;
        private DateTime Tempsprdu;
        private String Hibele;
        public Mitnps(long idmit, DateTime tempsprdu, String hibele)
        {
            Idmit = idmit;
            Tempsprdu = tempsprdu;
            Hibele = hibele;
        }
        public Mitnps()
        {
        }
        public long getIdmit()
        {
            return Idmit;
        }
        public void setIdmit(long idmit)
        {
            Idmit = idmit;
        }
        public DateTime getTempsprdu()
        {
            return Tempsprdu;
        }
        public void setTempsprdu(DateTime tempsprdu)
        {
            Tempsprdu = tempsprdu;
        }
        public String getHibele()
        {
            return Hibele;
        }
        public void setHibele(String hibele)
        {
            Hibele = hibele;
        }


    }
}

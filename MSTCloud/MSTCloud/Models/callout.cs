using System;

namespace MSTCloud.Models
{
    public class callout
    {
        public int division { get; set; }
        public int location { get; set; }
        public int shiftarea { get; set; }
        public string shiftareadesc { get; set; }
        public DateTime auditdatetime { get; set; }
        public int assocnbr { get; set; }
        public string assocname { get; set; }
        public DateTime shiftstart { get; set; }
        public DateTime shiftend { get; set; }
        public string errorcode { get; set; }

        public callout()
        {

        }
        public callout(int div, int loc, int sa, string sad, DateTime adt, int anum, string aname, DateTime ss, DateTime se)
        {
            this.division = div;
            this.location = loc;
            this.shiftarea = sa;
            this.shiftareadesc = sad;
            this.auditdatetime = adt;
            this.assocnbr = anum;
            this.assocname = aname;
            this.shiftstart = ss;
            this.shiftend = se;
        }
    }
}
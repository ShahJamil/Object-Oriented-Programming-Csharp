using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdwcrzSatisFinal
{
    internal class Parliament
    {
        public class MissingMemberException : Exception { }
        public List<Congressman> cmen;
        public List<DraftLaw> laws;

        public Parliament(List<Congressman> cm)
        {
            cmen = new List<Congressman>();
            laws = new List<DraftLaw>();

            foreach (var c in cm)
            {
                c.parliament = this;
                if (!cmen.Contains(c))
                {
                    cmen.Add(c);
                }
            }

        }

        public void Submit(DraftLaw d)
        {
            bool l = false;
            int n = 0;
            while (!l && n < laws.Count)
            {
                l = laws[n].ID == d.ID;
                n++;
            }
            if (l)
            {
                throw new MissingMemberException();
            }
            laws.Add(d);
            d.parliament = this;

        }
        public void Vote(Congressman cm, bool b, String ID)
        {
            bool l = false;
            DraftLaw elem = null;

            foreach (var t in laws)
            {
                l = t.ID == ID;
                elem = t;
            }
            if (!l)
            {
                throw new MissingFieldException();
            }
            foreach (var member in elem.cmen)
            {
                if (member == cm)
                {
                    throw new ArgumentException();
                }
            }
            elem.cmen.Add(cm);
            elem.votes.Add(b);
        }

        public List<string> ValidLaws()
        {
            List<string> validLaws = new List<string>();
            foreach (var t in laws)
            {
                if (t.isValid())
                {
                    validLaws.Add(t.ID);
                }
            }
            return validLaws;
        }
    }
}

using cdwcrzSatisFinal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdwcrzSatisFinal
{
    abstract class DraftLaw
    {
        public string date;
        public string ID;
        public List<bool> votes;
        public Parliament parliament;
        public List<Congressman> cmen;
        protected DraftLaw(string d, string ID)
        {
            votes = new List<bool>();
            cmen = new List<Congressman>();
            this.date = d;
            this.ID = ID;
        }

        protected int YesCount()
        {
            int count = 0;
            foreach (var item in votes)
            {
                if (item)
                {
                    count++;
                }
            }
            return count;
        }
        public abstract bool isValid();
    }

    class Normal : DraftLaw
    {
        public Normal(string d, string ID) : base(d, ID) { }

        public override bool isValid()
        {
            return YesCount() * 2 > votes.Count;
        }
    }
    class Cardinal : DraftLaw
    {
        public Cardinal(string d, string ID) : base(d, ID) { }

        public override bool isValid()
        {
            if (this.parliament == null)
            {
                return false;
            }
            return YesCount() * 2 > parliament.cmen.Count;
        }
    }

    class Constitutional : DraftLaw
    {
        public Constitutional(string d, string ID) : base(d, ID) { }

        public override bool isValid()
        {
            if (this.parliament == null || parliament.cmen.Count == 0)
            {
                return false;
            }
            return YesCount() * 3 >= parliament.cmen.Count * 2;
        }
    }
}

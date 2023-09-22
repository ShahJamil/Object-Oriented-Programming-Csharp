using cdwcrzSatisFinal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdwcrzSatisFinal
{
    internal class Congressman
    {
        public string name;
        public Parliament parliament;
        public Congressman(string n)
        {
            this.name = n;
        }
        public void Vote(bool vote, string ID)
        {
            if (parliament == null)
            {
                throw new ArgumentNullException();
            }
            parliament.Vote(this, vote, ID);
        }
    }
}

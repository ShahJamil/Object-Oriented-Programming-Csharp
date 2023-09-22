using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCDWCRZ
{
    public abstract class Pets
    {
        public string Name;
        protected int exhilaration;

        public int getEx()
        {
            return this.exhilaration;
        }
        public void modifyEx(int e)
        {
            exhilaration += e;
            if (exhilaration < 0)
            {
                exhilaration = 0;
            }
        }
        public bool Alive() { return exhilaration > 0; }

        public bool Factor()
        {
            bool cond = this.getEx() > 5;
            return cond;
        }
        public Pets(string str, int e)
        {
            Name = str;
            if (e <= 0 || e > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            exhilaration = e;
        }


        public void ChangeMood(IMood mood)
        {
            if (Alive())
            {
                Traverse(mood);
            }

        }
        public abstract IMood Traverse(IMood mood);

    }

    public class Dog : Pets
    {
        public Dog(string str, int e) : base(str, e)
        {
            Name = str;
            if (e <= 0 || e > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            exhilaration = e;
        }


        public override IMood Traverse(IMood mood)
        {
            return mood.ChangeD(this);
        }
    }
    public class Bird : Pets
    {
        public Bird(string str, int e) : base(str, e)
        {
            Name = str;
            if (e <= 0 || e > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            exhilaration = e;
        }
        public override IMood Traverse(IMood mood)
        {
            return mood.ChangeB(this);
        }
    }

    public class Fish : Pets
    {
        public Fish(string str, int e) : base(str, e)
        {
            Name = str;
            if (e <= 0 || e > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            exhilaration = e;
        }
        public override IMood Traverse(IMood mood)
        {
            return mood.ChangeF(this);
        }
    }
}

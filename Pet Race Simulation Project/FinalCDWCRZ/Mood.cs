using FinalCDWCRZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCDWCRZ
{

    public interface IMood
    {
        IMood ChangeD(Dog p);
        IMood ChangeF(Fish p);
        IMood ChangeB(Bird p);

    }
    public class Good : IMood
    {
        public IMood ChangeD(Dog p)
        {
            p.modifyEx(3);
            return this;
        }
        public IMood ChangeF(Fish p)
        {
            p.modifyEx(1);
            return this;
        }
        public IMood ChangeB(Bird p)
        {
            p.modifyEx(2);
            return this;
        }



        private Good() { }

        private static Good instance = null;

        public static Good Instance()
        {
            if (instance == null)
            {
                instance = new Good();
            }
            return instance;
        }
    }

    public class Ordinary : IMood
    {
        public IMood ChangeD(Dog p)
        {
            p.modifyEx(0);
            return this;
        }
        public IMood ChangeF(Fish p)
        {
            p.modifyEx(-3);
            return this;
        }
        public IMood ChangeB(Bird p)
        {
            p.modifyEx(-1);
            return this;
        }


        private Ordinary() { }

        private static Ordinary instance = null;

        public static Ordinary Instance()
        {
            if (instance == null)
            {
                instance = new Ordinary();
            }
            return instance;
        }
    }

    public class Bad : IMood
    {
        public IMood ChangeD(Dog p)
        {
            p.modifyEx(-10);
            return this;

        }
        public IMood ChangeF(Fish p)
        {
            p.modifyEx(-5);
            return this;
        }
        public IMood ChangeB(Bird p)
        {
            p.modifyEx(-3);
            return this;
        }



        private Bad() { }

        private static Bad instance = null;

        public static Bad Instance()
        {
            if (instance == null)
            {
                instance = new Bad();
            }
            return instance;
        }
    }

}

using FinalCDWCRZ;

namespace TestPets
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Create()
        {
            List<Pets> zero = new List<Pets>();

            List<Pets> onePet = new List<Pets>();
            onePet.Add(new Dog("Leon", 77));


            List<Pets> myPets = new List<Pets>();
            myPets.Add(new Dog("Walter", 100));
            myPets.Add(new Fish("Nemo", 20));
            myPets.Add(new Bird("Soap", 10));

            char[] myMoods = "ooobbgbb".ToCharArray();
            List<IMood> moods = new List<IMood>();

            foreach (char ch in myMoods)
            {
                switch (ch)
                {
                    case 'g': moods.Add(Good.Instance()); break;
                    case 'o': moods.Add(Ordinary.Instance()); break;
                    case 'b': moods.Add(Bad.Instance()); break;
                }
            }

            bool result = true;
            for (int i = 0; i < moods.Count; i++)
            {

                for (int j = 0; j < myPets.Count; j++)
                {
                    myPets[j].ChangeMood(moods[i]);
                    result = myPets[j].Factor();
                }
                if (result)
                {
                    switch (myMoods[i])
                    {
                        case 'o': moods[i] = Good.Instance(); break;
                        case 'b': moods[i] = Ordinary.Instance(); break;
                    }
                }
                result = false;
            }
            Assert.IsTrue(myPets[0].Alive());
            Assert.AreEqual(false, myPets[2].Alive());
            Assert.AreEqual(Good.Instance(), moods[0]);
            Assert.AreEqual(Bad.Instance(), moods[7]);


        }
        [TestMethod]
        public void SinglePet()
        {
            List<Pets> justDog = new List<Pets>();
            justDog.Add(new Dog("Timothy", 50));

            List<IMood> noMood = new List<IMood>();
            List<IMood> oneMood = new List<IMood>();

            char[] myMoods = "o".ToCharArray();

            foreach (char ch in myMoods)
            {
                switch (ch)
                {
                    case 'g': oneMood.Add(Good.Instance()); break;
                    case 'o': oneMood.Add(Ordinary.Instance()); break;
                    case 'b': oneMood.Add(Bad.Instance()); break;
                }
            }

            for (int i = 0; i < oneMood.Count; i++)
            {
                for (int j = 0; j < justDog.Count; j++)
                {
                    if (justDog[j].Alive())
                    {
                        justDog[j].ChangeMood(oneMood[i]);
                    }
                }
            }

            List<IMood> moreMoods = new List<IMood>();
            List<Pets> justBird = new List<Pets>();
            justBird.Add(new Bird("Rick", 50));

            char[] moodList = "ooggobg".ToCharArray();

            foreach (char ch in moodList)
            {
                switch (ch)
                {
                    case 'g': moreMoods.Add(Good.Instance()); break;
                    case 'o': moreMoods.Add(Ordinary.Instance()); break;
                    case 'b': moreMoods.Add(Bad.Instance()); break;
                }
            }

            for (int i = 0; i < moreMoods.Count; i++)
            {
                for (int j = 0; j < justBird.Count; j++)
                {
                    if (justBird[j].Alive())
                    {
                        justBird[j].ChangeMood(moreMoods[i]);
                    }
                }
            }
            Assert.IsTrue(justBird[0].Alive());
        }
        [TestMethod]
        public void MinimumVal()
        {
            List<Pets> goodPets = new List<Pets>();
            goodPets.Add(new Dog("Arthur", 40));
            goodPets.Add(new Fish("John", 40));
            goodPets.Add(new Bird("Dutch", 40));
            goodPets.Add(new Dog("Micah", 80));

            char[] myMoods = "ooobbgbb".ToCharArray();
            List<IMood> moods = new List<IMood>();

            foreach (char ch in myMoods)
            {
                switch (ch)
                {
                    case 'g': moods.Add(Good.Instance()); break;
                    case 'o': moods.Add(Ordinary.Instance()); break;
                    case 'b': moods.Add(Bad.Instance()); break;
                }
            }

            for (int i = 0; i < moods.Count; i++)
            {
                for (int j = 0; j < goodPets.Count; j++)
                {
                    if (goodPets[j].Alive())
                    {
                        goodPets[j].ChangeMood(moods[i]);
                    }
                }
            }
            List<Pets> alivePets = new List<Pets>();
            for (int i = 0; i < goodPets.Count; i++)
            {
                if (goodPets[i].Alive())
                {
                    alivePets.Add(goodPets[i]);
                }
            }

            int min = alivePets[0].getEx();
            string val = alivePets[0].Name;
            for (int i = 1; i < alivePets.Count; i++)
            {
                if (min > alivePets[i].getEx())
                {
                    min = alivePets[i].getEx();
                    val = alivePets[i].Name;
                }
            }
            Assert.AreEqual("Arthur", val);
        }

        [TestMethod]
        public void OrdinaryDay()
        {
            List<Pets> goodPets = new List<Pets>();
            goodPets.Add(new Dog("Beta", 40));
            goodPets.Add(new Fish("Alpha", 15));


            char[] myMoods = "ooooooooooooo".ToCharArray();
            List<IMood> moods = new List<IMood>();

            foreach (char ch in myMoods)
            {
                switch (ch)
                {
                    case 'g': moods.Add(Good.Instance()); break;
                    case 'o': moods.Add(Ordinary.Instance()); break;
                    case 'b': moods.Add(Bad.Instance()); break;
                }
            }

            bool result = true;
            for (int i = 0; i < moods.Count; i++)
            {

                for (int j = 0; j < goodPets.Count; j++)
                {
                    goodPets[j].ChangeMood(moods[i]);
                    result = goodPets[j].Factor();
                }
                if (result)
                {
                    switch (myMoods[i])
                    {
                        case 'o': moods[i] = Good.Instance(); break;
                        case 'b': moods[i] = Ordinary.Instance(); break;
                    }
                }
                result = false;
            }

            Assert.IsTrue(goodPets[0].Alive());
            Assert.IsFalse(goodPets[1].Alive());
            Assert.AreEqual(Good.Instance(), moods[0]);
        }

        [TestMethod]
        public void GoodDayMinimum()
        {
            List<Pets> goodPets = new List<Pets>();
            goodPets.Add(new Fish("Beta", 40));
            goodPets.Add(new Fish("Alpha", 15));


            char[] myMoods = "ggggggg".ToCharArray();
            List<IMood> moods = new List<IMood>();

            foreach (char ch in myMoods)
            {
                switch (ch)
                {
                    case 'g': moods.Add(Good.Instance()); break;
                    case 'o': moods.Add(Ordinary.Instance()); break;
                    case 'b': moods.Add(Bad.Instance()); break;
                }
            }

            for (int i = 0; i < moods.Count; i++)
            {
                for (int j = 0; j < goodPets.Count; j++)
                {
                    if (goodPets[j].Alive())
                    {
                        goodPets[j].ChangeMood(moods[i]);
                    }
                }
            }
            List<Pets> alivePets = new List<Pets>();
            for (int i = 0; i < goodPets.Count; i++)
            {
                if (goodPets[i].Alive())
                {
                    alivePets.Add(goodPets[i]);
                }
            }

            int min = alivePets[0].getEx();
            string val = alivePets[0].Name;
            for (int i = 1; i < alivePets.Count; i++)
            {
                if (min > alivePets[i].getEx())
                {
                    min = alivePets[i].getEx();
                    val = alivePets[i].Name;
                }
            }
            Assert.AreEqual("Alpha", val);
        }
        [TestMethod]
        public void LiterallyWorstDay()
        {


            List<Pets> myPets = new List<Pets>();
            myPets.Add(new Dog("Dog1", 100));
            myPets.Add(new Dog("Dog2", 20));
            myPets.Add(new Dog("Dog3", 7));

            char[] myMoods = "bbbbb".ToCharArray();
            List<IMood> moods = new List<IMood>();

            foreach (char ch in myMoods)
            {
                switch (ch)
                {
                    case 'g': moods.Add(Good.Instance()); break;
                    case 'o': moods.Add(Ordinary.Instance()); break;
                    case 'b': moods.Add(Bad.Instance()); break;
                }
            }

            for (int i = 0; i < moods.Count; i++)
            {
                for (int j = 0; j < myPets.Count; j++)
                {
                    if (myPets[j].Alive())
                    {
                        myPets[j].ChangeMood(moods[i]);
                    }
                }
            }
            Assert.IsTrue(myPets[0].Alive());
            Assert.AreEqual(false, myPets[1].Alive());
            Assert.AreEqual(false, myPets[2].Alive());
        }
        [TestMethod]
        public void testExceptions()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = new Fish("Walter", -5));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _ = new Dog("Walter", -5));
        }

        [TestMethod]
        public void testExhilarations()
        {
            Dog Walt = new Dog("Walt", 10);
            Walt.modifyEx(-20);
            Assert.IsFalse(Walt.Alive());

            Dog Walt2 = new Dog("Walt2", 10);
            Walt2.modifyEx(20);
            Assert.IsTrue(Walt2.Alive());
        }

        [TestMethod]
        public void negativeExhilaration()
        {
            Dog Walt = new Dog("Walt", 10);
            Walt.modifyEx(-20);
            Assert.AreEqual(0, Walt.getEx());

            Dog Walt2 = new Dog("Walt2", 10);
            Walt2.modifyEx(20);
            Assert.AreEqual(30, Walt2.getEx());
        }
    }
}
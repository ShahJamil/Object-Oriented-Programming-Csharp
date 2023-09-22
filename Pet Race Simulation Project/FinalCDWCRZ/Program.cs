using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace FinalCDWCRZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new TextFileReader("inp.txt");
            reader.ReadInt(out int e);
            List<Pets> pets = new List<Pets>();

            try
            {
                for (int i = 0; i < e; i++)
                {
                    Pets pet = null;

                    if (reader.ReadChar(out char ch))
                    {
                        reader.ReadString(out string name);
                        reader.ReadInt(out int Ex);

                        switch (ch)
                        {
                            case 'D': pet = new Dog(name, Ex); break;
                            case 'F': pet = new Fish(name, Ex); break;
                            case 'B': pet = new Bird(name, Ex); break;
                        }

                    }
                    pets.Add(pet);
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("Wrong value for exhilaration level, please change it.");
                return;
            }

            reader.ReadString(out string line);

            char[] moodList = line.ToCharArray();
            List<IMood> moods = new List<IMood>();

            foreach (char ch in moodList)
            {
                switch (ch)
                {
                    case 'g': moods.Add(Good.Instance()); break;
                    case 'o': moods.Add(Ordinary.Instance()); break;
                    case 'b': moods.Add(Bad.Instance()); break;
                }
            }

            List<Pets> alivePets = new List<Pets>();

            

            bool result = true;
            try
            {
                if (pets.Count == 0)
                {
                    throw new Exception();
                }

                for (int i = 0; i < moods.Count; i++)
                {
                    Console.WriteLine($"Round {i + 1}");
                    Console.WriteLine(" ");
                    Pets val = pets[0];
                    int min = pets[0].getEx();
                    for (int k = 1; k < pets.Count; k++)
                    {
                        if (pets[k].getEx() < min && pets[k].Alive())
                        {
                            val = pets[k];
                            min = val.getEx();
                        }
                    }
                    foreach (var pet in pets)
                    {
                        Console.WriteLine($"Pet {pet.Name}");
                        Console.WriteLine($"Exhilaration level {pet.getEx()}");
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine($"Pet with the lowest level of exhilaration which is alive is : {val.Name}");
                    Console.WriteLine(" ");

                    for (int j = 0; j < e; j++)
                    {
                        pets[j].ChangeMood(moods[i]);
                        result = pets[j].Factor();
                        
                    }

                    if (result)
                    {
                        switch (moodList[i])
                        {
                            case 'o': moods[i] = Good.Instance(); break;
                            case 'b': moods[i] = Ordinary.Instance(); break;
                        }
                    }
                    result = false;
                }
                for (int i = 0; i < e; i++)
                {
                    if (pets[i].Alive())
                    {
                        alivePets.Add(pets[i]);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("there are no pets.");
            }
            

            try
            {
                if (alivePets.Count == 0)
                {
                    throw new Exception();
                }
                else if (alivePets.Count == 1)
                {
                    Console.WriteLine($"The pet with the lowest level of exhilaration which is alive is {alivePets[0].Name}");
                }
                int min = alivePets[0].getEx();
                string val = alivePets[0].Name;
                for (int i = 1; i < alivePets.Count; i++)
                {
                    if (min > alivePets[i].getEx() && alivePets[i].Alive())
                    {
                        min = alivePets[i].getEx();
                        val = alivePets[i].Name;
                    }
                }
                Console.WriteLine($"The pet with the lowest level of exhilaration that survived the competition is {val}");

            }
            catch (Exception)
            {
                Console.WriteLine("None of the pets survived the competition.");
            }





        }
    }
}

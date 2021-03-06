﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Second
    {
        //public void GetVoice(Animal animal)
        //{
        //    animal.Voice();
        //   if (animal is IZuk)
        //    {
        //        IZuk zuk = (IZuk)animal;
        //        zuk.Trk();
        //    }
        //}

        public void GetVoiceList(List<Animal> listAnimal)
        {
            foreach (Animal A in listAnimal)
            {
                A.Voice();

                if (A is ISay say)
                {
                    //ISay say = (ISay)A;
                    say.Say();

                }
            }
        }

        List<Animal> ListOfAnimal = new List<Animal>
        {

        };

        public void Execute()
        {
            Animal animal;

            for (int i = 0; i < 5; i++)
            {
                animal = GetAnimal(i);
                ListOfAnimal.Add(animal);
            }
            GetVoiceList(ListOfAnimal);
            Console.WriteLine(" общее количество живности - " + ListOfAnimal.Count);
        }

        //public string GetDogName()
        //{
        //    Random random = new Random(Guid.NewGuid().GetHashCode());
        //    string[] dogsName = new string[] { "Rex", "Rich", "Butcher", "Killer", "ALF" };

        //    int animalDogIndex = random.Next(0, dogsName.Length);
        //    return dogsName[animalDogIndex];

        //}

        //public string GetCatName()
        //{
        //    Random random = new Random(Guid.NewGuid().GetHashCode());
        //    string[] catsName = new string[] { "Lucky", "Barsyk", "Ginger", "Marquis", "Leo" };

        //    int animalCatIndex = random.Next(0, catsName.Length);
        //    return catsName[animalCatIndex];

        //}

        

        private Animal GetAnimal(int i)
        {

            Random random = new Random(Guid.NewGuid().GetHashCode());

            string[] dogsName = Enum.GetNames(typeof(DogsName));
            int animalDogIndex = random.Next(0, dogsName.Length);
            string nameOfDogsAnimal = dogsName[animalDogIndex];

            string[] catsName = Enum.GetNames(typeof(CatsName));
            int animalCatIndex = random.Next(0, catsName.Length);
            string nameOfCatsAnimal = catsName[animalCatIndex];

            Animal animalanimal;

            if (i < 3)
            {
                Dog D = new Dog(nameOfDogsAnimal);
                //D.Gav();
                animalanimal = D;
            }

            else
            {
                Cat C = new Cat(nameOfCatsAnimal);
                animalanimal = C;
            }
            return animalanimal;
        }
    }

    

    class Animal
    {
        public string NameOfAnimal;
        public Animal(string nameAnimal)
        {
            NameOfAnimal = nameAnimal;
        }

        public virtual void Voice()
        {
            Console.WriteLine("Animal don't have voice");
        }
    }

    enum DogsName : int { Rex, Rich, Butcher, Killer, ALF }
    enum CatsName : int { Lucky, Barsyk, Ginger, Marquis, Leo }
    enum DogBreed { Terrier, Hound, Schnauzer, Malamute, Spaniel }
    enum CatBreed { Bengal, Ceylon, Russian, Munchkin, Persian }

    class Dog : Animal, ISay
    {
        public Dog(string nameAnimal) : base(nameAnimal)
        {
            //Random random = new Random(Guid.NewGuid().GetHashCode());
            //foreach (DogBreed i in Enum.GetValues(typeof(DogBreed)))
            //{
            //    string value = i.ToString();
            //    int DogIndex = random.Next(0, value);
            //}

            Random random = new Random(Guid.NewGuid().GetHashCode());
            string[] i = Enum.GetNames(typeof(DogBreed)); //Terrier, Hound, Schnauzer, Malamute, Spaniel
            int e = i.Length; //5
            int dogIndex = random.Next(0, e);
            string dogBreedName = i[dogIndex];
            DogBreedName = dogBreedName;
        }

        public string DogBreedName;
        
        public void Say()
        {
            Gav();
        }
 
        public override void Voice()
        {
            Console.WriteLine($"{DogBreedName} {NameOfAnimal} say woof -woof" );
            
        }

        public void Gav()
        {
            Console.WriteLine($"{DogBreedName}  {NameOfAnimal} say Gav-Gav");
        }
    }

     class Cat : Animal, ISay
    {
        public Cat(string nameAnimal) : base(nameAnimal)
        {
            string[] i = Enum.GetNames(typeof(CatBreed));
            int e = i.Length;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int catIndex = random.Next(0, e);
            string catBreedName = i[catIndex];
            CatBreedName = catBreedName;
        }

        public string CatBreedName;

        void ISay.Say()
        {
            LeakApaw();
        }
        
        public override void Voice()
        {
            Console.WriteLine($"{CatBreedName} {NameOfAnimal} say myaw-myaw");
        }

        public void LeakApaw()
        {
            Console.WriteLine($"{CatBreedName} {NameOfAnimal} say murrr");
        }
    }

    interface ISay
    {
        void Say();
    }

    //random поле из массива породы кошки и собаки переменная Enum. поле property, name животных переделать на property. передать в конструкторе Enum как и имя.
    //отдельно имена на котов и псов
}

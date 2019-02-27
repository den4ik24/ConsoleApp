using System;
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

                if (A is ISay)
                {
                    ISay say = (ISay)A;
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

                animal = getAnimal(i);

                ListOfAnimal.Add(animal);



            }
            GetVoiceList(ListOfAnimal);
            Console.WriteLine(" общее количество живности - " + ListOfAnimal.Count);
        }
        
        public string GetDogName()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            string[] dogsName = new string[] { "Rex", "Rich", "Butcher", "Killer", "ALF" };
            
            int animalDogIndex = random.Next(0, dogsName.Length);
            return dogsName[animalDogIndex];

        }

        public string GetCatName()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            string[] catsName = new string[] { "Lucky", "Barsyk", "Ginger", "Marquis", "Leo" };

            int animalCatIndex = random.Next(0, catsName.Length);
            return catsName[animalCatIndex];

        }

        
        


        


        private Animal getAnimal(int i)
        {


            Animal animalanimal;

            if (i < 3)
            {

                Dog D = new Dog(GetDogName());
                //D.Gav();

                animalanimal = D;


            }

            else
            {

                Cat C = new Cat(GetCatName());
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

    enum DogBreed : int { Terrier, Hound, Schnauzer, Malamute, Spaniel }

    class Dog : Animal, ISay
    {
        public Dog(string nameAnimal) : base(nameAnimal)
        {

            string [] i = Enum.GetNames(typeof(DogBreed));
            int e = i.Length; 


            Random random = new Random(Guid.NewGuid().GetHashCode());
            int DogIndex = random.Next(1, e);
            

        }

        public void Say()
        {
            Gav();
        }

        

        public override void Voice()
        {
            Console.WriteLine($"{e} {NameOfAnimal} say woof -woof" );
            
        }

        public void Gav()
        {
            Console.WriteLine($"{i.ToString()}  {NameOfAnimal} say Gav-Gav");
        }
    }

    class Cat : Animal, ISay
    {
        public Cat(string nameAnimal) : base(nameAnimal)
        {

        }

        void ISay.Say()
        {
            LeakApaw();
        }

        enum CatBreed { Bengal, Ceylon, Russian, Munchkin, Persian }
        Random random = new Random(Guid.NewGuid().GetHashCode());
        int i = Enum.GetNames(typeof(CatBreed)).Length;

        public override void Voice()
        {
            Console.WriteLine($"{i.ToString()} {NameOfAnimal} say myaw-myaw");
        }

        public void LeakApaw()
        {
            Console.WriteLine($"{i.ToString()} {NameOfAnimal} say murrr");
        }
    }

    interface ISay
    {
        void Say();
    }

    //random поле из массива породы кошки и собаки переменная Enum. поле property, name животных переделать на property. передать в конструкторе Enum как и имя.
    //отдельно имена на котов и псов
}

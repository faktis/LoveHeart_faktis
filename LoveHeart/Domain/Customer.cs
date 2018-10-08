using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Customer : User
    {
        public List<Animal> animals;
        public Customer(string userName, string passWord, Animal animal = null) : base(userName, passWord)
        {
            Init();
            if (animal != null)
            {
                animals = new List<Animal>() { animal };
            }
            else
            {
                animals = new List<Animal>();
            }
        }
        
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public override void Init()
        {
            AccessLevel = AccessLevel.Receptionist;

        }

        public override string ToString()
        {
            return "$Account Type: Receptionist\n" +
                "Name: {UserName}";
        }
    }
}

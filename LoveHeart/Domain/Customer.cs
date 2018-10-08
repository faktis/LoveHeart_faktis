using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Customer : User
    {
        public List<Animal> animals;
        public string SocialSequrityNumber { get; private set; }
        public Customer(string userName, string passWord, string socialSequrityNumber , Animal animal = null, List <Animal> animals = null) : base(userName, passWord)
        {
            Init();
            SocialSequrityNumber = socialSequrityNumber;
            if (animals != null)
            {
                this.animals = animals; 
                if (animal != null)
                {

                    animals.Add(animal);
                }
            }
            else if(animal != null)
            {
                animals = new List<Animal>() { animal };
            }
            else
            {
                animals = new List<Animal>();
            }
        }

        public bool AddAnimal(Animal animal)
        {
            if (!animals.Contains(animal))
            {
                animals.Add(animal);
                return true;
            }
            return false;
        }

        public override void Init()
        {
            AccessLevel = AccessLevel.Receptionist;

        }

        public override string ToString()
        {
            return "$Account Type: Customer\n" +
                "Name: {UserName}";
        }
    }
}

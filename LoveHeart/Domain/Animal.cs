using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Animal
    {
        private static int AnimalId = 0;
        public string Name { get; set; }
        public List <string> MedicalJournal
        {
            get; set;
        }
        public Animal(string name, List <string> medicalJournal = null)
        {

            if (medicalJournal != null)
            {
                MedicalJournal = medicalJournal;
            }
            else
            {
                medicalJournal = new List<string>();
            }
            AnimalId++;
            Name = name;
        }
            
    }
}

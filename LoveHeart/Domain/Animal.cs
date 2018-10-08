using System;
using System.Collections.Generic;
using System.Text;

namespace LoveHeart.Domain
{
    class Animal
    {
        private static int AnimalId = 0;
        public string Name { get; set; }
        public Dictionary <string, string> MedicalJournal
        {
            get; set;
        }
        public Animal(string name, Dictionary <string, string> medicalJournal = null)
        {

            if (medicalJournal != null)
            {
                MedicalJournal = medicalJournal;
            }
            else
            {
                medicalJournal = new Dictionary<string, string>();
            }
            AnimalId++;
            Name = name;
        }
            
    }
}

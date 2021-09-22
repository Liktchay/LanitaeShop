using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.DataAccess.Entities
{
    public class Person
    {
        public int ID { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonAddress { get; set; }
        public List<Sale> Sale { get; set; }
    }
}

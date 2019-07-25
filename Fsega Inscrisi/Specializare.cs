using System;
using System.Collections.Generic;
using System.Text;

namespace Fsega_Inscrisi
{
    class Specializare
    {
        public Specializare(int id, string name, Finantare finantare, int max)
        {
            Id = id;
            Name = name;
            Finantare = finantare;
            Max = max;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Finantare Finantare { get; set; }

        public int Max { get; set; }

        public List<Student> StudentIds { get; set; } = new List<Student>();

        public bool IsFull { get => StudentIds.Count >= Max; }
    }
}

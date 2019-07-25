using System.Collections.Generic;

namespace Fsega_Inscrisi
{
    public class Student
    {
        public int Id { get; set; }

        public double Nota { get; set; }

        public List<int> Options { get; set; }

        public int SpecializareId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fsega_Inscrisi
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"./inscrisi.csv";
            List<String> lines = new List<String>();
            var students = new List<Student>();

            if (File.Exists(path)) ;
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String line;


                    while ((line = reader.ReadLine()) != null)
                    {
                        var trimmedLine = line.Trim();
                        if (!string.IsNullOrWhiteSpace(trimmedLine) && trimmedLine[0] >= '0' && trimmedLine[0] <= '9')
                        {
                            var matches = Regex.Matches(trimmedLine, @"(\d+\.\d+)|(\d+)").ToList().Select(m => m.Value).ToList();
                            if(matches.Count >= 5)
                            {
                                students.Add(new Student
                                {
                                    Id = int.Parse(matches[0]),
                                    Nota = double.Parse(matches[1]),
                                    Options = matches.Skip(5).Select(o => int.Parse(o)).ToList()
                                });
                            }
                        }
                    }

                    students = students.OrderByDescending(s => s.Nota).ToList();
                    //var test = students.Where(s => s.Options.Count > 3 && s.Options[0] == 17 && s.Options[1] == 11 && s.Options[2] == 19).ToList();

                    var specializari = new List<Specializare>
                    {
                        new Specializare(9, "MK", Finantare.Buget, 39),
                        new Specializare(59, "MK", Finantare.Rural, 2),
                        new Specializare(79, "MK", Finantare.Etnici, 1),
                        new Specializare(19, "MK", Finantare.Taxa, 108),
                        new Specializare(87, "MK", Finantare.Distanta, 100),
                        new Specializare(99, "MK", Finantare.Rrom, 10),

                        new Specializare(24, "MK Maghiara", Finantare.Buget, 23),
                        new Specializare(64, "MK Maghiara", Finantare.Rural, 1),
                        new Specializare(34, "MK Maghiara", Finantare.Taxa, 26),

                        new Specializare(2, "ECTS", Finantare.Buget, 36),
                        new Specializare(52, "ECTS", Finantare.Rural, 1),
                        new Specializare(72, "ECTS", Finantare.Etnici, 1),
                        new Specializare(12, "ECTS", Finantare.Taxa, 112),
                        new Specializare(82, "ECTS", Finantare.Distanta, 75),
                        new Specializare(92, "ECTS", Finantare.Rrom, 10),

                        new Specializare(41, "ECTS (Sf Gh)", Finantare.Buget, 12),
                        new Specializare(66, "ECTS (Sf Gh)", Finantare.Rural, 1),
                        new Specializare(45, "ECTS (Sf Gh)", Finantare.Taxa, 37),
                                             
                        new Specializare(42, "ECTS (Sf Gh) Maghiara", Finantare.Buget, 12),
                        new Specializare(67, "ECTS (Sf Gh) Maghiara", Finantare.Rural, 1),
                        new Specializare(46, "ECTS (Sf Gh) Maghiara", Finantare.Taxa, 37),

                        new Specializare(43, "EF (Sf Gh) Maghiara", Finantare.Buget, 12),
                        new Specializare(68, "EF (Sf Gh) Maghiara", Finantare.Rural, 1),
                        new Specializare(47, "EF (Sf Gh) Maghiara", Finantare.Taxa, 37),
                        new Specializare(89, "EF (Sf Gh) Maghiara", Finantare.Distanta, 50),

                        new Specializare(25, "AA Germana", Finantare.Buget, 33),
                        new Specializare(65, "AA Germana", Finantare.Rural, 1),
                        new Specializare(35, "AA Germana", Finantare.Taxa, 66),

                        new Specializare(3, "EAM", Finantare.Buget, 17),
                        new Specializare(53, "EAM", Finantare.Rural, 1),
                        new Specializare(73, "EAM", Finantare.Etnici, 1),
                        new Specializare(13, "EAM", Finantare.Taxa, 56),
                        new Specializare(93, "EAM", Finantare.Rrom, 10),

                        new Specializare(4, "EG", Finantare.Buget, 18),
                        new Specializare(54, "EG", Finantare.Rural, 1),
                        new Specializare(74, "EG", Finantare.Etnici, 1),
                        new Specializare(14, "EG", Finantare.Taxa, 70),
                        new Specializare(94, "EG", Finantare.Rrom, 10),

                        new Specializare(6, "FB", Finantare.Buget, 50),
                        new Specializare(56, "FB", Finantare.Rural, 2),
                        new Specializare(76, "FB", Finantare.Etnici, 1),
                        new Specializare(16, "FB", Finantare.Taxa, 187),
                        new Specializare(84, "FB", Finantare.Distanta, 100),
                        new Specializare(96, "FB", Finantare.Rrom, 10),

                        new Specializare(21, "FB Maghiara", Finantare.Buget, 50),
                        new Specializare(61, "FB Maghiara", Finantare.Rural, 1),
                        new Specializare(31, "FB Maghiara", Finantare.Taxa, 24),

                        new Specializare(27, "FB Engleza", Finantare.Buget, 14),
                        //new Specializare(1, "FB Engleza", Finantare.NonUE, 3),
                        new Specializare(37, "FB Engleza", Finantare.Taxa, 33),

                        new Specializare(1, "CIG", Finantare.Buget, 28),
                        new Specializare(51, "CIG", Finantare.Rural, 1),
                        new Specializare(71, "CIG", Finantare.Etnici, 1),
                        new Specializare(11, "CIG", Finantare.Taxa, 220),
                        new Specializare(81, "CIG", Finantare.Distanta, 100),
                        new Specializare(91, "CIG", Finantare.Rrom, 10),

                        new Specializare(30, "CIG Franceza", Finantare.Buget, 15),
                        //new Specializare(1, "CIG Franceza", Finantare.NonUE, 3),
                        new Specializare(40, "CIG Franceza", Finantare.Taxa, 32),

                        new Specializare(26, "CIG Engleza", Finantare.Buget, 14),
                        //new Specializare(1, "CIG Engleza", Finantare.NonUE, 3),
                        new Specializare(36, "CIG Engleza", Finantare.Taxa, 33),

                        new Specializare(44, "CIG (Sighetul Marmatiei)", Finantare.Buget, 14),
                        new Specializare(69, "CIG (Sighetul Marmatiei)", Finantare.Rural, 1),
                        new Specializare(48, "CIG (Sighetul Marmatiei)", Finantare.Taxa, 35),
                        new Specializare(90, "CIG (Sighetul Marmatiei)", Finantare.Distanta, 30),

                        new Specializare(8, "MG", Finantare.Buget, 36),
                        new Specializare(58, "MG", Finantare.Rural, 1),
                        new Specializare(78, "MG", Finantare.Etnici, 1),
                        new Specializare(18, "MG", Finantare.Taxa, 112),
                        new Specializare(86, "MG", Finantare.Distanta, 100),
                        new Specializare(98, "MG", Finantare.Rrom, 10),

                        new Specializare(23, "MG Maghiara", Finantare.Buget, 35),
                        new Specializare(63, "MG Maghiara", Finantare.Rural, 2),
                        new Specializare(33, "MG Maghiara", Finantare.Taxa, 38),
                        new Specializare(88, "MG Maghiara", Finantare.Distanta, 50),

                        new Specializare(28, "MG Engleza", Finantare.Buget, 14),
                        //new Specializare(1, "MG Engleza", Finantare.NonUE, 3),
                        new Specializare(38, "MG Engleza", Finantare.Taxa, 33),

                        new Specializare(7, "IE", Finantare.Buget, 70),
                        new Specializare(57, "IE", Finantare.Rural, 9),
                        new Specializare(77, "IE", Finantare.Etnici, 1),
                        new Specializare(17, "IE", Finantare.Taxa, 160),
                        new Specializare(85, "IE", Finantare.Distanta, 125),
                        new Specializare(97, "IE", Finantare.Rrom, 10),

                        new Specializare(22, "IE Maghiara", Finantare.Buget, 37),
                        new Specializare(62, "IE Maghiara", Finantare.Rural, 1),
                        new Specializare(32, "IE Maghiara", Finantare.Taxa, 12),

                        new Specializare(10, "SPE", Finantare.Buget, 20),
                        new Specializare(60, "SPE", Finantare.Rural, 1),
                        new Specializare(80, "SPE", Finantare.Etnici, 1),
                        new Specializare(20, "SPE", Finantare.Taxa, 68),
                        new Specializare(100, "SPE", Finantare.Rrom, 10),

                        new Specializare(5, "EAI", Finantare.Buget, 36),
                        new Specializare(55, "EAI", Finantare.Rural, 1),
                        new Specializare(75, "EAI", Finantare.Etnici, 1),
                        new Specializare(15, "EAI", Finantare.Taxa, 112),
                        new Specializare(83, "EAI", Finantare.Distanta, 50),
                        new Specializare(95, "EAI", Finantare.Rrom, 10),

                        new Specializare(29, "EAI Engleza", Finantare.Buget, 9),
                        //new Specializare(1, "EAI Engleza", Finantare.NonUE, 5),
                        new Specializare(39, "EAI Engleza", Finantare.Taxa, 36),
                    };

                    var specializariDictionary = specializari.ToDictionary(s => s.Id);

                    foreach(var student in students)
                    {
                        foreach(var optiune in student.Options)
                        {
                            if (!specializariDictionary[optiune].IsFull && student.SpecializareId == 0)
                            {
                                specializariDictionary[optiune].StudentIds.Add(student);
                                student.SpecializareId = optiune;
                            }
                        }
                    }
                }
            }
        }
    }
}
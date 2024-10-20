using System;

namespace Praktichne4
{
    
    class Person
    {
        public string Name { get; set; } 
        public int Age { get; set; } 
        public string Role { get; set; } 

        public Person(string N, string R, int A)
        {
            Name = N;
            Age = A;
            Role = R;
        }

        public string GetName() { return Name; }
    }

    
    class StudentAssessment
    {
        private double[] assessments = new double[10];

        public double CalculateRating(Random rand)
        {
            double rating = 0;
            for (int i = 0; i < 10; i++)
            {
                assessments[i] = rand.Next(56, 101); 
                rating += assessments[i];
                Console.Write(assessments[i].ToString() + ", ");
            }
            Console.WriteLine();
            return rating / 10;
        }
    }

    
    class Student : Person
    {
        public string Faculty { get; set; }
        public string Group { get; set; }
        public int Course { get; set; }
        private StudentAssessment assessment1 = new StudentAssessment();
        private StudentAssessment assessment2 = new StudentAssessment();

        public Student(string N, string R, int A, string F, string G, int C)
            : base(N, R, A)
        {
            Faculty = F;
            Group = G;
            Course = C;
        }

        public void CalculateAverageRating(Random rand)
        {
            double rating1 = assessment1.CalculateRating(rand);
            double rating2 = assessment2.CalculateRating(rand);
            double averageRating = (rating1 + rating2) / 2;
            Console.WriteLine("Середній рейтинг студента за семестр = {averageRating}");
        }
    }

    
    class Faculty
    {
        public string Name { get; set; }
        private Department department1 = new Department();
        private Department department2 = new Department();

        public Faculty(string name)
        {
            Name = name;
            department1.SetDepartmentName("Компютерних наук");
            department2.SetDepartmentName("Інформаційних технологій");
        }

        public void CallDepartmentMethods()
        {
            department1.SetNumberOfTeachers(10);
            department2.SetNumberOfTeachers(5);
            Console.WriteLine($"{Name}:\nКафедра: {department1.Name}, {department1.NumberOfTeachers} викладачів");
            Console.WriteLine($"{Name}:\nКафедра: {department2.Name}, {department2.NumberOfTeachers} викладачів");
        }
    }

    
    partial class Department
    {
        public string Name { get; private set; }
        public int NumberOfTeachers { get; private set; }

        public void SetDepartmentName(string name)
        {
            Name = name;
        }

        public void SetNumberOfTeachers(int count)
        {
            NumberOfTeachers = count;
        }
    }

   
    partial class Department
    {
        private string[] subjects = new string[3]; 

        public string this[int index]
        {
            get { return subjects[index]; }
            set { subjects[index] = value; }
        }
    }

   
    static class SearchUtility
    {
        public static (int min, int max) FindMinMax(int[] array)
        {
            int min = array[0];
            int max = array[0];
            foreach (var item in array)
            {
                if (item < min) min = item;
                if (item > max) max = item;
            }
            return (min, max);
        }

        public static int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] == target)
                    return mid;
                if (array[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Student newStudent = new Student("Іванов", "студент", 20, "КННІ", "K-01", 3);
            Random rand = new Random();
            newStudent.CalculateAverageRating(rand);
            Console.WriteLine();

            
            Faculty faculty = new Faculty("Компютерних наук");
            faculty.CallDepartmentMethods();

            
            int[] array = { 4, 5, 2, 3, 8, 7, 6, 1 };
            var (min, max) = SearchUtility.FindMinMax(array);
            Console.WriteLine($"Мінімальний елемент: {min}, Максимальний елемент: {max}");

            
            int[] largeArray = new int[100];
            for (int i = 0; i < largeArray.Length; i++)
                largeArray[i] = i + 1; 

            int searchElement = 50;
            int resultIndex = SearchUtility.BinarySearch(largeArray, searchElement);
            if (resultIndex != -1)
                Console.WriteLine($"Елемент {searchElement} знайдено на індексі: {resultIndex}");
            else
                Console.WriteLine($"Елемент {searchElement} не знайдено.");

            Console.ReadKey();
        }
    }
}

using System;

namespace StudentDecoratorExample
{
    // Базовий інтерфейс студента
    public interface IStudent
    {
        string Name { get; }
        void DisplayInfo();
    }

    // Конкретний студент
    public class Student : IStudent
    {
        public string Name { get; private set; }

        public Student(string name)
        {
            Name = name;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Студент: {Name}");
        }
    }

    // Абстрактний декоратор
    public abstract class StudentDecorator : IStudent
    {
        protected IStudent _student;

        public StudentDecorator(IStudent student)
        {
            _student = student;
        }

        public string Name => _student.Name;

        public virtual void DisplayInfo()
        {
            _student.DisplayInfo();
        }
    }

    // Декоратор для додавання стипендії
    public class ScholarshipDecorator : StudentDecorator
    {
        public double ScholarshipAmount { get; private set; }

        public ScholarshipDecorator(IStudent student, double scholarshipAmount)
            : base(student)
        {
            ScholarshipAmount = scholarshipAmount;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Стипендія: {ScholarshipAmount} грн");
        }
    }

    // Декоратор для додавання балу успішності
    public class GPAStudentDecorator : StudentDecorator
    {
        public double GPA { get; private set; }

        public GPAStudentDecorator(IStudent student, double gpa)
            : base(student)
        {
            GPA = gpa;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Бал успішності: {GPA}");
        }
    }

    class Program
    {
        static void Main()
        {
            IStudent student = new Student("Іван Іванов");

            // Декоруємо студента додатковими характеристиками
            student = new ScholarshipDecorator(student, 1500);
            student = new GPAStudentDecorator(student, 4.5);

            student.DisplayInfo();

            Console.ReadLine();
        }
    }
}

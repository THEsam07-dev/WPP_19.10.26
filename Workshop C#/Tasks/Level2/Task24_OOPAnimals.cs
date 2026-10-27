using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task24_OOPAnimals : ITask
    {
        public string Title => "ООП: Animal -> Dog/Cat/Bird";
        public string Description => "Построить иерархию животных.";
        public string[] Requirements => new[]
        {
            "Абстрактный класс Animal: свойство Name, абстрактный метод MakeSound(), переопределённый ToString().",
            "Классы Dog, Cat, Bird — наследники, реализуют MakeSound().",
            "Bird дополнительно имеет метод Fly()",
            "Продемонстрировать полиморфизм: List<Animal> с разными животными, вызов MakeSound() в цикле"
        };
        public void Run()
        {
            Console.WriteLine("=== Демонстрация полиморфизма ===\n");

            List<Animal> animals = new List<Animal>
            {
                new Dog("Зик"),
                new Cat("Злата"),
                new Bird("Воробей")
            };

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());

                animal.MakeSound();

                if (animal is Bird bird)
                {
                    bird.Fly();
                }

                Console.WriteLine();
            }
        }
        public abstract class Animal
        {
            public string Name { get; set; }
            public Animal(string name)
            {
                Name = name;
            }
            public abstract void MakeSound();
            public override string ToString()
            {
                return $"Животное: {Name,-6} | Вид: {GetType().Name}";
            }
        }
        public class Dog : Animal
        {
            public Dog(string name) : base(name) { }
            public override void MakeSound()
            {
                Console.WriteLine($"-- {Name} говорит: Гав-гав!");
            }
        }
        public class Cat : Animal
        {
            public Cat(string name) : base(name) { }
            public override void MakeSound()
            {
                Console.WriteLine($"-- {Name} говорит: Мяу-мяу!");
            }
        }
        public class Bird : Animal
        {
            public Bird(string name) : base(name) { }
            public override void MakeSound()
            {
                Console.WriteLine($"-- {Name} говорит: Чирик-чирик!");
            }
            public void Fly()
            {
                Console.WriteLine($"-- {Name} взмахнул крыльями и полетел!");
            }
        }
    }
}

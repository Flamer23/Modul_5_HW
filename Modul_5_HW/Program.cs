using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Modul_5_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            ShowAnketa(Anketa());
        }
        static void ShowAnketa((string name, string surname, int age, string[] petNames, string[] favColors) User)
        {
            Console.WriteLine($"Имя - {User.name}");
            Console.WriteLine($"Фамилия - {User.surname}");
            Console.WriteLine($"Возраст - {User.age}");
            if (User.petNames != null)
            {
                Console.WriteLine("Клички питомцев:");
                for (int i = 0; i < User.petNames.Length; i++)
                {
                    Console.WriteLine(User.petNames[i]);
                }
            }
            else Console.WriteLine("Питомцев нет");
            Console.WriteLine("Любимые цвета:");
            for(int i = 0; i < User.favColors.Length; i++)
            {
                Console.WriteLine(User.favColors[i]);
            }

        }
        static (string name, string surname, int age, string[] petNames,  string[] favColors) Anketa()
        {
            (string name, string surname, int age, string[] petNames, string[] favColors) User;
            bool flag = false;
            do
            {
                Console.WriteLine("Введите ваше имя:");
                User.name = Console.ReadLine();
                flag = CheckName(User.name);   
                
            } while (!flag);
            flag = false;
            Console.Clear();
            do
            {
                Console.WriteLine("Введите вашу фамилию:");
                User.surname = Console.ReadLine();
                flag = CheckName(User.surname);
            } while (!flag);
            flag = false;
            Console.Clear();
            do
            {
                Console.WriteLine("Введите ваш возраст");
                int.TryParse(Console.ReadLine(), out User.age);
                flag = CheckNum(User.age);
            }while (!flag);

            flag = false;
            Console.Clear();
            int answer;
            do
            {
                Console.WriteLine("У вас есть питомцы?\n1 - Нет  2 - Есть");
                int.TryParse((string)Console.ReadLine(), out answer);
                flag = CheckAnswer(answer);
            } while (!flag);
            flag = false;
            Console.Clear();
            if (answer == 2)
            {
                do
                {
                    Console.WriteLine("Сколько у вас питомцев?");
                    int.TryParse((string)Console.ReadLine(), out answer);
                    flag = CheckNum(answer);
                } while (!flag);
                User.petNames = GetPetNames(answer);
            }
            else
            {
                User.petNames = null;
            }
            flag = false;
            Console.Clear();
            do
            {
                Console.WriteLine("Сколько у вас любимых цветов?");
                int.TryParse((string)Console.ReadLine(), out answer);
                flag = CheckNum(answer);
                User.favColors = GetFavColors(answer);
            } while (!flag);
            Console.Clear();
            return User;
        }
        static string[] GetFavColors(int amount)
        {
            string[] colors = new string[amount];
            bool flag = false;
            string color;
            for (int i = 0; i < amount; i++)
            {
                do
                {
                    Console.WriteLine("Введите любимый цвет {0}", i + 1);
                    color = Console.ReadLine();
                    flag = CheckName(color);
                    if (flag)
                    {
                        colors[i] = color;
                    }

                } while (!flag);
                flag = false;
            }
            return colors;
        }
        static string[] GetPetNames(int amount)
        {
            string[] names = new string[amount];
            bool flag = false;
            string name;
            for (int i = 0; i < amount; i++)
            {
                do
                {
                    Console.WriteLine("Введите имя питомца {0}", i + 1);
                    name = Console.ReadLine();
                    flag = CheckName(name);
                    if (flag)
                    {
                        names[i] = name;
                    }

                } while (!flag);
                flag= false;
            }
            return names;
        }
        static bool CheckAnswer(int num)
        {
            if ((num > 0) && (num < 3))
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректное данные!\nПовторите ввод");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(1000);
                Console.Clear();
                return false;
            }
        }
        static bool CheckNum(int num) 
        { 
            if (num > 0)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректное данные!\nПовторите ввод");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(1000);
                Console.Clear();
                return false;
            }
        }
        static bool CheckName(string name)
        {
            if ((name == null) || (name == ""))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректное данные!\nПовторите ввод");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(1000);
                Console.Clear();
                return false;
            }
            else
            {
                bool containsNumbers = Regex.IsMatch(name, @"\d");
                if (containsNumbers)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные содержит числа!\nПовторите ввод");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(1000);
                    Console.Clear();
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
    }
    
}

using System;
using System.Collections.Generic;

namespace OOP
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public DateTime Time { get; set; }

        public Employee(int employeeID, string name, string gender, int salary, DateTime time)
        {
            EmployeeID = employeeID;
            Name = name;
            Gender = gender;
            Salary = salary;
            Time = time;
        }

        public static void Main(string[] args)
        {
            Stack<Employee> companyStack = new Stack<Employee>();

            // Lägg till 10 anställda med olika attribut
            PushEmployee(companyStack, 1, "Liza", "Non-Binary", 49000, DateTime.Now);
            PushEmployee(companyStack, 2, "Ken", "Male", 47000, DateTime.Now);
            PushEmployee(companyStack, 3, "Anna-Maria", "Female", 47000, DateTime.Now);
            PushEmployee(companyStack, 4, "Kalle", "Male", 51500, DateTime.Now);
            PushEmployee(companyStack, 5, "Olivia", "Non-Binary", 35000, DateTime.Now);
            PushEmployee(companyStack, 6, "Lovisa", "Female", 45000, DateTime.Now);
            PushEmployee(companyStack, 7, "Malin", "Female", 41000, DateTime.Now);
            PushEmployee(companyStack, 8, "Christoffer", "Male", 59000, DateTime.Now);
            PushEmployee(companyStack, 9, "Nemo", "Male", 46000, DateTime.Now);
            PushEmployee(companyStack, 10, "Lina", "Female", 29000, DateTime.Now);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Välkommen till Företaget AB:");
                Console.WriteLine("1. Visa alla Anställda: ");
                Console.WriteLine("2. Anställ en ny Person (Push): ");
                Console.WriteLine("3. Sparka senast anställd (Pop): ");
                Console.WriteLine("4. Visa senast anställd (Peek): ");
                Console.WriteLine("5. Sök i Indexet med Fullständig information: ");
                Console.WriteLine("6. Ge en Löneökning ");
                Console.WriteLine("7. Avsluta Programmet ");
                Console.Write("Var god gör ditt val: ");
                Console.ResetColor();

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Fel!!! Var god försök igen..\n");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            ShowAllEmployees(companyStack);
                            break;
                        case 2:
                            PushEmployee(companyStack); // Anropa PushEmployee för att lägga till en ny anställd
                            break;
                        case 3:
                            PopEmployee(companyStack); // Anropa PopEmployee för att ta bort senast anställd
                            break;
                        case 4:
                            PeekEmployee(companyStack); // Anropa PeekEmployee för att visa senast anställd
                            break;
                        case 5:
                            SearchEmployee(companyStack);
                            break;
                        case 6:
                            PromoteEmployee(companyStack);
                            break;
                        case 7:
                            Console.WriteLine("Avslutar programmet.");
                            return;
                        default:
                            Console.WriteLine("Felaktigt alternativ. Var god försök igen.\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ett fel uppstod: {ex.Message}\n");
                }
            }
        }

        private static void PushEmployee(Stack<Employee> companyStack)
        {
            Console.Write("Vad ska personen ha för ID: ");
            int employeeID;
            if (!int.TryParse(Console.ReadLine(), out employeeID))
            {
                Console.WriteLine("Felaktigt ID-format. Var god försök igen.");
                return;
            }

            Console.Write("Vad heter personen?: ");
            string name = Console.ReadLine();
            Console.WriteLine("Vad har personen för kön?: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Vad har personen för löneanspråk? ");
            int salary;
            if (!int.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Felaktigt löneformat. Var god försök igen.");
                return;
            }
            DateTime time = DateTime.Now; // Lägg till aktuell tid

            PushEmployee(companyStack, employeeID, name, gender, salary, time); // Anropa den andra versionen av PushEmployee
            Console.WriteLine("Anställd tillagd i systemet!\n");
        }

        public static void ShowAllEmployees(Stack<Employee> companyStack)
        {
            if (companyStack.Count == 0)
            {
                Console.WriteLine("Du har inga anställda ännu, Dags att anställa någon?");
            }
            else
            {
                Console.WriteLine("Alla Anställda:");
                foreach (Employee currentEmployee in companyStack)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"EmployeeID: {currentEmployee.EmployeeID}, Name: {currentEmployee.Name}, Gender: {currentEmployee.Gender}, Salary: {currentEmployee.Salary}, Time: {currentEmployee.Time}");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }

        private static void PushEmployee(Stack<Employee> companyStack, int employeeID, string name, string gender, int salary, DateTime time)
        {
            Employee newEmployee = new Employee(employeeID, name, gender, salary, time);
            companyStack.Push(newEmployee);
        }

        private static void PopEmployee(Stack<Employee> companyStack)
        {
            if (companyStack.Count > 0)
            {
                Employee removedEmployee = companyStack.Pop();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Senast anställd borttagen: EmployeeID: {removedEmployee.EmployeeID}, Name: {removedEmployee.Name}");
                Console.WriteLine($"\n{removedEmployee.Name} har fått sparken! \n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Det finns inga anställda att ta bort.");
            }
        }

        private static void PeekEmployee(Stack<Employee> companyStack)
        {
            if (companyStack.Count > 0)
            {
                Employee topEmployee = companyStack.Peek();
                Console.WriteLine($"Senast anställd: EmployeeID: {topEmployee.EmployeeID}, Name: {topEmployee.Name}");
            }
            else
            {
                Console.WriteLine("Det finns inga anställda i systemet.");
            }
        }

        private static void SearchEmployee(Stack<Employee> companyStack)
        {
            Console.Write("Skriv gärna ett nyckelord: ");
            string chosenWord = Console.ReadLine().ToLower();

            bool found = false;

            foreach (Employee currentEmployee in companyStack)
            {
                if (currentEmployee.Name.ToLower().Contains(chosenWord))
                {
                    found = true;
                    Console.WriteLine($"EmployeeID: {currentEmployee.EmployeeID}, Name: {currentEmployee.Name}, Gender: {currentEmployee.Gender}, Salary: {currentEmployee.Salary} Time: {currentEmployee.Time}");
                }
            }

            if (!found)
            {
                Console.WriteLine($"Inget matchar din sökning... '{chosenWord}'.");
            }

            Console.WriteLine();
        }

        private static void PromoteEmployee(Stack<Employee> companyStack)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Vill du ge en löneökning till en enskild anställd (1) eller till alla anställda (2)?");
            int promoteChoice;
            if (!int.TryParse(Console.ReadLine(), out promoteChoice))
            {
                Console.WriteLine("Felaktigt val. Var god försök igen.");
                return;
            }

            if (promoteChoice == 1)
            {
                Console.Write("Ange EmployeeID för den anställda du vill befordra: ");
                int employeeID;
                if (!int.TryParse(Console.ReadLine(), out employeeID))
                {
                    Console.WriteLine("Felaktigt ID-format. Var god försök igen.");
                    return;
                }

                Employee employeeToPromote = null;

                foreach (Employee currentEmployee in companyStack)
                {
                    if (currentEmployee.EmployeeID == employeeID)
                    {
                        employeeToPromote = currentEmployee;
                        break;
                    }
                }

                if (employeeToPromote != null)
                {
                    // En person får 5% löneökning.
                    employeeToPromote.Salary = (int)(employeeToPromote.Salary * 1.05);
                    Console.WriteLine($"Löneökning för {employeeToPromote.Name}. Den nya lönen är: {employeeToPromote.Salary}");
                }
                else
                {
                    Console.WriteLine("Anställd med det angivna EmployeeID hittades inte.");
                }
            }
            else if (promoteChoice == 2)
            {
                foreach (Employee currentEmployee in companyStack)
                {
                    // 5% löneökning till alla!
                    currentEmployee.Salary = (int)(currentEmployee.Salary * 1.05);
                    Console.WriteLine($"Löneökning för {currentEmployee.Name}. Den nya lönen är: {currentEmployee.Salary}");
                    Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⢯⠙⠩⠀⡇⠊⠽⢖⠆⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠱⣠⠀⢁⣄⠔⠁⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣷⣶⣾⣾⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⢀⡔⠙⠈⢱⡟⣧⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⡠⠊⠀⠀⣀⡀⠀⠘⠕⢄⠀⠀⠀⠀⠀\r\n⠀⠀⠀⢀⠞⠀⠀⢀⣠⣿⣧⣀⠀⠀⢄⠱⡀⠀⠀⠀\r\n⠀⠀⡰⠃⠀⠀⢠⣿⠿⣿⡟⢿⣷⡄⠀⠑⢜⢆⠀⠀\r\n⠀⢰⠁⠀⠀⠀⠸⣿⣦⣿⡇⠀⠛⠋⠀⠨⡐⢍⢆⠀\r\n⠀⡇⠀⠀⠀⠀⠀⠙⠻⣿⣿⣿⣦⡀⠀⢀⠨⡒⠙⡄\r\n⢠⠁⡀⠀⠀⠀⣤⡀⠀⣿⡇⢈⣿⡷⠀⠠⢕⠢⠁⡇\r\n⠸⠀⡕⠀⠀⠀⢻⣿⣶⣿⣷⣾⡿⠁⠀⠨⣐⠨⢀⠃\r\n⠀⠣⣩⠘⠀⠀⠀⠈⠙⣿⡏⠁⠀⢀⠠⢁⡂⢉⠎⠀\r\n⠀⠀⠈⠓⠬⢀⣀⠀⠀⠈⠀⠀⠀⢐⣬⠴⠒⠁⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀");
                }
            }
            else
            {
                Console.WriteLine("Felaktigt val. Var god försök igen.");
            }
        }
    }
}

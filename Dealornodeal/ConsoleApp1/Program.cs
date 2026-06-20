// COMMENTS DONE BY CHATGPT



using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        // Temporary variable used for swapping People objects (sorting/shuffling)
        private static People temp;

        // Array to store the 10 selected finalists
        static People[] finalists = new People[10];

        // Random generator used in multiple tasks
        static Random rnd = new Random();

        // Main list of contestants (not fully used consistently in current code)
        People[] clients = new People[35];

        // Struct representing a contestant
        public struct People
        {
            public string firstname;
            public string lastname;
            public string interst;
        }

        static void Main(string[] args)
        {
            int choice;

            // Main menu loop
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=============================");
                Console.WriteLine("Who Wants to Be a Millionaire");
                Console.WriteLine("=============================");
                Console.ResetColor();

                Console.WriteLine();
                Console.WriteLine("1. Load and List Contestants");
                Console.WriteLine("2. Update a Contestant's Interest");
                Console.WriteLine("3. Generate 10 Finalists");
                Console.WriteLine("4. Select One Player");
                Console.WriteLine("5. Select Questions");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int.TryParse(Console.ReadLine(), out choice);

                // Menu selection
                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 0:
                        Console.WriteLine("BYE BYE BYE");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                // Pause before returning to menu
                if (choice != 0)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }

            } while (choice != 0);
        }

        // TASK 1: Load contestants from file and display + sort by surname
        static void Task1()
        {
            People[] clients = new People[35];
            int count = 0;

            // Read contestant data from file (3 lines per person)
            StreamReader sr = new StreamReader(@"Millionaire.txt");

            while (!sr.EndOfStream)
            {
                clients[count].firstname = sr.ReadLine();
                clients[count].lastname = sr.ReadLine();
                clients[count].interst = sr.ReadLine();
                count++;
            }

            sr.Close();

            // Display unsorted list
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.firstname,-18} {client.lastname,-16} {client.interst}");
            }

            // Bubble sort by lastname
            for (int i = 0; i < count - 1; i++)
            {
                for (int pos = 0; pos < count - 1; pos++)
                {
                    if (string.Compare(clients[pos + 1].lastname, clients[pos].lastname) < 0)
                    {
                        temp = clients[pos + 1];
                        clients[pos + 1] = clients[pos];
                        clients[pos] = temp;
                    }
                }
            }
        }

        // TASK 2: Placeholder for updating contestant interest
        // TASK 2: Update contestant interest
        static void Task2()
        {
            People[] clients = new People[35];
            int count = 0;

            // Load file
            StreamReader sr = new StreamReader(@"Millionaire.txt");

            while (!sr.EndOfStream)
            {
                clients[count].firstname = sr.ReadLine();
                clients[count].lastname = sr.ReadLine();
                clients[count].interst = sr.ReadLine();
                count++;
            }

            sr.Close();

            // Ask for contestant
            Console.Write("Enter contestant first name: ");
            string first = Console.ReadLine();

            Console.Write("Enter contestant last name: ");
            string last = Console.ReadLine();

            bool found = false;

            // Search contestant
            for (int i = 0; i < count; i++)
            {
                if (clients[i].firstname.Equals(first, StringComparison.OrdinalIgnoreCase)
                    && clients[i].lastname.Equals(last, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Current Interest: {clients[i].interst}");

                    Console.Write("Enter new interest: ");
                    clients[i].interst = Console.ReadLine();

                    found = true;
                    break;
                }
            }

            if (found)
            {
                // Save updated data back to file
                StreamWriter sw = new StreamWriter(@"Millionaire.txt");

                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(clients[i].firstname);
                    sw.WriteLine(clients[i].lastname);
                    sw.WriteLine(clients[i].interst);
                }

                sw.Close();

                Console.WriteLine("Interest updated successfully.");
            }
            else
            {
                Console.WriteLine("Contestant not found.");
            }
        }

        // TASK 3: Generate 10 random finalists from file
        static void Task3()
        {
            // Load contestants again from file
            People[] clients = new People[35];
            int count = 0;

            StreamReader sr = new StreamReader(@"Millionaire.txt");

            while (!sr.EndOfStream)
            {
                clients[count].firstname = sr.ReadLine();
                clients[count].lastname = sr.ReadLine();
                clients[count].interst = sr.ReadLine();
                count++;
            }

            sr.Close();

            // Shuffle array using Fisher-Yates style swap
            for (int i = 0; i < count; i++)
            {
                int randomPos = rnd.Next(i, count);

                People temp = clients[i];
                clients[i] = clients[randomPos];
                clients[randomPos] = temp;
            }

            // Take first 10 as finalists
            Console.WriteLine("=== 10 FINALISTS ===");

            for (int i = 0; i < 10; i++)
            {
                finalists[i] = clients[i];
                Console.WriteLine($"{i + 1}. {finalists[i].firstname} {finalists[i].lastname}");
            }
        }

        // TASK 4: Select a random finalist
        static void Task4()
        {
            int selected = rnd.Next(10);

            Console.WriteLine("\n=== SELECTED FINALIST ===");
            Console.WriteLine($"{finalists[selected].firstname} {finalists[selected].lastname}");
        }

        // TASK 5: Simple quiz system with random question
        static void Task5()
        {
            string[] questions = new string[5];
            string[,] answers = new string[5, 4];
            int[] correct = new int[5];

            // Questions
            questions[0] = "What is the capital of New Zealand?";
            questions[1] = "What is 5 + 7?";
            questions[2] = "Which planet is known as the Red Planet?";
            questions[3] = "Who wrote 'Harry Potter'?";
            questions[4] = "What is the largest ocean on Earth?";

            // Multiple choice answers
            answers[0, 0] = "Auckland";
            answers[0, 1] = "Wellington";
            answers[0, 2] = "Christchurch";
            answers[0, 3] = "Hamilton";

            answers[1, 0] = "10";
            answers[1, 1] = "12";
            answers[1, 2] = "14";
            answers[1, 3] = "15";

            answers[2, 0] = "Earth";
            answers[2, 1] = "Mars";
            answers[2, 2] = "Jupiter";
            answers[2, 3] = "Venus";

            answers[3, 0] = "J.K. Rowling";
            answers[3, 1] = "Stephen King";
            answers[3, 2] = "Tolkien";
            answers[3, 3] = "Rowling Jr";

            answers[4, 0] = "Atlantic";
            answers[4, 1] = "Indian";
            answers[4, 2] = "Pacific";
            answers[4, 3] = "Arctic";

            // Correct answer indexes
            correct[0] = 1;
            correct[1] = 1;
            correct[2] = 1;
            correct[3] = 0;
            correct[4] = 2;

            // Pick random question
            int q = rnd.Next(questions.Length);

            Console.WriteLine("\n=== SELECTED QUESTION ===");
            Console.WriteLine(questions[q]);

            Console.WriteLine("A. " + answers[q, 0]);
            Console.WriteLine("B. " + answers[q, 1]);
            Console.WriteLine("C. " + answers[q, 2]);
            Console.WriteLine("D. " + answers[q, 3]);

            Console.Write("\nEnter answer (0-3): ");
            int userAnswer;
            int.TryParse(Console.ReadLine(), out userAnswer);

            // Check answer
            if (userAnswer == correct[q])
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Wrong answer.");
            }
        }
    }
}
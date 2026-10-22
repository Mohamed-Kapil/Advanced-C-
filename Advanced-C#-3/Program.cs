namespace Advanced_C__3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 1: Student Grade Manager
            Console.WriteLine("========== Exercise 1: Student Grade Manager ==========");
            Exercise1();

            static void Exercise1()
            {
                // 1. Create a Collection
                List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

                // 2. Print the collection, Count, first and last grade
                Console.WriteLine($"Grades: {string.Join(", ", grades)}");
                Console.WriteLine($"Count: {grades.Count}");
                Console.WriteLine($"First Grade: {grades[0]}");
                Console.WriteLine($"Last Grade: {grades[^1]}"); // Or grades[grades.Count - 1]

                // 3. Sort the grades ascending, then print
                grades.Sort();
                Console.WriteLine($"Sorted Grades: {string.Join(", ", grades)}");

                // 4. Get the first grade above 90
                int firstAbove90 = grades.First(g => g > 90);
                Console.WriteLine($"First grade above 90: {firstAbove90}");

                // 5. Get all grades below 75 (failing grades)
                List<int> failingGrades = grades.Where(g => g < 75).ToList();
                Console.WriteLine($"Failing grades (below 75): {string.Join(", ", failingGrades)}");

                // 6. Remove all failing grades (below 75)
                grades.RemoveAll(g => g < 75);
                Console.WriteLine($"Grades after removing failing grades: {string.Join(", ", grades)}");

                // 7. Check if any grade equals 100
                bool has100 = grades.Contains(100);
                Console.WriteLine($"Is there any grade equal to 100? {has100}");

                // 8. Create a List<string> where each grade becomes "Grade: X"
                List<string> formattedGrades = grades.Select(g => $"Grade: {g}").ToList();
                Console.WriteLine("Formatted Grades:");
                formattedGrades.ForEach(g => Console.WriteLine(g));
            }
            #endregion

            #region Exercise 2: Leaderboard
            Console.WriteLine("\n========== Exercise 2: Leaderboard ==========");
            Exercise2();

            static void Exercise2()
            {
                // 1. Create a leaderboard (SortedList automatically sorts by key ascending)
                // Using Score as Key, and Name as Value.
                SortedList<int, string> leaderboard = new SortedList<int, string>
            {
                { 500, "Ahmed" },
                { 200, "Sara" },
                { 800, "Ali" },
                { 350, "Mona" }
            };

                // 2. Print all entries (they should be sorted by score automatically)
                Console.WriteLine("Leaderboard:");
                foreach (var entry in leaderboard)
                {
                    Console.WriteLine($"{entry.Key} = {entry.Value}");
                }

                // 3. Access the first key and first value
                Console.WriteLine($"First Key (Lowest Score): {leaderboard.Keys[0]}");
                Console.WriteLine($"First Value: {leaderboard.Values[0]}");

                // 4. Check if score 500 exists
                Console.WriteLine($"Does score 500 exist? {leaderboard.ContainsKey(500)}");

                // 5. Safely get the player with score 999
                if (leaderboard.TryGetValue(999, out string player))
                {
                    Console.WriteLine($"Player with score 999: {player}");
                }
                else
                {
                    Console.WriteLine("Player with score 999 not found.");
                }

                // 6. Remove the player with score 200 and print the updated list
                leaderboard.Remove(200);
                Console.WriteLine("Leaderboard after removing score 200:");
                foreach (var entry in leaderboard)
                {
                    Console.WriteLine($"{entry.Key} = {entry.Value}");
                }
            }
            #endregion

            #region Exercise 3: Phone Book
            Console.WriteLine("\n========== Exercise 3: Phone Book ==========");
            Exercise3();

            static void Exercise3()
            {
                // 1. Create a Collection with 4 contacts
                Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                { "Ahmed", "0101111111" },
                { "Sara", "0112222222" },
                { "Mona", "0123333333" },
                { "Ali", "0154444444" }
            };

                // 2. Add a new contact using [] syntax (add or update)
                phoneBook["Omar"] = "0109999999";

                // 3. Try adding a duplicate using .Add() — catch the exception
                try
                {
                    phoneBook.Add("Ahmed", "0100000000");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($".Add() Duplicate Error: {ex.Message}");
                }

                // 4. Try adding a duplicate using .TryAdd() — print whether it succeeded
                bool isAdded = phoneBook.TryAdd("Sara", "0110000000");
                Console.WriteLine($".TryAdd() success for 'Sara'? {isAdded}");

                // 5. Search for a contact that doesn’t exist
                Console.WriteLine($"Does 'Youssef' exist? {phoneBook.ContainsKey("Youssef")}");

                // 6. Get a contact with a fallback of "Not Found"
                // Note: GetValueOrDefault is available in newer C# versions. 
                // Alternatively: phoneBook.TryGetValue("Youssef", out var num) ? num : "Not Found";
                string fallbackNumber = phoneBook.GetValueOrDefault("Youssef", "Not Found");
                Console.WriteLine($"Number for 'Youssef': {fallbackNumber}");

                // 7. Print all Keys on one line, then all Values on another line
                Console.WriteLine($"Keys: {string.Join(" | ", phoneBook.Keys)}");
                Console.WriteLine($"Values: {string.Join(" | ", phoneBook.Values)}");
            }

            #endregion

            #region Exercise 4: Unique Email Validator
            Console.WriteLine("\n========== Exercise 4: Unique Email Validator ==========");
            Exercise4();


            static void Exercise4()
            {
                // 1. Create a HashSet<string> with a case-insensitive comparer
                HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                // 2. Add these emails
                emails.Add("ahmed@test.com");
                emails.Add("AHMED@test.com");
                emails.Add("sara@test.com");
                emails.Add("Sara@Test.Com");

                // 3. Print Count — Explain why
                Console.WriteLine($"Emails Count: {emails.Count}");
                Console.WriteLine("Explanation: The count is 2 because we used 'StringComparer.OrdinalIgnoreCase'. It treats 'ahmed@test.com' and 'AHMED@test.com' as duplicates, and the same for Sara's email.");

                // 4. Create two sets
                HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
                HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

                // 5. Print the result of: UnionWith, IntersectWith, ExceptWith
                // Note: These methods modify the original set, so we clone SetA to show correct results for each.

                HashSet<int> unionSet = new HashSet<int>(setA);
                unionSet.UnionWith(setB);
                Console.WriteLine($"UnionWith: {string.Join(", ", unionSet)}");

                HashSet<int> intersectSet = new HashSet<int>(setA);
                intersectSet.IntersectWith(setB);
                Console.WriteLine($"IntersectWith: {string.Join(", ", intersectSet)}");

                HashSet<int> exceptSet = new HashSet<int>(setA);
                exceptSet.ExceptWith(setB);
                Console.WriteLine($"ExceptWith (A - B): {string.Join(", ", exceptSet)}");

                // 6. Use IsSubsetOf to check if {1,2} is a subset of Set A
                HashSet<int> subsetCheck = new HashSet<int> { 1, 2 };
                Console.WriteLine($"Is {{1,2}} a subset of Set A? {subsetCheck.IsSubsetOf(setA)}");
            }
            #endregion

            #region Exercise 5: Print Queue Simulator

            Console.WriteLine("\n========== Exercise 5: Print Queue Simulator ==========");
            Exercise5();

            static void Exercise5()
            {
                // 1. Create a Queue<string> and enqueue 5 documents
                Queue<string> printQueue = new Queue<string>();
                printQueue.Enqueue("Report.pdf");
                printQueue.Enqueue("Invoice.pdf");
                printQueue.Enqueue("Letter.docx");
                printQueue.Enqueue("Resume.pdf");
                printQueue.Enqueue("Photo.jpg");

                // Print the queue contents and Count
                Console.WriteLine($"Queue Contents: {string.Join(", ", printQueue)}");
                Console.WriteLine($"Queue Count: {printQueue.Count}");

                // 2. Use Peek to see which document will print next
                Console.WriteLine($"Next document to print (Peek): {printQueue.Peek()}");

                // 3. Process the queue: Dequeue each document
                Console.WriteLine("Processing Queue:");
                while (printQueue.Count > 0)
                {
                    string doc = printQueue.Dequeue();
                    Console.WriteLine($"Printing: {doc}");
                }

                // 4. Try TryDequeue on the now-empty queue — what happens?
                bool success = printQueue.TryDequeue(out string missingDoc);
                Console.WriteLine($"TryDequeue on empty queue succeeded? {success}");
                // What happens: It returns false and does not throw an Exception. The out variable is null.
            }
            #endregion
        }
    }
}

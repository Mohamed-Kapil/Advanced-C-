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
        }
    }
}

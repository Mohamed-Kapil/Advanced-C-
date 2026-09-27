namespace Advanced_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1 What is a generic class? Why use generics?
            /*A generic class is a class that can work with different data types using a type parameter.

            Generics are used to:
            *Reuse code.
            *Provide type safety.
            *Reduce casting.
            *Improve performance.*/
            #endregion

            #region Q2 Write a generic class Container<T> with Add and Get methods.
            Container<int> c = new Container<int>();
            c.Add(10);
            Console.WriteLine(c.Get());
            #endregion

            #region Q3 What are multiple type parameters? Write Pair<TKey, TValue>.
            Pair<int, string> p = new Pair<int, string>(1, "Mohamed");
            #endregion
        }
    }
}

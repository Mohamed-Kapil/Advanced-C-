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

            #region Q4: What is a generic method? Write Swap<T> method.
            /*static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
            int x = 10;
            int y = 20;

            Swap(ref x, ref y);*/
            #endregion

            #region Q5 Write a generic method FindMax<T> that finds maximum value
            /*public static T FindMax<T>(T a, T b)
               where T : IComparable<T>
             {
            return a.CompareTo(b) > 0 ? a : b;
              }
            Console.WriteLine(FindMax(10, 20));*/
            #endregion

            #region Q6 What is a generic interface? Write IRepository<T>.
            /*A generic interface can work with different types.
             
             * public interface IRepository<T>
            {
                void Add(T item);
                T Get(int id);
                void Delete(int id);
            }*/

            #endregion

            #region Q7  What is the 'struct' constraint? Write an example.
            /*The struct constraint specifies that the type must be a value type.*/
            Test<int> t1 = new Test<int>();
            #endregion

            #region Q8 What is the 'class' constraint? Write an example.
            /*The class constraint specifies that the type must be a reference type.*/
            Test_2<string> t2 = new Test_2<string>();
            #endregion

            #region Q9 What is the 'new()' constraint? Write an example.
            /*Requires a parameterless constructor.

            public class Factory<T>
            where T : new()
            {
            public T Create()
            {
            return new T();
            }
            }*/
            #endregion

            #region Q10  What is the interface constraint? Write an example.
            /*An interface constraint specifies that the generic type must implement a specific interface.

            public class Test<T> where T : IDisposable
            {
            }*/
            #endregion

            #region Q11 What is the base class constraint? Write an example.
            /*A base class constraint specifies that the generic type must inherit from a specific base class.

            public class Animal
            {
            }

            public class Zoo<T> where T : Animal
            {
            }*/
            #endregion

            #region Q12 How do you apply multiple constraints? Write an example. 
            /*Multiple constraints can be applied by writing them after the where keyword.

            public class Example<T>
            where T : Animal, IDisposable, new()
            {
            }*/
            #endregion

            #region Q13 What does the 'default' keyword do in generics?
            /*The default keyword returns the default value of a type.

            Examples:

            default(int);      // 0
            default(bool);     // false
            default(string);   // null*/
            #endregion

            #region Q14 Write a SafeList<T> that returns default when the index is invalid.
            /*public class SafeList<T> 
              { 
              private List<T> items = new List<T>();
              public void Add(T item) 
              { 
              items.Add(item); 
              } 
              public T Get(int index)
              { 
              if (index >= 0 && index < items.Count)
              return items[index];
              return default(T);
              } 
              }*/
            #endregion

        }

    }
}

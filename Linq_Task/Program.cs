using System.Numerics;

namespace Linq_Task
{
    public static class CustomeExtensionMethods
    {
        public static T CustomFirst<T>(this T[] x, Predicate<T> Cond)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (Cond(x[i]))
                    return x[i];
            }

            throw new InvalidOperationException("No element met the given condition.");
        }

        public static T CustomLastOrDefault<T>(this T[] x, Predicate<T> Cond)
        {
            for (int i = x.Length - 1; i >= 0; i--)
            {
                if (Cond(x[i]))
                    return x[i];
            }

            return default;
        }

        public static T CustomSingleOrDefault<T>(this T[] x, Predicate<T> Cond)
        {
            bool wasFoundOnce = false;
            T requiredElement;

            for (int i = 0; i < x.Length; i++)
            {
                if (Cond(x[i]))
                {
                    if (wasFoundOnce)
                        throw new InvalidOperationException("The input sequence contains more than one element.");

                    wasFoundOnce = true;
                    requiredElement = x[i];
                }
            }

            return default;
        }

        public static T[] CustomOrderBy<T>(this T[] x) where T : INumber<T>
        {
            // This method is based on bubble sort algorithm
            for (int i = 1; i < x.Length; i++)
            {
                for (int j = 0; j < x.Length - i; j++)
                {
                    // left = x[j]; right = x[j+1];

                    if (x[j] > x[j + 1])
                    {
                        T temp = x[j + 1];
                        x[j + 1] = x[j];
                        x[j] = temp;
                    }
                }
            }

            return x;
        }

        public static T[] CustomDistinct<T>(this T[] x)
        {
            return x.ToHashSet().ToArray();
        }

        public static T[] CustomeWhere<T>(this T[] x, Predicate<T> Cond)
        {
            List<T> list = new List<T>();
            for (int i = 0; i < x.Length; i++)
            {
                if (Cond(x[i]))
                    list.Add(x[i]);
            }

            return list.ToArray();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] arr = { 2, 3, 4, 8, 6, 4, 2, 8, 3, 2, 1 };

            foreach (var item in arr.CustomeWhere(n=>n>5))
            {
                Console.WriteLine(item);
            }
            
        }
    }
}

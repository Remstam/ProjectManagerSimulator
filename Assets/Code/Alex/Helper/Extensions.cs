using System;
using System.Collections.Generic;

namespace Code.Alex.Helper
{
    public static class Extensions
    {
        private static Random _rng = new Random();

        private static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = _rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static Queue<T> ToShuffledQueue<T>(this IList<T> list)
        {
            var interimList = new List<T>(list);
            var queue = new Queue<T>(list.Count);
            interimList.Shuffle();
            foreach (var figure in interimList)
                queue.Enqueue(figure);
            return queue;
        }

        public static Queue<T> ToQueue<T>(this IList<T> list)
        {
            var interimList = new List<T>(list);
            var queue = new Queue<T>(list.Count);
            interimList.Shuffle();
            foreach (var figure in interimList)
                queue.Enqueue(figure);
            return queue;
        }
    }
}
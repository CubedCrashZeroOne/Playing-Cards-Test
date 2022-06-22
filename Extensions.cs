using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqCards
{
    internal static class Extensions
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            if (list.Count == 0 || list.Count == 1)
            {
                return list;
            }

            int count = list.Count;
            var random = new Random();
            for (int i = 0; i < count; ++i)
            {
                int a = random.Next(count);
                T temp = list[i];
                list[i] = list[a];
                list[a] = temp;
            }

            return list;
        }

        // Задание 3
        public static void OutputHearts(this IEnumerable<Card> list)
        {
            var sortedList = from c in list
                where c.Suit == CardSuit.Heart
                orderby c.Value
                select c;

            if (sortedList.Any())
            {
                Console.WriteLine(String.Join(", ", sortedList.Select(a => a.ToString()).ToArray()));
            }
            else
            {
                Console.WriteLine("no hearts");
            }
        }
        
        // Задание 3
        public static void OutputSpades(this IEnumerable<Card> list)
        {
            var sortedList = from c in list
                where c.Suit == CardSuit.Spade
                orderby c.Value == CardValue.Ace, c.Value
                select c;

            if (sortedList.Any())
            {
                Console.WriteLine(String.Join(", ", sortedList.Select(a => a.ToString()).ToArray()));
            }
            else
            {
                Console.WriteLine("no spades");
            }
        }

        // Задание 4
        public static IEnumerable<Card> CombineSeries(this IEnumerable<Card> first, IEnumerable<Card> next)
        {
            var result = first.Concat(next);
            if (result.IsSeries())
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        
        // Задание 5
        public static bool IsSeries(this IEnumerable<Card> list)
        {
            // Check if empty or 1 element. 
            var count = list.Count();
            if (count == 0 || count == 1)
            {
                return true;
            }

            var justValues = list.Select(c => c.Value);
            // Check if sorted.
            var sortedValues = justValues.OrderBy(c => c);
            if (!justValues.SequenceEqual(sortedValues))
            {
                return false;
            }
            // Check for duplicates.
            var noDuplicates = justValues.Distinct();
            if (!justValues.SequenceEqual(noDuplicates))
            {
                return false;
            }
            // Check for gaps.
            var hasGaps = Enumerable.Range(justValues.Min(v => (int)v), justValues.Count())
                .Except(justValues.Select(v => (int)v))
                .Any();
            if (hasGaps)
            {
                return false;
            }
            // Check for alternating suits.
            // Split the suits into two collections: odd and even.
            var oddSuits = list.Select(c => c.Suit).Where((s, i) => i % 2 == 1);
            var evenSuits = list.Select(c => c.Suit).Where((s, i) => i % 2 == 0);

            var oddHasBlack = oddSuits.Any(s => s.Equals(CardSuit.Spade) || s.Equals(CardSuit.Club));
            var evenHasBlack = evenSuits.Any(s => s.Equals(CardSuit.Spade) || s.Equals(CardSuit.Club));
            var oddHasRed = oddSuits.Any(s => s.Equals(CardSuit.Diamond) || s.Equals(CardSuit.Heart));
            var evenHasRed = evenSuits.Any(s => s.Equals(CardSuit.Diamond) || s.Equals(CardSuit.Heart));
            
            // if odd and even have at least 1 common colour, it's not a series.
            if ((oddHasBlack && evenHasBlack) || (oddHasRed && evenHasRed))
            {
                return false;
            }

            return true;

        }
    }
}
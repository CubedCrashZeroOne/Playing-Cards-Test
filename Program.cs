using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqCards
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            
            Console.WriteLine("Часть 1");
            // Часть 1: Создать колоду, перетасовать, вывести первые и вторые 6 карт.
            var deck = new List<Card>()
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Three),
                new Card(CardSuit.Club, CardValue.Four),
                new Card(CardSuit.Club, CardValue.Five),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Seven),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.King),

                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Two),
                new Card(CardSuit.Diamond, CardValue.Three),
                new Card(CardSuit.Diamond, CardValue.Four),
                new Card(CardSuit.Diamond, CardValue.Five),
                new Card(CardSuit.Diamond, CardValue.Six),
                new Card(CardSuit.Diamond, CardValue.Seven),
                new Card(CardSuit.Diamond, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Nine),
                new Card(CardSuit.Diamond, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Jack),
                new Card(CardSuit.Diamond, CardValue.Queen),
                new Card(CardSuit.Diamond, CardValue.King),

                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Two),
                new Card(CardSuit.Heart, CardValue.Three),
                new Card(CardSuit.Heart, CardValue.Four),
                new Card(CardSuit.Heart, CardValue.Five),
                new Card(CardSuit.Heart, CardValue.Six),
                new Card(CardSuit.Heart, CardValue.Seven),
                new Card(CardSuit.Heart, CardValue.Eight),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Ten),
                new Card(CardSuit.Heart, CardValue.Jack),
                new Card(CardSuit.Heart, CardValue.Queen),
                new Card(CardSuit.Heart, CardValue.King),

                new Card(CardSuit.Spade, CardValue.Ace),
                new Card(CardSuit.Spade, CardValue.Two),
                new Card(CardSuit.Spade, CardValue.Three),
                new Card(CardSuit.Spade, CardValue.Four),
                new Card(CardSuit.Spade, CardValue.Five),
                new Card(CardSuit.Spade, CardValue.Six),
                new Card(CardSuit.Spade, CardValue.Seven),
                new Card(CardSuit.Spade, CardValue.Eight),
                new Card(CardSuit.Spade, CardValue.Nine),
                new Card(CardSuit.Spade, CardValue.Ten),
                new Card(CardSuit.Spade, CardValue.Jack),
                new Card(CardSuit.Spade, CardValue.Queen),
                new Card(CardSuit.Spade, CardValue.King),
            };

            // Sorted deck output.
            Console.WriteLine(String.Join(", ", deck.Select(a => a.ToString()).ToArray()));
            
            deck.Shuffle();

            // Shuffled deck output. 
            Console.WriteLine("\n\n" + String.Join(", ", deck.Select(a => a.ToString()).ToArray()));

            // First 6 cards.
            Console.WriteLine("\n\n" + String.Join(", ", deck.Take(6).Select(a => a.ToString()).ToArray()));
            
            // Second 6 cards.
            Console.WriteLine("\n\n" + String.Join(", ", deck.Skip(6).Take(6).Select(a => a.ToString()).ToArray()));
            
            //-------------------------------------------------------------------------------------------------------

            Console.WriteLine(Environment.NewLine + "Часть 2");
            // Часть 2: Реаализовать метод TryParse.

            Card output = new Card();
            
            var stringList = new List<string>()
            {
                "", "2♥", "K♦", "10♣", "A♠", "2♥", "2♥", " ", "4♦5", "♦3", "k♦"
            };

            var parsedList = stringList.Where(s => Card.TryParse(s, out output)).Select(s => output);

            Console.WriteLine(String.Join(", ", parsedList.Distinct().Select(a => a.ToString()).ToArray()));
            
            
            
            //-------------------------------------------------------------------------------------------------------

            Console.WriteLine(Environment.NewLine + "Часть 3");
            // Часть 3: Вывести по возрастанию червы(A-K) и пики(2-A).

            var deck1 = new List<Card>();
            var deck2 = new List<Card>()
            {
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.King),
                new Card(CardSuit.Heart, CardValue.Queen),
                new Card(CardSuit.Heart, CardValue.Jack),
                new Card(CardSuit.Heart, CardValue.Ten),
                new Card(CardSuit.Spade, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ace),
            };

            var deck3 = new List<Card>()
            {
                new Card(CardSuit.Heart, CardValue.Ace)
            };
            
            var deck4 = new List<Card>()
            {
                new Card(CardSuit.Spade, CardValue.Ace),
                new Card(CardSuit.Spade, CardValue.King),
                new Card(CardSuit.Spade, CardValue.Queen),
                new Card(CardSuit.Spade, CardValue.Five),
            };
            
            var deck5 = new List<Card>()
            {
                new Card(CardSuit.Heart, CardValue.Three),
                new Card(CardSuit.Heart, CardValue.Four),
                new Card(CardSuit.Heart, CardValue.Seven),
                new Card(CardSuit.Heart, CardValue.Nine),
            };
            
            // Methods defined in ListExtensions.cs
            deck.OutputHearts();
            deck1.OutputHearts();
            deck2.OutputHearts();
            deck3.OutputHearts();
            deck4.OutputHearts();
            deck5.OutputHearts();
            
            deck.OutputSpades();
            deck1.OutputSpades();
            deck2.OutputSpades();
            deck3.OutputSpades();
            deck4.OutputSpades();
            deck5.OutputSpades();
            
            //-------------------------------------------------------------------------------------------------------

            Console.WriteLine(Environment.NewLine + "Часть 5");
            // Часть 5: Реализовать метод, проверяющий, является ли коллекция серией.

            var series1 = new List<Card>()
            {
                new Card(CardSuit.Spade, CardValue.Two),
                new Card(CardSuit.Heart, CardValue.Three),
                new Card(CardSuit.Club, CardValue.Four),
                new Card(CardSuit.Heart, CardValue.Five),
                new Card(CardSuit.Spade, CardValue.Six),
                new Card(CardSuit.Diamond, CardValue.Seven)
            };

            var series2 = new List<Card>()
            {
                new Card(CardSuit.Spade, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Nine)
            };
            
            var series3 = new List<Card>()
            {
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Diamond, CardValue.King)
            };
            
            var notSeries4 = new List<Card>()
            {
                new Card(CardSuit.Spade, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.King)
            };
            
            var notSeries5 = new List<Card>()
            {
                new Card(CardSuit.Spade, CardValue.Ace),
                new Card(CardSuit.Spade, CardValue.Two)
            };
            
            var notSeries6 = new List<Card>()
            {
                new Card(CardSuit.Spade, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace)
            };
            
            Console.WriteLine(deck.IsSeries());
            Console.WriteLine(deck1.IsSeries());
            Console.WriteLine(deck2.IsSeries());
            Console.WriteLine(deck3.IsSeries());
            Console.WriteLine(series1.IsSeries());
            Console.WriteLine(series2.IsSeries());
            Console.WriteLine(series3.IsSeries());
            Console.WriteLine(notSeries4.IsSeries());
            Console.WriteLine(notSeries5.IsSeries());
            Console.WriteLine(notSeries6.IsSeries());

            
            //-------------------------------------------------------------------------------------------------------

            Console.WriteLine(Environment.NewLine + "Часть 4");
            // Часть 4: Реализовать метод, объединяющий две серии.

            var combo1 = deck1.CombineSeries(deck1);
            Console.WriteLine(combo1 != null ? String.Join(", ", combo1.Select(a => a.ToString()).ToArray()) : "bad series");
            var combo2 = deck1.CombineSeries(deck3);
            Console.WriteLine(combo2 != null ? String.Join(", ", combo2.Select(a => a.ToString()).ToArray()) : "bad series");
            var combo3 = deck3.CombineSeries(deck1);
            Console.WriteLine(combo3 != null ? String.Join(", ", combo3.Select(a => a.ToString()).ToArray()) : "bad series");
            var combo4 = deck3.CombineSeries(deck3);
            Console.WriteLine(combo4 != null ? String.Join(", ", combo4.Select(a => a.ToString()).ToArray()) : "bad series");
            var combo5 = series1.CombineSeries(series2);
            Console.WriteLine(combo5 != null ? String.Join(", ", combo5.Select(a => a.ToString()).ToArray()) : "bad series");
            var combo6 = series2.CombineSeries(series3);
            Console.WriteLine(combo6 != null ? String.Join(", ", combo6.Select(a => a.ToString()).ToArray()) : "bad series");
            var combo7 = series2.CombineSeries(series1);
            Console.WriteLine(combo7 != null ? String.Join(", ", combo7.Select(a => a.ToString()).ToArray()) : "bad series");
            var combo8 = series1.CombineSeries(series3);
            Console.WriteLine(combo8 != null ? String.Join(", ", combo8.Select(a => a.ToString()).ToArray()) : "bad series");
            var combo9 = deck3.CombineSeries(series1).CombineSeries(series2).CombineSeries(series3);
            Console.WriteLine(combo9 != null ? String.Join(", ", combo9.Select(a => a.ToString()).ToArray()) : "bad series");

            
            //-------------------------------------------------------------------------------------------------------

            Console.WriteLine(Environment.NewLine + "Часть 6-7");
            // Часть 6-7: Найти макс. и мин. ранг каждой масти за одно обращение к списку.
            
            var query = deck.GroupBy(c => c.Suit).Select(g => (key: g.Key, max: g.Max(c => c.Value), min: g.Min(c => c.Value)));
            var query1 = deck1.GroupBy(c => c.Suit).Select(g => (key: g.Key, max: g.Max(c => c.Value), min: g.Min(c => c.Value)));
            var query2 = deck2.GroupBy(c => c.Suit).Select(g => (key: g.Key, max: g.Max(c => c.Value), min: g.Min(c => c.Value)));
            var query3 = deck3.GroupBy(c => c.Suit).Select(g => (key: g.Key, max: g.Max(c => c.Value), min: g.Min(c => c.Value)));
            var query4 = deck4.GroupBy(c => c.Suit).Select(g => (key: g.Key, max: g.Max(c => c.Value), min: g.Min(c => c.Value)));
            var query5 = deck5.GroupBy(c => c.Suit).Select(g => (key: g.Key, max: g.Max(c => c.Value), min: g.Min(c => c.Value)));

            Console.WriteLine("deck:");
            foreach (var k in query)
            {
                Console.WriteLine(k.key + " max:" + k.max + " min:" + k.min);
            }
            Console.WriteLine("deck1:");
            foreach (var k in query1)
            {
                Console.WriteLine(k.key + " max:" + k.max + " min:" + k.min);
            }
            Console.WriteLine("deck2:");
            foreach (var k in query2)
            {
                Console.WriteLine(k.key + " max:" + k.max + " min:" + k.min);
            }
            Console.WriteLine("deck3:");
            foreach (var k in query3)
            {
                Console.WriteLine(k.key + " max:" + k.max + " min:" + k.min);
            }
            Console.WriteLine("deck4:");
            foreach (var k in query4)
            {
                Console.WriteLine(k.key + " max:" + k.max + " min:" + k.min);
            }
            Console.WriteLine("deck5:");
            foreach (var k in query5)
            {
                Console.WriteLine(k.key + " max:" + k.max + " min:" + k.min);
            }
        }
    }
}
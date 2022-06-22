using System.Security.Cryptography.X509Certificates;

namespace LinqCards
{
    internal struct Card
    {
        private CardSuit _suit;
        private CardValue _value;

        public CardSuit Suit
        {
            get { return _suit; }
        }

        public CardValue Value
        {
            get { return _value; }
        }

        public override string ToString()
        {
            string result = string.Empty;

            switch (_value)
            {
                case CardValue.Two:
                    result += "2";
                    break;
                case CardValue.Three:
                    result += "3";
                    break;
                case CardValue.Four:
                    result += "4";
                    break;
                case CardValue.Five:
                    result += "5";
                    break;
                case CardValue.Six:
                    result += "6";
                    break;
                case CardValue.Seven:
                    result += "7";
                    break;
                case CardValue.Eight:
                    result += "8";
                    break;
                case CardValue.Nine:
                    result += "9";
                    break;
                case CardValue.Ten:
                    result += "10";
                    break;
                case CardValue.Jack:
                    result += "J";
                    break;
                case CardValue.Queen:
                    result += "Q";
                    break;
                case CardValue.King:
                    result += "K";
                    break;
                case CardValue.Ace:
                    result += "A";
                    break;
            }
            
            switch (_suit)
            {
                case CardSuit.Club:
                    result += "\U00002663";
                    break;
                case CardSuit.Diamond:
                    result += "\U00002666";
                    break;
                case CardSuit.Heart:
                    result += "\U00002665";
                    break;
                case CardSuit.Spade:
                    result += "\U00002660";
                    break;
            }
            
            return result;
        }

        // Задание 2
        public static bool TryParse(string input, out Card result)
        {
            if (!(input.Length == 2 || (input.Length == 3 && input[0] == '1' && input[1] == '0')))
            {
                result = default(Card);
                return false;
            }
            else
            {
                CardValue cardValue;
                switch (input.Remove(input.Length - 1).ToUpper())
                {
                    case "2":
                        cardValue = CardValue.Two;
                        break;
                    case "3":
                        cardValue = CardValue.Three;
                        break;
                    case "4":
                        cardValue = CardValue.Four;
                        break;
                    case "5":
                        cardValue = CardValue.Five;
                        break;
                    case "6":
                        cardValue = CardValue.Six;
                        break;
                    case "7":
                        cardValue = CardValue.Seven;
                        break;
                    case "8":
                        cardValue = CardValue.Eight;
                        break;
                    case "9":
                        cardValue = CardValue.Nine;
                        break;
                    case "10":
                        cardValue = CardValue.Ten;
                        break;
                    case "J":
                        cardValue = CardValue.Jack;
                        break;
                    case "Q":
                        cardValue = CardValue.Queen;
                        break;
                    case "K":
                        cardValue = CardValue.King;
                        break;
                    case "A":
                        cardValue = CardValue.Ace;
                        break;
                    default:
                        result = default(Card);
                        return false;
                }

                CardSuit cardSuit;

                switch (input[input.Length - 1])
                {
                    case '\U00002663':
                        cardSuit = CardSuit.Club;
                        break;
                    case '\U00002666':
                        cardSuit = CardSuit.Diamond;
                        break;
                    case '\U00002665':
                        cardSuit = CardSuit.Heart;
                        break;
                    case '\U00002660':
                        cardSuit = CardSuit.Spade;
                        break;
                    default:
                        result = default(Card);
                        return false;
                }
                
                result = new Card(cardSuit, cardValue);
                return true;
            }
        }
        
        public Card(CardSuit suit, CardValue value)
        {
            _suit = suit;
            _value = value;
        }
    }
}
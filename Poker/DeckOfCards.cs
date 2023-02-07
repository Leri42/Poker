using Poker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class DeckOfCards
    {
        private readonly List<Card> cards = new List<Card>();
        int currentIndex = 0;

        public DeckOfCards()
        {
            Initialize();
            Shuffle();
        }

        private void Initialize()
        {
            CardSuit[] suits = new CardSuit[] { CardSuit.Diamonds, CardSuit.Clubs, CardSuit.Spades, CardSuit.Hearts };
            CardRank[] ranks = new CardRank[] {CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six,
            CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.Jack, CardRank.Queen, CardRank.King, CardRank.Ace};

            for (int i = 0; i < ranks.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    Card card = new Card(ranks[i], suits[j]);
                    cards.Add(card);
                }
            }
        }

        private void Shuffle()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < cards.Count; j++)
                {
                    Random rnd = new Random();
                    Card CurrentCard = cards[j];
                    int randomIndex = rnd.Next(0, cards.Count);
                    cards[j] = cards[randomIndex];
                    cards[randomIndex] = CurrentCard;
                }
            }
        }

        public Card PullCard()
        {
            return cards[currentIndex++];
        }

    }
}

using Poker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Player
    {
        public List<Card> playerCards = new List<Card>();
        public HandRank handRank;

        public void AddCard(Card card)
        {
            playerCards.Add(card);
        }

        public void PrintPlayerCards()
        {
            foreach (var card in playerCards)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
            Console.WriteLine($"Handrank equals to {handRank}");
        }

        public void SortCards()
        {
            for (int i = 0; i < playerCards.Count; i++)
            {
                Card CurrentCard = playerCards[i];
                for (int j = i-1; j >=0; j--)
                {
                    Card cardj = playerCards[j];
                    if ((int)CurrentCard.Rank < (int)cardj.Rank)
                    {
                        playerCards[j + 1] = playerCards[j];
                        playerCards[j] = CurrentCard;
                    }
                    else
                        break;
                }
            }
            handRank = GetHandRank();
        }


        public bool Straight(List<Card> cards)
        {
            Card firstCard = cards[0];
            int Rank = (int)firstCard.Rank;
            for (int i = 1; i < cards.Count; i++)
            {
                Card CurrentCard = cards[i];
                if ((int)CurrentCard.Rank!=++Rank)
                {
                    return false;
                }

            }
            return true;
        }

        public bool Flush(List<Card> cards)
        {
            Card firstCard = cards[0];
            CardSuit firstCardsuit = firstCard.Suit;
            for (int i = 1; i < cards.Count; i++)
            {
                Card CurrentCard = cards[i];
                if (firstCardsuit!=CurrentCard.Suit)
                {
                    return false;
                }

            }
            return true;
        }


        public HandRank GetHandRank()
        {
            if (Flush(playerCards) && Straight(playerCards) && playerCards[4].Rank==CardRank.Ace)
            {
                return HandRank.RoyalFlush;
            }
            else if (Flush(playerCards) && Straight(playerCards))
            {
                return HandRank.StraighFlush;
            }
            else if (Flush(playerCards))
            {
                return HandRank.Flush;
            }
            else if (Straight(playerCards))
            {
                return HandRank.Straight;
            }

            int[] arr = new int[15];

            foreach (Card card in playerCards)
            {
                int rank = (int)card.Rank;
                arr[rank]++;
            }
            int pairCounter = 0;

            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i]==2)
                {
                    pairCounter++;
                }
            }
            
            if (arr.Contains(4))
            {
                return HandRank.FourOfAKind;
            }
            else if (arr.Contains(3)&&arr.Contains(2))
            {
                return HandRank.FullHouse;
            }
            else if (arr.Contains(3))
            {
                return HandRank.ThreeOfAkind;
            }
            if (pairCounter == 2)
            {
                return HandRank.TwoPairs;
            }
            else if (pairCounter == 1)
            {
                return HandRank.OnePair;
            }
            else
            {
                return HandRank.HighHand;
            }
            


        }




















    }
}

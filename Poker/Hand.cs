using Poker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Hand
    {
        public readonly Player firstPlayer = new Player();
        public readonly Player secondPlayer = new Player();
        public readonly DeckOfCards deck = new DeckOfCards();

        public void DealCards()
        {
            for (int i = 0; i < 5; i++)
            {
                Card firstCard = deck.PullCard();
                Card secondCard = deck.PullCard();
                firstPlayer.AddCard(firstCard);
                secondPlayer.AddCard(secondCard);
            }
            firstPlayer.SortCards();
            secondPlayer.SortCards();
            
        }

        public void PrintCards()
        {
            Console.WriteLine("First Player");
            firstPlayer.PrintPlayerCards();
            Console.WriteLine("Second Player");
            secondPlayer.PrintPlayerCards();
        }

        public void Winner()
        {
            int firstPlayerRank = (int)firstPlayer.handRank;
            int secondPlayerRank = (int)secondPlayer.handRank;

            if (firstPlayerRank < secondPlayerRank)
            {
                Console.WriteLine("First Player wins");
            }
            else if (firstPlayerRank>secondPlayerRank)
            {
                Console.WriteLine("Second Player wins");
            }
            else
            {
                switch (firstPlayerRank)
                {
                    case 1:
                        Console.WriteLine("Daw");
                        return;
                    case 2:
                        {
                            Card p1Card = firstPlayer.playerCards[0];
                            Card p2Card = secondPlayer.playerCards[0];
                            int p1CardRank = (int)p1Card.Rank;
                            int p2CardRank = (int)p2Card.Rank;
                            if (p1CardRank>p2CardRank)
                            {
                                Console.WriteLine("First Player wins");
                            }else if (p1CardRank < p2CardRank)
                            {
                                Console.WriteLine("Second Player wins");
                            }else
                                Console.WriteLine("Draw");
                            return;
                        }
                    case 3:
                        {
                            Dictionary<CardRank, int>P1=new Dictionary<CardRank, int>();
                            Dictionary<CardRank, int>P2=new Dictionary<CardRank, int>();
                            for (int i = 0; i < firstPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = firstPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P1.ContainsKey(currentRank))
                                {
                                    P1[currentRank]++;
                                }
                                else
                                {
                                    P1.Add(currentRank, 1);
                                }
                            }
                            for (int i = 0; i < secondPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = secondPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P2.ContainsKey(currentRank))
                                {
                                    P2[currentRank]++;
                                }
                                else
                                {
                                    P2.Add(currentRank, 1);
                                }
                            }

                            int P1KareRank = 0;
                            int P1OneCardRank = 0;
                            int P2KareRank = 0;
                            int P2OneCardRank = 0;

                            foreach (CardRank rank in P1.Keys)
                            {
                                if (P1[rank]==4)
                                {
                                    P1KareRank = (int)rank;
                                }
                                if (P1[rank]==1)
                                {
                                    P1OneCardRank = (int)rank;
                                }
                            }
                            foreach (CardRank rank in P2.Keys)
                            {
                                if (P2[rank] == 4)
                                {
                                    P2KareRank = (int)rank;
                                }
                                if (P2[rank] == 1)
                                {
                                    P2OneCardRank = (int)rank;
                                }
                            }

                            if (P1KareRank>P2KareRank)
                            {
                                Console.WriteLine("First Player win.");
                            }else if (P1KareRank < P2KareRank)
                            {
                                
                                Console.WriteLine("Second Player win.");
                                }
                           
                            else if (P1OneCardRank > P2OneCardRank)
                            {
                                Console.WriteLine("First Player win.");
                            }
                            else if (P1OneCardRank < P2OneCardRank)
                            {
                                Console.WriteLine("Second Player win.");
                            }
                            else
                            {
                                Console.WriteLine("Draw");
                            }
                            return;


                        }

                    case 4:
                        {
                            Dictionary<CardRank, int> P1 = new Dictionary<CardRank, int>();
                            Dictionary<CardRank, int> P2 = new Dictionary<CardRank, int>();
                            for (int i = 0; i < firstPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = firstPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P1.ContainsKey(currentRank))
                                {
                                    P1[currentRank]++;
                                }
                                else
                                {
                                    P1.Add(currentRank, 1);
                                }
                            }
                            for (int i = 0; i < secondPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = secondPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P2.ContainsKey(currentRank))
                                {
                                    P2[currentRank]++;
                                }
                                else
                                {
                                    P2.Add(currentRank, 1);
                                }
                            }

                            int P1ThreeCard = 0;
                            int P1twoCardRank = 0;
                            int P2threeRank = 0;
                            int P2TwoCardRank = 0;

                            foreach (CardRank rank in P1.Keys)
                            {
                                if (P1[rank] == 3)
                                {
                                    P1ThreeCard = (int)rank;
                                }
                                if (P1[rank] == 2)
                                {
                                    P1twoCardRank = (int)rank;
                                }
                            }
                            foreach (CardRank rank in P2.Keys)
                            {
                                if (P2[rank] == 3)
                                {
                                    P2threeRank = (int)rank;
                                }
                                if (P2[rank] == 2)
                                {
                                    P2TwoCardRank = (int)rank;
                                }
                            }

                            if (P1ThreeCard > P2threeRank)
                            {
                                Console.WriteLine("First Player win.");
                            }
                            else if (P1ThreeCard < P2threeRank)
                            {

                                Console.WriteLine("Second Player win.");
                            }
                            else if (P1twoCardRank > P2TwoCardRank)
                            {
                                Console.WriteLine("First Player win.");
                            }
                            else if (P1twoCardRank < P2TwoCardRank)
                            {
                                Console.WriteLine("Second Player win.");
                            }
                            else
                            {
                                Console.WriteLine("Draw");
                            }
                            return;

                            


                        }

                    case 5:
                        {
                            List<Card> p1Cards = firstPlayer.playerCards;
                            List<Card> p2Cards = firstPlayer.playerCards;
                            bool equal = true;
                            for (int i = p1Cards.Count - 1; i >= 0; i--)
                            {
                                int p1CardsRank = (int)p1Cards[i].Rank;
                                int p2CardsRank = (int)p1Cards[i].Rank;
                                if (p1CardsRank > p2CardsRank)
                                {
                                    Console.WriteLine("First Player win");
                                    equal = false;
                                    break;
                                }
                                else if (p1CardsRank < p2CardsRank)
                                {
                                    Console.WriteLine("First Player win");
                                    equal = false;
                                    break;
                                }
                                
                               
                            }
                            if (equal)
                            {
                                Console.WriteLine("Draw");

                            }
                            return;
                        }

                    case 6:
                        {
                            Card p1Cards = firstPlayer.playerCards[0];
                            Card p2Cards = firstPlayer.playerCards[0];
                            int p1CardsRank = (int)p1Cards.Rank;
                            int p2CardsRank = (int)p1Cards.Rank;
                            if (p1CardsRank> p2CardsRank)
                            {
                                Console.WriteLine("Fist Player Wins!");
                            }else if(p1CardsRank < p2CardsRank)
                            {
                                Console.WriteLine("Second Player Wins!");
                            }else
                                Console.WriteLine("Draw");
                            return;
                        }

                    case 7:
                        {
                            Dictionary<CardRank, int> P1 = new Dictionary<CardRank, int>();
                            Dictionary<CardRank, int> P2 = new Dictionary<CardRank, int>();
                            for (int i = 0; i < firstPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = firstPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P1.ContainsKey(currentRank))
                                {
                                    P1[currentRank]++;
                                }
                                else
                                {
                                    P1.Add(currentRank, 1);
                                }
                            }
                            for (int i = 0; i < secondPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = secondPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P2.ContainsKey(currentRank))
                                {
                                    P2[currentRank]++;
                                }
                                else
                                {
                                    P2.Add(currentRank, 1);
                                }
                            }

                            int p1ThreeOfAKind = 0;
                            List<int> p1OtherCards = new List<int>();
                            int p2ThreeOfAKind = 0;
                            List<int> p2OtherCards = new List<int>();
                            foreach (CardRank rank in P1.Keys)
                            {
                                if (P1[rank]==3)
                                {
                                    p1ThreeOfAKind = (int)rank;
                                   
                                }else if (P1[rank] == 1)
                                {
                                    p1OtherCards.Add ((int)rank);
                                }
                            }
                            foreach (CardRank rank in P2.Keys)
                            {
                                if (P2[rank] == 3)
                                {
                                    p2ThreeOfAKind = (int)rank;

                                }
                                else if (P1[rank] == 1)
                                {
                                    p2OtherCards.Add((int)rank);
                                }
                            }

                            if (p1ThreeOfAKind > p2ThreeOfAKind)
                            {
                                Console.WriteLine("First Player win.");
                            }
                            else if (p1ThreeOfAKind < p2ThreeOfAKind)
                            {

                                Console.WriteLine("Second Player win.");
                            }
                            else
                            {
                                p1OtherCards.Sort();
                                p2OtherCards.Sort();
                                int winner = 0;
                                for (int i = p1OtherCards.Count-1; i > p1OtherCards.Count; i--)
                                {
                                    if (p1OtherCards[i] > p2OtherCards[i])
                                    {
                                        winner = 1;
                                    }
                                    else if (p1OtherCards[i] < p2OtherCards[i])
                                    {
                                        winner = 2;
                                    }
                                }
                                if (winner==1)
                                {
                                    Console.WriteLine("First player win");
                                }else if (winner==2)
                                    Console.WriteLine("Second Player Win");
                                else
                                {
                                    Console.WriteLine("Draw");
                                }
                                
                            }
                            return;

                        }
                    case 8:
                        {
                            Dictionary<CardRank, int> P1 = new Dictionary<CardRank, int>();
                            Dictionary<CardRank, int> P2 = new Dictionary<CardRank, int>();
                            for (int i = 0; i < firstPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = firstPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P1.ContainsKey(currentRank))
                                {
                                    P1[currentRank]++;
                                }
                                else
                                {
                                    P1.Add(currentRank, 1);
                                }
                            }
                            for (int i = 0; i < secondPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = secondPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P2.ContainsKey(currentRank))
                                {
                                    P2[currentRank]++;
                                }
                                else
                                {
                                    P2.Add(currentRank, 1);
                                }
                            }

                            int p1LastCard = 0;
                            List<int> p1PairsRank = new List<int>();
                            int p2LastCard = 0;
                            List<int> p2PairsRank = new List<int>();
                            int winner = 0;
                            foreach (CardRank rank in P1.Keys)
                            {
                                if (P1[rank] == 2)
                                {
                                    p1PairsRank.Add((int)rank);

                                }
                                else if (P1[rank] == 1)
                                {
                                    p1LastCard = ((int)rank);
                                }
                            }
                            foreach (CardRank rank in P2.Keys)
                            {
                                if (P2[rank] == 2)
                                {
                                    p2PairsRank.Add((int)rank);

                                }
                                else if (P2[rank] == 1)
                                {
                                    p2LastCard = ((int)rank);
                                }
                            }

                            p1PairsRank.Sort();
                            p2PairsRank.Sort();

                            for (int i = p1PairsRank.Count - 1; i > p1PairsRank.Count; i--)
                            {
                                if (p1PairsRank[i] > p2PairsRank[i])
                                {
                                    winner = 1;
                                }
                                else if ((p1PairsRank[i] < p2PairsRank[i]))
                                {
                                    winner = 2;
                                }
                            }
                            if (winner == 1)
                            {
                                Console.WriteLine("First player win");
                            }
                            else if (winner == 2)
                                Console.WriteLine("Second Player Win");
                            else if (p1LastCard > p2LastCard)
                                Console.WriteLine("First player win");
                            else if(p1LastCard < p2LastCard)
                                Console.WriteLine("Second Player Win");
                            else
                            {
                                Console.WriteLine("Draw");
                            }

                            return;
                        }

                    case 9:
                        {
                            Dictionary<CardRank, int> P1 = new Dictionary<CardRank, int>();
                            Dictionary<CardRank, int> P2 = new Dictionary<CardRank, int>();
                            for (int i = 0; i < firstPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = firstPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P1.ContainsKey(currentRank))
                                {
                                    P1[currentRank]++;
                                }
                                else
                                {
                                    P1.Add(currentRank, 1);
                                }
                            }
                            for (int i = 0; i < secondPlayer.playerCards.Count; i++)
                            {
                                Card currentCard = secondPlayer.playerCards[i];
                                CardRank currentRank = currentCard.Rank;
                                if (P2.ContainsKey(currentRank))
                                {
                                    P2[currentRank]++;
                                }
                                else
                                {
                                    P2.Add(currentRank, 1);
                                }
                            }

                            int P1PairRank = 0;
                            List<int> P1OtherRanks = new List<int>();
                            int P2PairRank = 0;
                            List<int> P2OtherRanks = new List<int>();

                            foreach (CardRank rank in P1.Keys)
                            {
                                if (P1[rank] == 3)
                                {
                                    P1PairRank = (int)rank;
                                    
    
                                }
                                else if (P1[rank] == 1)
                                {
                                    P1OtherRanks.Add((int)rank);
                                }
                            }
                            foreach (CardRank rank in P2.Keys)
                            {
                                if (P2[rank] == 3)
                                {
                                    P2PairRank = (int)rank;


                                }
                                else if (P2[rank] == 1)
                                {
                                    P2OtherRanks.Add((int)rank);
                                }
                            }

                            if (P1PairRank>P2PairRank)
                            {
                                Console.WriteLine("First Player win");
                            }else if (P1PairRank < P2PairRank)
                            {
                                Console.WriteLine("Second Player win");
                            }
                            else
                            {
                                P1OtherRanks.Sort();
                                P2OtherRanks.Sort();
                                int winner = 0;
                                for (int i = P1OtherRanks.Count; i >= 0; i--)
                                {
                                    if (P1OtherRanks[i] > P2OtherRanks[i])
                                    {
                                        winner = 1;
                                    }else if (P1OtherRanks[i] < P2OtherRanks[i])
                                    {
                                        winner = 2;
                                    }
                                }
                                if (winner == 1)
                                    {
                                        Console.WriteLine("First player win");
                                    }
                                    else if (winner == 2)
                                        Console.WriteLine("Second Player Win");
                                    else
                                        Console.WriteLine("Draw");
                                

                            }
                            return;

                        }

                    case 10:
                        {
                            List<Card> p1Cards = new List<Card>();
                            List<Card> p2Cards = new List<Card>();

                            bool equal = true;
                            for (int i = p1Cards.Count-1; i >=0; i--)
                            {
                                int p1CardRank = (int)p1Cards[i].Rank;
                                int p2CardRank = (int)p1Cards[i].Rank;
                                if (p1CardRank > p2CardRank)
                                {
                                    Console.WriteLine("First Player Win.");
                                    equal = false;
                                    break;
                                }else if (p1CardRank < p2CardRank)
                                {
                                    Console.WriteLine("Second Player Win");
                                    equal = false;
                                    break;
                                }
                            }if(equal)
                                Console.WriteLine("Draw.");
                            return;
                        }


                            default:
                        break;
                }

            }
        }
    }
}
























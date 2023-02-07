using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hand hand = new Hand();
            hand.DealCards();
            hand.PrintCards();
            hand.Winner();
        }
    }
}

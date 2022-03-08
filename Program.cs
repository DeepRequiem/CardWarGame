using System;

namespace GameCardWar
{
    class Program
    {
        static void Main(string[] args)
        {
            int nP1Tot = 0;
            int nP2Tot = 0;
            int nMatch = 0;
            int nTie = 0;

            int nP1Card;
            int nP2Card;
            int nCount = 0;

            string sP1Suit;
            string sP2Suit;
            string sP1Card;
            string sP2Card;
            string sResult = "";

            string[] sCardNames = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            string[] sCardSuits = { "Clubs", "Diamonds", "Hearts", "Spades" };

            int[] nDeck = new int[52];

            try
            {
                Get_Shuffle(ref nDeck);

                for (int x = 0; x < 26; x++)
                {
                    nP1Card = ChooseCard(nDeck, ref nCount, out int nSuit);

                    if (nP1Card > 12)
                    {
                        nP1Card = 0;
                    }

                    sP1Suit = sCardSuits[nSuit];
                    sP1Card = sCardNames[nP1Card];

                    nP2Card = ChooseCard(nDeck, ref nCount, out nSuit);

                    if (nP2Card > 12)
                    {
                        nP2Card = 0;
                    }

                    sP2Suit = sCardSuits[nSuit];
                    sP2Card = sCardNames[nP2Card];

                    if (nP1Card > nP2Card)
                    {

                        nP1Tot++;
                        sResult = "Player 1 wins";

                    }

                    else if (nP1Card < nP2Card)
                    {

                        nP2Tot++;
                        sResult = "Player 2 wins";

                    }

                    else if (nP1Card == nP2Card)
                    {

                        //nP1Tot++;
                        //nP2Tot++;

                        sResult = "Tie";
                        nTie++;

                    }

                    Console.WriteLine("\n==================================== Game #{0} ====================================\n", x + 1);

                    Console.WriteLine("Player 1: {0} of {1}", sP1Card, sP1Suit);
                    Console.WriteLine("Player 2: {0} of {1}\n", sP2Card, sP2Suit);
                    Console.WriteLine("{0}\n", sResult);
                    Console.WriteLine("Player 1 Score: {0}", nP1Tot);
                    Console.WriteLine("Player 2 Score: {0}", nP2Tot);

                    if (x < 25)
                    {
                        Console.WriteLine("\nPress any key to the next match #{0}\n", x + 2);
                        Console.ReadKey();
                    }

                    nMatch++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                Console.WriteLine("\n===================================== Final =====================================\n");

                if (nP1Tot > nP2Tot)
                {
                    Console.WriteLine("Winner Player 1 with Score: {0}", nP1Tot);
                    Console.WriteLine("Loser Player 2 with Score: {0}", nP2Tot);
                }
                else if (nP1Tot < nP2Tot)
                {
                    Console.WriteLine("Winner Player 2 with Score: {0}", nP2Tot);
                    Console.WriteLine("Loser Player 1 with Score: {0}", nP1Tot);
                }
                else if (nP1Tot == nP2Tot)
                {
                    Console.WriteLine("Tie\n");
                    Console.WriteLine("Player 1 with Score: {0}", nP1Tot);
                    Console.WriteLine("Player 2 with Score: {0}\n", nP2Tot);
                    Console.WriteLine("\nWith a total {0} ties", nP1Tot + nP2Tot);
                }

                if (nP1Tot != nP2Tot)
                {
                    Console.WriteLine("\nWith a total {0} ties", nTie);
                }
                
                Console.WriteLine("With a total {0} matches", nMatch);

                Console.ReadKey();
            }

        }
        private static void Get_Shuffle(ref int[] Deck)
        {
            Random nCards = new Random();

            for (int x = 0; x < 52; x++)
            {
                Deck[x] = nCards.Next(1, 52);
            }

        }
        private static int ChooseCard(int[] Deck, ref int nCount, out int nSuit)
        {
            int nCard;

            nCard = Deck[nCount];
            nCount++;
            nSuit = (nCard - 1) % 4;
            return (nCard - 1) / 4 + 1;
        }
    }
}

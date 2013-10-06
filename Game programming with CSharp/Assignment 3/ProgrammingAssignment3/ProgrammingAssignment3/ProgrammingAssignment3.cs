using System;
using ConsoleCards;

namespace ProgrammingAssignment3
{
    class ProgrammingAssignment3
    {
        static void Main()
        {
            Deck gameDeck = new Deck();
            BlackjackHand dealerHand = new BlackjackHand("Dealer");
            BlackjackHand playerHand = new BlackjackHand("Player");

            Console.WriteLine(new String('=', 40));
            Console.WriteLine("This game will play a hand of Blackjack");
            Console.WriteLine(new String('=', 40));
            Console.WriteLine();

            // Shuffle the deck before playing
            gameDeck.Shuffle();

            // Deals 2 cards to the player and the dealer from the top of the deck
            playerHand.AddCard(gameDeck.TakeTopCard());
            dealerHand.AddCard(gameDeck.TakeTopCard());
            playerHand.AddCard(gameDeck.TakeTopCard());
            dealerHand.AddCard(gameDeck.TakeTopCard());

            // Turn appropriate cards face up
            playerHand.ShowAllCards();
            dealerHand.ShowFirstCard();

            // Print player and dealer hands
            playerHand.Print();
            dealerHand.Print();

            // Let the player hit and add another card to their hand if they chose to do so
            Console.Write("Hit (y/n)? ");
            char choice = (char)Console.Read();
            if (choice == 'y' || choice == 'Y')
            {
                playerHand.AddCard(gameDeck.TakeTopCard());
                playerHand.ShowAllCards();
            }

            // Turn all dealer's cards face up
            dealerHand.ShowAllCards();
            
            // Print both hands
            Console.WriteLine();
            playerHand.Print();
            dealerHand.Print();

            // Print the score for the hands
            Console.WriteLine("Player score: " + playerHand.Score);
            Console.WriteLine("Dearer score: " + dealerHand.Score);
            Console.WriteLine();
        }
    }
}

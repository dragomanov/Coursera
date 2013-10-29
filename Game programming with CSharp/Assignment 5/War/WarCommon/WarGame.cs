using System;

namespace War
{
    public class WarGame
    {
        const int NUM_OF_ROUNDS = 21;

        private int p1MatchesWon;
        private int p2MatchesWon;
        private int p1BattlesWon;
        private int p2BattlesWon;
        private bool isRunning;
        private Random random;

        public WarGame()
        {
            this.p1MatchesWon = 0;
            this.p2MatchesWon = 0;
            random = new Random();
            isRunning = false;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to War!");
            Console.WriteLine();
            isRunning = true;
            while (isRunning)
            {
                PlayMatch();
                isRunning = PromptForAnotherMatch();
            }
        }

        private void PlayMatch()
        {
            p1BattlesWon = 0;
            p2BattlesWon = 0;

            for (int i = 0; i < NUM_OF_ROUNDS; i++)
            {
                PlayBattle();
            }

            Console.WriteLine();

            if (p1BattlesWon > p2BattlesWon)
            {
                p1MatchesWon++;
                Console.WriteLine("P1 is the overall Winner with {0} battles! ", p1BattlesWon);
            }
            else
            {
                p2MatchesWon++;
                Console.WriteLine("P2 is the overall Winner with {0} battles! ", p2BattlesWon);
            }

            Console.WriteLine();
        }

        private void PlayBattle()
        {
            int p1Roll = random.Next(1, 14);
            int p2Roll = random.Next(1, 14);

            if (p1Roll > p2Roll)
            {
                p1BattlesWon++;
                Console.WriteLine("BATTLE: P1:{0} \t P2:{1} \t P1 Wins!", p1Roll, p2Roll);
            }
            else if (p2Roll > p1Roll)
            {
                p2BattlesWon++;
                Console.WriteLine("BATTLE: P1:{0} \t P2:{1} \t P2 Wins!", p1Roll, p2Roll);
            }
            else
            {
                Console.WriteLine("   WAR! P1:{0} \t P2:{1}", p1Roll, p2Roll);
                PlayBattle();
            }
        }

        private bool PromptForAnotherMatch()
        {
            Console.Write("Do you want to play again (y/n)? ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine();
            bool playAgain = input != 'n' && input != 'N' ? true : false;
            return playAgain;
        }

        static void Main()
        {
            WarGame game = new WarGame();
            game.Start();
        }
    }
}

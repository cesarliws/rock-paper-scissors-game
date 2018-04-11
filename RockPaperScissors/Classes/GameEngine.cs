using System;

namespace RockPaperScissors.Classes
{
    class Play
    {
        public Play(string[] values)
        {
            var Player = values[0];
            var Strategy = values[1];

            if (!IsValid())
            {
                throw new NoSuchStrategyError(
                    String.Format("Strategy {0} is not valid!", Strategy));
            }

        }
        public string Player { get; set; }

        public char Strategy
        {
            get { return Strategy; }
            set { Strategy = char.ToUpperInvariant(value); }
        }

        public bool IsValid()
        {
            return (this.Strategy == 'R' || this.Strategy == 'P' || this.Strategy == 'S');
        }

        public bool Compare(Play otherPlay)
        {
            return (
                (this.Strategy == 'R' && otherPlay.Strategy == 'S') ||
                (this.Strategy == 'S' && otherPlay.Strategy == 'P') ||
                (this.Strategy == 'P' && otherPlay.Strategy == 'R') ||
                this.Strategy == otherPlay.Strategy
            );
        }
    }

    class GameEngine
    {
        private Play FirstPlay;
        private Play SecondPlay;

        private void CheckPlayCount(string[][] values)
        {
            if (values.Length != 2)
            {
                throw new WrongNumberOfPlayersError("The number of players is not equal to 2!");
            }
        }

        public string rps_game_winner(string[][] values)
        {
            CheckPlayCount(values);

            FirstPlay = new Play(values[0]);
            SecondPlay = new Play(values[1]);

            if (FirstPlay.Compare(SecondPlay))
            {
                return FirstPlay.Player;
            }
            else
            {
                return SecondPlay.Player;
            }

        }
    }
}

using System;
using System.Linq;

namespace RockPaperScissors.Classes
{
    public class Play
    {
        private string strategy;

        public Play(string[] values)
        {
            this.Player = values[0];
            this.Strategy = values[1];

        }
        public string Player { get; set; }

        public string Strategy
        {
            get { return strategy; }
            set { strategy = value.ToUpperInvariant(); }
        }

        public void CheckIsValid()
        {
            string[] rps = new string[3] { "R", "P", "S" };
            var strategyIsValid = (Strategy != null && (Strategy.Length == 1 && rps.Contains(Strategy)));

            if (!strategyIsValid)
            {
                throw new NoSuchStrategyError(
                    String.Format("Strategy {0} is not valid!", Strategy));
            }
        }

        public bool Compare(Play otherPlay)
        {
            return (
                (this.Strategy == "R" && otherPlay.Strategy == "S") ||
                (this.Strategy == "S" && otherPlay.Strategy == "P") ||
                (this.Strategy == "P" && otherPlay.Strategy == "R") ||
                (this.Strategy == otherPlay.Strategy)
            );
        }
    }

    public class GameEngine
    {
        public Play FirstPlay;
        public Play SecondPlay;

        private void CheckPlayCount(string[][] values)
        {
            if (values.Length != 2)
            {
                throw new WrongNumberOfPlayersError("The number of players is not equal to 2!");
            }
        }

        public string rps_game_winner(string[][] values)
        {
            var Winner = rps_game_winner_player_values(values);
            return Winner.Player;

        }

        public Play rps_game_winner_player_values(string[][] values)
        {
            CheckPlayCount(values);

            FirstPlay = new Play(values[0]);
            FirstPlay.CheckIsValid();

            SecondPlay = new Play(values[1]);
            SecondPlay.CheckIsValid();
            return rps_game_winner_player(FirstPlay, SecondPlay);
        }

        public Play rps_game_winner_player(Play FirstPlay, Play SecondPlay)
        {
            FirstPlay.CheckIsValid();
            SecondPlay.CheckIsValid();

            if (FirstPlay.Compare(SecondPlay))
            {
                return FirstPlay;
            }
            else
            {
                return SecondPlay;
            }

        }
    }
}

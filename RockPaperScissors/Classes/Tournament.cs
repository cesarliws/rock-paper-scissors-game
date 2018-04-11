using System.Collections.Generic;
using System.Linq;


namespace RockPaperScissors.Classes
{
    public class TournamentEngine
    {
        private GameEngine engine = new GameEngine();

        public string[] rps_tournament_winner(string[][][][] values)
        {
            var games = new List<GameEngine>();
            var winners = new List<Play>();
            Play tournamentWinner = null;

            foreach (string[][][] groups in values)
            {
                winners.AddRange(RunGroups(groups));
            }

            Play first = null;
            Play second = null;
            Play winner = null;

            while (winners.Count > 1)
            {
                first = winners[0];
                second = winners[1];
                winner = RunGame(first, second);

                if (winner == first)
                {
                    winners.Remove(second);
                }
                else
                {
                    winners.Remove(first);
                }
            }

            tournamentWinner = winners.First();
            return new string[] { tournamentWinner.Player, tournamentWinner.Strategy };
        }

        public Play RunGame(Play FirstPlay, Play SecondPlay)
        {
            return engine.rps_game_winner_player(FirstPlay, SecondPlay);
        }

        public List<Play> RunGroups(string[][][] groups)
        {
            var winners = new List<Play>();
            foreach (string[][] game in groups)
            {
                winners.Add(engine.rps_game_winner_player_values(game));
            }

            return winners;
        }

    }
}

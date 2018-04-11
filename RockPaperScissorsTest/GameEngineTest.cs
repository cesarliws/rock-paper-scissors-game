using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.Classes;

namespace RockPaperScissorsTest
{
    [TestClass]
    public class GameEngineTest
    {
        [TestMethod]
        public void rps_game_winner_S_beats_P_test()
        {
            var engine = new GameEngine();

            string[][] plays = { new string[] { "Armando", "P" }, new string[] { "Dave", "S" } };
            var winner = engine.rps_game_winner(plays);

            Assert.AreEqual("Dave", winner);
        }

        [TestMethod]
        public void rps_game_winner_p_beats_r_test()
        {
            var engine = new GameEngine();

            string[][] plays = { new string[] { "Armando", "p" }, new string[] { "Dave", "r" } };
            var winner = engine.rps_game_winner(plays);

            Assert.AreEqual("Armando", winner);
        }

        [TestMethod]
        public void rps_game_winner_r_beats_s_test()
        {
            var engine = new GameEngine();

            string[][] plays = { new string[] { "Armando", "r" }, new string[] { "Dave", "s" } };
            var winner = engine.rps_game_winner(plays);
            Assert.AreEqual("Armando", winner);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongNumberOfPlayersError))]
        public void rps_game_winner_WrongNumberOfPlayersError_test()
        {
            var engine = new GameEngine();
            string[][] plays = { new string[] { "Armando", "P" } };
            engine.rps_game_winner(plays);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchStrategyError))]
        public void rps_game_winner_NoSuchStrategyError_first_test()
        {
            var engine = new GameEngine();
            string[][] plays = { new string[] { "John", "E" }, new string[] { "Mike", "R" } };
            engine.rps_game_winner(plays);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchStrategyError))]
        public void rps_game_winner_NoSuchStrategyError_second_test()
        {
            var engine = new GameEngine();
            string[][] plays = { new string[] { "John", "S" }, new string[] { "Mike", "" } };
            engine.rps_game_winner(plays);
        }
    }
}

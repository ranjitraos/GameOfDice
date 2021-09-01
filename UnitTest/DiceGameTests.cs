using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GameOfDice.Models;
using GameOfDice;

namespace UnitTest
{
    [TestClass]
    public class DiceGameTests
    {
        [TestMethod]
        public void TestIsGameOver()
        {
            var testPlayersList = new List<Player>();
            testPlayersList.Add(new Player { name = "test player 1", rank = 1, score = 10 });
            testPlayersList.Add(new Player { name = "test player 2", rank = 2, score = 12 });
            testPlayersList.Add(new Player { name = "test player 3", rank = 3, score = 10 });

            var isOverActual = DiceGame.isGameOver(testPlayersList);
            var isOverExpected = true;

            Assert.AreEqual(isOverExpected, isOverActual);

            testPlayersList.Add(new Player { name = "test player 4", score = 7 });

            isOverActual = DiceGame.isGameOver(testPlayersList);
            isOverExpected = false;

            Assert.AreEqual(isOverExpected, isOverActual);
        }
    }
}

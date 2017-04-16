using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Memorypuzzle;

namespace MemorypuzzleTest
{
    [TestClass]
    public class MemorygameBoardTest
    {
        [TestMethod]
        public void TestCreateNewBoard()
        {
            var windowwidth = 640;
            var windowheight = 480;
            var boxsize = 40;
            var gapsize = 10;
            var boardwidth = 10;
            var boardheight = 7;

            var board = new MemorygameBoard(windowwidth, windowheight, boardwidth, boardheight, boxsize, gapsize);

            Assert.AreEqual(70, board.Xmargin);
            Assert.AreEqual(65, board.Ymargin);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateNewBoardExceptionOnUnevenNumber()
        {
            var windowwidth = 640;
            var windowheight = 480;
            var boxsize = 40;
            var gapsize = 10;
            var boardwidth = 5;
            var boardheight = 3;

            var board = new MemorygameBoard(windowwidth, windowheight, boardwidth, boardheight, boxsize, gapsize);
        }


        [TestMethod]
        public void TestGenerateRevealedBoxesData()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestSplitIntoGroupsOf()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestGenerateRevealedBoxesData_()
        {
            Assert.Fail();
        }
    }
}

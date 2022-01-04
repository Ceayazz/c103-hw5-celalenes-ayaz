using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce103_hw5_snake_functions;

namespace ce103_hw5_snake_test
{
    [TestClass]
    public class Snake_Test
    {


        [TestMethod]
        public void collisionDetection_test_1()
        {
            ce103snakegamecode meat = new ce103snakegamecode();
            int consolerrWidth = 50;
            int consoleeeHeight = 50;
            int[,] SSsnakeXY = new int[2, 310];
            SSsnakeXY[0, 0] = 10;
            SSsnakeXY[1, 0] = 20;
            int SSsnakeLength = 10;
            bool situuuation = meat.collisionDetection(SSsnakeXY, consolerrWidth, consoleeeHeight, SSsnakeLength);
            Assert.AreEqual(false, situuuation);
        }

        [TestMethod]
        public void collisionDetection_test_2()
        {
            ce103snakegamecode meat = new ce103snakegamecode();
            int consolerrWidth = 50;
            int consolerrHeight = 50;
            int[,] sSSnakeXY = new int[2, 310];
            sSSnakeXY[0, 0] = 10;
            sSSnakeXY[1, 0] = 20;
            int sSSnakeLength = 10;
            bool SSsituation = meat.collisionDetection(sSSnakeXY, consolerrWidth, consolerrHeight, sSSnakeLength);
            Assert.AreEqual(false, SSsituation);
        }

        [TestMethod]
        public void collisionDetection_test_3()
        {
            ce103snakegamecode meat = new ce103snakegamecode();
            int cCconsoleWidth = 50;
            int CCconsoleHeight = 50;
            int[,] SSsnakeXY = new int[2, 310];
            SSsnakeXY[0, 0] = 10;
            SSsnakeXY[1, 0] = 20;
            int SSsnakeLength = 10;
            bool sİİituation = meat.collisionDetection(SSsnakeXY, cCconsoleWidth, CCconsoleHeight, SSsnakeLength);
            Assert.AreEqual(false, sİİituation);
        }

        [TestMethod]
        public void eatfood_test_1()
        {
            ce103snakegamecode meat = new ce103snakegamecode();
            int[,] sSSnakeXY = new int[2, 310];
            sSSnakeXY[0, 0] = 20;
            sSSnakeXY[1, 0] = 10;
            int[] fFFoodXY = { 5, 5 };
            Assert.AreEqual(false, meat.eatFood(sSSnakeXY, fFFoodXY));
        }

        [TestMethod]
        public void eatfood_test_2()
        {
            ce103snakegamecode meat = new ce103snakegamecode();
            int[,] SSsnakeXY = new int[2, 310];
            SSsnakeXY[0, 0] = 20;
            SSsnakeXY[1, 0] = 10;
            int[] FFfoodXY = { 5, 5 };
            Assert.AreEqual(false, meat.eatFood(SSsnakeXY, FFfoodXY));
        }

        [TestMethod]
        public void eatfood_test_3()
        {
            ce103snakegamecode meat = new ce103snakegamecode();
            int[,] SSsnakeXY = new int[2, 310];
            SSsnakeXY[0, 0] = 20;
            SSsnakeXY[1, 0] = 10;
            int[] FFfoodXY = { 5, 5 };
            Assert.AreEqual(false, meat.eatFood(SSsnakeXY, FFfoodXY));
        }

        [TestMethod]
        public void collision_snake_test1()
        {
            ce103snakegamecode cCcollision = new ce103snakegamecode();
            int[,] NsnakeXY = new int[2, 310];
            NsnakeXY[0, 0] = 50;
            NsnakeXY[1, 0] = 20;
            Assert.AreEqual(false, cCcollision.collisionSnake(29, 3, NsnakeXY, 9, 1));
        }

        [TestMethod]
        public void collision_snake_test2()
        {
            ce103snakegamecode cCcollision = new ce103snakegamecode();
            int[,] NsnakeXY = new int[2, 310];
            NsnakeXY[0, 0] = 50;
            NsnakeXY[1, 0] = 20;
            Assert.AreEqual(false, cCcollision.collisionSnake(29, 3, NsnakeXY, 9, 1));
        }

        [TestMethod]
        public void collision_snake_test3()
        {
            ce103snakegamecode cCcollision = new ce103snakegamecode();
            int[,] NsnakeXY = new int[2, 310];
            NsnakeXY[0, 0] = 50;
            NsnakeXY[1, 0] = 20;
            Assert.AreEqual(false, cCcollision.collisionSnake(29, 3, NsnakeXY, 9, 1));
        }
    }
}

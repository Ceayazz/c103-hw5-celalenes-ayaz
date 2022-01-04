using System;
using System.Threading;

namespace ce103_hw5_snake_functions
{
    public class ce103snakegamecode
    {
        public const int SNAKE_ARRAY_SIZE = 310;
        public const ConsoleKey UP_ARROW = ConsoleKey.UpArrow;
        public const ConsoleKey LEFT_ARROW = ConsoleKey.LeftArrow;
        public const ConsoleKey RIGHT_ARROW = ConsoleKey.RightArrow;
        public const ConsoleKey DOWN_ARROW = ConsoleKey.DownArrow;
        public const ConsoleKey ENTER_KEY = ConsoleKey.Enter;
        public const ConsoleKey EXIT_BUTTON = ConsoleKey.Escape; // ESC
        public const ConsoleKey PAUSE_BUTTON = ConsoleKey.P; //p
        const char SNAKE_HEAD = (char)125;
        const char SNAKE_BODY = (char)62;
        const char WALL = (char)219;
        const char FOOD = (char)64;
        const char BLANK = ' ';


        public ConsoleKey waitForAnyKey()
        {
            ConsoleKey push;

            while (!Console.KeyAvailable) ;

            push = Console.ReadKey(false).Key;
            //pressed = tolower(pressed);
            return push;
        }


        public int getGameSpeed()
        {
            int hiz = 10;
            Console.Clear();
            Console.Write("Select The game speed between 1 and 9 and press enter");
            int selection = Convert.ToUInt16(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    hiz = 40;
                    break;
                case 2:
                    hiz = 35;
                    break;
                case 3:
                    hiz = 30;
                    break;
                case 4:
                    hiz = 25;
                    break;
                case 5:
                    hiz = 20;
                    break;
                case 6:
                    hiz = 15;
                    break;
                case 7:
                    hiz = 15;
                    break;
                case 8:
                    hiz = 10;
                    break;
                case 9:
                    hiz = 5;
                    break;

            }
            return hiz;
        }

        public void pauseMenu()
        {

            Console.SetCursorPosition(28, 23);
            Console.Write("**Paused**");

            waitForAnyKey();
            Console.SetCursorPosition(28, 23);
            Console.Write("            ");
            return;
        }

        //This function checks if a key has press, then checks if its any of the arrow keys/ p/esc key. It changes direction acording to the key press.
        public ConsoleKey checkKeyspress(ConsoleKey ddirectionn)
        {
            ConsoleKey push;

            if (Console.KeyAvailable == true) //If a key has been press
            {
                push = Console.ReadKey(false).Key;
                if (ddirectionn != push)
                {
                    if (push == DOWN_ARROW && ddirectionn != UP_ARROW)
                    {
                        ddirectionn = push;
                    }
                    else if (push == UP_ARROW && ddirectionn != DOWN_ARROW)
                    {
                        ddirectionn = push;
                    }
                    else if (push == LEFT_ARROW && ddirectionn != RIGHT_ARROW)
                    {
                        ddirectionn = push;
                    }
                    else if (push == RIGHT_ARROW && ddirectionn != LEFT_ARROW)
                    {
                        ddirectionn = push;
                    }
                    else if (push == EXIT_BUTTON || push == PAUSE_BUTTON)
                    {
                        pauseMenu();
                    }
                }
            }
            return (ddirectionn);
        }
        //Cycles around checking if the x y coordinates ='s the snake coordinates as one of this parts
        //One thing to note, a snake of length 4 cannot collide with itself, therefore there is no need to call this function when the snakes length is <= 4
        public bool collisionSnake(int s, int j, int[,] YXsnakeXY, int snakelong, int detected)
        {
            int c;
            for (c = detected; c < snakelong; c++) //Checks if the snake collided with itself
            {
                if (s == YXsnakeXY[0, c] && j == YXsnakeXY[1, c])
                    return true;
            }
            return false;
        }
        //Generates food & Makes sure the food doesn't appear on top of the snake <- This sometimes causes a lag issue!!! Not too much of a problem tho
        public void generateFood(int[] eatXY, int WwidthH, int hei7ght, int[,] ssnakeXY, int snakelong)
        {
            Random RandomNumberss = new Random();
            do
            {
                //RandomNumbers.Seed(time(null));
                eatXY[0] = RandomNumberss.Next() % (WwidthH - 2) + 2;
                //RandomNumbers.Seed(time(null));
                eatXY[1] = RandomNumberss.Next() % (hei7ght - 6) + 2;
            } while (collisionSnake(eatXY[0], eatXY[1], ssnakeXY, snakelong, 0)); //This should prevent the "Food" from being created on top of the snake. - However the food has a chance to be created ontop of the snake, in which case the snake should eat it...

            Console.SetCursorPosition(eatXY[0], eatXY[1]);
            Console.Write(FOOD);
        }

        /*
        Moves the snake array forward, i.e. 
        This:
         x 1 2 3 4 5 6
         y 1 1 1 1 1 1
        Becomes This:
         x 1 1 2 3 4 5
         y 1 1 1 1 1 1

         Then depending on the direction (in this case west - left) it becomes:

         x 0 1 2 3 4 5
         y 1 1 1 1 1 1

         snakeXY[0][0]--; <- if direction left, take 1 away from the x coordinate
        */
        public void moveSnakeArray(int[,] SnakeeXY, int SnakeLengtthh, ConsoleKey Direcction)
        {
            int f;
            for (f = SnakeLengtthh - 1; f >= 1; f--)
            {
                SnakeeXY[0, f] = SnakeeXY[0, f - 1];
                SnakeeXY[1, f] = SnakeeXY[1, f - 1];
            }

            /*
            because we dont actually know the new snakes head x y, 
            we have to check the direction and add or take from it depending on the direction.
            */
            switch (Direcction)
            {
                case DOWN_ARROW:
                    SnakeeXY[1, 0]++;
                    break;
                case RIGHT_ARROW:
                    SnakeeXY[0, 0]++;
                    break;
                case UP_ARROW:
                    SnakeeXY[1, 0]--;
                    break;
                case LEFT_ARROW:
                    SnakeeXY[0, 0]--;
                    break;
            }

            return;
        }

        /**
        *
        *	  @name   Move Snake Body (move)
        *
        *	  @brief Move snake body
        *
        *	  Moving snake body
        *
        *	  @param  [in] snakeXY [\b int[,]]  snake coordinates
        *	  
        *	  @param  [in] snakeLength [\b int]  index of fibonacci number in the serie
        *	  
        *	  @param  [in] direction [\b ConsoleKey]  index of fibonacci number in the serie
        **/
        public void move(int[,] SsnakeXY, int SSnakeLlength, ConsoleKey Direcction)
        {
            int c;
            int e;

            //Remove the tail ( HAS TO BE DONE BEFORE THE ARRAY IS MOVED!!!!! )
            c = SsnakeXY[0, SSnakeLlength - 1];
            e = SsnakeXY[1, SSnakeLlength - 1];

            Console.SetCursorPosition(c, e);
            Console.Write(BLANK);

            //Changes the head of the snake to a body part
            Console.SetCursorPosition(SsnakeXY[0, 0], SsnakeXY[1, 0]);
            Console.Write(SNAKE_BODY);

            moveSnakeArray(SsnakeXY, SSnakeLlength, Direcction);

            Console.SetCursorPosition(SsnakeXY[0, 0], SsnakeXY[1, 0]);
            Console.Write(SNAKE_HEAD);

            Console.SetCursorPosition(1, 1); //Gets rid of the darn flashing underscore.

            return;
        }


        /**
        *
        *	  @name   eatfood (eat)
        *
        *	  @brief Snake eat food
        *
        *	  Eating @
        *
        *	  @param  [in] snakeXY [\b int[,]]  snake coordinates
        *	  
        *	  @param  [in] foodXY [\b int]  index of fibonacci number in the serie
        *	  
        *	  
        **/
        //This function checks if the snakes head his on top of the food, if it is then it'll generate some more food...
        public bool eatFood(int[,] SsnakeXY, int[] FfoodXY)
        {
            if (SsnakeXY[0, 0] == FfoodXY[0] && SsnakeXY[1, 0] == FfoodXY[1])
            {
                FfoodXY[0] = 0;
                FfoodXY[1] = 0; //This should prevent a nasty bug (loops) need to check if the bug still exists...

                return true;
            }

            return false;
        }


        /**
        *
        *	  @name   Collision Detection (console)
        *
        *	  @brief Detection of collision
        *
        *	  Collision Detection
        *
        *	  @param  [in] snakeXY [\b int[,]]  snake coordinates
        *	  
        *	  @param  [in] consoleWidth [\b int]  console witdh
        *	  
        *	  @param  [in] snakeLength [\b int]  snake length
        **/

        public bool collisionDetection(int[,] SsnakeXY, int CconsoleWidthh, int CconsoleHeightt, int SsnakeLengthh) //Need to Clean this up a bit
        {
            bool Ccolision = false;
            if ((SsnakeXY[0, 0] == 1) || (SsnakeXY[1, 0] == 1) || (SsnakeXY[0, 0] == CconsoleWidthh) || (SsnakeXY[1, 0] == CconsoleHeightt - 4)) //Checks if the snake collided wit the wall or it's self
                Ccolision = true;
            else
                if (collisionSnake(SsnakeXY[0, 0], SsnakeXY[1, 0], SsnakeXY, SsnakeLengthh, 1)) //If the snake collided with the wall, theres no point in checking if it collided with itself.
                Ccolision = true;

            return (Ccolision);
        }


        /**
        *
        *	  @name   Refresh Bar (refresh)
        *
        *	  @brief Refresh menu
        *
        *	  Refresh bar
        *
        *	  @param  [in] score [\b int]  snake coordinates
        *	  
        *	  @param  [in] speed [\b int]  index of fibonacci number in the serie
        *	  
        *	  
        **/
        public void refreshInfoBar(int Point, int Speedd)
        {
            Console.SetCursorPosition(5, 23);
            Console.Write("Score: " + Point);

            Console.SetCursorPosition(5, 24);
            Console.Write("Speed: " + Speedd);

            Console.SetCursorPosition(52, 23);
            Console.Write("Coder: Celal Enes Ayaz");

            Console.SetCursorPosition(52, 24);
            Console.Write("Version: 1.0");

            return;
        }


        /**
        *
        *	  @name   youWinScreen (win)
        *
        *	  @brief Win screen
        *
        *	  Win Screen
        *
        *	  
        **/

        public void youWinScreen()
        {
            int c = 6, e = 7;
            Console.SetCursorPosition(c, e++);
            Console.Write("'##:::'##::'#######::'##::::'##::::'##:::::'##:'####:'##::: ##:'####:");
            Console.SetCursorPosition(c, e++);
            Console.Write(". ##:'##::'##.... ##: ##:::: ##:::: ##:'##: ##:. ##:: ###:: ##: ####:");
            Console.SetCursorPosition(c, e++);
            Console.Write(":. ####::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ####: ##: ####:");
            Console.SetCursorPosition(c, e++);
            Console.Write("::. ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ## ## ##:: ##::");
            Console.SetCursorPosition(c, e++);
            Console.Write("::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##. ####::..:::");
            Console.SetCursorPosition(c, e++);
            Console.Write("::: ##:::: ##:::: ##: ##:::: ##:::: ##: ##: ##:: ##:: ##:. ###:'####:");
            Console.SetCursorPosition(c, e++);
            Console.Write("::: ##::::. #######::. #######:::::. ###. ###::'####: ##::. ##: ####:");
            Console.SetCursorPosition(c, e++);
            Console.Write(":::..::::::.......::::.......:::::::...::...:::....::..::::..::....::");
            Console.SetCursorPosition(c, e++);

            waitForAnyKey();
            Console.Clear(); //clear the console
            return;
        }


        /**
        *
        *	  @name   Game Over Screen 
        *
        *	  @brief Game Over Screen
        *
        *	  Game Over Screen
        *
        *	 
        **/
        public void gameOverScreen()
        {
            int s = 17, j = 3;

            //http://www.network-science.de/ascii/ <- Ascii Art Gen

            Console.SetCursorPosition(s, j++);
            Console.Write(":'######::::::'###::::'##::::'##:'########:\n");
            Console.SetCursorPosition(s, j++);
            Console.Write("'##... ##::::'## ##::: ###::'###: ##.....::\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(" ##:::..::::'##:. ##:: ####'####: ##:::::::\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(" ##::'####:'##:::. ##: ## ### ##: ######:::\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(" ##::: ##:: #########: ##. #: ##: ##...::::\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(" ##::: ##:: ##.... ##: ##:.:: ##: ##:::::::\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(". ######::: ##:::: ##: ##:::: ##: ########:\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(":......::::..:::::..::..:::::..::........::\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(":'#######::'##::::'##:'########:'########::'####:\n");
            Console.SetCursorPosition(s, j++);
            Console.Write("'##.... ##: ##:::: ##: ##.....:: ##.... ##: ####:\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(" ##:::: ##: ##:::: ##: ##::::::: ##:::: ##: ####:\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(" ##:::: ##: ##:::: ##: ######::: ########::: ##::\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(" ##:::: ##:. ##:: ##:: ##...:::: ##.. ##::::..:::\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(" ##:::: ##::. ## ##::: ##::::::: ##::. ##::'####:\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(". #######::::. ###:::: ########: ##:::. ##: ####:\n");
            Console.SetCursorPosition(s, j++);
            Console.Write(":.......::::::...:::::........::..:::::..::....::\n");

            waitForAnyKey();
            Console.Clear(); //clear the console
            return;
        }

        /**
        *
        *	  @name   Start Game (start)
        *
        *	  @brief Start Game 
        *
        *	  Collision Detection
        *
        *	  @param  [in] snakeXY [\b int[,]]  snake coordinates
        *	  
        *	  @param  [in] consoleWidth [\b int]  console witdh
        *	  
        *	  @param  [in] consoleHeight [\b int]  console Height
        *	  
        *	   @param  [in] snakeLength [\b int]  snake length
        *	   
        *	   @param  [in] direction [\b Console Key]  direction
        *	   
        *
        *	   
        *	   @param  [in] score [\b int]  score
        *	   
        *	   @param  [in] speed [\b int]  speed
        **/



        //Messy, need to clean this function up
        public void startGame(int[,] SsnakeXY, int[] FfoodXY, int CconsoleWidth, int CconsoleHeight, int SSsnakeLength, ConsoleKey DDdirection, int sCCcore, int speEEed)
        {
            bool gamerOver = false;
            ConsoleKey oldDirection = ConsoleKey.NoName;
            bool canChangeDirection = true;
            int gamerOver2 = 1;
            do
            {
                if (canChangeDirection)
                {
                    oldDirection = DDdirection;
                    DDdirection = checkKeyspress(DDdirection);
                }

                if (oldDirection != DDdirection)//Temp fix to prevent the snake from colliding with itself
                    canChangeDirection = false;

                if (true) //haha, it moves according to how fast the computer running it is...
                {
                    //Console.SetCursorPosition(1,1);
                    //Console.Write("%d - %d",clock() , endWait);
                    move(SsnakeXY, SSsnakeLength, DDdirection);
                    canChangeDirection = true;


                    if (eatFood(SsnakeXY, FfoodXY))
                    {
                        generateFood(FfoodXY, CconsoleWidth, CconsoleHeight, SsnakeXY, SSsnakeLength); //Generate More Food
                        SSsnakeLength++;
                        switch (speEEed)
                        {
                            case 90:
                                sCCcore += 5;
                                break;
                            case 80:
                                sCCcore += 7;
                                break;
                            case 70:
                                sCCcore += 9;
                                break;
                            case 60:
                                sCCcore += 12;
                                break;
                            case 50:
                                sCCcore += 15;
                                break;
                            case 40:
                                sCCcore += 20;
                                break;
                            case 30:
                                sCCcore += 23;
                                break;
                            case 20:
                                sCCcore += 25;
                                break;
                            case 10:
                                sCCcore += 30;
                                break;
                        }

                        refreshInfoBar(sCCcore, speEEed);
                    }
                    Thread.Sleep(speEEed);
                }

                gamerOver = collisionDetection(SsnakeXY, CconsoleWidth, CconsoleHeight, SSsnakeLength);

                if (SSsnakeLength >= SNAKE_ARRAY_SIZE - 5) //Just to make sure it doesn't get longer then the array size & crash
                {
                    gamerOver2 = 2;//You Win! <- doesn't seem to work - NEED TO FIX/TEST THIS
                    sCCcore += 1500; //When you win you get an extra 1500 points!!!
                }

            } while (!gamerOver);

            switch (gamerOver2)
            {
                case 1:
                    gameOverScreen();

                    break;
                case 2:
                    youWinScreen();
                    break;
            }



            return;
        }

        /**
        *
        *	  @name   Load Environment (environment)
        *
        *	  @brief Load environment
        *
        *	  Load Environment
        *
        *	  @param  [in] consoleWitdh [\b int]  consoleWitdh
        *	  
        *	  @param  [in] consoleHeight [\b int]  consoleHeight
        *	  
        *	  
        **/
        public void loadEnviroment(int consOOoleWidth, int SiuconsoleHeight)//This can be done in a better way... FIX ME!!!! Also i think it doesn't work properly in ubuntu <- Fixed
        {

            int E = 1, B = 1;
            int rectanglesiuHeight = SiuconsoleHeight - 4;
            Console.Clear(); //clear the console

            Console.SetCursorPosition(E, B); //Top left corner

            for (; B < rectanglesiuHeight; B++)
            {
                Console.SetCursorPosition(E, B); //Left Wall 
                Console.Write("#", WALL);

                Console.SetCursorPosition(consOOoleWidth, B); //Right Wall
                Console.Write("#", WALL);
            }

            B = 1;
            for (; E < consOOoleWidth + 1; E++)
            {
                Console.SetCursorPosition(E, B); //Left Wall 
                Console.Write("#", WALL);

                Console.SetCursorPosition(E, rectanglesiuHeight); //Right Wall
                Console.Write("#", WALL);
            }


            return;
        }

        /**
        *
        *	  @name   Load Snake (Snake)
        *
        *	  @brief Load Snake
        *
        *	  Load Environment
        *
        *	  @param  [in] snakeXY [\b int]  snakeXY
        *	  
        *	  @param  [in] snakeLength [\b int]  snakeLength
        *	  
        *	  
        **/
        public void loadSnake(int[,] snNsakeXY, int snNsakeLength)
        {
            int b;
            /*
            First off, The snake doesn't actually have enough XY coordinates (only 1 - the starting location), thus we use
            these XY coordinates to "create" the other coordinates. For this we can actually use the function used to move the snake.
            This helps create a "whole" snake instead of one "dot", when someone starts a game.
            */
            //moveSnakeArray(snakeXY, snakeLength); //One thing to note ATM, the snake starts of one coordinate to whatever direction it's pointing...

            //This should print out a snake :P
            for (b = 0; b < snNsakeLength; b++)
            {
                Console.SetCursorPosition(snNsakeXY[0, b], snNsakeXY[1, b]);
                Console.Write("%c", SNAKE_BODY); //Meh, at some point I should make it so the snake starts off with a head...
            }

            return;
        }

        /* NOTE, This function will only work if the snakes starting direction is left!!!! 
        Well it will work, but the results wont be the ones expected.. I need to fix this at some point.. */

        /**
        *
        *	  @name   prepairSnakeArray (prepair snake)
        *
        *	  @brief Prepair Snake Array
        *
        *	  Prepair Snake Array
        *
        *	  @param  [in] snakeXY [\b int]  snakeXY
        *	  
        *	  @param  [in] snakeLength [\b int]  snakeLength
        *	  
        *	  
        **/
        public void prepairSnakeArray(int[,] snakEEeXY, int SsnNakeLength)
        {
            int e;
            int snakessX = snakEEeXY[0, 0];
            int snakessY = snakEEeXY[1, 0];

            // this is used in the function move.. should maybe create a function for it...



            for (e = 1; e <= SsnNakeLength; e++)
            {
                snakEEeXY[0, e] = snakessX + e;
                snakEEeXY[1, e] = snakessY;
            }

            return;
        }

        /**
        *
        *	  @name   Load Game (Load Game)
        *
        *	  @brief Load Game
        *
        *	  Load Game
        *
        *	  
        **/
        //This function loads the enviroment, snake, etc
        public void loadGame()
        {
            int[,] snakessXY = new int[2, SNAKE_ARRAY_SIZE]; //Two Dimentional Array, the first array is for the X coordinates and the second array for the Y coordinates

            int snakessLength = 4; //Starting Length

            ConsoleKey directionNs = ConsoleKey.LeftArrow; //DO NOT CHANGE THIS TO RIGHT ARROW, THE GAME WILL INSTANTLY BE OVER IF YOU DO!!! <- Unless the prepairSnakeArray function is changed to take into account the direction....

            int[] FbfoodXY = { 5, 5 };// Stores the location of the food

            int score = 0;
            //int level = 1;

            //Window Width * Height - at some point find a way to get the actual dimensions of the console... <- Also somethings that display dont take this dimentions into account.. need to fix this...
            int cCconsoleWidth = 80;
            int cCconsoleHeight = 25;

            int spPEeed = getGameSpeed();

            //The starting location of the snake
            snakessXY[0, 0] = 40;
            snakessXY[1, 0] = 10;

            loadEnviroment(cCconsoleWidth, cCconsoleHeight); //borders
            prepairSnakeArray(snakessXY, snakessLength);
            loadSnake(snakessXY, snakessLength);
            generateFood(FbfoodXY, cCconsoleWidth, cCconsoleHeight, snakessXY, snakessLength);
            refreshInfoBar(score, spPEeed); //Bottom info bar. Score, Level etc
            startGame(snakessXY, FbfoodXY, cCconsoleWidth, cCconsoleHeight, snakessLength, directionNs, score, spPEeed);

            return;
        }

        //**************MENU STUFF**************//

        /**
        *
        *	  @name   menuSelector (menuSelector)
        *
        *	  @brief menu Selector
        *
        *	  Menu Selector
        *
        *	  @param  [in] x [\b int]  x
        *	  
        *	  @param  [in] y [\b int]  y
        *	  
        *	  @param  [in] yStart [\b int]  yStart
        *	  
        *	  
        **/
        public int menuSelector(int E, int B, int yStarttt)
        {
            char keys;
            int v = 0;
            E = E - 2;
            Console.SetCursorPosition(E, yStarttt);

            Console.Write(">");

            Console.SetCursorPosition(1, 1);


            do
            {
                keys = (char)waitForAnyKey();
                //Console.Write("%c %d", key, (int)key);
                if (keys == (char)UP_ARROW)
                {
                    Console.SetCursorPosition(E, yStarttt + v);
                    Console.Write(" ");

                    if (yStarttt >= yStarttt + v)
                        v = B - yStarttt - 2;
                    else
                        v--;
                    Console.SetCursorPosition(E, yStarttt + v);
                    Console.Write(">");
                }
                else
                    if (keys == (char)DOWN_ARROW)
                {
                    Console.SetCursorPosition(E, yStarttt + v);
                    Console.Write(" ");

                    if (v + 2 >= B - yStarttt)
                        v = 0;
                    else
                        v++;
                    Console.SetCursorPosition(E, yStarttt + v);
                    Console.Write(">");
                }
                //Console.SetCursorPosition(1,1);
                //Console.Write("%d", key);
            } while (keys != (char)ENTER_KEY); //While doesn't equal enter... (13 ASCII code for enter) - note ubuntu is 10
            return (v);
        }

        /**
        *
        *	  @name   Welcome Art (Welcome Art)
        *
        *	  @brief Welcome Art
        *
        *	  Welcome Art
        *
        *	  
        **/
        public void welcomeArt()
        {
            Console.Clear(); //clear the console
                             //Ascii art reference: http://www.chris.com/ascii/index.php?art=animals/reptiles/snakes
            Console.Write("\n");
            Console.Write("\t\t    _________         _________ 			\n");
            Console.Write("\t\t   /         \\       /         \\ 			\n");
            Console.Write("\t\t  /  /~~~~~\\  \\     /  /~~~~~\\  \\ 			\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  | 			\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  | 			\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  |         /	\n");
            Console.Write("\t\t  |  |     |  |     |  |     |  |       //	\n");
            Console.Write("\t\t (o  o)    \\  \\_____/  /     \\  \\_____/ / 	\n");
            Console.Write("\t\t  \\__/      \\         /       \\        / 	\n");
            Console.Write("\t\t    |        ~~~~~~~~~         ~~~~~~~~ 		\n");
            Console.Write("\t\t    ^											\n");
            Console.Write("\t		Welcome To The Snake Game!			\n");
            Console.Write("\t			    Press Any Key To Continue...	\n");
            Console.Write("\n");

            waitForAnyKey();
            return;
        }

        /**
        *
        *	  @name   Controls (Controls)
        *
        *	  @brief Controls of game
        *
        *	  Game Control
        *
        *	  
        **/
        public void controls()
        {
            int e = 10, b = 5;
            Console.Clear(); //clear the console
            Console.SetCursorPosition(e, b++);
            Console.Write("Controls\n");
            Console.SetCursorPosition(e++, b++);
            Console.Write("Use the following arrow keys to direct the snake to the food: ");
            Console.SetCursorPosition(e, b++);
            Console.Write("Right Arrow");
            Console.SetCursorPosition(e, b++);
            Console.Write("Left Arrow");
            Console.SetCursorPosition(e, b++);
            Console.Write("Top Arrow");
            Console.SetCursorPosition(e, b++);
            Console.Write("Bottom Arrow");
            Console.SetCursorPosition(e, b++);
            Console.SetCursorPosition(e, b++);
            Console.Write("P & Esc pauses the game.");
            Console.SetCursorPosition(e, b++);
            Console.SetCursorPosition(e, b++);
            Console.Write("Press any key to continue...");
            waitForAnyKey();
            return;
        }

        /**
        *
        *	  @name   exitXY (exit)
        *
        *	  @brief Exit from game
        *
        *	  Exit Game
        *
        *	  
        **/
        public void exitYN()
        {
            char press;
            Console.SetCursorPosition(9, 8);
            Console.Write("Are you sure you want to exit(Y/N)\n");

            do
            {
                press = (char)waitForAnyKey();
                press = char.ToLower(press);
            } while (!(press == 'y' || press == 'n'));

            if (press == 'y')
            {
                Console.Clear(); //clear the console
                Environment.Exit(1);
            }
            return;
        }

        /**
        *
        *	  @name  Main Menu (Main Menu)
        *
        *	  @brief Main Menu
        *
        *	  Main Menu
        *
        *	  
        **/
        public int mainMenu()
        {
            int a = 10, b = 5;
            int ab = b;

            int selectttion;

            Console.Clear(); //clear the console
                             //Might be better with arrays of strings???
            Console.SetCursorPosition(a, b++);
            Console.Write("New Game\n");
            Console.SetCursorPosition(a, b++);
            Console.Write("High Scores\n");
            Console.SetCursorPosition(a, b++);
            Console.Write("Controls\n");
            Console.SetCursorPosition(a, b++);
            Console.Write("Exit\n");
            Console.SetCursorPosition(a, b++);

            selectttion = menuSelector(a, b, ab);

            return (selectttion);
        }

        //**************END MENU STUFF**************//





    }
}

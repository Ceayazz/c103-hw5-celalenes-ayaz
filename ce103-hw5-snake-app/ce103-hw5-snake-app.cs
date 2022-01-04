	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using ce103_hw5_snake_functions;

	namespace ce103_hw5_snake_app
	{
		internal class ce103_console_app
		{
			static void Main(string[] args)
			{
				ce103snakegamecode snake = new ce103snakegamecode();
				snake.welcomeArt();

				do
				{
					switch (snake.mainMenu())
					{
						case 0:
							snake.loadGame();
							break;
						case 1:
						
							break;
						case 2:
							snake.controls();
							break;
						case 3:
							snake.exitYN();
							break;
					}
				} while (true);    //
			}

        
		}
	}

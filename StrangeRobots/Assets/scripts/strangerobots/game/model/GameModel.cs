﻿//Storage of data that reflects how the player is doing

using System;

namespace strange.examples.strangerobots.game
{
	public class GameModel : IGameModel
	{
		public GameModel ()
		{
		}

		#region IGameModel implementation

		public void Reset ()
		{
			score = 0;
			level = 0;
			lives = initLives;
		}

		public int score { get; set; }

		public int lives { get; set; }

		public int initLives { get; set; }

		public int level { get; set; }

		public bool levelInProgress{ get; set; }

		#endregion
	}
}


﻿//API for a device that spawns things.

using System;

namespace strange.examples.strangerobots.game
{
	public interface ISpawner
	{
		//Start spawning
		void Start();

		//Stop spawning
		void Stop();
	}
}


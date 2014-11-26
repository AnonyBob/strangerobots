﻿//Instantiates and binds a special GAME_FIELD GameObject to parent the rest of the game elements.

using System;
using strange.extensions.command.impl;
using UnityEngine;
using strange.extensions.context.api;

namespace strange.examples.strangerobots.game
{
	public class CreateGameFieldCommand : Command
	{
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{ get; set; }
		
		[Inject]
		public IGameConfig config { get; set; }
		
		[Inject]
		public IGameModel gameModel{ get; set; }

		public override void Execute ()
		{
			Vector3 center = Vector3.zero;

			//setup the game field
			if (injectionBinder.GetBinding<GameObject> (GameElement.GAME_FIELD) == null)
			{
				GameObject gameField = new GameObject (GameElement.GAME_FIELD.ToString());
				gameField.transform.localPosition = center;
				gameField.transform.parent = contextView.transform;

				GameObject evenTile =  Resources.Load<GameObject> ("EvenTile");
				GameObject oddTile =  Resources.Load<GameObject> ("OddTile");

				//Create tiles
				ILevelConfig level = config.getLevel(gameModel.level);
				int w = level.width;
				int h = level.height;

				float halfW = (float)w * .5f;
				float halfH = (float)h * .5f;
				float mod = 5f;

				int a = 0;
				for (int x = 0; x < w; x++) {
					for (int y = 0; y < h; y++) {
						a++;
						float xPos = ((float)x + .5f - halfW) * mod;
						float yPos = ((float)y + .5f - halfH) * mod;

						GameObject tile = (a % 2 == 0) ? evenTile : oddTile;
						GameObject newTile = GameObject.Instantiate(tile, new Vector3(xPos, 0f, yPos), Quaternion.identity) as GameObject;
						newTile.transform.parent = gameField.transform;
					}
				}

				//Bind it so we can use it elsewhere
				injectionBinder.Bind<GameObject> ().ToValue (gameField).ToName (GameElement.GAME_FIELD);
			}
		}
	}
}


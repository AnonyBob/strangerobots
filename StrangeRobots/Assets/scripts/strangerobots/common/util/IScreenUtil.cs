﻿//Interface for a service which provides camera utilities
//(see ScreenUtil)

using System;
using UnityEngine;

namespace strange.examples.strangerobots
{
	public interface IScreenUtil
	{
		Rect GetScreenRect(float x, float y, float width, float height);

		bool IsInCamera(GameObject go);

		void TranslateToFarSide(GameObject go);

		Vector3 RandomPositionOnLeft();

		Vector3 GetAnchorPosition(ScreenAnchor horizontal, ScreenAnchor vertical);

		Vector3 FillFrustum(float width, float height);
	}
}


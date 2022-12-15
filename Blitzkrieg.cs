﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Ufast {

	public enum Direction { Left, None, Right };
	
	/// <summary>
	/// Verifies if the specified int value belongs to the interval (min, max).
	/// </summary>
	/// <param name="min">Minimum.</param>
	/// <param name="max">Max.</param>
	/// <param name="value">Value.</param>
	/// <param name="inclusive">If set to <c>true</c>, allows 
	/// the specified value to be on the boundaries.</param>
	public static bool Between (float min, float max, float value, bool inclusive = false) {
		if (inclusive) {
			return (
			    (min <= value) &&
			    (value <= max)
			);
		} else {
			return (
			    (min < value) &&
			    (value < max)
			);
		}
	}

	/// <summary>
	/// Verifies if the specified float value belongs to the interval (min, max).
	/// </summary>
	/// <param name="min">Minimum.</param>
	/// <param name="max">Max.</param>
	/// <param name="value">Value.</param>
	/// <param name="inclusive">If set to <c>true</c>, allows 
	/// the specified value to be on the boundaries.</param>
	public static bool Between (int min, int max, int value, bool inclusive = false) {
		return Between ((float)min, (float)max, (float)value, inclusive);
	}

	/// <summary>
	/// Gets the game object position translated by WorldToViewportPoint, to the interval [[0,0],[1,1]].
	/// </summary>
	/// <returns>Returns a Vector2 with two values from 0f to 1f and
	/// uses the World to Viewport Point function to do so.
	/// Basically, (0,0) is the lower left, (1,1) is the top right;
	/// Simply put, 0.5 is the middle of the screen.</returns>
	/// <param name="theObject">GameObject.</param>
	public static Vector2 GetGameObjectPosition (GameObject theObject) {
		return (
		    new Vector2 (
				(float)Camera.main.WorldToViewportPoint (theObject.transform.position).x,
				(float)Camera.main.WorldToViewportPoint (theObject.transform.position).y
		    )
		);
	}

	/// <summary>
	/// Gets the game object X translated by WorldToViewportPoint offset by 0.5, to the interval [-0.5, 0.5].
	/// </summary>
	/// <returns>The game object position after setting 0 as the center of the screen.</returns>
	/// <param name="theObject">GameObject.</param>
	public static float GetGameObjectXFromCenter (GameObject theObject) {
		return (float) System.Math.Round((decimal)(GetGameObjectPosition (theObject) [0] - 0.5f), 2);
	}

	/// <summary>
	/// Gets the game object Y translated by WorldToViewportPoint offset by 0.5, to the interval [-0.5, 0.5].
	/// </summary>
	/// <returns>The game object position after setting 0 as the center of the screen.</returns>
	/// <param name="theObject">GameObject.</param>
	public static float GetGameObjectYFromCenter (GameObject theObject) {
		return (float) System.Math.Round((decimal)(GetGameObjectPosition (theObject) [0] - 0.5f), 2);
	}

	/// <summary>
	/// Returns a random boolean.
	/// </summary>
	/// <returns><c>True</c> or <c>false</c>.</returns>
	public static bool GetRandomBoolean () {
		return (Random.value > 0.5f);
	}

	/// <summary>
	/// Returns a random direction.
	/// </summary>
	/// <returns><c>Left</c> or <c>Right</c>.</returns>
	public static Direction GetRandomDirection () {
		return  (Direction)Random.Range (0, 2);
	}

	/// <summary>
	/// Returns a Vector2 based on the mouse X and Y.
	/// </summary>
	/// <returns>The Vector2.</returns>
	/// <param name="mouseX">X.</param>
	/// <param name="mouseY">Y.</param>
	public static Vector2 CastRayToClick (float mouseX, float mouseY) {
		return new Vector2 (
			Camera.main.ScreenToViewportPoint (new Vector3 (mouseX, mouseY, 0)).x,
			Camera.main.ScreenToViewportPoint (new Vector3 (mouseX, mouseY, 0)).y
		);
	}

	/// <summary>
	/// Returns the direction of a Horizontal Swipe.
	/// </summary>
	/// <returns>The direction of the horizontal swipe</returns>
	/// <param name="start">Start of the Swipe.</param>
	/// <param name="end">End of the Swipe.</param>
	/// <param name="minDist">Minimum distance to evaluate.</param>
	public static Direction EvalHorizontalSwipe (float start, float end, float minDist) {
		float dragDistance = (end - start) * 100;

		if (Mathf.Abs (dragDistance) > minDist) {
			if (dragDistance > 0) {
				return Direction.Right;
			} else if (dragDistance < 0) {
				return Direction.Left;
			}
		}

		return Direction.None;
	}
}

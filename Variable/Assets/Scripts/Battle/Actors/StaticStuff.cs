using UnityEngine;
using System.Collections;

public static class StaticStuff {

	public const int STRENGTH_INCREMENT = 5;

	public static int level;
	public static int damageStrength;

	public static void GainLevel()
	{
		level++;
		damageStrength += STRENGTH_INCREMENT;
	}
}

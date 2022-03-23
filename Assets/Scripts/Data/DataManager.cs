using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
	public static void SaveAmountOfGames()
	{
		PlayerPrefs.SetInt("AmountOfGames", PlayerPrefs.GetInt("AmountOfGames", 0) + 1);
		PlayerPrefs.Save();
	}

	public static int GetAmountOfGames()
	{
		return PlayerPrefs.GetInt("AmountOfGames", 0);
	}

	public static void SaveAmountOfGamesWon()
	{
		PlayerPrefs.SetInt("AmountOfGamesWon", PlayerPrefs.GetInt("AmountOfGamesWon", 0) + 1);
		PlayerPrefs.Save();
	}

	public static int GetAmountOfGamesWon()
	{
		return PlayerPrefs.GetInt("AmountOfGamesWon", 0);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance { get; private set; }

	[Header("MainMenu")]
	[SerializeField] private GameObject MainMenu;
	[SerializeField] private Text GamesPlayedText;
	[SerializeField] private Text GamesWonText;

	[Header("Game")]
	[SerializeField] private GameObject Game;
	[SerializeField] private Text HPText;
	[SerializeField] private Text AmountOfBombText;

	[Header("GameOver")]
	[SerializeField] private GameObject GameOver;
	[SerializeField] private Text GameResultText;



	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		Instance.LaunchMainMenu();
	}

	public void LaunchMainMenu()
	{
		Instance.MainMenu.SetActive(true);
		Instance.Game.SetActive(false);
		Instance.GameOver.SetActive(false);

		Instance.GamesPlayedText.text = DataManager.GetAmountOfGames().ToString();
		Instance.GamesWonText.text = DataManager.GetAmountOfGamesWon().ToString();
	}

	public void LaunchGame()
	{
		DataManager.SaveAmountOfGames();

		Instance.MainMenu.SetActive(false);
		Instance.Game.SetActive(true);
		Instance.GameOver.SetActive(false);

		Instance.HPText.text = PlayerModel.Instance.GetAmountOfHealthPoints().ToString();
		Instance.AmountOfBombText.text = BombController.Instance.GetNumberOfBombs().ToString();
	}

	public void UpdateGameUI()
	{
		Instance.HPText.text = PlayerModel.Instance.GetAmountOfHealthPoints().ToString();
		Instance.AmountOfBombText.text = BombController.Instance.GetNumberOfBombs().ToString();
	}

	public void LaunchGameOver(bool isWon)
	{
		Instance.MainMenu.SetActive(false);
		Instance.Game.SetActive(false);
		Instance.GameOver.SetActive(true);

		if (isWon)
		{
			Instance.GameResultText.text = "You Won!" + '\n' + "Play again!";
		}
		else
		{
			Instance.GameResultText.text = "You lose!" + '\n' + "Play again!";
		}
	}

	public void OnClickRestartButton()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

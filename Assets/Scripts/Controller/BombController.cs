using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BombView))]
public class BombController : MonoBehaviour
{
	public static BombController Instance { get; private set; }

	[Header("Number of bombs")]
	[SerializeField] private int maxNumberOfBombs = 1;

	[Header("Bomb cooldown")]
	[SerializeField] private float bombCooldown;


	private	void Awake()
	{
		Instance = this;
	}

	private void IncreaseBombAmount()
	{
		maxNumberOfBombs++;
	}

	public void DecreaseBombAmount()
	{
		maxNumberOfBombs--;
	}

	public int GetNumberOfBombs()
	{
		return maxNumberOfBombs;
	}

	public void OnButtonClick()
	{
		BombView.Instance.CreateBomb();	
	}

	public void BombRefresh()
	{
		StartCoroutine(BombCooldownCoroutine());
	}

	private IEnumerator BombCooldownCoroutine()
	{
		GetComponent<Animator>().Play("BombTimer");
		yield return new WaitForSecondsRealtime(bombCooldown);
		Instance.IncreaseBombAmount(); 
		GetComponent<Animator>().Play("Base");

		UIManager.Instance.UpdateGameUI();
	}
}

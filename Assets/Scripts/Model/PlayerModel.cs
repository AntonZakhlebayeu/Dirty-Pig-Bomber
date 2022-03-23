using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
	public static PlayerModel Instance { get; private set; }

	[Header("Health")]
	private int healthPoints = 3;

	[Header("Speed")]
	[SerializeField] private float walkSpeed;

	private void Awake()
	{
		Instance = this;
	}

	public void DecreaseHealthPoints()
	{
		healthPoints--;
		if (healthPoints > 0)
		{
			GetComponent<Animator>().Play("Hit");
		}
		else
		{
			StartCoroutine(DeathCoroutine());
		}
	}

	private IEnumerator DeathCoroutine()
	{
		GetComponent<Animator>().Play("Death");
		GetComponent<CircleCollider2D>().enabled = false;
		yield return new WaitForSecondsRealtime(0.5f);
		Destroy(this.gameObject);
		UIManager.Instance.LaunchGameOver(false);
	}

	public int GetAmountOfHealthPoints()
	{
		return healthPoints;
	}

	public float GetWalkSpeed()
	{
		return walkSpeed;
	}
}
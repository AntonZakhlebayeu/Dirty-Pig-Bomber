using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DogModel : EnemyModel
{
	public static DogModel Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
		Instance.aiPath = gameObject.GetComponent<AIPath>();
		Instance.DisableMovement();
	}

	public override void DisableMovement()
	{
		Instance.aiPath.isStopped = true;
	}

	public override void EnableMovement()
	{
		Instance.aiPath.isStopped = false;
	}


	protected override void OnTriggerEnter2D(Collider2D other)
	{
		if (other.TryGetComponent(out PlayerModel Player) && !Instance.isStunned)
		{
			Instance.EnableMovement();
		}
	}

	protected override void OnTriggerExit2D(Collider2D other)
	{
		if (other.TryGetComponent(out PlayerModel Player))
		{
			Instance.DisableMovement();
			DogView.Instance.SetIdleState();
		}
	}

	protected override void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && !Instance.isStunned)
		{
			PlayerModel.Instance.DecreaseHealthPoints();
			StartCoroutine(AttackCooldown());
			UIManager.Instance.UpdateGameUI();
		}
	}

	protected override IEnumerator AttackCooldown()
	{
		Instance.DisableMovement();
		yield return new WaitForSecondsRealtime(cooldown);
		Instance.EnableMovement();
	}

	public override void DecreaseHealthPoints()
	{
		health--;
		if (health > 0)
		{
			GetComponent<Animator>().Play("Hit");
		}
		else
		{
			DogView.Instance.SetStunState();
			StartCoroutine(StunCoroutine());
		}
	}

	protected override IEnumerator StunCoroutine()
	{
		if (GameObject.FindGameObjectWithTag("Farmer").GetComponent<FarmerModel>().isStunned)
		{
			yield return new WaitForSecondsRealtime(0.5f);
			DataManager.SaveAmountOfGamesWon();
			UIManager.Instance.LaunchGameOver(true);
		}
		else
		{
			GetComponent<Animator>().Play("Stun");
			Instance.isStunned = true;
			Instance.DisableMovement();
			yield return new WaitForSecondsRealtime(10f);
			Instance.EnableMovement();
			Instance.health = 3;
			GetComponent<Animator>().Play("Base");
		}
	}
}

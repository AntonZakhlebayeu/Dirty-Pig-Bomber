using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombView : MonoBehaviour
{
	public static BombView Instance { get; private set; }

	[SerializeField] private GameObject bombObject;
	private GameObject spawnedBomb;

	private void Awake()
	{
		Instance = this;
	}

	public void CreateBomb()
	{
		if (BombController.Instance.GetNumberOfBombs() != 0)
		{
			BombController.Instance.DecreaseBombAmount();
			Transform Spawnpoint = PlayerView.Instance.GetTransform();
			spawnedBomb = Instantiate(bombObject, new Vector2(Spawnpoint.position.x, Spawnpoint.position.y), Quaternion.identity);
			spawnedBomb.GetComponent<CircleCollider2D>().enabled = false;
			BombModel.Instance.Explode();

			BombController.Instance.BombRefresh();
			UIManager.Instance.UpdateGameUI();
		}
		else
		{
			GetComponent<Animator>().Play("BombNotReady");
		}
	}
}

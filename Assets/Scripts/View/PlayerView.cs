using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
	public static PlayerView Instance { get; private set; }

	public Sprite[] pigSprites;

	[SerializeField] private Transform playerSpawnpoint;
	[SerializeField] private GameObject playerObject;

	private SpriteRenderer _spriteRenderer;

	private GameObject spawnedPlayer;

	private void Awake()
	{
		Instance = this;
		spawnedPlayer = Instantiate(playerObject, playerSpawnpoint);
	}

	private void Start()
	{
		_spriteRenderer = spawnedPlayer.GetComponent<SpriteRenderer>();
	}

	public Transform GetTransform()
	{
		return spawnedPlayer.GetComponent<Transform>();
	}

	public void SetPlayerSprite(Vector2 direction)
	{
		if (direction.x > 0.5)
		{
			_spriteRenderer.sprite = pigSprites[(int)DirectionState.Right];
		}
		else if (direction.x < -0.5)
		{
			_spriteRenderer.sprite = pigSprites[(int)DirectionState.Left];
		}

		if (direction.y > 0.5)
		{
			_spriteRenderer.sprite = pigSprites[(int)DirectionState.Up];
		}
		else if (direction.y < -0.5)
		{
			_spriteRenderer.sprite = pigSprites[(int)DirectionState.Down];
		}
	}

	public enum DirectionState
	{
		Right,
		Left,
		Up,
		Down
	}
}



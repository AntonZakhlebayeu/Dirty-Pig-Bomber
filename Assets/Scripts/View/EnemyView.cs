using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public abstract class EnemyView : MonoBehaviour
{
	public static EnemyView Instance { get; private set; }

	protected DirectionState _direction = DirectionState.Right;

	[SerializeField] protected Sprite[] enemySpritesChill;
	[SerializeField] protected Sprite[] enemySpritesAttack;
	[SerializeField] protected Sprite[] enemySpritesStun;


	[SerializeField] protected Transform enemySpawnpoint;
	[SerializeField] protected GameObject enemyObject;

	protected SpriteRenderer _spriteRenderer;

	public abstract Transform GetTransform();

	public abstract void SetIdleState();
	public abstract void SetStunState();

	private void Awake()
	{
		Instance = this;
	}


	protected enum DirectionState
	{
		Right,
		Left,
		Up,
		Down
	}
}

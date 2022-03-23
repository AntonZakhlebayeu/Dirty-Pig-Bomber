using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class DogView : EnemyView
{
    public static DogView Instance { get; private set; }

    private GameObject spawnedDog;

	private void Awake()
	{
		Instance = this;
		spawnedDog = Instantiate(enemyObject, enemySpawnpoint);
	}

	private void Start()
	{
		_spriteRenderer = spawnedDog.GetComponent<SpriteRenderer>();
		Instance.SetIdleState();
	}

    public override Transform GetTransform()
    {
        return spawnedDog.GetComponent<Transform>();
    }

	public override void SetIdleState()
	{
		_spriteRenderer.sprite = enemySpritesChill[(int)_direction];
	}

	public override void SetStunState()
	{
		_spriteRenderer.sprite = enemySpritesStun[(int)_direction];
	}

    private void Update()
	{
        if (Math.Abs(DogModel.Instance.aiPath.velocity.x) > Math.Abs(DogModel.Instance.aiPath.velocity.y) && DogModel.Instance.aiPath.velocity.x > 0 && !DogModel.Instance.aiPath.isStopped)
		{
			_direction = DirectionState.Right;
			_spriteRenderer.sprite = enemySpritesAttack[(int)DirectionState.Right];
		}
		else if(Math.Abs(DogModel.Instance.aiPath.velocity.x) > Math.Abs(DogModel.Instance.aiPath.velocity.y) && DogModel.Instance.aiPath.velocity.x < 0 && !DogModel.Instance.aiPath.isStopped)
		{
			_direction = DirectionState.Left;
			_spriteRenderer.sprite = enemySpritesAttack[(int)DirectionState.Left];
		}

		if (Math.Abs(DogModel.Instance.aiPath.velocity.y) > Math.Abs(DogModel.Instance.aiPath.velocity.x) && DogModel.Instance.aiPath.velocity.y > 0 && !DogModel.Instance.aiPath.isStopped)
		{
			_direction = DirectionState.Up;
			_spriteRenderer.sprite = enemySpritesAttack[(int)DirectionState.Up];
		}
		else if (Math.Abs(DogModel.Instance.aiPath.velocity.y) > Math.Abs(DogModel.Instance.aiPath.velocity.x) &&  DogModel.Instance.aiPath.velocity.y < 0 && !DogModel.Instance.aiPath.isStopped)
		{
			_direction = DirectionState.Down;
			_spriteRenderer.sprite = enemySpritesAttack[(int)DirectionState.Down];
		}
	}
}

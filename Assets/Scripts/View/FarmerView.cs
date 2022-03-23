using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class FarmerView : EnemyView
{
    public static FarmerView Instance { get; private set; }

    private GameObject spawnedFarmer;

	public override void SetIdleState()
	{
		_spriteRenderer.sprite = enemySpritesChill[(int)_direction];
	}


	public override void SetStunState()
	{
		_spriteRenderer.sprite = enemySpritesStun[(int)_direction];
	}

	private void Awake()
	{
		Instance = this;
		spawnedFarmer = Instantiate(enemyObject, enemySpawnpoint);
	}

	private void Start()
	{
		_spriteRenderer = spawnedFarmer.GetComponent<SpriteRenderer>();
		Instance.SetIdleState();
	}

    public override Transform GetTransform()
    {
        return spawnedFarmer.GetComponent<Transform>();
    }

    private void Update()
	{
        if (Math.Abs(FarmerModel.Instance.aiPath.velocity.x) > Math.Abs(FarmerModel.Instance.aiPath.velocity.y) && FarmerModel.Instance.aiPath.velocity.x > 0 && !FarmerModel.Instance.aiPath.isStopped)
		{
			_direction = DirectionState.Right;
			_spriteRenderer.sprite = enemySpritesAttack[(int)DirectionState.Right];
		}
		else if(Math.Abs(FarmerModel.Instance.aiPath.velocity.x) > Math.Abs(FarmerModel.Instance.aiPath.velocity.y) && FarmerModel.Instance.aiPath.velocity.x < 0 && !FarmerModel.Instance.aiPath.isStopped)
		{
			_direction = DirectionState.Left;
			_spriteRenderer.sprite = enemySpritesAttack[(int)DirectionState.Left];
		}

		if (Math.Abs(FarmerModel.Instance.aiPath.velocity.y) > Math.Abs(FarmerModel.Instance.aiPath.velocity.x) && FarmerModel.Instance.aiPath.velocity.y > 0 && !FarmerModel.Instance.aiPath.isStopped)
		{
			_direction = DirectionState.Up;
			_spriteRenderer.sprite = enemySpritesAttack[(int)DirectionState.Up];
		}
		else if (Math.Abs(FarmerModel.Instance.aiPath.velocity.y) > Math.Abs(FarmerModel.Instance.aiPath.velocity.x) &&  FarmerModel.Instance.aiPath.velocity.y < 0 && !FarmerModel.Instance.aiPath.isStopped)
		{
			_direction = DirectionState.Down;
			_spriteRenderer.sprite = enemySpritesAttack[(int)DirectionState.Down];
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerView))]
public class PlayerController : MonoBehaviour
{
	public static PlayerController Instance { get; private set; }

	private Transform playerTransform;

	private float speed;
	private bool touchStart = false;
	private Vector2 pointA;
	private Vector2 pointB;

	public Transform circle;
	public Transform outerCircle;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		speed = PlayerModel.Instance.GetWalkSpeed();
		playerTransform = PlayerView.Instance.GetTransform();
	}


	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width * 0.75f)
		{
			pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

			circle.transform.position = pointA;
			outerCircle.transform.position = pointA;
			circle.GetComponent<SpriteRenderer>().enabled = true;
			outerCircle.GetComponent<SpriteRenderer>().enabled = true;
		}
		if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2)
		{
			touchStart = true;
			pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
		}
		else
		{
			touchStart = false;
		}

	}

	private void FixedUpdate()
	{
		if (touchStart)
		{
			Vector2 offset = pointB - pointA;
			Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
			moveCharacter(direction);

			circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
		}
		else
		{
			circle.GetComponent<SpriteRenderer>().enabled = false;
			outerCircle.GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	private void moveCharacter(Vector2 direction)
	{
		PlayerView.Instance.SetPlayerSprite(direction);
		playerTransform.Translate(direction * speed * Time.deltaTime);
	}

	public enum MoveState
	{
		Idle,
		Walk
	}
}
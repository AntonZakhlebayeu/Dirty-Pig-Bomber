using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombModel : MonoBehaviour
{
	public static BombModel Instance { get; private set; }

	[Header("Explode Timer")]
	[SerializeField] private float bombTimer;

	private void Awake()
	{
		Instance = this;
	}

	public void Explode()
	{
		StartCoroutine(ExplodeDelay());
	}

	private IEnumerator ExplodeDelay()
	{
		yield return new WaitForSecondsRealtime(bombTimer);
		StartCoroutine(ExplodeCoroutine());
	}

	private IEnumerator ExplodeCoroutine()
	{	
		GetComponent<Animator>().Play("Explode");
		GetComponent<CircleCollider2D>().enabled = true;
		GetComponent<ParticleSystem>().Play();
		yield return new WaitForSecondsRealtime(0.2f);
		Destroy(this.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.TryGetComponent(out PlayerModel Player))
		{
			PlayerModel.Instance.DecreaseHealthPoints();

			UIManager.Instance.UpdateGameUI();	
		}

		if(other.TryGetComponent(out FarmerModel Farmer) && !other.GetComponent<FarmerModel>().isHitted)
		{
			FarmerModel.Instance.DecreaseHealthPoints();
			other.GetComponent<FarmerModel>().isHitted = true;
		}
		else if(Farmer != null && other.GetComponent<FarmerModel>().isHitted)
		{
			other.GetComponent<FarmerModel>().isHitted = false;
		}

		if(other.TryGetComponent(out DogModel Dog) && !other.GetComponent<DogModel>().isHitted)
		{
			DogModel.Instance.DecreaseHealthPoints();
			other.gameObject.GetComponent<DogModel>().isHitted = true;
		}
		else if(Dog != null && other.GetComponent<DogModel>().isHitted)
		{
			other.gameObject.GetComponent<DogModel>().isHitted = false;
		}
	}
}

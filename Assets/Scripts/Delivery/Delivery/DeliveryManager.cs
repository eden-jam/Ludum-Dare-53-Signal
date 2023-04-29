namespace DENT
{
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class DeliveryManager : MonoBehaviour
	{
		#region Fields
		[SerializeField] private CharacterController _player = null;
		[SerializeField] private Transform _compass = null;
		[SerializeField] private List<House> _houses = null;
		private List<House> _remainHouses = null;
		private House _activeHouse = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_remainHouses = _houses;
			TargetNewQuest();
		}

		public void TargetNewQuest()
		{ 
			_activeHouse = _remainHouses[Random.Range(0, _remainHouses.Count)];
			_activeHouse.SetActive(true);
		}

		public void CompleteQuest()
		{
			UnityEngine.Debug.Log("CompleteQuest");
			_activeHouse.SetActive(false);
			_remainHouses.Remove(_activeHouse);
			if (_remainHouses.Count == 0)
			{
				Win();
			}
			else
			{
				TargetNewQuest();
			}
		}

		private void Update()
		{
			_compass.transform.forward = _activeHouse.transform.position - _player.transform.position;
		}
		
		private void Win()
		{
			UnityEngine.Debug.Log("Win");
		}
		#endregion Methods
	}
}
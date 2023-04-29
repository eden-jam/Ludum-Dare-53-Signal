namespace DENT
{
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class House : MonoBehaviour
	{
		#region Fields
		private DeliveryManager _delivery = null;
		private bool _isActive = false;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_delivery = FindObjectOfType<DeliveryManager>();
		}

		public void SetActive(bool active)
		{
			_isActive = active;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player") && _isActive)
			{
				_delivery.CompleteQuest();
			}
		}
		#endregion Methods
	}
}
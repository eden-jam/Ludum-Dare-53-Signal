namespace Eden.MV
{
	using System;
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private GameObject _fog = null;
		public void Start()
		{
			_fog.SetActive(true);
		}
	}
}
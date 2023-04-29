namespace DENT
{
	using System;
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class ParticleCollider : MonoBehaviour
	{
		#region Fields
		public Scanner Scanner = null;
		#endregion Fields

		#region Methods
		public void OnParticleCollision(GameObject other)
		{
			Scanner.OnParticleCollision(other);
		}
		#endregion Methods
	}
}
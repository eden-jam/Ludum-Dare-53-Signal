namespace DENT
{
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class Scanner : MonoBehaviour
	{
		#region 
		[SerializeField] private int _raycastCount;
		[SerializeField] private int _radarDist;
		[SerializeField] private int _fogDist;
		[SerializeField] private float _speed;
		[SerializeField] private ParticleSystem _fogRevealer = null;
		[SerializeField] private ParticleSystem _radarEmitter = null;
		#endregion Fields

		#region Methods
		public void PlaceRaycast(Vector3 position)
		{
			position.y = transform.position.y;
			for (int i = 0; i < _raycastCount; i++)
			{
				float angle = Mathf.PI * 2.0f * ((float)i / (float)_raycastCount);
				Vector3 dir = new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle));
				if (Physics.Raycast(position, dir, out RaycastHit hit, _radarDist))
				{
					EnnemyAI enemy = hit.rigidbody?.GetComponent<EnnemyAI>();
					if (enemy != null)
					{
						// TODO_Hamza enemy.IsScanned(position);
						ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
						emitParams.position = hit.point;
						emitParams.position += Vector3.up * 10.0f;
						emitParams.startSize = 20.0f;
						emitParams.startColor = Color.blue;
						_fogRevealer.Emit(emitParams, 1);
						//UnityEngine.Debug.Log(hit.point);
						UnityEngine.Debug.DrawLine(position, hit.point, Color.black, 5.0f);
						continue;
					}

					if (hit.distance < _fogDist)
					{
						ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
						emitParams.position = hit.point;
						emitParams.position += Vector3.up * 10.0f;
						_fogRevealer.Emit(emitParams, 1);
						//UnityEngine.Debug.Log(hit.point);
						UnityEngine.Debug.DrawLine(position, hit.point, Color.blue, 5.0f);
					}
					else
					{
						//UnityEngine.Debug.Log(hit.point);
						UnityEngine.Debug.DrawLine(position, hit.point, Color.green, 5.0f);
					}

					{
						ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
						emitParams.position = hit.point;
						_radarEmitter.Emit(emitParams, 1);
					}
				}
				else
				{
					UnityEngine.Debug.DrawRay(position, dir * _radarDist, Color.red, 5.0f);
				}
			}
		}

		[ContextMenu("RaycastMap")]
		public void RaycastMap()
		{
			for (int i = 0; i < _raycastCount; i++)
			{
				float angle = Mathf.PI * 2.0f * ((float)i / (float)_raycastCount);
				Vector3 dir = new Vector3(Mathf.Cos(angle), 0.0f, Mathf.Sin(angle));
				if (Physics.Raycast(transform.position, dir, out RaycastHit hit, _radarDist))
				{
					if (hit.distance < _fogDist)
					{
						ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
						emitParams.position = hit.point;
						emitParams.position += Vector3.up * 10.0f;
						_fogRevealer.Emit(emitParams, 1);
						//UnityEngine.Debug.Log(hit.point);
						UnityEngine.Debug.DrawLine(transform.position, hit.point, Color.blue, 5.0f);
					}
					else
					{
						//UnityEngine.Debug.Log(hit.point);
						UnityEngine.Debug.DrawLine(transform.position, hit.point, Color.green, 5.0f);
					}

					{
						ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
						emitParams.position = hit.point;
						_radarEmitter.Emit(emitParams, 1);
					}
				}
				else
				{
					UnityEngine.Debug.DrawRay(transform.position, dir * _radarDist, Color.red, 5.0f);
				}
			}
		}
		#endregion Methods
	}
}
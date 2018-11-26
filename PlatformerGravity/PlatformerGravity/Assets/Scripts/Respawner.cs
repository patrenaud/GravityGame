using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour 
{

	public List<Transform> m_SpawnPoints;

	public int m_Level = 1;
	

	private void OnTriggerExit(Collider aOther)
	{
		aOther.gameObject.transform.position = m_SpawnPoints[m_Level-1].position;
		aOther.gameObject.GetComponent<PlayerController>().ResetVelocity();
	}
}

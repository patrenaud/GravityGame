using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : MonoBehaviour 
{
	public GameObject m_Player;



	void Update () 
	{
		if (Vector3.Distance(transform.position, m_Player.transform.position) <= 50.0f)
		{
			transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, transform.position.z);
		}		
	}
}

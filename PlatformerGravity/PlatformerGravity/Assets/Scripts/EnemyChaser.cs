using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaser : MonoBehaviour 
{
	private Vector3 m_StartPos = new Vector3();
	private NavMeshAgent m_EnemyAgent;

	public GameObject m_Player;
	public float m_ChaseThreshold = 800.0f;

	private bool m_CanChase = true;

	private void Start()
	{
		m_StartPos = transform.position;
		m_EnemyAgent = GetComponent<NavMeshAgent>();
	}


	void Update () 
	{

		//if (Vector3.Distance(transform.position, m_Player.transform.position) <= m_ChaseThreshold)
		{
			m_EnemyAgent.SetDestination(m_Player.transform.position);

		}
	}
}

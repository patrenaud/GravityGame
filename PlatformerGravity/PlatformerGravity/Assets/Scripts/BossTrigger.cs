using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour 
{

	public GameObject m_Respawner;

	[SerializeField]
	private GameObject m_Player;
	private bool m_PowerActivated;
	private float m_Time;


	private void Update()
	{
		if(m_PowerActivated)
		{
			m_Time += Time.deltaTime;
			if(m_Time >= 5.0f)
			{
				
			}
		}
	}


	private void OnTriggerEnter(Collider aOther)
	{
		aOther.gameObject.GetComponent<PlayerController>().m_IsInPlatforms = false;
		if(m_Respawner.GetComponentInChildren<Respawner>().m_Level + 1 < m_Respawner.GetComponentInChildren<Respawner>().m_SpawnPoints.Count)
		{
			m_Respawner.GetComponentInChildren<Respawner>().m_Level += 1;
		}
		
		aOther.gameObject.GetComponent<PlayerController>().m_VerticalHoverText1.enabled = false;
		aOther.gameObject.GetComponent<PlayerController>().m_VerticalHoverText2.enabled = false;
		aOther.gameObject.GetComponent<PlayerController>().m_VerticalPowerText.enabled = false;
		aOther.gameObject.GetComponent<PlayerController>().m_CancelGravText.enabled = false;
		aOther.gameObject.GetComponent<PlayerController>().m_HoverText.enabled = false;
		aOther.gameObject.GetComponent<PlayerController>().m_BossText.enabled = true;

		m_PowerActivated = true;
	}
}

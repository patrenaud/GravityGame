using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioRelays : MonoBehaviour 
{
	public GameObject m_Boss;
	private bool m_Triggered = false;


	private void OnTriggerEnter(Collider aOther)
	{
		if(!m_Triggered)
		{
			m_Boss.GetComponent<BossLife>().m_Lives -= 1;
			m_Triggered = true;
		}
		
		Destroy(gameObject);
	}
}

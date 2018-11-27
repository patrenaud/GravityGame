using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour 
{

	public GameObject m_Respawner;

	[SerializeField]
	private GameObject m_Player;
    [SerializeField]
    private GameObject m_Boss;
	private bool m_PowerActivated;
	private float m_Time;

    private Vector3 m_CurrentScale;

    private void Start()
    {
        m_Boss.GetComponent<Transform>().localScale = m_CurrentScale;
    }

	private void Update()
	{
        m_Boss.GetComponent<Transform>().localScale -= new Vector3(0.01f, 0.01f, 0.01f);

		if(m_PowerActivated)
		{
			m_Time += Time.deltaTime;
			if(m_Time >= 5.0f)
			{
                m_Player.GetComponent<PlayerController>().SwitchGravity();
                m_Time = 0f;
                m_Boss.GetComponent<Transform>().localScale = m_CurrentScale;

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

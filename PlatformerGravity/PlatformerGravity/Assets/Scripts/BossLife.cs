using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLife : MonoBehaviour
{
	public int m_Lives = 3;
	public GameObject m_BossBehavior;
	public Text m_IntroText;

	private string m_Gratz;


	void Start () 
	{		
		m_Gratz = "YOU WIN GOOD JOB!";
	}
	

	void Update () 
	{
		if(m_Lives == 0)
		{
			Destroy(gameObject);
			m_BossBehavior.GetComponent<BossTrigger>().enabled = false;
			m_IntroText.text = m_Gratz;
		}
	}
}

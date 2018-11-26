using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 m_Offset = new Vector3();
    [SerializeField]
    private PlayerController m_Player;


	private void Start ()
    {
        SetOffset();
    }

    public void SetOffset()
    {
        if(m_Player.m_IsInPlatforms)
        {
            m_Offset.z = m_Player.transform.position.z - transform.position.z;
            m_Offset.x = 0;
            m_Offset.y = 0;
        }
        else
        {
            m_Offset.z = m_Player.transform.position.z - transform.position.z;
            m_Offset.x = m_Player.transform.position.x - transform.position.x;
            m_Offset.y = 0;
        }
    }
	

	private void Update ()
    {
        if (m_Player.m_IsInPlatforms)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, m_Player.transform.position.z - m_Offset.z);
        }
        else
        {
            transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, m_Player.transform.position.z - m_Offset.z);
        }
        
	}
}

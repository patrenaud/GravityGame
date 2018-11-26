using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHoverText : MonoBehaviour 

{

	private void OnTriggerEnter(Collider aOther)
	{
		aOther.gameObject.GetComponent<PlayerController>().m_HoverText.enabled = true;
	}
}

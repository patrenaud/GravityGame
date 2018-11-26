using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideGravityScroll : MonoBehaviour
{

    private void OnTriggerEnter(Collider aOther)
    {
        aOther.gameObject.GetComponent<PlayerController>().m_GravSidesEnabled = true;
        aOther.gameObject.GetComponent<PlayerController>().m_VerticalHoverText1.enabled = true;
        aOther.gameObject.GetComponent<PlayerController>().m_VerticalHoverText2.enabled = true;
        aOther.gameObject.GetComponent<PlayerController>().m_CancelGravText.enabled = true;
        Destroy(gameObject);
    }

        private void Update()
    {
        gameObject.transform.Rotate(Vector3.right);
    }

}

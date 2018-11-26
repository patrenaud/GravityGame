using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideGravityScroll : MonoBehaviour
{

    private void OnTriggerEnter(Collider aOther)
    {
        aOther.gameObject.GetComponent<PlayerController>().m_GravSidesEnabled = true;
        Destroy(gameObject);
    }

}

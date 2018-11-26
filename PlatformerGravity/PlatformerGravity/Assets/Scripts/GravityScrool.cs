using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScrool : MonoBehaviour
{

    private void OnTriggerEnter(Collider aOther)
    {
        aOther.gameObject.GetComponent<PlayerController>().m_GravUpEnabled = true;
        aOther.gameObject.GetComponent<PlayerController>().m_IsInPlatforms = true;
        Destroy(gameObject);
    }
}

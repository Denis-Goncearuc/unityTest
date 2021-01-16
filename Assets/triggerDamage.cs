using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDamage : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
            other.gameObject.GetComponentInParent<CoinObserver>().deleteCoin();
    }
}

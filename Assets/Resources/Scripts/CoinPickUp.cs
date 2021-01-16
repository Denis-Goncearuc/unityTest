using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Animator>().Play("idle");
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInParent<CoinObserver>().addCoin();
        Debug.Log("coin added");
        Destroy(this.gameObject);
    }
}

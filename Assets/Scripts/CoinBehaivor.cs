using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaivor : MonoBehaviour
{
    private float amount = 5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().SetScore(amount);
            Destroy(gameObject);//gameObject küçük harfle yazıldığından this.gameObject anlamına geliyor.
        }
    }
}

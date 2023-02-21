using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public LayerMask layer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(((1 << other.gameObject.layer) & layer) != 0) {
            Debug.Log("oui" + other.gameObject.layer);
        }

    }
    
}

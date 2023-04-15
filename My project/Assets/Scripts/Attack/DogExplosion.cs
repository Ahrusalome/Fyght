using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogExplosion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer != this.transform.parent.gameObject.layer && other.gameObject.layer != 8) {
            this.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Explode");
        }
    }

}
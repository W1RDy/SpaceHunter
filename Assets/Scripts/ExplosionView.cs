using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionView : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    public void ActivateExplosion()
    {
        AudioManager.instance.PlaySound("Destroy");
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 0.6f);
        Destroy(gameObject);
    }
}

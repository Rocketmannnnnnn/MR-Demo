using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.transform.root.GetComponentInChildren<Health>();
        if (health)
            health.Damage(1);
        Destroy(this.transform.root.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 10;

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
            Destroy(this.gameObject);
    }
}

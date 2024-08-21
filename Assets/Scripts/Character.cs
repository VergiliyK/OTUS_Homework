using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private HealthComponent _health;

    private void Start()
    {
        _health = this.GetComponent<HealthComponent>();
    }

    void Update()
    {
        if (!_health.Alive)
        {
            this.gameObject.SetActive(false);
        }
    }
}

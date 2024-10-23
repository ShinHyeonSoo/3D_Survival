using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int _damage;
    public float _damageRate;

    List<IDamageable> _things = new List<IDamageable>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DealDamage", 0f, _damageRate);
    }

    private void DealDamage()
    {
        for(int i = 0; i < _things.Count; ++i)
        {
            _things[i].TakePhysicalDamage(_damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamageable damagable))
        {
            _things.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damagable))
        {
            _things.Remove(damagable);
        }
    }
}

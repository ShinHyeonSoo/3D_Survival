using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : Equip
{
    public float _attackRate;
    public float _attackDistance;
    private bool _attacking;

    [Header("Resource Gathering")]
    public bool _doesGatherResources;

    [Header("Combat")]
    public bool _doesDealDamage;
    public int _damage;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void OnAttackInput()
    {
        if(!_attacking)
        {
            _attacking = true;
            _animator.SetTrigger("Attack");
            Invoke("OnCanAttack", _attackRate);
        }
    }

    private void OnCanAttack()
    {
        _attacking = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : Equip
{
    public float _attackRate;
    public float _attackDistance;
    public float _useStamina;
    private bool _attacking;

    [Header("Resource Gathering")]
    public bool _doesGatherResources;

    [Header("Combat")]
    public bool _doesDealDamage;
    public int _damage;

    private Animator _animator;
    private Camera _camera;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
    }

    public override void OnAttackInput()
    {
        if(!_attacking)
        {
            if(CharacterManager.Instance.Player._condition.UseStamina(_useStamina))
            {
                _attacking = true;
                _animator.SetTrigger("Attack");
                Invoke("OnCanAttack", _attackRate);
            }
        }
    }

    private void OnCanAttack()
    {
        _attacking = false;
    }

    public void OnHit()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, _attackDistance))
        {
            if(_doesGatherResources && hit.collider.TryGetComponent(out Resource resource))
            {
                resource.Gather(hit.point, hit.normal);
            }
        }
    }
}

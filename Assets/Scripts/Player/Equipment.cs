using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip _curEquip;
    public Transform _equipParent;

    private PlayerController _controller;
    private PlayerCondition _condition;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<PlayerController>();
        _condition = GetComponent<PlayerCondition>();
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        _curEquip = Instantiate(data._equipPrefab, _equipParent).GetComponent<Equip>();
    }

    public void UnEquip()
    {
        if(_curEquip != null)
        {
            Destroy(_curEquip.gameObject);
            _curEquip = null;
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed && _curEquip != null && _controller._canLook)
        {
            _curEquip.OnAttackInput();
        }
    }
}

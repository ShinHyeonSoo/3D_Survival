using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData _item;
    public UIInventory _inventory;

    public Button _button;
    public Image _icon;
    public TextMeshProUGUI _quantityText;
    private Outline _outLine;
    
    public int _index;
    public bool _equipped;
    public int _quantity;

    private void Awake()
    {
        _outLine = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        _outLine.enabled = _equipped;
    }

    public void Setting()
    {
        _icon.gameObject.SetActive(true);
        _icon.sprite = _item._icon;
        _quantityText.text = _quantity > 1 ? _quantity.ToString() : string.Empty;

        if(_outLine != null)
        {
            _outLine.enabled = _equipped;
        }
    }

    public void Clear()
    {
        _item = null;
        _icon.gameObject.SetActive(false);
        _quantityText.text = string.Empty;
    }

    public void OnClickButton()
    {
        _inventory.SelectItem(_index);
    }
}

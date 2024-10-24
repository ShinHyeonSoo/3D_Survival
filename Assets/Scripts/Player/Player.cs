using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController _controller;
    public PlayerCondition _condition;

    public ItemData _itemData;
    public Action AddItem;

    public Transform _dropPosition;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        _controller = GetComponent<PlayerController>();
        _condition = GetComponent<PlayerCondition>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ItemData _itemToGive;
    public int _quantityPerHit = 1;
    public int _capacity;

    public void Gather(Vector3 hitPoint, Vector3 hitNormal)
    {
        for(int i = 0; i < _quantityPerHit; ++i)
        {
            if (_capacity <= 0) break;
            _capacity--;
            Instantiate(_itemToGive._dropPrefab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }
    }
}

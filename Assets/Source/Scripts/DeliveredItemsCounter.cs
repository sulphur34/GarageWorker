using System;
using UnityEngine;

public class DeliveredItemsCounter : MonoBehaviour
{
    [field: SerializeField] public int GoalItemsCount { get; private set; }

    private int _deliveredItemsCount = 0;

    public event Action<int> GoalItemsCountChanged;
    public event Action GoalItemsCountDelivered;

    private void Start()
    {
        GoalItemsCountChanged?.Invoke(_deliveredItemsCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IItemStatus>(out var itemStatus) != null)
        {
            if (itemStatus.IsPicked)
                itemStatus.Dropped += OnItemDropped;
            else
                AddCount();
        }

        if (_deliveredItemsCount == GoalItemsCount)
        {
            GoalItemsCountDelivered?.Invoke();
            enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IItemStatus>(out var itemStatus) != null)
        {
            if (itemStatus.IsPicked)
                itemStatus.Dropped -= OnItemDropped;
            else
                _deliveredItemsCount--;
        }
    }

    private void OnItemDropped(IItemStatus itemStatus)
    {
        itemStatus.Dropped -= OnItemDropped;
        AddCount();
    }

    private void AddCount()
    {
        _deliveredItemsCount++;
        GoalItemsCountChanged?.Invoke(_deliveredItemsCount);
    }
}
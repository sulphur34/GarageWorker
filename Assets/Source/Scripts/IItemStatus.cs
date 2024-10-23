using System;

public interface IItemStatus
{
    public event Action<IItemStatus> Picked;
    public event Action<IItemStatus> Dropped;

    public bool IsPicked { get;}
}
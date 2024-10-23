using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _pickupRange = 20.0f;

    private Item _pickedItem;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TryPickupItem();

        if (Input.GetMouseButtonDown(1))
            DropItem();
    }

    void TryPickupItem()
    {
        if (_pickedItem != null)
            return;

        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _pickupRange))
        {
            if (hit.collider.gameObject.TryGetComponent<Item>(out var item))
            {
                _pickedItem = item;
                _pickedItem.transform.SetParent(_transform);
                _pickedItem.transform.localPosition = Vector3.zero;
                _pickedItem.SetPicked();
            }
        }
    }

    void DropItem()
    {
        if (_pickedItem == null)
            return;

        _pickedItem.transform.SetParent(null);
        _pickedItem.SetDropped();
        _pickedItem = null;
    }
}
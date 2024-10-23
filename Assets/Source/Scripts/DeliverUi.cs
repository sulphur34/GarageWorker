using TMPro;
using UnityEngine;

namespace Source.Scripts
{
    public class DeliverUi : MonoBehaviour
    {
        private readonly string delimeter = "/";

        [SerializeField] private DeliveredItemsCounter _deliveredItemsCounter;
        [SerializeField] private TextMeshProUGUI _deliveredItemsText;

        private string _goalItemsCountText;

        private void Awake()
        {
            _goalItemsCountText = _deliveredItemsCounter.GoalItemsCount.ToString();
            _deliveredItemsCounter.GoalItemsCountChanged += OnDeliveredItemsChanged;
        }

        private void OnDeliveredItemsChanged(int value)
        {
            _deliveredItemsText.text = value + delimeter + _goalItemsCountText;
        }
    }
}
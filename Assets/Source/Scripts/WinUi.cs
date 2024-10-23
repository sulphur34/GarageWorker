using TMPro;
using UnityEngine;

namespace Source.Scripts
{
    public class WinUi : MonoBehaviour
    {
        [SerializeField] private DeliveredItemsCounter _deliveredItemsCounter;
        [SerializeField] private TextMeshProUGUI _deliveredItemsText;
        [SerializeField] private string _winText;
        private void Awake()
        {
            _deliveredItemsCounter.GoalItemsCountDelivered += OnGoalItemsCountChanged;
        }

        private void OnGoalItemsCountChanged()
        {
            _deliveredItemsText.enabled = true;
            _deliveredItemsText.text = _winText;
        }
    }
}
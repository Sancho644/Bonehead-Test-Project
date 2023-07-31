using UnityEngine;

namespace UI
{
    public class NewItemStatsController : MonoBehaviour
    {
        [SerializeField] private GameObject _healthDifferenceUp;
        [SerializeField] private GameObject _healthDifferenceDown;
        [SerializeField] private GameObject _defenceDifferenceUp;
        [SerializeField] private GameObject _defenceDifferenceDown;
        [SerializeField] private GameObject _attackDifferenceUp;
        [SerializeField] private GameObject _attackDifferenceDown;

        public void UpdateIcons()
        {
            _healthDifferenceUp.gameObject.SetActive(false);
            _healthDifferenceDown.gameObject.SetActive(false);
            _defenceDifferenceUp.gameObject.SetActive(false);
            _defenceDifferenceDown.gameObject.SetActive(false);
            _attackDifferenceUp.gameObject.SetActive(false);
            _attackDifferenceDown.gameObject.SetActive(false);
        }

        public void SetHealthDifference(bool higher)
        {
            if (higher)
            {
                _healthDifferenceUp.gameObject.SetActive(true);
            }
            else
            {
                _healthDifferenceDown.gameObject.SetActive(true);
            }
        }

        public void SetDefenceDifference(bool higher)
        {
            if (higher)
            {
                _defenceDifferenceUp.gameObject.SetActive(true);
            }
            else
            {
                _defenceDifferenceDown.gameObject.SetActive(true);
            }
        }

        public void SetAttackDifference(bool higher)
        {
            if (higher)
            {
                _attackDifferenceUp.gameObject.SetActive(true);
            }
            else
            {
                _attackDifferenceDown.gameObject.SetActive(true);
            }
        }
    }
}
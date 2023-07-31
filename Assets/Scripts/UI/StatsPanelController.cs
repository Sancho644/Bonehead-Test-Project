using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StatsPanelController : MonoBehaviour
    {
        [SerializeField] private Text _healthValue;
        [SerializeField] private Text _defenceValue;
        [SerializeField] private Text _attackValue;

        public void SetStats(int hp, int def, int atk)
        {
            _healthValue.text = hp.ToString();
            _defenceValue.text = def.ToString();
            _attackValue.text = atk.ToString();
        }
    }
}
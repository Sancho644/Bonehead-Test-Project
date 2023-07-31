using System.Collections;
using UnityEngine;
using Utils;

namespace UI
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _objectTransform;
        [SerializeField] private float _speed;
        [SerializeField] private Cooldown _animationDelay;

        private float _timeUp;

        private void Start()
        {
            _animationDelay.Reset();
        }

        private void Update()
        {
            if (_animationDelay.IsReady)
                StartCoroutine(StartAnimation());
        }

        private IEnumerator StartAnimation()
        {
            while (enabled)
            {
                _objectTransform.position =
                    Vector3.Lerp(transform.position, _targetTransform.position, _speed * Time.deltaTime);

                yield return null;
            }
        }
    }
}
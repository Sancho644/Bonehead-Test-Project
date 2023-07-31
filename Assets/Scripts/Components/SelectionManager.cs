using UnityEngine;

namespace Components
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private float _maxDistance = 20f;
        [SerializeField] private LayerMask _selectionLayer;

        private Camera _camera;
        private Transform _selection;
        private bool _isSelect;

        public delegate void OnReadValues(GameObject item);
        public OnReadValues OnRead;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Select();
        }

        public void ManagerSwitcher(bool value)
        {
            gameObject.SetActive(value);
        }

        private void Select()
        {
            var ray = _camera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(ray, Vector2.up, _maxDistance, _selectionLayer);

            if (hit.collider != null)
                SelectObject(hit);
        }

        private void SelectObject(RaycastHit2D hit)
        {
            _selection = hit.transform;

            if (_selection.TryGetComponent(out SwordManController controller))
                controller.StartAnimation();

            if (_selection.TryGetComponent(out ItemStats item))
                OnRead?.Invoke(item.Item);
        }
    }
}
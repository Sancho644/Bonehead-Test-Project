using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private LayerMask _selectionLayer;
    [SerializeField] private LayerMask _itemLayer;

    private Camera _camera;
    private Material _defaultMaterial;
    private Renderer _selectionRenderer;
    private Transform _selection;
    private Transform _firstSelection;
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
        {
            Select();
        }
    }

    private void Select()
    {
        var ray = _camera.ScreenToWorldPoint(Input.mousePosition);

        var hit = Physics2D.Raycast(ray, Vector2.up, _maxDistance, _selectionLayer);

        if (hit.collider != null)
        {
            SelectObject(hit);
        }


        /*if (_isSelect)
        {
            if (Physics.Raycast(ray, out hit, _maxDistance, _playerPlanetLayer))
            {
                SelectNeutral(hit, _selection);

                return;
            }
        }

        if (Physics.Raycast(ray, out hit, _maxDistance, _playerPlanetLayer))
        {
            SelectPlayerPlanet(hit);

            return;
        }

        if (Physics.Raycast(ray, out hit, _maxDistance, _neutralPlanetLayer) && _isSelect)
        {
            SelectNeutral(hit, _selection);
        }
        else if (_selectionRenderer != null)
        {
            _firstSelection = default;
            _isSelect = false;
            _selectionRenderer.material = _defaultMaterial;
        }*/
    }

    private void SelectObject(RaycastHit2D hit)
    {
        _selection = hit.transform;

        if (_selection.TryGetComponent(out SwordManController controller))
        {
            controller.StartAnimation();
        }

        if (_selection.TryGetComponent(out ItemStats item))
        {
            OnRead?.Invoke(item.Item);
        }
    }

    /*
    private void SelectPlayerPlanet(RaycastHit hit)
    {
        _selection = hit.transform;
        _selectionRenderer = _selection.GetComponent<Renderer>();

        if (_firstSelection == _selection)
        {
            return;
        }

        _defaultMaterial = _selectionRenderer.material;

        if (_selectionRenderer != null)
        {
            _firstSelection = _selection;
            _selectionRenderer.material = DefsFacade.I.Settings.SelectionMaterial;
            _isSelect = true;
            return;
        }
    }

    private void SelectNeutral(RaycastHit hit, Transform select)
    {
        var selection = hit.transform;

        if (selection == select) return;

        if (selection.TryGetComponent(out PlanetController selectionController))
        {
            if (select.TryGetComponent(out PlanetController playerPlanet))
            {
                playerPlanet.SpawnShips(selectionController.AgentTarget, selectionController.Index);
            }
        }
    }*/
}
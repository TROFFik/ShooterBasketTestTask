using UnityEngine;
using UnityEngine.EventSystems;

public class InputControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private float shootForce;

    private BasketShooter basketShooter;
    private TragectoryRenderer tragectoryRenderer;
    private Projectile projectile;

    private Vector2 startPointerPosition;
    private Vector2 currentPointerPosition;

    private bool registerClicks = true;
    private void Start()
    {
        basketShooter = BasketShooter.instance;
        tragectoryRenderer = TragectoryRenderer.instance;
        projectile = Projectile.instance;

        projectile.trigger += Reload;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (registerClicks)
        {
            startPointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (registerClicks)
        {
            currentPointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetsOnDrag();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (registerClicks)
        {
            SetsOnEndDrag();
        }   
    }

    private void SetsOnDrag()
    {
        Vector2 TensionForce = startPointerPosition - currentPointerPosition;
        if (TensionForce.magnitude > 1)
        {
            basketShooter.ChangeRotation = TensionForce;
            tragectoryRenderer.DrawTragectory(TensionForce, shootForce);
        }
        else
        {
            tragectoryRenderer.DrawTragectory(Vector3.zero, 0);
        }
    }

    private void SetsOnEndDrag()
    {
        Vector2 TensionForce = startPointerPosition - currentPointerPosition;
        if (TensionForce.magnitude > 1)
        {
            basketShooter.Shoot(TensionForce, shootForce);
            registerClicks = false;
        }
    }

    private void Reload(int EventNumber)
    {
        if (EventNumber != 2 && EventNumber != 3)
        {
            registerClicks = true;
        }
        tragectoryRenderer.DrawTragectory(Vector3.zero, 0);
    }
}

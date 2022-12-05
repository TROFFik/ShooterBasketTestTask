using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Color white;
    [SerializeField] private Color black;
    CinemachineVirtualCamera vcam;
    private float _startAspect = 1080f / 1920f;

    private float _defaultHeight;
    private float _defaultWidth;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        _defaultHeight = Camera.main.orthographicSize;
        _defaultWidth = Camera.main.orthographicSize * _startAspect;

        vcam.m_Lens.OrthographicSize = _defaultWidth / Camera.main.aspect;
    }

    public void ChangeMode()
    {
        if (Camera.main.backgroundColor == white)
        {
            Camera.main.backgroundColor = black;
        }
        else
        {
            Camera.main.backgroundColor = white;
        }
    }
}

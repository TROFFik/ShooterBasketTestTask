using UnityEngine;

public class TragectoryRenderer : MonoBehaviour
{
    public static TragectoryRenderer instance { get; private set; }
    private LineRenderer lineRenderer;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawTragectory(Vector3 ValueVector, float ValueMultiplaer)
    {
        Vector3[] points = new Vector3[10];
        lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            if (ValueMultiplaer == 0)
            {
                points[i] = Vector3.zero;
            }
            else
            {
                float Time = i * 0.1f;
                points[i] = transform.position + ValueVector * Time * ValueMultiplaer + Physics.gravity * Mathf.Pow(Time, 2) / 2f;
            }
        }

        lineRenderer.SetPositions(points);
        
    }
}

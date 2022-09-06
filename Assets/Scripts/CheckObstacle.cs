using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class CheckObstacle : MonoBehaviour
{
    [Tooltip("The percent of the line that is consumed by the arrowhead")]
    [Range(0, 1)]
    public float PercentHead = 0.4f;
    public Vector3 ArrowOrigin;
    public Vector3 ArrowTarget;
    public LineRenderer cachedLineRenderer;
    public static CheckObstacle instance;

    private void Awake()
    {
        CheckObstacle.instance = this;
    }

    void Start()
    {
        UpdateArrow();
        cachedLineRenderer.enabled = false;
    }

    [ContextMenu("UpdateArrow")]
    void UpdateArrow()
    {
        ArrowOrigin = transform.position;
        ArrowTarget = GameObject.Find("center").GetComponent<Transform>().position;

        if (cachedLineRenderer == null)
            cachedLineRenderer = this.GetComponent<LineRenderer>();

        cachedLineRenderer.widthCurve = new AnimationCurve(
            new Keyframe(0, 0f)
            , new Keyframe(1 - PercentHead, 0.4f)  // neck of arrow
            , new Keyframe(0.999f - PercentHead, 1f)  // max width of arrow head
            , new Keyframe(1, 0.4f));  // tip of arrow
        cachedLineRenderer.SetPositions(new Vector3[] {
              ArrowOrigin
              , Vector3.Lerp(ArrowOrigin, ArrowTarget, 0.999f - PercentHead)
              , Vector3.Lerp(ArrowOrigin, ArrowTarget, 1 - PercentHead)
              , ArrowTarget });
    }

    private void OnTriggerEnter(Collider other)
    {
        cachedLineRenderer.enabled = false;

        if (other.tag.Equals("Obstacle")) return;

        if (other.tag.Equals("Tile") || other.tag.Equals("Bridge"))
        {
            cachedLineRenderer.enabled = true;
            UpdateArrow();

        }
    }

}

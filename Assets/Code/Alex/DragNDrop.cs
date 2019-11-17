using System.Collections.Generic;
using Code;
using Code.Alex;
using Code.Alex.Helper;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragNDrop : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Figure Figure { get; private set; }

    public TweenerCore<Vector3, Vector3, VectorOptions> TweenMove { get; private set; }
    public TweenerCore<Vector2, Vector2, VectorOptions> TweenSize { get; private set; }

    private Vector3 _onDownPose;

    #region API
    public void SetFigure(Figure figure)
    {
        Figure = figure;
    }

    public void SetMoveTweener(TweenerCore<Vector3, Vector3, VectorOptions> move)
    {
        TweenMove = move;
    }

    public void SetSizeTweener(TweenerCore<Vector2, Vector2, VectorOptions> size)
    {
        TweenSize = size;
    }

    #endregion


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TweenMove.Pause();
        TweenSize.Pause();
        _onDownPose = transform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOMove(_onDownPose, 0.3f).SetEase(Ease.OutSine).OnComplete(() =>
        {
            TweenMove.Play();
            TweenSize.Play();
        });
        var ray = GetComponentInParent<GraphicRaycaster>();
        var list = new List<RaycastResult>();
        ray.Raycast(eventData, list);
        foreach (var raycastResult in list)
        {
            var match = raycastResult.gameObject.GetComponent<MatchIconUi>();
            if (match != null)
            {
                match.Match(Figure);
                Destroy(gameObject);
            }
        }
    }
}
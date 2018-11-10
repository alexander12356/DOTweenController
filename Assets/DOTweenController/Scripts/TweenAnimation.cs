using System;

using UnityEngine;

using DG.Tweening;

namespace DOTWeenControllerClasses
{
    [Serializable]
    public partial class TweenAnimation
    {
        [SerializeField] private TweenAnimationType m_Type = TweenAnimationType.TransformScale;

        // Targets
        [SerializeField] private CanvasGroup m_CanvasGroupTarget = null;
        [SerializeField] private Transform m_TransformTarget = null;
        [SerializeField] private RectTransform m_RectTransformTarget = null;

        // Params
        [SerializeField] private float m_FloatInitValue = 0f;
        [SerializeField] private float m_FloatTargetValue = 0f;
        [SerializeField] private Vector3 m_Vector3InitValue = Vector3.zero;
        [SerializeField] private Vector3 m_Vector3TargetValue = Vector3.zero;

        // Common
        [SerializeField] private float m_DurationValue = 0f;
        [SerializeField] private Ease m_Ease = Ease.OutQuad;

        public Tweener DoAnimate()
        {
            switch (m_Type)
            {
                case TweenAnimationType.TransformScale:
                    return DoTransformScale();
                case TweenAnimationType.TransformMoving:
                    return DoTransformMoving();
                case TweenAnimationType.RectTransformLocalMove:
                    return DoRectTransformLocalMove();
                case TweenAnimationType.CanvasGroupFade:
                    return DoFadeCanvasGroup();
                default:
                    Debug.Log($"DOTweenController unknown animation type: {m_Type}");
                    return null;
            }
            
        }
    }

    public enum TweenAnimationType
    {
        TransformScale,
        TransformMoving,
        RectTransformLocalMove,
        CanvasGroupFade
    }
}
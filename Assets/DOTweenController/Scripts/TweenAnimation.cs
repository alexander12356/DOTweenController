using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using DG.Tweening;

namespace DOTWeenControllerClasses
{
    [Serializable]
    public partial class TweenAnimation
    {
        private struct AnimationPattern
        {
            public Action InitAction;
            public Func<Tweener> DoFunc;
        }

        private Dictionary<TweenAnimationType, AnimationPattern> m_AnimationPatterns = null;

        [SerializeField] private TweenAnimationType m_Type = TweenAnimationType.TransformScale;

        // Targets
        [SerializeField] private CanvasGroup m_CanvasGroupTarget = null;
        [SerializeField] private Transform m_TransformTarget = null;
        [SerializeField] private RectTransform m_RectTransformTarget = null;
        [SerializeField] private Image m_ImageTarget = null;
        [SerializeField] private UnityEvent m_UnityEvent = null;

        // Params
        [SerializeField] private float m_FloatInitValue = 0f;
        [SerializeField] private float m_FloatTargetValue = 0f;
        [SerializeField] private Vector3 m_Vector3InitValue = Vector3.zero;
        [SerializeField] private Vector3 m_Vector3TargetValue = Vector3.zero;

        // Common
        [SerializeField] private float m_DurationValue = 0f;
        [SerializeField] private Ease m_Ease = Ease.OutQuad;

        public void Setup()
        {
            m_AnimationPatterns = new Dictionary<TweenAnimationType, AnimationPattern>()
            {
                [TweenAnimationType.CanvasGroupFade] = new AnimationPattern()
                {
                    InitAction = InitFadeCanvasGroup,
                    DoFunc = DoFadeCanvasGroup
                },
                [TweenAnimationType.ImageFade] = new AnimationPattern()
                {
                    InitAction = InitImageFade,
                    DoFunc = DoImageFade
                },
                [TweenAnimationType.RectTransformLocalMove] = new AnimationPattern()
                {
                    InitAction = InitRectTransformLocalMove,
                    DoFunc = DoRectTransformLocalMove
                },
                [TweenAnimationType.TransformMoving] = new AnimationPattern()
                {
                    InitAction = InitTransformMoving,
                    DoFunc = DoTransformMoving
                },
                [TweenAnimationType.TransformScale] = new AnimationPattern()
                {
                    InitAction = InitTransformScale,
                    DoFunc = DoTransformScale
                }
            };
        }

        public void Init()
        {
            m_AnimationPatterns[m_Type].InitAction();
        }

        public Tweener DoAnimate()
        {
            return m_AnimationPatterns[m_Type].DoFunc().SetEase(m_Ease);
        }

        public void Invoke()
        {
            m_UnityEvent?.Invoke();
        }
    }

    public enum TweenAnimationType
    {
        TransformScale,
        TransformMoving,
        RectTransformLocalMove,
        CanvasGroupFade,
        ImageFade,
        Invoke
    }
}
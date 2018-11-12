using UnityEngine;

using DG.Tweening;

namespace DOTWeenControllerClasses
{
    /// <summary>
    /// Scale animation
    /// </summary>
    public partial class TweenAnimation
    {
        public void InitTransformScale()
        {
            m_TransformTarget.localScale = Vector3.one * m_FloatInitValue;
        }

        private Tweener DoTransformScale()
        {
            return m_TransformTarget.DOScale(m_FloatTargetValue, m_DurationValue);
        }
    }
}
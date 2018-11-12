using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

namespace DOTWeenControllerClasses
{
    /// <summary>
    /// Image Fade Animation
    /// </summary>
    public partial class TweenAnimation
    {
        private void InitImageFade()
        {
            m_ImageTarget.color = new Color(m_ImageTarget.color.r, m_ImageTarget.color.g, m_ImageTarget.color.b, m_FloatInitValue);
        }

        private Tweener DoImageFade()
        {
            return m_ImageTarget.DOFade(m_FloatTargetValue, m_DurationValue);
        }
    }
}
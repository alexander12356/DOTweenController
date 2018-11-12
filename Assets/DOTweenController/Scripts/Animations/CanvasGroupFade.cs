using DG.Tweening;

namespace DOTWeenControllerClasses
{
    /// <summary>
    /// Canvas Group Fade
    /// </summary>
    public partial class TweenAnimation
    {
        private void InitFadeCanvasGroup()
        {
            m_CanvasGroupTarget.alpha = m_FloatInitValue;
        }

        private Tweener DoFadeCanvasGroup()
        {
            return m_CanvasGroupTarget.DOFade(m_FloatTargetValue, m_DurationValue);
        }
    }
}
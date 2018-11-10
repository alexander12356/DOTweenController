using DG.Tweening;

namespace DOTWeenControllerClasses
{
    /// <summary>
    /// RectTransform Local Move
    /// </summary>
    public partial class TweenAnimation  
    {
        private Tweener DoRectTransformLocalMove()
        {
            return m_RectTransformTarget.DOLocalMove(m_Vector3TargetValue, m_DurationValue).SetEase(m_Ease);
        }
    }
}
using DG.Tweening;

namespace DOTWeenControllerClasses
{
    /// <summary>
    /// RectTransform Local Move
    /// </summary>
    public partial class TweenAnimation  
    {
        private void InitRectTransformLocalMove()
        {
            m_RectTransformTarget.localPosition = m_Vector3InitValue;
        }

        private Tweener DoRectTransformLocalMove()
        {
            return m_RectTransformTarget.DOLocalMove(m_Vector3TargetValue, m_DurationValue);
        }
    }
}
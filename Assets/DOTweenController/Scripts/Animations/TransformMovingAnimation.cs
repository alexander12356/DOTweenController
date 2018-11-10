using DG.Tweening;

namespace DOTWeenControllerClasses
{
    /// <summary>
    /// Transform Moving Animation
    /// </summary>
    public partial class TweenAnimation
    {
        public void InitTransformMoving()
        {
            m_TransformTarget.position = m_Vector3InitValue;
        }

        private Tweener DoTransformMoving()
        {
            return m_TransformTarget.DOMove(m_Vector3TargetValue, m_DurationValue).SetEase(m_Ease);
        }
    }
}
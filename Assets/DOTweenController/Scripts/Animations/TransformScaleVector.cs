using DG.Tweening;

namespace DOTWeenControllerClasses
{
    /// <summary>
    /// Transform scale vector
    /// </summary>
    public partial class TweenAnimation
    {
        private void InitTransformScaleVector()
        {
            m_TransformTarget.localScale = m_Vector3InitValue;
        }

        private Tweener DOTransformScaleVector()
        {
            return m_TransformTarget.DOScale(m_Vector3TargetValue, m_DurationValue);
        }
    }
}
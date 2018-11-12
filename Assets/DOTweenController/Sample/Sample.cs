using UnityEngine;

using DG.Tweening;

using DOTWeenControllerClasses;

public class Sample : MonoBehaviour
{
    private DOTweenController m_DOTWeenController = null;

    private void Awake()
    {
        m_DOTWeenController = GetComponent<DOTweenController>();
    }

    public void PlayAnimation()
    {
        var sequence = DOTween.Sequence();

        sequence.
            Append(m_DOTWeenController.Play("MoveOne")).
            Join(m_DOTWeenController.Play("Scaling")).
            Append(m_DOTWeenController.Play("MoveTwo")).
            Append(m_DOTWeenController.Play("Fading")).
            Append(m_DOTWeenController.Play("CanvasGroupAppear")).
            Append(m_DOTWeenController.Play("ImageFading")).
            AppendCallback(() => m_DOTWeenController.Invoke("InvokeImageNew")).
            Append(m_DOTWeenController.Play("ScaleImageNew"));
    }
}

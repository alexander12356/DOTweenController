using System;
using System.Collections.Generic;

using UnityEngine;

using DG.Tweening;

namespace DOTWeenControllerClasses
{
    public class DOTweenController : MonoBehaviour
    {
        [Serializable]
        public struct Animation
        {
            public string Id;
            public TweenAnimation Tweener;
        }

        private Dictionary<string, TweenAnimation> m_AnimationDictionary = null;

        [SerializeField] private Animation[] m_Animations = null;

        private void Awake()
        {
            m_AnimationDictionary = new Dictionary<string, TweenAnimation>();

            for (int i = 0; i < m_Animations.Length; i++)
            {
                m_Animations[i].Tweener.Setup();
                m_AnimationDictionary.Add(m_Animations[i].Id, m_Animations[i].Tweener);
            }
        }

        public void Init(string id)
        {
            if (!m_AnimationDictionary.ContainsKey(id))
            {
                return;
            }
            m_AnimationDictionary[id].Init();
        }

        public Tweener Play(string id)
        {
            if (!m_AnimationDictionary.ContainsKey(id))
            {
                return null;
            }
            return m_AnimationDictionary[id].DoAnimate();
        }

        public void Invoke(string id)
        {
            if (!m_AnimationDictionary.ContainsKey(id))
            {
                return;
            }
            m_AnimationDictionary[id].Invoke();
        }
    }
}
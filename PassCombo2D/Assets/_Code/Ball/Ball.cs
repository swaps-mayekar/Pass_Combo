using UnityEngine;
using UnityEngine.UI;

namespace PassCombo2D
{
    public class Ball : MonoBehaviour, IBall
    {
        Image m_visibility = null;

        bool m_isTravelling = true;

        Vector3 m_defaultPos = Vector3.zero, m_targetPos = Vector3.zero;

        const float m_ballSpeed = 1f;

        /// <summary>
        /// Show ball.
        /// </summary>
        public void Show()
        {
            m_visibility.enabled = true;
        }

        /// <summary>
        /// Hide ball.
        /// </summary>
        public void Hide()
        {
            m_visibility.enabled = false;
        }

        /// <summary>
        /// Start travelling to teammate position.
        /// </summary>
        /// <param name="a_endPos">Target position for ball</param>
        public void TravelTo(Vector2 a_endPos)
        {
            transform.position = m_defaultPos;
            m_targetPos = a_endPos;
            m_isTravelling = true;
            Show();
        }

        void Update()
        {
            if (!m_isTravelling)
                return;

            transform.position = Vector3.MoveTowards(transform.position, m_targetPos, m_ballSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, m_targetPos) < 0.01f)
            {
                m_isTravelling = false;
                Hide();
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System;

namespace PassCombo2D
{
    public class Teammate : MonoBehaviour, ITeammate
    {
        bool isShown, isDeactivated, isMissed;

        public bool IsShown { get=> isShown; }
        public bool IsDeactivated { get=> isDeactivated; }

        [SerializeField]
        Image m_imgVisibility = null;

        public event Action OnPassFailed = null, OnPassSucceeded = null;

        Color m_activeColour = Color.yellow, m_deactiveColor = Color.red;


        /// <summary>
        /// Show teammate. Show in active colour.
        /// </summary>
        public void Show()
        {
            isShown = true;
            isDeactivated = false;
            m_imgVisibility.color = m_activeColour;
            m_imgVisibility.enabled = true;
        }

        /// <summary>
        /// Hide teammate.
        /// </summary>
        public void Hide() 
        {
            isShown = false;
            isDeactivated = false;
            m_imgVisibility.enabled = false;
        }

        /// <summary>
        /// Deactivate teammate. Show in deactivated colour.
        /// </summary>
        public void Deactivate()
        {
            isDeactivated = true;
            m_imgVisibility.color = m_deactiveColor;
            // isShown = false;
        }

        /// <summary>
        /// Gets called after clicking on teammate.
        /// </summary>
        public void OnClick_Teammate()
        {
            if (!isShown || isMissed)
            {
                return;
            }

            if (isDeactivated)
            {
                isMissed = true;
                OnPassFailed.Invoke();
                OnPassFailed = OnPassSucceeded = null;
                return;
            }
            else
            {
                isMissed = false;
                OnPassSucceeded.Invoke();
                OnPassFailed = OnPassSucceeded = null;
            }
        }
    }
}

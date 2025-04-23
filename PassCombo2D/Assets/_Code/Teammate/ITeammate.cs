using UnityEngine;
using System;

namespace PassCombo2D
{
    public interface ITeammate
    {
        void Show();
        void Deactivate();
        void Hide();

        bool IsShown { get; }
        bool IsDeactivated { get; }

        void OnClick_Teammate();

        event Action OnPassFailed;
        event Action OnPassSucceeded;
    }
}

using UnityEngine;

namespace PassCombo2D
{
    public interface IBall
    {
        void Show();
        void Hide();
        void TravelTo(Vector2 a_endPos);
    }
}

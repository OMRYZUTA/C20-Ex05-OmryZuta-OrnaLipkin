using System.Drawing;
using System.Windows.Forms;
using C20_Ex02_Omry_308345826_Orna_043548734;

namespace WinFormsCheckers
{
    internal class BlackButton : Button
    {
        private const int k_ButtonSize = 45;

        public BlackButton(Position i_CurrentPosition, Point i_StartLocation)
        {
            BackColor = Color.Gray;
            Width = k_ButtonSize;
            Height = k_ButtonSize;
            Location = new Point(
                (k_ButtonSize * i_CurrentPosition.Row) + i_StartLocation.X,
                (k_ButtonSize * i_CurrentPosition.Column) + i_StartLocation.Y);
            Enabled = false;
        }
    }
}

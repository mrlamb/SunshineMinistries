using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Contact_App
{
    class RoundButton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0 , 0 , ClientSize.Width , ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
    }
}

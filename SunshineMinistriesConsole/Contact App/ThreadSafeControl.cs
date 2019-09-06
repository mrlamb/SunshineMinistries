using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_App
{
    public static class ThreadSafeControl
    {
        //Should work for most generic controls.
        delegate void SetTextCallback(Form form, Control ctrl, string text);
        delegate void SetTextCallbackStatusLabel(Form form, ToolStripStatusLabel statusLabel, string Text);

        public static void SetText(Form form, Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextCallback stb = new SetTextCallback(SetText);
                form.Invoke(stb, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }

        //Status Labels aren't controls... who knew...
        public static void SetTextStatusLabel(Form form, ToolStripStatusLabel statusLabel, string text)
        {
            if (form.InvokeRequired)
            {
                SetTextCallbackStatusLabel stb = new SetTextCallbackStatusLabel(SetTextStatusLabel);
                form.Invoke(stb, new object[] { form, statusLabel, text });
            }
            else
            {
                statusLabel.Text = text;
            }
        }
    }
}

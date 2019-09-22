using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Contact_App
{
    static class Program
    {
        public static StateObject stateObject = new StateObject();
        private static byte nextID = 21;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginBox lb = new Contact_App.LoginBox();
            MainForm mf = new MainForm();
            TwoAppContext appctx = new TwoAppContext(lb, mf);

            Application.Run(appctx);
        }

        class TwoAppContext : ApplicationContext
        {
            Form secondForm;
            Form firstForm;

            public TwoAppContext(Form firstForm, Form secondForm) : base(firstForm)
            {
                this.secondForm = secondForm;
                this.firstForm = firstForm;
            }

            protected override void OnMainFormClosed(object sender, EventArgs e)
            {
                if (sender == firstForm && (sender as LoginBox).Authentication_Success){
                    base.MainForm = secondForm;
                    base.MainForm.Show();
                }
                else 
                {
                    base.OnMainFormClosed(sender, e);
                }
                
            }
        }

        internal static byte GetNextID()
        {
            return nextID++;
        }
    }
}

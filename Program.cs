using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditerForm1 {
    static class Program {

       public static MyCreate.EditorForm editorForm;
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            editorForm = new MyCreate.EditorForm();
            Application.Run(editorForm);
        }
    }
}

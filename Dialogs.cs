using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace MyCreate {
   public class Dialogs /*:exe_Path*/
   {
       private static string path = Application.ExecutablePath;
       private static string folderPath1 = Path.GetDirectoryName(path);


        public string OpenFolder_DaiaLog(string Path) //フォルダ指定
        {
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            string returnstr = "";

            // ダイアログの説明文を指定する
            fbDialog.Description = "ダイアログの説明文";

            // デフォルトのフォルダを指定する
            fbDialog.SelectedPath = Path;

            // 「新しいフォルダーの作成する」ボタンを表示する
            fbDialog.ShowNewFolderButton = true;

            //フォルダを選択するダイアログを表示する
            if (fbDialog.ShowDialog() == DialogResult.OK) {
                Console.WriteLine(fbDialog.SelectedPath);
                returnstr = fbDialog.SelectedPath;
            } else {
                Console.WriteLine("キャンセルされました");
                returnstr = null;
            }

            // オブジェクトを破棄する
            fbDialog.Dispose();
            return returnstr;
        }

        public string SaveFile_Dialog(string Start_Folder_path,string StartFileName,string limit) {
            System.Windows.Forms.SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Filter = "画像ファイル | *.gif; *.png"+" |すべてのファイル(*)|*|すべてのファイル(*.*)|*.*";
            //はじめに「ファイル名」で表示される文字列を指定する

            // "画像ファイル | *.gif; *.png|pngファイル(*.png)|*.png|gifファイル(*.gif)|*.gif";
            //limit = "*.txt"など
            dialog.Filter = "保存形式("+limit+")|"+limit + "|すべてのファイル(*)|*"+"|すべてのファイル(*.*)|*.*";
            dialog.FileName=StartFileName;
            dialog.InitialDirectory = Start_Folder_path;

            /* ダイアログを表示し「開く」場合 */
            if (dialog.ShowDialog() == DialogResult.OK) {
                string Path = dialog.FileName;//選択したファイルへのパス(文字列型)

                //ファイル名をパスから取得するには、「GetFileNameメソッド」を使います
                string Name = System.IO.Path.GetFileName(Path);
                /* ファイル名を表示する */
                //MessageBox.Show(Name);

                return Path;
            }
            return "";
        }

        public string OpenFile_Dialog(string Start_Folder_path, string StartFileName, string limit) {

            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "保存形式(" + limit + ")|" + limit + "|すべてのファイル(*)|*" + "|すべてのファイル(*.*)|*.*";

            //op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\Screenshots";
            //op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
            op.FileName = StartFileName;
            op.InitialDirectory = Start_Folder_path;

            /* ダイアログを表示し「開く」場合 */
            if (op.ShowDialog() == DialogResult.OK) {

                /* ファイル名を表示する */
                // MessageBox.Show(op.FileName);
                string Path = op.FileName;//選択したファイルへのパス(文字列型)

                //ファイル名をパスから取得するには、「GetFileNameメソッド」を使います
                string Name = System.IO.Path.GetFileName(Path);
                return Path;

            } else {
                return "";
            }
        }

        public string OpenFile_Dialog(string Start_Folder_path, string StartFileName, string[] limitList) {

            OpenFileDialog op = new OpenFileDialog();
            //*.gif; *.png
            string Filter1 = ""; Filter1 = "保存形式(" + limitList[0] ;
            string Filter2 = ")|"+"*"+ limitList[0];

            for (int i=1;i<limitList.Length;i++) 
            {
                Filter1 += ", *" + limitList[i];
                Filter2 += "; *" + limitList[i];
            }

            op.Filter = Filter1 + Filter2 + "|すべてのファイル(*)|*" + "|すべてのファイル(*.*)|*.*";

            //op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\Screenshots";
            //op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
            op.FileName = StartFileName;
            op.InitialDirectory = Start_Folder_path;

            /* ダイアログを表示し「開く」場合 */
            if (op.ShowDialog() == DialogResult.OK) {

                /* ファイル名を表示する */
                // MessageBox.Show(op.FileName);
                string Path = op.FileName;//選択したファイルへのパス(文字列型)

                //ファイル名をパスから取得するには、「GetFileNameメソッド」を使います
                string Name = System.IO.Path.GetFileName(Path);
                return Path;

            } else {
                return "";
            }
        }

        public string OpenFile_Dialog_List(string Start_Folder_path, string StartFileName, string limit) {

           string[] resultList = null;
            string moji = "";

            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "保存形式(" + limit + ")|" + limit;

            op.FileName = StartFileName;
            op.InitialDirectory = Start_Folder_path;

            /* ダイアログを表示し「開く」場合 */
            if (op.ShowDialog() == DialogResult.OK) {

                /* ファイル名を表示する */
                // MessageBox.Show(op.FileName);
                string pth = op.FileName;//選択したファイルへのパス(文字列型)

                moji = pth;
            } 

            return moji;
        }

   }
}
 //dialog.Filter = "リッチテキスト形式(*.rtf)|*.rtf";
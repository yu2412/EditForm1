using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCreate {
   public class Text_IO {

       static string  FolderPath =@"List\";
       static string LangtxtName = @"LanguageList.txt";

        public static void TextRead_To_ListBox(ref ListBox list,string txtPath) {//言語リストの読み込み

           // string txtpath = Exe_Path.exe_Path() + FolderPath + LangtxtName;

            if (File.Exists(txtPath)) {
                StreamReader sr = new StreamReader(txtPath, Encoding.GetEncoding("UTF-8"));

                while (sr.Peek() != -1) {
                    list.Items.Add(sr.ReadLine());
                }

                sr.Close();
                list.SelectedIndex = 0;
            } else {
                Console.WriteLine("ファイルが存在しません");

            }
        }

        public static List<string> TextRead_To_List(string txtPath) {//言語リストの読み込み

            List<string> Result = new List<string>();

            if (File.Exists(txtPath)) {
                StreamReader sr = new StreamReader(txtPath, Encoding.GetEncoding("UTF-8"));

                while (sr.Peek() != -1) {
                    Result.Add(sr.ReadLine());
                }

                sr.Close();

            } else {
                Console.WriteLine("ファイルが存在しません");

            }

            return Result;
        }


        public static void TextRead_To_Dictionary(ref Dictionary<string,string> dictionary, char[] cut, string txtPath) {//言語リストの読み込み

            // string txtpath = Exe_Path.exe_Path() + FolderPath + LangtxtName;

            if (File.Exists(txtPath)) {
                StreamReader sr = new StreamReader(txtPath, Encoding.GetEncoding("UTF-8"));

                dictionary.Clear();

                while (sr.Peek() != -1) {
                    string[] strLine = sr.ReadLine().Split(cut);
                    dictionary.Add(strLine[1], strLine[0]);
                }

                sr.Close();
            } else {
                Console.WriteLine("ファイルが存在しません");

            }
        }

        public static void TextRead_To_ListBox(ref CheckedListBox list, string txtPath) {//言語リストの読み込み

            // string txtpath = Exe_Path.exe_Path() + FolderPath + LangtxtName;

            if (File.Exists(txtPath)) {
                StreamReader sr = new StreamReader(txtPath, Encoding.GetEncoding("UTF-8"));

                while (sr.Peek() != -1) {
                    list.Items.Add(sr.ReadLine());
                }

                sr.Close();
                list.SelectedIndex = 0;
            } else {
                Console.WriteLine("ファイルが存在しません");

            }
        }

        public static void TextRead_To_ListBox(ref ComboBox list, string txtPath) {//言語リストの読み込み

            // string txtpath = Exe_Path.exe_Path() + FolderPath + LangtxtName;

            if (File.Exists(txtPath)) {
                StreamReader sr = new StreamReader(txtPath, Encoding.GetEncoding("UTF-8"));

                while (sr.Peek() != -1) {
                    list.Items.Add(sr.ReadLine());
                }

                sr.Close();
                list.SelectedIndex = 0;
            } else {
                Console.WriteLine("ファイルが存在しません");

            }
        }

        public static void LangTextRead_To_ComboBox(ref ComboBox list) {//言語リストの読み込み

            string txtpath = Exe_Path.exe_Path() + FolderPath + LangtxtName;

            if (File.Exists(txtpath)) {
                StreamReader sr = new StreamReader(txtpath, Encoding.GetEncoding("UTF-8"));

                while (sr.Peek() != -1) {
                    list.Items.Add(sr.ReadLine());
                }

                sr.Close();
                list.SelectedIndex = 0;
            } else {
                Console.WriteLine("ファイルが存在しません");

            }
        }

        public static void txtDelete(string name) {
            File.Delete(name);//Form1.CurrentDirectorylibraryPth +
            //MessageBox.Show("削除完了");
        }

        public static string[] TextListRead(string Paths) {
            List<string> strList = new List<string>();

            if (File.Exists(Paths)) {

                StreamReader sr = new StreamReader(Paths, Encoding.GetEncoding("UTF-8"));

                while (sr.Peek() != -1) {
                    strList.Add(sr.ReadLine());
                }

                sr.Close();
                return strList.ToArray();

            } else {
                //MessageBox.Show("ファイルが存在しません");
                return null;
            }
        }

        #region 作業用テキスト1

        public static void Txt_OUT_Edit(string txt)//------　　　テキストサンプルを展開------------------------
        {
            string OyaFolder = (Exe_Path.exe_Path() + @"List\");
            txtDelete(OyaFolder + "編集用テキスト.txt");

           // 文字コードを指定
           Encoding enc = Encoding.GetEncoding("UTF-8");

           // ファイルを開く
           StreamWriter writer = new StreamWriter(OyaFolder + @"編集用テキスト.txt", false, enc);


           // テキストを書き込む
            writer.WriteLine(txt);

           // ファイルを閉じる
            writer.Close();

        }//-----------------------------------//


        public static void Txt_EditEnd(ref TextBox T)//-----------Form１のテキスト取り込み用-取り込み内容の修正--修正処置------------------//
        {


            //// 文字コードを指定
            //Encoding enc = Encoding.GetEncoding("UTF-8");

            //// ファイルを開く
            //StreamReader reader = new StreamReader(FoldaList + @"編集用テキスト.txt");


            //// テキストを書き込む
            //T.Text = reader.ReadToEnd();

            //// ファイルを閉じる
            //reader.Close();

        }//-----------------------------

        public static void Txt_EditEnd(ref RichTextBox R)//------------アップデート用--終了処置------------------//
        {


            //// 文字コードを指定
            //Encoding enc = Encoding.GetEncoding("UTF-8");

            //// ファイルを開く
            //StreamReader reader = new StreamReader(FoldaList + @"編集用テキスト.txt");


            //// テキストを書き込む
            //R.Text = reader.ReadToEnd();

            //// ファイルを閉じる
            //reader.Close();

        }//-----------------------------

        #endregion

        #region 作業用テキスト2（複数のサンプルを展開して作業)
        public static void Txt_Multiple_Edit(string txtPath, string name, string S1)//-複数のサンプルを展開---
        {

            // 文字コードを指定
            Encoding enc = Encoding.GetEncoding("UTF-8");

            // ファイルを開く
            StreamWriter writer = new StreamWriter(txtPath + @"\" + name + ".txt", false, enc);//falseで上書き

            // テキストを書き込む
            writer.WriteLine(S1);//上書き内容（Accessへのパス）

            // ファイルを閉じる
            writer.Close();

        }


        public static void Txt_OUTEditEnd(string name)//-----１枚のサンプルを破棄---------------------------//
        {
            txtDelete(name + ".txt");

        }//-----------------------------

        #endregion
        public static void TextReadDF(string Paths, ref string[] dfst) {//Accessに取り込む時に使用
            if (File.Exists(Paths)) {

                StreamReader sr = new StreamReader(Paths, Encoding.GetEncoding("UTF-8"));

                for (int i = 0; i < dfst.Length; i++) {
                    dfst[i] = sr.ReadLine();
                }
                sr.Close();


            } else {
                MessageBox.Show("ファイルが存在しません");
                return;
            }
        }
        public static string TextWorkRead(string Paths, ListBox langlist) {
            if (File.Exists(Paths)) {

                StreamReader sr;

                if (langlist.Text == "C言語") {
                    sr = new StreamReader(Paths, Encoding.GetEncoding("shift_jis"));
                } else if (langlist.Text == "Java") {
                    sr = new StreamReader(Paths, Encoding.GetEncoding("shift_jis"));
                } else if (langlist.Text == "C++")//C言語のゲームサンプルの読み取りの場合
                  {
                    sr = new StreamReader(Paths, Encoding.GetEncoding("shift_jis"));
                }
                  //else if (listLang.Text == "C++")
                  //{
                  //    sr = new StreamReader(Paths, Encoding.GetEncoding("UTF-8"));
                  //}
                  else {
                    sr = new StreamReader(Paths, Encoding.GetEncoding("UTF-8"));
                }
                string text = sr.ReadToEnd();

                sr.Close();

                Console.Write(text);
                return text;
            } else {
                Console.WriteLine("ファイルが存在しません");
                return "失敗";
            }
        }
        public static string TextRead(string Paths) {//Accessに取り込む時に使用
            if (File.Exists(Paths)) {

                StreamReader sr = new StreamReader(Paths, Encoding.GetEncoding("UTF-8"));

                string text = sr.ReadToEnd();

                sr.Close();

                Console.Write(text);
                return text;
            } else {
                Console.WriteLine("ファイルが存在しません");
                return "失敗";
            }

        }

        public static string TextRead(string Paths,string Encodingmoji) {//Accessに取り込む時に使用
            if (File.Exists(Paths)) {

                StreamReader sr = new StreamReader(Paths, Encoding.GetEncoding(Encodingmoji));// "UTF-8"));

                string text = sr.ReadToEnd();

                sr.Close();

                Console.Write(text);
                return text;
            } else {
                Console.WriteLine("ファイルが存在しません");
                return "失敗";
            }

        }

        public static bool NG_Word_Chack(string Key)//エラーが起きるワードの入力チェック
{
            switch (Key) {
                case "bit": return false;

                case "Bit":
                    return false;

                case "BIt":
                    return false;

                case "BIT":
                    return false;


                case "biT":
                    return false;


                case "bIT":
                    return false;

                case "bIt":
                    return false;


                default: return true;

            }

        }

        public static void ListBox_Writer(string txtPath, List<string> strlist) {
            File.Delete(txtPath);

            // 文字コードを指定
            Encoding enc = Encoding.GetEncoding("UTF-8");

            // ファイルを開く
            StreamWriter writer = new StreamWriter(txtPath, true, enc);//falseで上書き

            int num = strlist.Count;

            for (int i = 0; i < num; i++) {

                // テキストを書き込む
                writer.WriteLine(strlist[i]);//上書き内容（Accessへのパス）

            }
            // ファイルを閉じる
            writer.Close();

        }

        public static bool TextFileCreate(string stringPath,string txt) {
            bool Flg = false;
            try {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(stringPath);
                //Write a line of text
                sw.WriteLine(txt);
                //Write a second line of text
                //Close the file
                sw.Close();
                Flg = true;
            } catch (Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            } finally {
                Console.WriteLine("Executing finally block.");
            }
            return Flg;
        }

        public static bool TextFileReWrite(string path,string moji) {
            bool Flg = false;
            try {
                File.WriteAllText(path, moji);
                Flg = true;
            } catch(Exception e) {
                MessageBox.Show(e.Message+"\n"+$"{path}  が削除されている可能性があります");
            }

            return Flg;
        }

        public static bool TextFileReWrite(string path,Dictionary<string,string> dictionary) {
            bool Flg = false;
            try {

                string moji = "";

                int i = 0;

                //foreach (var keyValuePair in Line_MessageForm.Line_Form.TOKEN_List) {
                //    string key = keyValuePair.Key;
                //    string value = keyValuePair.Value;
                //    if (Line_MessageForm.Line_Form.TOKEN_List.Count > i) {
                //        moji += $"{value},{key}" + System.Environment.NewLine;
                //    } else {
                //        moji += $"{value},{key}";
                //    }
                //    i++;
                //}

                File.WriteAllText(path, moji);
                Flg = true;
            } catch(Exception e) {
                MessageBox.Show(e.Message+"\n"+$"{path}  が削除されている可能性があります");
            }

            return Flg;
        }

        public string[] DataGrid_To_StringAry(DataGridView data) {

            List<string> list = new List<string>();

            for(int i = 0; i < data.Rows.Count; i++) {
                string s = "";
                for(int j = 0; j < data.ColumnCount; j++) {
                    s += data.Rows[i].Cells[j];
                }

                list.Add(s);
            }
            return list.ToArray();

        } 


    }
}

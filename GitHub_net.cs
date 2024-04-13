using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCreate;
using static System.Net.Mime.MediaTypeNames;

namespace MyCreate {
  public  class Web_URL_net {


       static string[] Google_Path = new string[] { @"C:\Program Files\Google\Chrome\Application\chrome.exe", @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" };

        int select = 1;
        string exepath = Exe_Path.exe_Path() + @"List\Web_URL_Button\";
        string txt;
        string url;           //"https://github.com/yu2412?tab=projects";

        public Web_URL_net(int number) 
        {
            if (number == 1) {
                url = Text_IO.TextRead(exepath + "ButtonURL1.txt");
            } else {
                url = Text_IO.TextRead(exepath + "ButtonURL2.txt");
            }
         
        }

        public void URL_Open() {



            try {

                System.Diagnostics.Process.Start(Google_Path[select], url);


            } catch (Exception ee) {


                if (select == 0) {
                    try {
                        select = 1;

                        System.Diagnostics.Process.Start(Google_Path[select], url);


                    } catch (Exception ee2) {
                        MessageBox.Show("接続に失敗\nキャンセルします");
                    }
                } else {

                    try {
                        select = 0;

                        System.Diagnostics.Process.Start(Google_Path[select], url);


                    } catch (Exception ee2) {
                        MessageBox.Show("接続に失敗\nキャンセルします");
                    }

                }
            }


        }

    }
}

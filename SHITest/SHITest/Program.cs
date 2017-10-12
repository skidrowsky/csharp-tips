using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHIClassLibrary.Tools;

namespace SHITest
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region LogManager
            //LogManager log = new LogManager(null,"_SHITest");
            //log.WriteLine("[Begin Processing].....");

            //for (int index = 0; index < 10; index++)
            //{
            //    log.WriteLine("Processing: " + index);

            //    log.WriteLine("Done: " + index);
                
            //}
            //log.WriteLine("[End Processing].....");
            //#endregion

            #region EMailmanager static
            string contents = "Hello there, <br /> This is Derek.";
            EmailManager.send("misoro1@naver.com", "Hi...", contents);
            EmailManager.send("skidrowsky@naver.com", "misoro1@naver.com", "Hi...", contents);
            #endregion

            #region EMailmanager object instance
            contents = "Hello there, <br /> This is Derek.";
            EmailManager email = new EmailManager("smtp.naver.com",25,"skidrowsky","password");
            email.from = "skidrowsky@naver.com";
            email.to.Add("misoro1@naver.com");
            email.Subject = "Test email";
            email.Body = contents;
            email.Send();
            #endregion
        }


        ////확장 메소드 구현방법
        ////-static class 로 구현되어야 함
        ////-static funciton 로 구현
        ////-첫번째 인자가, 확장할 클래스나 인자가 와야한다.
        //public static class ExtensionTest
        //{
        //    public static void WriteConsole(this LogManager log, string data)
        //    {
        //        log.Write(data);
        //        Console.Write(data);
        //    }
        //}
    }
}

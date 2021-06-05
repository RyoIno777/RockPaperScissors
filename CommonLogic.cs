using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{

    /// <summary>
    /// 共通ロジッククラスです。
    /// </summary>
    static class CommonLogic
    {

        #region メソッド
        /// <summary>
        /// 指定された行数で改行を表示します。
        /// </summary>
        /// <param name="line">行数（未指定の場合1行）</param>
        public static void DispNewLine(int line = 1)
        {
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// メッセージをコンソールに表示します。
        /// </summary>
        /// <param name="isClear">True:前画面をクリア</param>
        /// <param name="msg">表示内容</param>
        /// <param name="color">メッセージカラー（初期値：白)</param>
        public static void DispMsg(bool isClear, string msg, ConsoleColor color = ConsoleColor.White)
        {
            if (isClear)
            {
                Console.Clear();
            }
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
        }

        /// <summary>
        /// キーボードからの入力を受け付けます。
        /// </summary>
        /// <param name="msg">入力メッセージ</param>
        /// <param name="color">メッセージカラー（初期値：白)</param>
        /// <returns>入力内容</returns>
        public static string InputValue(string msg, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.Write("> ");
            return Console.ReadLine();
        }

        /// <summary>
        /// エラーメッセージを表示します。
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        public static void DispError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        #endregion

    }

}

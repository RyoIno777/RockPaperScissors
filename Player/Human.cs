using RockPaperScissors.Abstract;
using RockPaperScissors.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RockPaperScissors.Player
{

    /// <summary>
    /// 人間プレイヤークラスです。
    /// </summary>
    public class Human : APlayer
    {

        #region コンストラクタ
        /// <summary>
        /// 人間プレイヤークラスを初期化します。
        /// </summary>
        /// <param name="name">名前</param>
        public Human(string name) : base(name)
        {
        }
        #endregion

        #region オーバーライドメソッド
        /// <summary>
        /// 人間プレイヤータイプを返します。
        /// </summary>
        /// <returns></returns>
        public override TypeEnum GetPlayerType()
        {
            return TypeEnum.人間;
        }

        /// <summary>
        /// 出す手を決定します。
        /// </summary>
        /// <returns>出す手</returns>
        public override HandEnum MakeUpHand(List<APlayer>list)
        {
            CommonLogic.DispMsg(true, "あなたの出す手を入力してください。", ConsoleColor.Yellow);
            string value;
            while (true)
            {
                value = CommonLogic.InputValue("G:グー C:チョキ P:パー [G(g),C(c),P(p)]", ConsoleColor.Yellow).ToUpper();
                if (value.Length == 1 && Regex.IsMatch(value, "[GCP]"))
                {
                    // GかCかPが入力された場合、入力処理を終了
                    break;
                }
                // G,C,P以外が入力された場合はエラーメッセージを表示してループ継続
                CommonLogic.DispError("G or g, C or c, P or p で入力してください。");
            }
            return this.GetHandEnum(value);
        }
        #endregion

    }

}

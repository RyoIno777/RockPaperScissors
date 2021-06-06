using RockPaperScissors.Abstract;
using RockPaperScissors.Enums;
using RockPaperScissors.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Tactics
{

    /// <summary>
    /// グーしか出さない戦術クラスです。
    /// </summary>
    public class RockTactics : ITactics
    {

        #region メンバ変数（フィールド変数）
        /// <summary>
        /// 戦術名
        /// </summary>
        public string TacticsName => "オンリー";
        #endregion

        #region メソッド
        /// <summary>
        /// 出す手を決定します。
        /// </summary>
        /// <param name="list">プレイヤーリスト</param>
        /// <returns>グー</returns>
        public HandEnum MakeUpHand(List<APlayer> list)
        {
            return HandEnum.G;
        }
        #endregion

    }

}

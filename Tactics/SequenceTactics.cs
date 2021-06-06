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
    /// グーチョキパーの順番で手を出す戦術クラスです。
    /// </summary>
    public class SequenceTactics : ITactics
    {

        #region メンバ変数（フィールド変数）
        /// <summary>
        /// 戦術名
        /// </summary>
        public string TacticsName => "シーケンス";

        /// <summary>
        /// シーケンス値
        /// </summary>
        private int _sequence;
        #endregion

        #region メソッド
        /// <summary>
        /// 出す手を決定します。
        /// </summary>
        /// <param name="list">プレイヤーリスト</param>
        /// <returns>グーチョキパーの順番（繰り返し）</returns>
        public HandEnum MakeUpHand(List<APlayer> list)
        {
            return (HandEnum)Enum.ToObject(typeof(HandEnum), _sequence ++ % 3);
        }
        #endregion

    }

}

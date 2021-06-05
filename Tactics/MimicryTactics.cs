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
    /// 人間プレイヤーの真似をして手を出す戦術クラスです。
    /// </summary>
    public class MimicryTactics : ITactics
    {

        #region メンバ変数（フィールド変数）
        /// <summary>
        /// シーケンス値
        /// </summary>
        private int _sequence;

        /// <summary>
        /// 手
        /// </summary>
        private HandEnum _hand;
        #endregion

        #region メソッド
        /// <summary>
        /// 出す手を決定します。
        /// </summary>
        /// <param name="list">プレイヤーリスト</param>
        /// <returns>前回人間プレイヤーが出した手</returns>
        public HandEnum MakeUpHand(List<APlayer> list)
        {
            // 前回出した手
            HandEnum hand = this._hand;
            // 人間プレイヤーを探索
            var target = list.Where(p => p.GetPlayerType() == TypeEnum.人間);

            if (target.Count() > 0)
            {
                // 人間プレイヤーがいる場合は手を記憶
                this._hand = target.Select(p => p.Hand).First();
            }
            if (this._sequence == 0 || target.Count() == 0)
            {
                // 初回プレイまたは人間プレイヤーがいない場合はランダムで返す
                hand = (HandEnum)Enum.GetValues(typeof(HandEnum)).GetValue(new Random().Next(0, 3));
            }

            this._sequence++;

            return hand;
        }
        #endregion

    }

}

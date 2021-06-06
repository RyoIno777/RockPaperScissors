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
    /// 鬼のような手を出す戦術クラスです。
    /// </summary>
    public class OniTactics : ITactics
    {

        #region メンバ変数（フィールド変数）
        /// <summary>
        /// 戦術名
        /// </summary>
        public string TacticsName => "おに";
        #endregion

        #region メソッド
        /// <summary>
        /// 出す手を決定します。
        /// </summary>
        /// <param name="list">プレイヤーリスト</param>
        /// <returns>人間プレイヤーに必ず勝つ手</returns>
        public HandEnum MakeUpHand(List<APlayer>list)
        {
            // 人間プレイヤーを抽出
            var target = list.Where(p => p.GetPlayerType() == TypeEnum.人間);
            if (target.Count() > 0)
            {
                // 人間プレイヤーが存在する場合は必ず勝つ手を返す
                var hand = target.Select(p => p.Hand).First();
                if (hand == HandEnum.G)
                {
                    return HandEnum.P;
                }
                else if (hand == HandEnum.C)
                {
                    return HandEnum.G;
                }
                else
                {
                    return HandEnum.C;
                }
            }
            // 人間プレイヤーが存在しない場合はランダムで手を返す
            return (HandEnum)Enum.GetValues(typeof(HandEnum)).GetValue(new Random().Next(0, 3));
        }
        #endregion

    }

}

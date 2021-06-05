using RockPaperScissors.Abstract;
using RockPaperScissors.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Interface
{

    /// <summary>
    /// 戦術インターフェースです。
    /// </summary>
    interface ITactics
    {

        #region メソッド
        /// <summary>
        /// 出す手を決定します。
        /// </summary>
        /// <param name="list">プレイヤーリスト</param>
        /// <returns>出す手</returns>
        HandEnum MakeUpHand(List<APlayer> list);
        #endregion

    }

}

﻿using RockPaperScissors.Abstract;
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
    /// チョキしか出さない戦術クラスです。
    /// </summary>
    public class ScissorsTactics : ITactics
    {

        #region メソッド
        /// <summary>
        /// 出す手を決定します。
        /// </summary>
        /// <param name="list">プレイヤーリスト</param>
        /// <returns>チョキ</returns>
        public HandEnum MakeUpHand(List<APlayer> list)
        {
            return HandEnum.C;
        }
        #endregion

    }

}

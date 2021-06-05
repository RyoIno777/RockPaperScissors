using RockPaperScissors.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Object
{

    /// <summary>
    /// 履歴クラスです。
    /// </summary>
    public class History
    {

        #region コンストラクタ
        /// <summary>
        /// 履歴クラスを初期化します。
        /// </summary>
        /// <param name="hand">出した手</param>
        /// <param name="result">結果</param>
        public History(HandEnum hand, ResultEnum result)
        {
            this.Hand = hand;
            this.Result = result;
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// 結果プロパティです。
        /// </summary>
        public ResultEnum Result
        {
            get; private set;
        }

        /// <summary>
        /// 出す手プロパティです。
        /// </summary>
        public HandEnum Hand
        {
            get; private set;
        }
        #endregion

    }

}

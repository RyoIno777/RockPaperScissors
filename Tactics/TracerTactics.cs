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
    /// 登録された通りの順番で手を出す戦術クラスです。
    /// </summary>
    public class TracerTactics : ITactics
    {

        #region メンバ変数（フィールド変数）
        /// <summary>
        /// シーケンス値
        /// </summary>
        private int _sequence;

        /// <summary>
        /// 出す順番
        /// </summary>
        private List<HandEnum> _listHands;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// 出す手の順番で初期化します。
        /// </summary>
        /// <param name="hands">手</param>
        public TracerTactics(params HandEnum[] hands)
        {
            _listHands = new List<HandEnum>(hands);
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 出す手を決定します。
        /// </summary>
        /// <param name="list">プレイヤーリスト</param>
        /// <returns>登録された順番（出す手が無くなったら最初から繰り返し）</returns>
        public HandEnum MakeUpHand(List<APlayer> list)
        {
            return this._listHands[_sequence++ % _listHands.Count];
        }
        #endregion

    }

}

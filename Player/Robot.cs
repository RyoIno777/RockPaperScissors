using RockPaperScissors.Abstract;
using RockPaperScissors.Enums;
using RockPaperScissors.Interface;
using RockPaperScissors.Tactics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Player
{

    /// <summary>
    /// ロボットプレイヤークラスです。
    /// </summary>
    class Robot : APlayer
    {

        #region フィールド
        /// <summary>
        /// 戦術クラス
        /// </summary>
        private List<ITactics> _tactics = new List<ITactics>();
        #endregion

        #region コンストラクタ
        /// <summary>
        /// ロボットクラスを初期化します。
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="tactics">戦術</param>
        public Robot(string name, ITactics tactics) : base(name)
        {
            if (tactics != null)
            {
                this._tactics.Add(tactics);
            }
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 戦術クラスを追加します。
        /// </summary>
        /// <param name="tactics"></param>
        public void AddTactics(ITactics tactics)
        {
            this._tactics.Add(tactics);
        }

        /// <summary>
        /// プレイヤータイプをロボットで返します。
        /// </summary>
        /// <returns>プレイヤータイプ：ロボット</returns>
        public override TypeEnum GetPlayerType()
        {
            return TypeEnum.ロボット;
        }

        /// <summary>
        /// 出す手を決めます。
        /// </summary>
        /// <returns>出す手</returns>
        public override HandEnum MakeUpHand(List<APlayer>list)
        {
            // 乱数クラス
            var rnd = new Random();
            // 戦術クラスが設定されている場合はその中から選択する
            if (_tactics.Count > 0)
            {
                return _tactics[rnd.Next(0, _tactics.Count)].MakeUpHand(list);
            }
            // 戦術クラスが設定されていない場合はデフォルトのランダム
            return (HandEnum)Enum.GetValues(typeof(HandEnum)).GetValue(rnd.Next(0, 3));
        }
        #endregion

    }

}

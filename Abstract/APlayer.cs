using RockPaperScissors.Enums;
using RockPaperScissors.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Abstract
{

    /// <summary>
    /// ゲームプレイヤークラスです。
    /// （プレイヤーとなるクラスはこのクラスを継承してください）
    /// </summary>
    public abstract class APlayer
    {

        #region メンバ変数（フィールド変数）
        /// <summary>
        /// プレイヤー名
        /// </summary>
        private string _name;

        /// <summary>
        /// 出す手
        /// </summary>
        private HandEnum _handEnum;

        /// <summary>
        /// 履歴情報のリスト
        /// </summary>
        private List<History> _histories = new List<History>();
        #endregion

        #region コンストラクタ
        /// <summary>
        /// プレイヤークラスを初期化します。
        /// </summary>
        /// <param name="name">プレイヤー名</param>
        public APlayer(string name)
        {
            this._name = name;
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// プレイヤー名のプロパティです。
        /// </summary>
        public string Name
        {
            get { return this._name; }
        }

        /// <summary>
        /// 手のプロパティです。
        /// </summary>
        public HandEnum Hand
        {
            get { return this._handEnum; }
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 履歴情報を取得します。
        /// </summary>
        /// <returns>戦績情報</returns>
        public List<History> GetHistories()
        {
            return this._histories;
        }

        /// <summary>
        /// 履歴情報を追加します。
        /// </summary>
        /// <param name="history">履歴</param>
        public void AddHistory(History history)
        {
            this._histories.Add(history);

        }
        /// <summary>
        /// 出す手をセットします。
        /// </summary>
        /// <param name="handEnum">手</param>
        public void SetHand(HandEnum handEnum)
        {
            this._handEnum = handEnum;
        }

        #region 抽象メソッド
        /// <summary>
        /// 出す手を決定します。
        /// （継承先で実装してください）
        /// </summary>
        /// <returns>出す手</returns>
        public abstract HandEnum MakeUpHand(List<APlayer>list);

        /// <summary>
        /// プレイヤーのタイプを返します。
        /// (継承先のクラスで返してください。)
        /// </summary>
        /// <returns>プレイヤータイプ</returns>
        public abstract TypeEnum GetPlayerType();
        #endregion

        /// <summary>
        /// 入力された文字列から手を取得します。
        /// </summary>
        /// <param name="value">入力文字</param>
        /// <returns>手</returns>
        protected HandEnum GetHandEnum(string value)
        {
            Enum.TryParse<HandEnum>(value, out HandEnum handEnum);
            return handEnum;
        }
        #endregion
    }
}

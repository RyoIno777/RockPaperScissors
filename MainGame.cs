using RockPaperScissors.Abstract;
using RockPaperScissors.Enums;
using RockPaperScissors.Object;
using RockPaperScissors.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RockPaperScissors
{

    /// <summary>
    /// ゲームクラスです。
    /// </summary>
    class MainGame
    {

        #region メンバ変数(フィールド変数)
        /// <summary>
        /// プレイヤー用のリストです。
        /// </summary>
        List<APlayer> _participationList = new List<APlayer>();
        #endregion

        #region コンストラクタ
        /// <summary>
        /// ゲームクラスを初期化します。
        /// </summary>
        public MainGame()
        {
        }
        #endregion

        #region メソッド
        /// <summary>
        /// プレイヤーを追加します。
        /// </summary>
        /// <param name="human">参加プレイヤー</param>
        public void AddPlayer(APlayer player)
        {
            this._participationList.Add(player);
        }

        /// <summary>
        /// ゲームへの参加人数を返します。
        /// </summary>
        /// <returns>参加人数</returns>
        public int GetParticipationNumber()
        {
            return this._participationList.Count;
        }

        /// <summary>
        /// ゲームをスタートします。
        /// </summary>
        public void Start()
        {

            Thread.Sleep(3000);

            // 行ったゲーム数（カウントしているが現在未使用）
            int loop = 0;
            // プレイユーザを登録ユーザからコピー
            var listPlayer = new List<APlayer>(_participationList);
            // あいこの判定
            var drawCnt = 0;

            #region ゲームのメインループ
            // 最後の一人までゲームを続ける
            while (listPlayer.Count > 1)
            {

                #region 出す手を決める処理
                // 参加者全員の出す手を決める処理
                // 多態性(ポリモーフィズム)　←　人間かロボットかで処理が違う
                // （手動で選ばせる、自動で選ぶ）
                // を人間とロボットの判定をしなくても実行できる
                // APlayerクラスに抽象メソッドであるMakeUpHand()が定義され、
                // Humanクラス、Robotクラスそれぞれで実装しているため
                listPlayer.ForEach(player => player.SetHand(player.MakeUpHand(listPlayer)));
                #endregion

                #region じゃんけんかけごえ処理
                if (drawCnt > 0)
                {
                    // 前回のゲームがあいこの場合
                    CommonLogic.DispMsg(false, "あーーーいこで", ConsoleColor.Green);
                    Thread.Sleep(2000);
                    CommonLogic.DispMsg(true, "しょっ！", ConsoleColor.Green);
                }
                else
                {
                    // 勝敗が決まった場合
                    CommonLogic.DispMsg(false, "じゃーーーんけーーん", ConsoleColor.Cyan);
                    Thread.Sleep(2000);
                    CommonLogic.DispMsg(true, "ぽん！", ConsoleColor.Cyan);
                }
                #endregion

                #region あいこ救済処理
                if (drawCnt > 1)
                {
                    // あいこが複数回続いた場合(グーとチョキに置換してしまう)
                    listPlayer.ForEach(player => player.SetHand((HandEnum)new Random().Next(0, 2)));
                }
                #endregion

                #region じゃんけんの手を出す処理
                // 参加者すべての手を表示
                listPlayer.ForEach(player => CommonLogic.DispMsg(false, string.Format("{0}：{1}", player.Name, player.Hand.ToString())));
                // 判定前の人数
                int beforeCnt = listPlayer.Count();
                listPlayer = this.Judgment(listPlayer);
                // 判定後の人数と比べて同じ場合はあいことする
                if (beforeCnt == listPlayer.Count())
                {
                    // 引き分け回数を加算
                    drawCnt++;
                }
                else
                {
                    // 勝敗が決まった場合
                    Thread.Sleep(1000);
                    CommonLogic.DispMsg(true, "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆\n　勝ち残ったプレイヤー\n◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆", ConsoleColor.Yellow);
                    this.DispPlayers(listPlayer);
                    drawCnt = 0;
                }
                #endregion

                // ゲーム数を加算
                loop++;
                Thread.Sleep(3000);
            }
            #endregion

        }

        /// <summary>
        /// プレイヤー情報を表示します。
        /// </summary>
        public void DispPlayers(List<APlayer>list = null)
        {
            var targetList = list == null ? this._participationList : list;
            targetList.ForEach(v =>
            {
                if (v.GetPlayerType() == TypeEnum.人間)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("　{0}", v.Name);
            });
        }

        /// <summary>
        /// 出す手を表示します。
        /// </summary>
        public void DispHands()
        {
            this._participationList.ForEach(v =>
            {
                if (v.GetPlayerType() == TypeEnum.人間)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("　{0}", v.Name);
            });
        }

        /// <summary>
        /// 戦績を表示します。
        /// </summary>
        public void DispResult()
        {
            CommonLogic.DispMsg(true, "");
            // 参加者全員分の表示
            _participationList.ForEach(player =>
            {
                string tacticsName = player is Robot ? ((Robot)player).TacticsName : "";
                CommonLogic.DispMsg(false, string.Format("【{0}】さんの戦績 {1}", player.Name, tacticsName), ConsoleColor.Yellow);
                int index = 0;
                player.GetHistories().ForEach(history =>
                {
                    // プレイヤーの戦績を表示
                    switch (history.Result)
                    {
                        case ResultEnum.Win:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case ResultEnum.Lose:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                        case ResultEnum.Draw:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        default:
                            break;
                    }
                    Console.Write("{0} " , history.Hand);

                    #region 優勝者の表示
                    if (player.GetHistories().Count() == ++index)
                    {
                        if (history.Result == ResultEnum.Win)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("　←　優勝！！！");
                        }
                    }
                    #endregion
                });
                CommonLogic.DispNewLine(2);
                Console.ResetColor();
            });
        }

        #region プライベートメソッド
        /// <summary>
        /// 勝ち残ったプレイヤーのリストを返します。
        /// </summary>
        /// <param name="list">対象リスト</param>
        /// <returns>勝者またはあいこのリスト</returns>
        private List<APlayer> Judgment(List<APlayer>list)
        {

            #region 処理用のリスト作成
            // グーを出したプレイヤー
            var g = list.FindAll(v => v.Hand == HandEnum.G);
            // チョキを出したプレイヤー
            var c = list.FindAll(v => v.Hand == HandEnum.C);
            // パーを出したプレイヤー
            var p = list.FindAll(v => v.Hand == HandEnum.P);
            #endregion

            #region 判定処理
            // あいこの判定
            if (
                // 全部が違う場合(リストが1件以上の場合は出された手である)
                (g.Count > 0 && c.Count > 0 && p.Count > 0) ||
                // 全体のリストとある手のリストサイズが同じ場合は全て同じ手が出されている
                (list.Count == g.Count || list.Count == c.Count || list.Count == p.Count)
            )
            {
                // あいこの場合は全て返す(戦績にDrawを設定する）
                return list.Select(player =>
                {
                    player.AddHistory(new History(player.Hand, ResultEnum.Draw));
                    return player;
                }).ToList();
            }
            if (g.Count > 0 && c.Count > 0)
            {
                // グーの勝ち
                g.ForEach(v => v.AddHistory(new History(HandEnum.G, ResultEnum.Win)));
                c.ForEach(v => v.AddHistory(new History(HandEnum.C, ResultEnum.Lose)));
                return new List<APlayer>(g);
            }
            if (g.Count > 0 && p.Count > 0)
            {
                // パーの勝ち
                p.ForEach(v => v.AddHistory(new History(HandEnum.P, ResultEnum.Win)));
                g.ForEach(v => v.AddHistory(new History(HandEnum.G, ResultEnum.Lose)));
                return new List<APlayer>(p);
            }
            // チョキの勝ち
            c.ForEach(v => v.AddHistory(new History(HandEnum.C, ResultEnum.Win)));
            p.ForEach(v => v.AddHistory(new History(HandEnum.P, ResultEnum.Lose)));
            return new List<APlayer>(c);
            #endregion
        }
        #endregion
        #endregion

    }

}

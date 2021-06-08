using RockPaperScissors.Enums;
using RockPaperScissors.Player;
using RockPaperScissors.Tactics;
using System;

namespace RockPaperScissors
{

    /// <summary>
    /// じゃんけんゲームプログラムクラスです。
    /// </summary>
    class Program
    {

        /// <summary>
        /// じゃんけんゲームを実行します。
        /// </summary>
        /// <param name="args">プログラム起動引数</param>
        static void Main(string[] args)
        {

            #region 参加人数の決定
            // 参加人数
            int sanka = 0;
            while (true)
            {
                string value = CommonLogic.InputValue("参加人数を入力してください。[1-99]");
                try
                {
                    sanka = int.Parse(value);
                    if ((0 < sanka) && (sanka < 100))
                    {
                        break;
                    }
                }
                catch { }
                CommonLogic.DispError("1-9の数字で入力してください。");
            }
            #endregion

            #region プレイヤー名の決定
            // プレイヤー名
            string playerName = CommonLogic.InputValue("プレイヤー名を入力してください。(人間が参加しない場合はそのままエンター)");
            #endregion

            #region ゲーム準備
            var mainGame = new MainGame();

            // 人間プレイヤーを参加させる
            if (!string.IsNullOrEmpty(playerName))
            {
                var mainPlayer = new Human(playerName);
                mainGame.AddPlayer(mainPlayer);
            }

            // 指定された参加人数になるまでロボットを参加させる
            int nowPlayerNumber = mainGame.GetParticipationNumber();
            var rnd = new Random();
            for (int i = nowPlayerNumber; i < nowPlayerNumber + sanka; i ++)
            {
                var robot = new Robot(string.Format("ロボット{0}", i + 1), null);

                switch(rnd.Next(0, 6))
                {
                    case 0:
                        // ノーマルタイプ
                        break;
                    case 1:
                        // グーしか出さない
                        robot.AddTactics(new RockTactics());
                        break;
                    case 2:
                        // パーかグーしか出さない
                        robot.AddTactics(new PaperTactics());
                        robot.AddTactics(new RockTactics());
                        break;
                    case 3:
                        // 指定した順番に出す
                        robot.AddTactics(new TracerTactics(HandEnum.G, HandEnum.C, HandEnum.C, HandEnum.G, HandEnum.P));
                        break;
                    case 4:
                        // グーチョキパーの順番で出す
                        robot.AddTactics(new SequenceTactics());
                        break;
                    case 5:
                        // ひとつ前の人間プレイヤーの手を出す
                        robot.AddTactics(new MimicryTactics());
                        break;
                    case 6:
                        // 人間プレイヤーに勝つ手を出す
                        robot.AddTactics(new OniTactics());
                        break;

                    default:
                        break;
                }
                // 各種戦術で作成したロボットを参加者に追加
                mainGame.AddPlayer(robot);
            }
            #endregion

            #region ゲーム開始
            CommonLogic.DispMsg(true, "◆プレイヤーリスト", ConsoleColor.Blue);
            mainGame.DispPlayers();
            CommonLogic.DispMsg(false, "◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆\n　ゲームをスタートします。\n◆◆◆◆◆◆◆◆◆◆◆◆◆◆◆", ConsoleColor.Yellow);

            // じゃんけんゲームを開始
            mainGame.Start();

            // 戦績を表示
            mainGame.DispResult();
            #endregion
        }

    }

}

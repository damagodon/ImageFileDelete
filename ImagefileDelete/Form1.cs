using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagefileDelete
{
    public partial class ImagefileDelete : Form
    {
        public ImagefileDelete()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagefileDelete_Shown(object sender, EventArgs e)
        {
            txtInputDir.Clear();
            fileClear();
        }

        /// <summary>
        /// 参照ボタンを押した時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRef_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = @"フォルダを指定してください。";
                //ルートフォルダを指定する
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                //最初に選択するフォルダを指定する
                string initSelectPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (string.IsNullOrWhiteSpace(txtInputDir.Text) == false)
                {
                    initSelectPath = txtInputDir.Text;
                }
                fbd.SelectedPath = initSelectPath;
                //ユーザーが新しいフォルダを作成できるようにする
                fbd.ShowNewFolderButton = true;
                //表示
                if (fbd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string selectPath = fbd.SelectedPath;
                txtInputDir.Text = selectPath;
            }
            fileClear();
            this.btnLoad.Focus();
        }


        /// <summary>
        /// 読み込みボタンを押した時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // 初期設定
            fileClear();
            // 入力チェック
            if (hasError())
            {
                return;
            }
            // イメージファイルを表示して対象がなければエラー
            if (showImageFiles() == 0)
            {
                MessageBox.Show("対象ファイルが存在しません","入力エラー",MessageBoxButtons.OK);
                this.txtInputDir.Focus();
                return;
            }
            string selectDir = txtInputDir.Text;
            string[] imagesPath = Directory.GetFiles(selectDir, @"*", SearchOption.TopDirectoryOnly);
            List<string> imagesPathList = new List<string>();
            foreach (string imagePath in imagesPath)
            {
                string afterImagePath = Path.GetFileName(imagePath);
                imagesPathList.Add(afterImagePath);
            }
            // .mdファイルのパス取得
            string frontSelectPath = selectDir.Substring(0, selectDir.LastIndexOf(@"\") + 1);
            string[] mdFilesPath = Directory.GetFiles(frontSelectPath, "*.md", SearchOption.AllDirectories);          
            // リスト(サイズ可変の配列)の宣言
            List<string> deleteImages = new List<string>();
            foreach(string image in imagesPathList)
            {
                // リストにイメージファイルを追加(Add)
                if (!containImageFile(image, mdFilesPath))
                {
                    deleteImages.Add(image);
                }
            }
            lstDeleteFile.Items.AddRange(deleteImages.ToArray());
            changeEnableBtnDelete();
        }

        /// <summary>
        /// 削除ボタンのクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectDir = txtInputDir.Text;
            foreach (Object lstDeleteFileitem in lstDeleteFile.Items)
            {
                string deleteFileName = lstDeleteFileitem.ToString();
                string deleteFilePath = selectDir + @"\" + deleteFileName;
                DialogResult result = MessageBox.Show("ファイルを削除しますか？","確認",MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    File.Delete(deleteFilePath);
                    MessageBox.Show("正常に作動しました", "ファイル削除", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// クリアボタンのクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllClear_Click(object sender, EventArgs e)
        {
            fileClear();
            txtInputDir.Clear();
        }

        // 以下関数群
        /// <summary>
        /// 初期設定
        /// </summary>
        private void fileClear()
        {
            lstImageFile.Items.Clear();
            lstDeleteFile.Items.Clear();
            changeEnableBtnDelete();
        }

        /// <summary>
        /// 入力内容にエラーがあればtrueを返す
        /// </summary>
        /// <returns></returns>
        private bool hasError()
        {
            string selectDir = txtInputDir.Text;
            
            // 必須チェック
            if (string.IsNullOrWhiteSpace(selectDir) == true)
            {
                MessageBox.Show("フォルダを選択してください", "入力エラー", MessageBoxButtons.OK);
                this.txtInputDir.Focus();
                return true;
            }

            // 存在チェック
            if (Directory.Exists(selectDir) == false)
            {
                MessageBox.Show("存在するフォルダを選択してください", "入力エラー", MessageBoxButtons.OK);
                this.txtInputDir.Focus();
                return true;
            }

            // .png存在チェック
            string[] imageFilePath = Directory.GetFiles(selectDir, @"*", System.IO.SearchOption.TopDirectoryOnly);
            string extension = Path.GetExtension(imageFilePath[0]);
            if (extension != ".png")
            {
                MessageBox.Show("直下にイメージファイルが存在するフォルダを選択してください", "入力エラー", MessageBoxButtons.OK);
                this.txtInputDir.Focus();
                return true;
            }
            // 選択したフォルダがドライブの時、.mdファイルを取得するために一階層上がれないのでエラー
            string directory = Path.GetDirectoryName(selectDir);
            if (string.IsNullOrWhiteSpace(directory) == true)
            {
                MessageBox.Show("イメージフォルダを選択してください","入力エラー",MessageBoxButtons.OK);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 削除ボタンが押せるかどうか
        /// </summary>
        private void changeEnableBtnDelete()
        {
            bool hasItem = (lstDeleteFile.Items.Count > 0);
            btnDelete.Enabled = hasItem;
        }

        /// <summary>
        /// イメージファイルリストボックスにイメージファイルを表示
        /// </summary>
        /// <returns>ファイル件数</returns>
        private int showImageFiles()
        {
            string selectDir = txtInputDir.Text;
            string[] files = Directory.GetFiles(selectDir, @"*", SearchOption.TopDirectoryOnly);
            //1つずつ表示する
            for (int i = 0; i < files.Length; i++)
            {
                string pathBefore = files[i];
                string pathAfter = pathBefore.Replace(selectDir + @"\", "");
                this.lstImageFile.Items.Add(pathAfter);
            }
            return files.Length;
        }

        /// <summary>
        /// .mdファイルの中にイメージファイルの文字列があるか
        /// </summary>
        /// <returns>イメージファイルが.mdファイル中に存在したらtrueを返す</returns>
        private bool containImageFile(string imagePath,string[] mdFilesPath)
        {
            bool isfind = false;
            string target = Path.GetFileNameWithoutExtension(imagePath);
            foreach (string mdFile in mdFilesPath)
            {
                // mdファイルのテキストを取得
                StreamReader readText = new StreamReader(mdFile);
                string mdFileText = readText.ReadToEnd();
                if (mdFileText.Contains(target))
                {
                    isfind = true;
                    break;
                }
            }
            return isfind;         
        }
    }
}
  
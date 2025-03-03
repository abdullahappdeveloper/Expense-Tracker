using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManagmentSystem
{
    class DialogueManager
    {

        #region Singleton
        private static DialogueManager _instance = null;
        
        private DialogueManager()
        {
        }
        public static DialogueManager GetManager()
        {
            if (_instance == null)
            {
                _instance = new DialogueManager();
            }
            return _instance;
        }
        #endregion

        public void ShowMessageBox(string msg) 
        {
            MessageBox.Show(msg); 
        }

        public void ShowSaveFileDialogue(out string fileSelected) 
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Create Project : ";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Filter = "Database Files (*.db)|*.db";
            //saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileSelected = saveFileDialog.FileName;
                ShowMessageBox(fileSelected); 
            }
            else 
            {
                fileSelected = string.Empty;
            }
        }

        public DialogResult ShowImportFileDialogue(out string fileSelected) 
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog.Filter = "Database Files (*.db)|*.db";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            DialogResult result = openFileDialog.ShowDialog();
            fileSelected = openFileDialog.FileName;

            return result;
        }


    }
}

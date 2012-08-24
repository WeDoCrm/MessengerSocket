using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace DragDropExam
{
    public partial class SourceForm : Form
    {
        public SourceForm()
        {
            InitializeComponent();


            for (int i = 0; i < 10; i++)
            {
                TreeNode node = new TreeNode("노드-" + i);
                for (int j = 0; j < 5; j++)
                {
                    node.Nodes.Add("자식노드-" + i +"," + j);
                }
                treeView.Nodes.Add(node);
            }
            treeView.ExpandAll();
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Debug.WriteLine("\t Source Tree Item Dragged... ");

            if (e.Button == MouseButtons.Left)
            {
                treeView.DoDragDrop(e.Item.ToString(), DragDropEffects.Copy | DragDropEffects.All);
            }
        }

        private void treeView_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            // 드래그 드랍을 받는 타겟에서 드랍 가능 여부를 e.Effect로 알수 있다. 

            Debug.WriteLine("\t Source Give Feedback : " + e.Effect);

            // 드랍 가능 여부 상태에 따라서 마우스 커서의 모양을 바꿔줄 수 있다.

            Cursor MyNormalCursor = null;
            Cursor MyNoDropCursor = null;
            try
            {

                MyNormalCursor = new Cursor("AllowDrop.cur");
                MyNoDropCursor = new Cursor("NoDrop.cur");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            // Sets the custom cursor based upon the effect.
            e.UseDefaultCursors = false;
            if ((e.Effect & DragDropEffects.All) == DragDropEffects.All)
                Cursor.Current = MyNormalCursor;
            else
                Cursor.Current = MyNoDropCursor;

        }

        private void treeView_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            Debug.WriteLine("\t Source Query Continue Drag: " + e.Action);
        }
    }
}

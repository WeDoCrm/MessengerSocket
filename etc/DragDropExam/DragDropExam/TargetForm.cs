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
    public partial class TargetForm : Form
    {
        public TargetForm()
        {
            InitializeComponent();
        }

        private void TargetForm_DragDrop(object sender, DragEventArgs e)
        {
            
            Debug.WriteLine("Target Form Dropped");
//            MessageBox.Show("Dropped" + e.Data.GetData( DataFormats.Text ).ToString() );

            Point pt = new Point(e.X, e.Y);
            pt = this.PointToClient(pt);

            Label label = new Label();
            label.Text = e.Data.GetData(DataFormats.Text).ToString();
            label.BorderStyle = BorderStyle.FixedSingle;
            label.AutoSize = true;
            this.Controls.Add(label);
            label.Location = new Point(pt.X, pt.Y);
  
        }

        private void TargetForm_DragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Target Form Drag Over: X:" + e.X + ", Y:" + e.Y + ", ITEM:" + e.Data.GetData( DataFormats.Text ));
            if (!e.Data.GetDataPresent(typeof(System.String)))
            {
                e.Effect = DragDropEffects.None;
                Debug.WriteLine("\t\t -----None - no string data.");
                return;
            }

        }

        private void TargetForm_DragLeave(object sender, EventArgs e)
        {
            Debug.WriteLine("Target Form Drag Leave ");
        }

        private void TargetForm_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Target Form Drag Enter");
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.All;
            else                                    // 아니면 이펙트를 모두 꺼서 금지표시가 나타나게 됨
                e.Effect = DragDropEffects.None;    
        }
    }
}

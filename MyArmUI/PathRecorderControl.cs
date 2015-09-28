using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyArmClient;

namespace MyArmUI
{
    public partial class PathRecorderControl : UserControl
    {
        private Path mPath = new Path();
        private BindingSource mBind;


        public Client Arm { get; set; }
        public ICoordinatesProvider CoordinatesProvider { get; set; }


        public PathRecorderControl()
        {
            InitializeComponent();
        }

        private void PathRecorderControl_Load(object sender, EventArgs e)
        {
            BindPath();
        }

        private void AddStepButton_Click(object sender, EventArgs e)
        {
            CheckClient();

            var position = CoordinatesProvider.GetCoordinates();

            mPath.Steps.Add(new PathStep() { Position = position.Clone(), Time = 500 });
            //mBind.Add(new PathStep() { Position = position, Time = 500 });
            mBind.ResetBindings(false);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    mPath = Path.Load(openFileDialog1.FileName);
                    BindPath();
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    mPath.Save(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            mPath.Steps.Clear();
            mBind.ResetBindings(false);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            CheckClient();

            mPath.Play(Arm,
                (s) => { SelectRowForStep(s); },
                () => { });
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var currentIdx = dataGridView1.CurrentRow.Index;
            if (currentIdx < 0 || currentIdx >= mPath.Steps.Count) return;

            var currentStep = mPath.Steps[currentIdx];

            mPath.PlaySingleStep(Arm, currentStep);

            var nextIdx = currentIdx + 1;
            nextIdx = (nextIdx >= mPath.Steps.Count) ? 0 : nextIdx;

            SelectRowForStep(mPath.Steps[nextIdx]);
        }


        private void SelectRowForStep(PathStep step)
        {
            Invoke(new Action(() =>
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.DataBoundItem == step)
                    {
                        dataGridView1.CurrentCell = r.Cells[0];
                    }
                }
            }));
        }

        private void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error");
        }

        private void BindPath()
        {
            mBind = new BindingSource(mPath, "Steps");
            dataGridView1.DataSource = mBind;
        }

        private void CheckClient()
        {
            if (Arm == null) throw new Exception("Arm client has not been initialized");
            if (CoordinatesProvider == null) throw new Exception("Coordinates provider has not been initialized");
        }

    }
}

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_11_D
{
    public delegate void StatusUpdateHandler(string newMessage);

    public class MedicationManager
    {
        public event StatusUpdateHandler StatusChanged;

        private readonly string[] _stages = new[]
        {
            "Discovery",
            "Preclinical",
            "Phase I",
            "Phase II",
            "Phase III",
            "Regulatory Review",
            "Approved"
        };

        private int _currentStageIndex = 0;
        private bool _safetyPassed = false;

        public string CurrentStage => _stages[_currentStageIndex];

        protected virtual void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(status);
        }

        public void AdvanceStage()
        {
            if (_currentStageIndex < _stages.Length - 1)
            {
                _currentStageIndex++;
            }
            else
            {
                // restart for demo purposes
                _currentStageIndex = 0;
            }

            string status = $"Stage: {CurrentStage} | Safety: {(_safetyPassed ? "Passed" : "Pending")}";
            OnStatusChanged(status);
        }

        public void SetSafety(bool passed)
        {
            _safetyPassed = passed;
            string status = $"Stage: {CurrentStage} | Safety: {(_safetyPassed ? "Passed" : "Pending")}";
            OnStatusChanged(status);
        }
    }

    public partial class Form1 : Form
    {
        private MedicationManager _manager;

        public Form1()
        {
            InitializeComponent();

            _manager = new MedicationManager();
            _manager.StatusChanged += UpdateProgressLabel; // update main progress label
            _manager.StatusChanged += UpdateLastUpdateLabel; // update last update label

            lblProgress.Text = $"Progress: {_manager.CurrentStage} | Safety: Pending";
            lblLastUpdate.Text = "Last update: none";
            btnNext.Text = "Next Stage";
        }

        private async void UpdateProgressLabel(string newMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new StatusUpdateHandler(UpdateProgressLabel), new object[] { newMessage });
                return;
            }

            // update text and flash background to show change
            lblProgress.Text = newMessage;
            var original = lblProgress.BackColor;
            lblProgress.BackColor = Color.LightYellow;
            await Task.Delay(300);
            lblProgress.BackColor = original;
        }

        private async void UpdateLastUpdateLabel(string newMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new StatusUpdateHandler(UpdateLastUpdateLabel), new object[] { newMessage });
                return;
            }

            lblLastUpdate.Text = $"Last update ({DateTime.Now:T}): {newMessage}";

            var original = lblLastUpdate.BackColor;
            lblLastUpdate.BackColor = Color.LightGreen;
            await Task.Delay(500);
            lblLastUpdate.BackColor = original;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _manager.AdvanceStage();
        }

        private void chkSafety_CheckedChanged(object sender, EventArgs e)
        {
            _manager.SetSafety(chkSafety.Checked);
        }
    }
}
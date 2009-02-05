using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Estimator.Simple;
using Estimation.Core;

namespace TestSimpleEstimation
{
    public partial class Form1 : Form
    {
        private EstimationEngine engine_ = new EstimationEngine();
        private EstimationRuleList rulesList_ = new EstimationRuleList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoScroll = true;
        }

        private void btnCreateRules_Click(object sender, EventArgs e)
        {
            int ruleCount = 0;

            int.TryParse(txtRulesCount.Text.Trim(), out ruleCount);

            panel2.Controls.Clear();
            rulesList_.Clear();

            panel2.AutoScroll = true;
            
            if (ruleCount > 0)
            {
                for (int i = 0; i < ruleCount; i++)
                {
                    Label l = new Label();
                    l.Text = i.ToString();
                    l.Bounds = new Rectangle(0, 25 * i, 20, 25);

                    panel2.Controls.Add(l);

                    ProgressBar bar = new ProgressBar();

                    bar.Maximum = 100;
                    bar.Minimum = 0;
                    bar.Bounds = new Rectangle(20, 25 * i, panel2.Width - 20, 25);
                    
                    panel2.Controls.Add(bar);

                    rulesList_.Add(new SimpleEstimationRule(i));
                }
            }
        }

        private void btnStartEstimator_Click(object sender, EventArgs e)
        {
            int eventCount = 0;

            int.TryParse(txtEventsCount.Text.Trim(), out eventCount);

            if (eventCount <= 0)
                return;

            Estimator estimator = engine_.CreateEstimator(new SimpleEstimationCategory(),
                new SimpleEstimationRuleSet(rulesList_));

            estimator.OnRuleRateUpdate += new UpdateRuleRateHandler(estimator_OnRuleRateUpdate);

            backgroundWorker1.RunWorkerAsync(estimator);
        }

        void estimator_OnRuleRateUpdate(UpdateRuleRateEventArgs args)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }
    }
}
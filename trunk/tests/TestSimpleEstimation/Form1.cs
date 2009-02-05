using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Estimation.Simple;
using Estimation.Core;

namespace TestSimpleEstimation
{
    public class Info
    {
        public TextBox UpDown;
        public ProgressBar Bar;
    }

    public partial class Form1 : Form
    {
        private EstimationEngine engine_ = new EstimationEngine();
        private EstimationRuleList rulesList_ = new EstimationRuleList();
        private List<Info> infoList_ = new List<Info>();

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
            infoList_.Clear();

            panel2.AutoScroll = true;
            
            if (ruleCount > 0)
            {
                for (int i = 0; i < ruleCount; i++)
                {
                    Label l = new Label();
                    l.Text = i.ToString();
                    l.Bounds = new Rectangle(0, 25 * i, 20, 25);

                    panel2.Controls.Add(l);

                    TextBox upDown = new TextBox();
                    upDown.Bounds = new Rectangle(20, 25 * i, 20, 25);

                    panel2.Controls.Add(upDown);

                    ProgressBar bar = new ProgressBar();

                    bar.Maximum = 100;
                    bar.Minimum = 0;
                    bar.Bounds = new Rectangle(20 + 20, 25 * i, panel2.Width - 20 - 20, 25);
                    
                    panel2.Controls.Add(bar);

                    rulesList_.Add(new SimpleEstimationRule(i));

                    Info info = new Info();
                    info.Bar = bar;
                    info.UpDown = upDown;

                    infoList_.Add(info);
                }
            }
        }

        private Estimator estimator_ = null;

        private void btnStartEstimator_Click(object sender, EventArgs e)
        {
            int eventCount = 0;

            int.TryParse(txtEventsCount.Text.Trim(), out eventCount);

            if (eventCount <= 0)
                return;

            if (estimator_ != null)
            {
                estimator_.Deinitialize();
            }

            estimator_ = engine_.CreateEstimator(new SimpleEstimationCategory(),
                new SimpleEstimationRuleSet(rulesList_));

            estimator_.Initialize();

            estimator_.OnRuleRateUpdate += new UpdateRuleRateHandler(estimator_OnRuleRateUpdate);

            backgroundWorker1.RunWorkerAsync(estimator_);
        }

        public delegate void UpdateRateHandler(Info info, long rate);

        private void estimator_OnRuleRateUpdate(UpdateRuleRateEventArgs args)
        {
            SimpleRuleIdentity id = args.NewRate.RuleIdentity as SimpleRuleIdentity;
            SimpleRuleRate newRate = args.NewRate as SimpleRuleRate;

            Info info = infoList_[id.IntId];

            if (info.Bar.InvokeRequired)
            {
                info.Bar.Invoke(new UpdateRateHandler(UpdateRate), info, newRate.LongRate);
            }
        }

        private void UpdateRate(Info info, long rate)
        {
            info.UpDown.Text = rate.ToString();

            if (rate < 0)
                rate = 0;

            if (rate > 100)
                rate = 100;

            info.Bar.Value = Convert.ToInt32(rate & 0x7FFFFFFF);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int eventCount = 0;

            int.TryParse(txtEventsCount.Text.Trim(), out eventCount);

            if (eventCount <= 0)
                return;

            Random rand = new Random(Convert.ToInt32(DateTime.Now.Ticks & 0x7FFFFFFF));
            Estimator estimator = e.Argument as Estimator;

            for (int i = 0; i < eventCount; i++)
            {
                int val = rand.Next(0, 100);

                SimpleEstimationEvent simpleEvent =
                    new SimpleEstimationEvent();
                simpleEvent.SimpleCategory = new SimpleEstimationCategory();
                simpleEvent.Value = val;

                estimator.PushEvent(simpleEvent);
            }
        }
    }
}
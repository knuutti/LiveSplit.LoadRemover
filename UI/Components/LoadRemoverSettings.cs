using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class LoadRemoverSettings : UserControl

    {
        
        public bool Display2Rows { get; set; }
        public LayoutMode Mode { get; set; }
        public bool IsLoading { get; set; }
        public float LoadTimes { get; set; }
        public enum LoadRemoverAccuracy
        {
            ZeroDecimal,
            OneDecimal,
            TwoDecimal
        }
        public LoadRemoverAccuracy Accuracy { get; set; }

        public LoadRemoverSettings()
        {

            InitializeComponent();

            Accuracy = LoadRemoverAccuracy.ZeroDecimal;
            Display2Rows = false;
            LoadTimes = 0;
            IsLoading = false;
        }

        private void LoadRemoverSettings_Load(object sender, EventArgs e)
        {
            /*
            if (Mode == LayoutMode.Horizontal)
            {
                chkTwoRows.Enabled = false;
                chkTwoRows.DataBindings.Clear();
                chkTwoRows.Checked = true;
            }
            else
            {
                chkTwoRows.Enabled = true;
                chkTwoRows.DataBindings.Clear();
                chkTwoRows.DataBindings.Add("Checked", this, "Display2Rows", false, DataSourceUpdateMode.OnPropertyChanged);
            }
            rdoDecimalZero.Checked = Accuracy == LoadRemoverAccuracy.ZeroDecimal;
            rdoDecimalOne.Checked = Accuracy == LoadRemoverAccuracy.OneDecimal;
            rdoDecimalTwo.Checked = Accuracy == LoadRemoverAccuracy.TwoDecimal;
            */
        }
        private void UpdateAccuracy()
        {
            /*
            if (rdoDecimalZero.Checked)
                Accuracy = LoadRemoverAccuracy.ZeroDecimal;
            else if (rdoDecimalOne.Checked)
                Accuracy = LoadRemoverAccuracy.OneDecimal;
            else
                Accuracy = LoadRemoverAccuracy.TwoDecimal;
            */
        }

        private void rdoDecimalZero_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAccuracy();
        }

        private void rdoDecimalOne_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAccuracy();
        }

        private void rdoDecimalTwo_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAccuracy();
        }
        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
                SettingsHelper.CreateSetting(document, parent, "Accuracy", Accuracy) ^
                SettingsHelper.CreateSetting(document, parent, "Display2Rows", Display2Rows);
        }
        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }
        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            Accuracy = SettingsHelper.ParseEnum<LoadRemoverAccuracy>(element["Accuracy"]);
            Display2Rows = SettingsHelper.ParseBool(element["Display2Rows"], false);
        }
    }
}

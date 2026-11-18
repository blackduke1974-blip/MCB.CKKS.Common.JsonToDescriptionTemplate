using MCB.CKKS.Common.JsonToDescriptionTemplate.Interfaces;

namespace MCB.CKKS.Common.JsonToDescriptionTemplate.UI
{
    public partial class FormMain : Form
    {
        private readonly IJsonDescriptionTemplate _jsonDescriptionTemplate;

        public FormMain(IJsonDescriptionTemplate jsonDescriptionTemplate)
        {
            _jsonDescriptionTemplate = jsonDescriptionTemplate;
            InitializeComponent();
        }
    }
}

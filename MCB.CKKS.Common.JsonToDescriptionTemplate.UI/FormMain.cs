using System.Collections.ObjectModel;
using MCB.CKKS.Common.JsonToDescriptionTemplate.Interfaces;

namespace MCB.CKKS.Common.JsonToDescriptionTemplate.UI
{
    public partial class FormMain : Form
    {
        private readonly IJsonDescriptionTemplate _jsonDescriptionTemplate;
        private readonly ObservableCollection<RenderItem> _renders = new();

        public FormMain(IJsonDescriptionTemplate jsonDescriptionTemplate)
        {
            _jsonDescriptionTemplate = jsonDescriptionTemplate;
            InitializeComponent();
            lstRenders.DisplayMember = "Name";
            lstRenders.ValueMember = "Id";
        }

        private async void btnSelectJson_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "JSON files|*.json|All files|*.*",
                Title = "Выберите JSON файл"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                txtJsonFile.Text = dlg.FileName;
        }

        private async void btnSelectTemplate_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "Text files|*.txt|Scriban files|*.sb|All files|*.*",
                Title = "Выберите файл шаблона"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                txtTemplateFile.Text = dlg.FileName;
        }

        private async void btnRender_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJsonFile.Text) || !File.Exists(txtJsonFile.Text))
            {
                MessageBox.Show("Выберите корректный JSON файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTemplateFile.Text) || !File.Exists(txtTemplateFile.Text))
            {
                MessageBox.Show("Выберите корректный файл шаблона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var jsonContext = await File.ReadAllTextAsync(txtJsonFile.Text);
                var templateContent = await File.ReadAllTextAsync(txtTemplateFile.Text);
                var result = _jsonDescriptionTemplate.RenderJson(jsonContext, templateContent);

                var item = new RenderItem
                {
                    Id = Guid.NewGuid(),
                    Name = $"{Path.GetFileName(txtJsonFile.Text)} + {Path.GetFileName(txtTemplateFile.Text)}",
                    Markdown = result
                };
                _renders.Add(item);
                lstRenders.Items.Add(item);
                lstRenders.SelectedIndex = lstRenders.Items.Count - 1;
                await mdViewer.LoadMarkdownFromStringAsync(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при рендеринге: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void lstRenders_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstRenders.SelectedItem is RenderItem selected)
            {
                await mdViewer.LoadMarkdownFromStringAsync(selected.Markdown);
            }
        }

        private class RenderItem
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Markdown { get; set; } = string.Empty;
        }
    }
}

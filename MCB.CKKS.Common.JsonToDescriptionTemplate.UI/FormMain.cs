using System.ComponentModel;
using Newtonsoft.Json;
using MCB.CKKS.Common.DependencyInjection;
using MCB.CKKS.Common.JsonToDescriptionTemplate.Interfaces;

namespace MCB.CKKS.Common.JsonToDescriptionTemplate.UI
{
    public partial class FormMain : Form, IScopedService<FormMain>
    {
        private readonly IJsonDescriptionTemplate _jsonDescriptionTemplate;
        private readonly BindingList<RenderItem> _renders = new();
        private readonly FileHistory _fileHistory;
        private const int MaxHistoryItems = 15;
        private bool _suppressSelectionChanged;
        private bool _updatingComboBoxHistory;

        public FormMain(IJsonDescriptionTemplate jsonDescriptionTemplate)
        {
            _jsonDescriptionTemplate = jsonDescriptionTemplate;
            _fileHistory = FileHistory.LoadOrCreate();
            InitializeComponent();
            dgvRenders.DataSource = _renders;
            SetupComboBoxes();
        }

        private void SetupComboBoxes()
        {
            _updatingComboBoxHistory = true;
            cmbJsonFile.DataSource = _fileHistory.JsonFiles.Cast<string>().ToList();
            cmbTemplateFile.DataSource = _fileHistory.TemplateFiles.Cast<string>().ToList();
            _updatingComboBoxHistory = false;

            cmbJsonFile.SelectedIndexChanged += CmbJsonFile_SelectedIndexChanged;
            cmbTemplateFile.SelectedIndexChanged += CmbTemplateFile_SelectedIndexChanged;
        }

        private void CmbJsonFile_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_updatingComboBoxHistory) return;
            if (cmbJsonFile.SelectedItem is string file && !string.IsNullOrEmpty(file))
            {
                _updatingComboBoxHistory = true;
                UpdateHistory(_fileHistory.JsonFiles, file);
                cmbJsonFile.DataSource = _fileHistory.JsonFiles.Cast<string>().ToList();
                cmbJsonFile.SelectedItem = file;
                _fileHistory.Save();
                _updatingComboBoxHistory = false;
            }
        }

        private void CmbTemplateFile_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_updatingComboBoxHistory) return;
            if (cmbTemplateFile.SelectedItem is string file && !string.IsNullOrEmpty(file))
            {
                _updatingComboBoxHistory = true;
                UpdateHistory(_fileHistory.TemplateFiles, file);
                cmbTemplateFile.DataSource = _fileHistory.TemplateFiles.Cast<string>().ToList();
                cmbTemplateFile.SelectedItem = file;
                _fileHistory.Save();
                _updatingComboBoxHistory = false;
            }
        }

        private void UpdateHistory(List<string> history, string filePath)
        {
            history.Remove(filePath);
            history.Insert(0, filePath);
            while (history.Count > MaxHistoryItems)
                history.RemoveAt(history.Count - 1);
        }

        private async void btnSelectJson_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "JSON files|*.json|All files|*.*",
                Title = "Выберите JSON файл"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _updatingComboBoxHistory = true;
                UpdateHistory(_fileHistory.JsonFiles, dlg.FileName);
                cmbJsonFile.DataSource = _fileHistory.JsonFiles.Cast<string>().ToList();
                cmbJsonFile.SelectedItem = dlg.FileName;
                _fileHistory.Save();
                _updatingComboBoxHistory = false;
            }
        }

        private async void btnSelectTemplate_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "Scriban files|*.sb|All files|*.*",
                Title = "Выберите файл шаблона"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _updatingComboBoxHistory = true;
                UpdateHistory(_fileHistory.TemplateFiles, dlg.FileName);
                cmbTemplateFile.DataSource = _fileHistory.TemplateFiles.Cast<string>().ToList();
                cmbTemplateFile.SelectedItem = dlg.FileName;
                _fileHistory.Save();
                _updatingComboBoxHistory = false;
            }
        }

        private async void btnRender_Click(object? sender, EventArgs e)
        {
            var jsonPath = cmbJsonFile.Text.Trim();
            var templatePath = cmbTemplateFile.Text.Trim();

            if (string.IsNullOrEmpty(jsonPath) || !File.Exists(jsonPath))
            {
                MessageBox.Show("Выберите корректный JSON файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(templatePath) || !File.Exists(templatePath))
            {
                MessageBox.Show("Выберите корректный файл шаблона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var jsonContext = await File.ReadAllTextAsync(jsonPath);
                var templateContent = await File.ReadAllTextAsync(templatePath);
                var result = _jsonDescriptionTemplate.RenderJson(jsonContext, templateContent);

                var item = new RenderItem
                {
                    Id = Guid.NewGuid(),
                    Name = $"{Path.GetFileName(jsonPath)} + {Path.GetFileName(templatePath)}",
                    Markdown = result,
                    Type = RenderType.File
                };
                _renders.Add(item);
                _suppressSelectionChanged = true;
                dgvRenders.CurrentCell = dgvRenders.Rows[dgvRenders.Rows.Count - 1].Cells[0];
                _suppressSelectionChanged = false;
                await mdViewer.LoadMarkdownFromStringAsync(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при рендеринге: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvRenders_SelectionChanged(object? sender, EventArgs e)
        {
            if (_suppressSelectionChanged) return;
            if (dgvRenders.CurrentRow?.DataBoundItem is RenderItem selected)
            {
                await mdViewer.LoadMarkdownFromStringAsync(selected.Markdown);
            }
        }

        private async void btnDeleteSelected_Click(object? sender, EventArgs e)
        {
            var selectedItems = _renders.Cast<RenderItem>()
                .Where(r => r.IsSelected)
                .ToList();
            if (!selectedItems.Any())
            {
                MessageBox.Show("Отметьте строки для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Удалить отмеченные элементы ({selectedItems.Count})?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (var item in selectedItems)
                {
                    _renders.Remove(item);
                }

                if (_renders.Count > 0)
                {
                    var firstRemaining = _renders[0];
                    firstRemaining.IsSelected = true;
                    var firstRow = dgvRenders.Rows.Cast<DataGridViewRow>()
                        .FirstOrDefault(r => r.DataBoundItem == firstRemaining);
                    if (firstRow != null)
                    {
                        _suppressSelectionChanged = true;
                        dgvRenders.CurrentCell = firstRow.Cells[0];
                        _suppressSelectionChanged = false;
                        await mdViewer.LoadMarkdownFromStringAsync(firstRemaining.Markdown);
                    }
                }
            }
        }

        private async void btnConcatenate_Click(object? sender, EventArgs e)
        {
            var selectedItems = _renders.Cast<RenderItem>()
                .Where(r => r.IsSelected)
                .ToList();
            if (selectedItems.Count < 2)
            {
                MessageBox.Show("Для конкатенации отметьте минимум 2 строки.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var markdownParts = new List<string>();
                foreach (var item in selectedItems)
                {
                    markdownParts.Add(item.Markdown);
                }

                var combinedMarkdown = string.Join("\n\n---\n\n", markdownParts);
                var combinedName = $"Конкатенация ({selectedItems.Count} файлов)";

                var combinedItem = new RenderItem
                {
                    Id = Guid.NewGuid(),
                    Name = combinedName,
                    Markdown = combinedMarkdown,
                    Type = RenderType.Concatenation
                };

                _renders.Add(combinedItem);
                _suppressSelectionChanged = true;
                dgvRenders.CurrentCell = dgvRenders.Rows[dgvRenders.Rows.Count - 1].Cells[0];
                _suppressSelectionChanged = false;
                combinedItem.IsSelected = true;
                await mdViewer.LoadMarkdownFromStringAsync(combinedItem.Markdown);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при конкатенации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMoveUp_Click(object? sender, EventArgs e)
        {
            MoveFocusedRow(-1);
        }

        private void btnMoveDown_Click(object? sender, EventArgs e)
        {
            MoveFocusedRow(1);
        }

        private async void MoveFocusedRow(int direction)
        {
            var focusedRow = dgvRenders.CurrentRow;
            if (focusedRow == null || focusedRow.Index < 0)
            {
                MessageBox.Show("Выберите строку для перемещения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int currentIndex = focusedRow.Index;
            int newIndex = currentIndex + direction;
            if (newIndex < 0 || newIndex >= _renders.Count)
                return;

            var moveItem = _renders[currentIndex];
            _renders.RemoveAt(currentIndex);
            _renders.Insert(newIndex, moveItem);

            _suppressSelectionChanged = true;
            dgvRenders.CurrentCell = dgvRenders.Rows[newIndex].Cells[0];
            var movedItem = _renders[newIndex];
            _suppressSelectionChanged = false;
            await mdViewer.LoadMarkdownFromStringAsync(movedItem.Markdown);
        }

        private void btnSaveAs_Click(object? sender, EventArgs e)
        {
            if (dgvRenders.CurrentRow?.DataBoundItem is not RenderItem selectedItem)
            {
                MessageBox.Show("Выберите строку для сохранения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new SaveFileDialog
            {
                Filter = "Markdown files|*.md|All files|*.*",
                Title = "Сохранить как"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(dlg.FileName, selectedItem.Markdown);
                    MessageBox.Show("Файл сохранён.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Nested Classes

        private enum RenderType
        {
            File,
            Concatenation
        }

        private class RenderItem
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Markdown { get; set; } = string.Empty;
            public RenderType Type { get; set; } = RenderType.File;
            public bool IsSelected { get; set; }

            public string TypeDisplay => Type == RenderType.File ? "Файл" : "Конкатенация";
        }

        private class FileHistory
        {
            private static readonly string HistoryFilePath = Path.Combine(
                AppContext.BaseDirectory,
                "appsettings.json");

            public List<string> JsonFiles { get; set; } = new();
            public List<string> TemplateFiles { get; set; } = new();

            public static FileHistory LoadOrCreate()
            {
                try
                {
                    if (File.Exists(HistoryFilePath))
                    {
                        var json = File.ReadAllText(HistoryFilePath);
                        return JsonConvert.DeserializeObject<FileHistory>(json) ?? new FileHistory();
                    }
                }
                catch
                {
                    // Ignore deserialization errors
                }
                return new FileHistory();
            }

            public void Save()
            {
                try
                {
                    var directory = Path.GetDirectoryName(HistoryFilePath)!;
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);

                    var json = JsonConvert.SerializeObject(this, Formatting.Indented);
                    File.WriteAllText(HistoryFilePath, json);
                }
                catch
                {
                    // Ignore save errors
                }
            }
        }

        #endregion
    }
}

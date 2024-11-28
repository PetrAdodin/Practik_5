using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Practik_5
{
    public partial class MainForm : Form
    {
        private List<Technika> technikaList = new List<Technika>();
        private ListBox listBoxTechnika;
        private Button buttonAdd, buttonRemove, buttonShowAll;
        private TextBox textBoxBrand, textBoxModel, textBoxColor, textBoxScreenSize, textBoxStations;
        private ComboBox comboBoxType;

        public MainForm()
        {
            // Инициализация формы
            this.Text = "Учет техники";
            this.Width = 600;
            this.Height = 450;

            // Инициализация ListBox
            listBoxTechnika = new ListBox { Left = 20, Top = 20, Width = 540, Height = 200 };
            this.Controls.Add(listBoxTechnika);

            // Инициализация ComboBox
            comboBoxType = new ComboBox
            {
                Left = 20,
                Top = 230,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxType.Items.AddRange(new string[] { "Техника", "Телевизор", "Радио" });
            comboBoxType.SelectedIndex = 0;
            this.Controls.Add(comboBoxType);

            // Инициализация TextBox
            textBoxBrand = CreatePlaceholderTextBox("Марка", 20, 310);
            textBoxModel = CreatePlaceholderTextBox("Модель", 170, 310);
            textBoxColor = CreatePlaceholderTextBox("Цвет", 320, 310);
            textBoxScreenSize = CreatePlaceholderTextBox("Размер экрана", 20, 340);
            textBoxStations = CreatePlaceholderTextBox("Количество станций", 170, 340);

            this.Controls.AddRange(new Control[] { textBoxBrand, textBoxModel, textBoxColor, textBoxScreenSize, textBoxStations });

            // Инициализация кнопок
            buttonAdd = new Button { Text = "Добавить", Left = 20, Top = 380, Width = 100 };
            buttonAdd.Click += ButtonAdd_Click;
            this.Controls.Add(buttonAdd);

            buttonRemove = new Button { Text = "Удалить", Left = 140, Top = 380, Width = 100 };
            buttonRemove.Click += ButtonRemove_Click;
            this.Controls.Add(buttonRemove);

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string type = comboBoxType.SelectedItem.ToString();
                string brand = textBoxBrand.Text;
                string model = textBoxModel.Text;
                string color = textBoxColor.Text;

                if (type == "Техника")
                {
                    technikaList.Add(new Technika(brand, model, color));
                }
                else if (type == "Телевизор")
                {
                    if (!int.TryParse(textBoxScreenSize.Text, out int screenSize))
                        throw new Exception("Размер экрана должен быть числом.");
                    technikaList.Add(new Television(brand, model, color, screenSize));
                }
                else if (type == "Радио")
                {
                    if (!int.TryParse(textBoxStations.Text, out int stations))
                        throw new Exception("Количество станций должно быть числом.");
                    technikaList.Add(new Radio(brand, model, color, stations));
                }

                UpdateTechnikaList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxTechnika.SelectedItem != null)
            {
                technikaList.RemoveAt(listBoxTechnika.SelectedIndex);
                UpdateTechnikaList();
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления.");
            }
        }

        private void ButtonShowAll_Click(object sender, EventArgs e)
        {
            UpdateTechnikaList();
        }

        private void UpdateTechnikaList()
        {
            listBoxTechnika.Items.Clear();
            foreach (var item in technikaList)
            {
                listBoxTechnika.Items.Add(item.ToString());
            }
        }

        private TextBox CreatePlaceholderTextBox(string placeholder, int left, int top)
        {
            var textBox = new TextBox
            {
                Text = placeholder,
                Left = left,
                Top = top,
                Width = 140,
                ForeColor = Color.Gray
            };

            textBox.GotFocus += (s, e) => RemovePlaceholder(textBox, placeholder);
            textBox.LostFocus += (s, e) => SetPlaceholder(textBox, placeholder);

            return textBox;
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }
    }
}

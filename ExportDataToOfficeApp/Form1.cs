using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    public partial class Form1 : Form
    {
        List<Car> carsInStock = null;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carsInStock = new List<Car>
            {
                new Car { Color="Green", Make = "VW", PetName = "Mary" },
                new Car { Color="Red", Make = "Saab", PetName = "Mel" },
                new Car { Color="Black", Make = "Ford", PetName = "Hank" },
                new Car { Color="Yellow", Make = "BMW", PetName = "Davie" }
            };
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dataGridCars.DataSource = null;
            dataGridCars.DataSource = carsInStock;
        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
            NewCarDialog d = new NewCarDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                // Добавить новый автомобиль в список
                carsInStock.Add(d.theCar);
                UpdateGrid();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(carsInStock);
        }

        static void ExportToExcel(List<Car> carsInStock)
        {
            // Загрузить Excel, затем создать новую пустую рабочую книгу
            Excel.Application excelApp = new Excel.Application();

            // Сделать приложение Excel видимым
            excelApp.Workbooks.Add();

            // В этом примере используется единственный рабочий лист
            Excel._Worksheet worksheet = excelApp.ActiveSheet;

            // Установить заголовки столбцов в ячейках
            worksheet.Cells[1, "A"] = "Make";
            worksheet.Cells[1, "B"] = "Color";
            worksheet.Cells[1, "C"] = "Pet Name";

            // Отобразить все данные в List<Car> на ячейки электронной таблицы
            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                worksheet.Cells[row, "A"] = c.Make;
                worksheet.Cells[row, "B"] = c.Color;
                worksheet.Cells[row, "C"] = c.PetName;
            }

            // Сохранить файл, завершить Excel и отобразить соббщение пользователю
            // Файл Inventory.xlsx сохранен в папке приложения
            worksheet.SaveAs(string.Format(@"{0}\Inventory.xlsx", Environment.CurrentDirectory));
            excelApp.Quit();
            MessageBox.Show("The Inventory.xlsx file has been saved to your app folder", "Export complete!");
        }
    }
}

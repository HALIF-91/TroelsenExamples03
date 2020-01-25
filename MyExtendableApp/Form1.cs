using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using CommonSnappableTypes;

namespace MyExtendableApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void snapInModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Позволить пользователю выбрать сборку для загрузки
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.Contains("CommonSnappableTypes"))
                    MessageBox.Show("CommonSnappableTypes has no snap-ins!");
                else if (!LoadExternalModule(dlg.FileName))
                    MessageBox.Show("Nothing Implements IAppFunctionality");
            }
        }
        private bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly theSnapInAsm = null;
            try
            {
                // Динамически загрузить выбранную сборку
                theSnapInAsm = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return foundSnapIn;
            }

            // Получить все совместимые с IAppFunctionality классы в сборке
            var theClassTypes = from t in theSnapInAsm.GetTypes()
                                where t.IsClass &&
                                (t.GetInterface("IAppFunctionality") != null)
                                select t;

            // Создать объект и вызвать метод DoIt()
            foreach (Type t in theClassTypes)
            {
                foundSnapIn = true;

                // Использовать позднее связывание длЯ создания экземпляра типа
                IAppFunctionality itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);
                itfApp.DoIt();
                lstLoadedSnapIns.Items.Add(t.FullName);

                // Отобразить информацию о компании
                DisplayCompanyData(t);
            }
            return foundSnapIn;
        }

        private void DisplayCompanyData(Type t)
        {
            // Получить данные [CompanyInfo]
            var compInfo = from ci in t.GetCustomAttributes(false) where
                           (ci.GetType() == typeof(CompanyInfoAttribute))
                           select ci;

            // Отобразить данные
            foreach (CompanyInfoAttribute c in compInfo)
            {
                MessageBox.Show(c.CompanyName, string.Format("More info about {0} can be found at ", c.CompanyUrl));
            }
        }
    }
}

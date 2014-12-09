using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MachineDefiner.Model;

namespace MachineDefiner.ET
{
    /// <summary>
    /// Логика взаимодействия для ET_Properties.xaml
    /// </summary>
    public partial class ET_Properties : Window
    {
        public Characteristic Context;
        public bool IsOperationComplete;
        public bool isAdd = false;

        public ET_Properties(Characteristic item)
        {
            Context = item;
            InitializeComponent();
            if (item.Name== null)
                isAdd = true;
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            cb_ValueTypes.ItemsSource = Characteristic.ValueTypes;
            cb_ValueTypes.Text = Characteristic.ValueTypes[ Context.ValueType];
            mainGrid.DataContext = Context;
        }

        private void bt_cancelAction(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_applyAction(object sender, RoutedEventArgs e)
        {
            if (isAdd)
                Context.Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(Context.Name) || Context.Name.Length < 3 || Context.Name.Length>50)
            {
                MessageBox.Show("Введите название", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cb_ValueTypes.SelectedValue == null)
            {
                MessageBox.Show("выберите тип данных", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Characteristic.ItemType selType;
            if (!Enum.TryParse(cb_ValueTypes.SelectedValue.ToString(), out selType))
            {
                MessageBox.Show("выберите тип данных", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Context.ValueType = selType;
             if (string.IsNullOrEmpty(Context.DefaultValue))
             {
                 MessageBox.Show("Укажите значение по умолчанию", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                 return;
             }

            IsOperationComplete = true;
            this.Close();
        }
    }
}

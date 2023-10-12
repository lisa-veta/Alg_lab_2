using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alg_lab_2.Model
{
    public static class CheckingErrors
    {

        public static bool isNotHasError;
        public static void CheckInt(string count) 
        {
            isNotHasError = int.TryParse(count, out int num);
            if (!isNotHasError)
            {
                MessageBox.Show("Введенные данные должны иметь тип integer");
            }
        } 

        public static void CheckInterval(int count, int maxValue, int minValue)
        {
            isNotHasError = count <= maxValue && count >= minValue;
            if (!isNotHasError)
            {
                MessageBox.Show($"Введенные данные должны соответствовать диапазону от {minValue} до {maxValue}");
            }
        }

        public static void CheckNotNull(string count)
        {
            isNotHasError = !String.IsNullOrWhiteSpace(count);
            if (!isNotHasError)
            {
                MessageBox.Show("Не должно быть пустых полей");
            }
        }
    }
}

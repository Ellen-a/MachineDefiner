using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDefiner.Model
{
    public class Characteristic
    {
        /// <summary>
        /// код типа характеристики
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// название характеристики
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// тип значения
        /// </summary>
        public ItemType ValueType { get; set; }

        /// <summary>
        /// значение записи
        /// </summary>
        public string Value { get; set; }


        /// <summary>
        /// порядок сортировки
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// список значений
        /// </summary>
        public string ValueItems { get; set; }
        /// <summary>
        /// коэффициент расчета
        /// </summary>
        public int Coefficient { get; set; }
        /// <summary>
        /// обязательное
        /// </summary>
        public bool IsNecessary { get; set; }

        /// <summary>
        /// обязательное поле - строковое представление
        /// </summary>
        public string IsNecessaryUI
        {
            get { return IsNecessary ? "Да" : "Нет"; }
        }

        /// <summary>
        /// значение по умолчанию
        /// </summary>
        public string DefaultValue { set; get; }

        public List<string>  ValueItemsList
        {
            get
            {
                return !string.IsNullOrEmpty(ValueItems) ? ValueItems.Split(';').ToList() : new List<string>();
            }
        }

        /// <summary>
        /// тип записи
        /// </summary>
        public enum ItemType
        {
            ItString, ItInt, ItList,  ItBool
        }

        public string ValueTypeName
        {
            get { return ValueTypes[ValueType]; }
        }

        public static Dictionary<ItemType, string>  ValueTypes {get
        {
            return  new Dictionary<ItemType, string>
                {
                    {ItemType.ItInt, "Число"},
                    {ItemType.ItString, "Строка"},
                    {ItemType.ItList, "Список"},
                    {ItemType.ItBool, "Логический"}
                };
        }}
    }
}

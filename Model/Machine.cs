using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MachineDefiner.Model
{
    
    public class Machine
    {
        /// <summary>
        /// название оборудования
        /// </summary>
        public string Name { set; get; }
        
        /// <summary>
        /// тип печати
        /// </summary>
        public string PrintType { set; get; }

        /// <summary>
        /// список характеристик станка
        /// </summary>
        public List<MachineCharactericticItem> Characteristic { get; set; }

        [XmlIgnoreAttribute]
        public double coefficientSumm { get; set; }

        /// <summary>
        /// список значений характеристик
        /// </summary>
        
        [XmlIgnoreAttribute]
        public Dictionary<Guid, String> CharacteristicValues
        {
            get
            {
                return Characteristic.ToDictionary(s => s.Id, s => s.Value);
            }
        }
        
        public Machine(){}
    }
    public class MachineCharactericticItem
    {
        [XmlAttribute]
        public Guid Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Value { get; set; }
    }
}

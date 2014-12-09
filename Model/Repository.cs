using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MachineDefiner.Model
{
    public class Repository
    {
        private const string fileNameCharacteristics = "Characteristics.xml";
        private const string fileNameMachines = "Machines.xml";
        /// <summary>
        /// список характеристик
        /// </summary>
        public List<Characteristic> Characteristics { get; set; }

        /// <summary>
        /// список станков
        /// </summary>
        public List<Machine> Machines { get; set; }

        /// <summary>
        /// загрузка данных
        /// </summary>
        /// <returns>результат выполнения операции</returns>
        public bool SetData()
        {
            Characteristics = new List<Characteristic>
                {
                    new Characteristic()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Character int 1",
                            Value= "1",
                            ValueType = Characteristic.ItemType.ItInt,
                            ValueItems = string.Empty,
                            Coefficient = 2,
                            IsNecessary = true,
                            DefaultValue =""
                        },
                        new Characteristic()
                        {
                       Id = Guid.NewGuid(),
                            Name = "Character int 2",
                            Value= "12",
                            ValueType = Characteristic.ItemType.ItInt,
                            ValueItems = string.Empty,
                              Coefficient = 4,
                            IsNecessary = true,
                            DefaultValue =""
                        },
                        new Characteristic()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Character bool 1",
                            Value= "True",
                            ValueType = Characteristic.ItemType.ItBool,
                            ValueItems = string.Empty,
                              Coefficient = 1,
                            IsNecessary = false,
                            DefaultValue =""
                        },
                        new Characteristic()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Character string 1",
                            Value= "1",
                            ValueType = Characteristic.ItemType.ItString,
                            ValueItems = string.Empty,
                            Coefficient = 3,
                            IsNecessary = false,
                            DefaultValue =""
                        },
                        new Characteristic()
                        { 
                            Id = Guid.NewGuid(),
                            Name = "Character list 1",
                            Value= "A2",
                            ValueType = Characteristic.ItemType.ItList,
                            ValueItems =  "A1;A2;A3;All",
                            Coefficient = 5,
                            IsNecessary = true,
                            DefaultValue ="A1"
                        },
                        new Characteristic()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Character list 2",
                            Value= "HB",
                            ValueType = Characteristic.ItemType.ItList,
                            ValueItems = "HB;All;Cintetik", 
                             Coefficient = 8,
                            IsNecessary = true,
                            DefaultValue ="HB"
                        }
                };

            Machines = new List<Machine>()
                {
                    new Machine()
                        {
                            Name = "Machine 1",
                            Characteristic = Characteristics.GetRange(1,3).Select(s=> new MachineCharactericticItem(){Id = s.Id,Value = s.Value, Name= s.Name  }).ToList()
                        },
                        new Machine()
                        {
                            Name = "Machine 2",
                            Characteristic = Characteristics.GetRange(2,2).Select(s=> new MachineCharactericticItem(){Id = s.Id,Value = s.Value, Name= s.Name  }).ToList()
                        },
                        new Machine()
                        {
                            Name = "Machine 3",
                            Characteristic = Characteristics.GetRange(3,2).Select(s=> new MachineCharactericticItem(){Id = s.Id,Value = s.Value, Name= s.Name  }).ToList()
                        }
                };
            return false;
        }

        public void SaveMathines()
        {

            XmlSerializer x = new XmlSerializer(typeof(List<Machine>));
            TextWriter writer = new StreamWriter(fileNameMachines);
            x.Serialize(writer, Machines);
            writer.Close();
        }

        public void LoadMathines()
        {

            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Machine>));
            FileStream myFileStream =
            new FileStream(fileNameMachines, FileMode.Open);
            Machines = (List<Machine>)
                       mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
        }


        public void SaveCharacteristics()
        {

            XmlSerializer x = new XmlSerializer(typeof(List<Characteristic>));
            TextWriter writer = new StreamWriter(fileNameCharacteristics);
            x.Serialize(writer, Characteristics);
            writer.Close();
        }

        public void LoadCharacteristics()
        {

            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Characteristic>));
            FileStream myFileStream =
            new FileStream(fileNameCharacteristics, FileMode.Open);
            Characteristics = (List<Characteristic>)
                       mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
        }
    }
}

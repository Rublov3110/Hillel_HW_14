using System.Reflection;

namespace PRO_HW_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new Car()
            {
                Brand = "BMV",
                Model = "X5",
                Year = "2020",
                Color = "Blake"
            };

            //Console.Write("Write Property: ");
            //var userProperty = Console.ReadLine();
            //GetProperty(userProperty);

            //void GetProperty(string userProperty)
            //{
            //    var property = car.GetType().GetProperty(userProperty);
            //    var value = property.GetValue(car);
            //    Console.WriteLine($"Your value: {value}");
            //}

            //Console.Write("Property: ");
            //var property = Console.ReadLine();
            //Console.Write("New value: ");
            //var userValue = Console.ReadLine();
            //NewValue(property, userValue);

            //void NewValue(string property, string userValue)
            //{
            //    var propertyCar = car.GetType().GetProperty(property);
            //    propertyCar.SetValue(car, userValue);
            //    var value = propertyCar.GetValue(car);
            //    Console.WriteLine($"Your new value: {value}");
            //}

            string FormatObjectFields(object obj)
            {
                Type type = obj.GetType();
                PropertyInfo[] properties = type.GetProperties();

                string result = "";
                foreach (PropertyInfo property in properties)
                {
                    string fieldName = property.Name;
                    object value = property.GetValue(obj);

                    result += $"{fieldName}:{value};";
                }

                return result.TrimEnd(';');
            }

            string formattedFields = FormatObjectFields(car);
            Console.WriteLine(formattedFields);

            //object CreateString(string formattedString, Type type)
            //{
            //    object obj = Activator.CreateInstance(type);

            //    string[] fields = formattedString.Split(';');
            //    foreach (string field in fields)
            //    {
            //        string[] parts = field.Split(':');
            //        string fieldName = parts[0];
            //        string value = parts[1];

            //        PropertyInfo property = type.GetProperty(fieldName);
            //        if (property != null)
            //        {
            //            Type propertyType = property.PropertyType;
            //            object convertedValue = Convert.ChangeType(value, propertyType);
            //            property.SetValue(obj, convertedValue);
            //        }
            //    }

            //    return obj;
            //}

            //Type type = typeof(Car);
            //object obj = CreateString(formattedFields, type);

            //Car myObj = (Car)obj;
            //Console.WriteLine(myObj.Brand);
            //Console.WriteLine(myObj.Model);
            //Console.WriteLine(myObj.Year);
            //Console.WriteLine(myObj.Color);

             T CreateString<T>(string formattedString)
            {
                Type type = typeof(T);
                T obj = Activator.CreateInstance<T>();

                string[] fields = formattedString.Split(';');
                foreach (string field in fields)
                {
                    string[] parts = field.Split(':');
                    string fieldName = parts[0];
                    string value = parts[1];

                    PropertyInfo property = type.GetProperty(fieldName);
                    if (property != null)
                    {
                        Type propertyType = property.PropertyType;
                        object convertedValue = Convert.ChangeType(value, propertyType);
                        property.SetValue(obj, convertedValue);
                    }
                }

                return obj;
            }


            Car myObj1 = CreateString<Car>(formattedFields);

            Console.WriteLine(myObj1.Brand);
            Console.WriteLine(myObj1.Model);
            Console.WriteLine(myObj1.Year);
            Console.WriteLine(myObj1.Color);
        }  
    }
}
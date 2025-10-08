using System.Reflection;

namespace Tester
{
    [TestClass]
    public sealed class Klasser
    {
        [TestMethod("Har minst tre egna klasser")]
        public void HasAtLeastThree()
        {
            var test = GetCustomClasses();
            if (GetCustomClasses().Length < 3)
            {
                Assert.Fail("Du måste deklarera minst 3 egna klasser");
            }
        }

        [TestMethod("Är inte tomma")]
        public void IsNotEmpty()
        {
            var errors = new List<string>();

            foreach (var classType in GetCustomClasses())
            {
                if (classType.GetAllFields().Length > 0) continue;
                if (classType.GetAllProperties().Length > 0) continue;
                if (classType.GetAllMethods().Length > 0) continue;

                var constructors = classType.GetAllConstructors();
                var invalid = true;
                foreach (var constructor in classType.GetAllConstructors())
                {
                    // Assume no parameters means default constructor
                    var parameters = constructor.GetParameters();
                    if (parameters.Length > 0)
                    {
                        invalid = false;
                        continue;
                    }
                }

                if (invalid)
                    errors.Add("class " + classType.Name);
            }

            if (errors.Count > 0)
                Assert.Fail($"Det finns {errors.Count} {(errors.Count == 1 ? "klass" : "klasser")} som inte har något innehåll:\n • {string.Join("\n • ", errors)}");
        }

        [TestMethod("Är skrivna i PascalCase")]
        public void HasPascalCase()
        {
            var errors = new List<string>();

            foreach (var classType in GetCustomClasses())
                if (!classType.IsPascalCase())
                    errors.Add("class " + classType.Name);

            if (errors.Count > 0)
                Assert.Fail($"Det finns {errors.Count} {(errors.Count == 1 ? "klass" : "klasser")} som inte har en stor första bokstav i sitt namn:\n • {string.Join("\n • ", errors)}");
        }

        [TestMethod("Har alla fält skrivna i camelCase")]
        public void HasCamelCaseFields()
        {
            var errors = new List<string>();

            foreach (var customClass in GetCustomClasses())
            {
                var fields = customClass.GetAllFields().Select(x => x.Name).ToArray();
                foreach (var field in fields)
                {
                    if (!field.IsCamelCase())
                    {
                        errors.Add($"{customClass.Name}.{field}");
                    }
                }
            }
            if (errors.Count > 0)
            {
                Assert.Fail($"Det finns {errors.Count} fält som inte har en liten första bokstav i sitt namn:\n • {string.Join("\n • ", errors)}");
            }
        }

        [TestMethod("Använder inte properties")]
        public void IsNotUsingProperties()
        {
            var errors = new List<string>();

            foreach (var customClass in GetCustomClasses())
            {
                var properties = customClass.GetAllProperties();
                foreach (var property in properties)
                {
                    errors.Add($"{customClass.Name}.{property.Name}");
                }
            }
            if (errors.Count > 0)
            {
                Assert.Fail($"Det finns {errors.Count} properties, endast fält bör användas:\n • {string.Join("\n • ", errors)}");
            }
        }


        [TestMethod("Minst en är abstrakt")]
        public void AtLeastOneAbstractClass()
        {
            foreach (var customClass in GetCustomClasses())
            {
                if (customClass.IsProperlyAbstract()) return;
            }
            Assert.Fail($"Det finns ingen abstrakt klass");
        }


        [TestMethod("Minst två implementerar en abstrakt klass")]
        public void UsesInheritence()
        {
            var errors = new List<string>();
            int numberOfAbstractChildren = 0;

            foreach (var customClass in GetCustomClasses())
            {
                if (customClass.BaseType == null || customClass.BaseType == typeof(object)) continue;

                if (customClass.BaseType.IsProperlyAbstract())
                {
                    numberOfAbstractChildren++;
                    continue;
                }
            }
            if (numberOfAbstractChildren == 0)
            {
                Assert.Fail($"Det finns ingen klass som implementerar en abstrakt klass, det ska finnas två");
            }
            else if (numberOfAbstractChildren == 1)
            {
                Assert.Fail($"Det finns bara en klass som implementerar en abstrakt klass, det ska finnas två");
            }
        }

        static Type[] GetCustomClasses()
        {
            return Utils.classes
                .Where(x => x != typeof(Program))
                .Where(x => x.GetCustomAttribute<System.Runtime.CompilerServices.CompilerGeneratedAttribute>() == null)
                .ToArray();
        }
    }
}
